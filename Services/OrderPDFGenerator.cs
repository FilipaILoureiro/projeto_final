using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SQLite;

namespace projetoPadariaApp.Services
{
    internal class OrderPDFGenerator
    {
        public static void GerarPDFEncomenda(int idEncomenda)
        {
            using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                connection.Open();

                string query = @"
                SELECT e.id, e.nif_clientes, e.data_encomenda, e.data_recolha, e.pago, e.entregue, 
                       p.nome, ep.qtdd, p.preco
                FROM enc e
                JOIN enc_prod ep ON e.id = ep.id_enc
                JOIN produtos p ON ep.id_prod = p.id
                WHERE e.id = @id";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idEncomenda);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Encomenda não encontrada!");
                            return;
                        }

                        string pastaPDF = Path.Combine(Application.StartupPath, "PDFs");
                        Directory.CreateDirectory(pastaPDF);
                        string caminho = Path.Combine(pastaPDF, $"encomenda_{idEncomenda}.pdf");

                        Document doc = new Document(PageSize.A4, 50, 50, 80, 50); // Margens ajustadas
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
                        doc.Open();

                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                        Paragraph header = new Paragraph("Padaria Pão Bom", titleFont);
                        header.Alignment = Element.ALIGN_CENTER;
                        doc.Add(header);

                        Paragraph subHeader = new Paragraph("Recibo de Encomenda\n\n", normalFont);
                        subHeader.Alignment = Element.ALIGN_CENTER;
                        doc.Add(subHeader);

                        reader.Read();

                        string nif = reader["nif_clientes"].ToString();
                        string dataEnc = Convert.ToDateTime(reader["data_encomenda"]).ToString("dd/MM/yyyy");
                        string dataRec = Convert.ToDateTime(reader["data_recolha"]).ToString("dd/MM/yyyy");
                        string pagoStr = reader["pago"].ToString();
                        string entregueStr = reader["entregue"].ToString();
                        string pago = pagoStr == "pago" ? "Sim" : "Não";
                        string entregue = entregueStr == "S" ? "Sim" : "Não";

                                PdfPTable infoTable = new PdfPTable(2);
                        infoTable.WidthPercentage = 100;
                        infoTable.SpacingAfter = 20;

                        infoTable.AddCell("ID Encomenda:");
                        infoTable.AddCell(idEncomenda.ToString());
                        infoTable.AddCell("NIF Cliente:");
                        infoTable.AddCell(nif);
                        infoTable.AddCell("Data da Encomenda:");
                        infoTable.AddCell(dataEnc);
                        infoTable.AddCell("Data da Recolha:");
                        infoTable.AddCell(dataRec);
                        infoTable.AddCell("Pago:");
                        infoTable.AddCell(pago);
                        infoTable.AddCell("Entregue:");
                        infoTable.AddCell(entregue);

                        doc.Add(infoTable);

                        PdfPTable table = new PdfPTable(4);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 40f, 20f, 20f, 20f });
                        table.SpacingBefore = 10;

                        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                        table.AddCell(new PdfPCell(new Phrase("Produto", boldFont)));
                        table.AddCell(new PdfPCell(new Phrase("Qtd", boldFont)));
                        table.AddCell(new PdfPCell(new Phrase("Preço Unit.", boldFont)));
                        table.AddCell(new PdfPCell(new Phrase("Subtotal", boldFont)));

                        decimal total = 0;

                        do
                        {
                            string produto = reader["nome"].ToString();
                            int qtdd = Convert.ToInt32(reader["qtdd"]);
                            decimal preco = Convert.ToDecimal(reader["preco"]);
                            decimal subtotal = preco * qtdd;
                            total += subtotal;

                            table.AddCell(produto);
                            table.AddCell(qtdd.ToString());
                            table.AddCell($"{preco:C}");
                            table.AddCell($"{subtotal:C}");
                        } while (reader.Read());

                        doc.Add(table);

                        Paragraph totalPar = new Paragraph($"\nTotal da Encomenda: {total:C}", boldFont);
                        totalPar.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(totalPar);

                        Paragraph footer = new Paragraph($"\nDocumento gerado em {DateTime.Now:dd/MM/yyyy HH:mm}", normalFont);
                        footer.Alignment = Element.ALIGN_CENTER;
                        doc.Add(footer);

                        doc.Close();

                        var resultado = MessageBox.Show("PDF gerado com sucesso! Queres abrir agora?", "PDF Criado 🎉", MessageBoxButtons.YesNo);
                        if (resultado == DialogResult.Yes)
                        {
                            var psi = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = caminho,
                                UseShellExecute = true
                            };
                            System.Diagnostics.Process.Start(psi);
                        }
                    }
                }
            }
        }

    }
}
