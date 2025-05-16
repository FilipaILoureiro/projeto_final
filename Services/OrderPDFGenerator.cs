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
                SELECT e.id, e.nif_clientes, e.data_encomenda, e.data_recolha, e.pago, e.entregue, p.nome, ep.qtdd, p.preco
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

                        Document doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
                        doc.Open();

                        doc.Add(new Paragraph("🍞 Encomenda da Pãodemónio 🍞\n\n"));
                        doc.Add(new Paragraph($"ID Encomenda: {idEncomenda}"));

                        decimal total = 0;
                        PdfPTable table = new PdfPTable(3);
                        table.AddCell("Produto");
                        table.AddCell("Quantidade");
                        table.AddCell("Preço Total");

                        while (reader.Read())
                        {
                            string produto = reader["nome"].ToString();
                            int qtdd = Convert.ToInt32(reader["qtdd"]);
                            decimal preco = Convert.ToDecimal(reader["preco"]);
                            decimal precoTotal = preco * qtdd;
                            total += precoTotal;

                            table.AddCell(produto);
                            table.AddCell(qtdd.ToString());
                            table.AddCell($"{precoTotal:C}");
                        }

                        doc.Add(table);
                        doc.Add(new Paragraph($"\nTotal da Encomenda: {total:C}"));
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
