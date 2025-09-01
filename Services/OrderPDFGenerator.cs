using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Diagnostics;

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
                            MessageBox.Show("Encomenda não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string pastaPDF = Path.Combine(Application.StartupPath, "PDFs");
                        Directory.CreateDirectory(pastaPDF);
                        string caminho = Path.Combine(pastaPDF, $"Fatura_Encomenda_{idEncomenda}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                        Document doc = new Document(PageSize.A4, 40, 40, 60, 40);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
                        doc.Open();

                        BaseColor corPrimaria = new BaseColor(41, 128, 185);  
                        BaseColor corSecundaria = new BaseColor(52, 73, 94);  
                        BaseColor corFundo = new BaseColor(245, 245, 245);    

                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, corPrimaria);
                        var subtitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, corSecundaria);
                        var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);
                        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                        var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.GRAY);

                        // === CABEÇALHO ===
                        PdfPTable headerTable = new PdfPTable(2);
                        headerTable.WidthPercentage = 100;
                        headerTable.SetWidths(new float[] { 60f, 40f });
                        headerTable.SpacingAfter = 20;

                        // Lado esquerdo - Informações da empresa
                        PdfPCell empresaCell = new PdfPCell();
                        empresaCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        empresaCell.PaddingBottom = 10;

                        Paragraph nomeEmpresa = new Paragraph("PADARIA PÃO BOM", titleFont);
                        empresaCell.AddElement(nomeEmpresa);

                        Paragraph infoEmpresa = new Paragraph(
                            "Rua das Padarias, 123\n" +
                            "4400-123 Vila Nova de Gaia\n" +
                            "Tel: (+351) 223 456 789\n" +
                            "Email: geral@padariapaobom.pt\n" +
                            "NIF: 123456789", normalFont);
                        empresaCell.AddElement(infoEmpresa);

                        headerTable.AddCell(empresaCell);

                        // Lado direito - Tipo de documento
                        PdfPCell documentoCell = new PdfPCell();
                        documentoCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        documentoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        documentoCell.BackgroundColor = corFundo;
                        documentoCell.Padding = 15;

                        Paragraph tipoDoc = new Paragraph("FATURA/RECIBO", subtitleFont);
                        tipoDoc.Alignment = Element.ALIGN_RIGHT;
                        documentoCell.AddElement(tipoDoc);

                        Paragraph numeroFatura = new Paragraph($"Nº {idEncomenda:D6}", boldFont);
                        numeroFatura.Alignment = Element.ALIGN_RIGHT;
                        documentoCell.AddElement(numeroFatura);

                        Paragraph dataEmissao = new Paragraph($"Data: {DateTime.Now:dd/MM/yyyy}", normalFont);
                        dataEmissao.Alignment = Element.ALIGN_RIGHT;
                        documentoCell.AddElement(dataEmissao);

                        headerTable.AddCell(documentoCell);
                        doc.Add(headerTable);

                        // === INFORMAÇÕES DA ENCOMENDA ===
                        reader.Read();

                        string nif = reader["nif_clientes"].ToString();
                        string nomeCliente = "Consumidor Final";
                        string dataEnc = Convert.ToDateTime(reader["data_encomenda"]).ToString("dd/MM/yyyy");
                        string dataRec = Convert.ToDateTime(reader["data_recolha"]).ToString("dd/MM/yyyy");
                        string pagoStr = reader["pago"].ToString();
                        string entregueStr = reader["entregue"].ToString();
                        string pago = pagoStr == "pago" ? "✓ Pago" : "✗ Pendente";
                        string entregue = entregueStr == "S" ? "✓ Entregue" : "✗ Pendente";

                        // Tabela com informações do cliente e encomenda
                        PdfPTable infoTable = new PdfPTable(2);
                        infoTable.WidthPercentage = 100;
                        infoTable.SetWidths(new float[] { 50f, 50f });
                        infoTable.SpacingAfter = 20;

                        // Informações do Cliente
                        PdfPCell clienteHeaderCell = new PdfPCell(new Phrase("DADOS DO CLIENTE", subtitleFont));
                        clienteHeaderCell.BackgroundColor = corPrimaria;
                        clienteHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        clienteHeaderCell.Padding = 8;
                        infoTable.AddCell(clienteHeaderCell);

                        // Informações da Encomenda
                        PdfPCell encomendaHeaderCell = new PdfPCell(new Phrase("DADOS DA ENCOMENDA", subtitleFont));
                        encomendaHeaderCell.BackgroundColor = corPrimaria;
                        encomendaHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        encomendaHeaderCell.Padding = 8;
                        infoTable.AddCell(encomendaHeaderCell);

                        // Dados do cliente
                        StringBuilder clienteInfo = new StringBuilder();
                        clienteInfo.AppendLine($"Nome: {nomeCliente}");
                        clienteInfo.AppendLine($"NIF: {nif}");

                        PdfPCell clienteDataCell = new PdfPCell(new Phrase(clienteInfo.ToString(), normalFont));
                        clienteDataCell.Padding = 10;
                        clienteDataCell.BackgroundColor = BaseColor.WHITE;
                        infoTable.AddCell(clienteDataCell);

                        // Dados da encomenda
                        StringBuilder encomendaInfo = new StringBuilder();
                        encomendaInfo.AppendLine($"ID Encomenda: {idEncomenda:D6}");
                        encomendaInfo.AppendLine($"Data Encomenda: {dataEnc}");
                        encomendaInfo.AppendLine($"Data Recolha: {dataRec}");
                        encomendaInfo.AppendLine($"Estado Pagamento: {pago}");
                        encomendaInfo.AppendLine($"Estado Entrega: {entregue}");

                        PdfPCell encomendaDataCell = new PdfPCell(new Phrase(encomendaInfo.ToString(), normalFont));
                        encomendaDataCell.Padding = 10;
                        encomendaDataCell.BackgroundColor = BaseColor.WHITE;
                        infoTable.AddCell(encomendaDataCell);

                        doc.Add(infoTable);

                        // === TABELA DE PRODUTOS ===
                        Paragraph produtosHeader = new Paragraph("PRODUTOS ENCOMENDADOS", subtitleFont);
                        produtosHeader.SpacingBefore = 10;
                        produtosHeader.SpacingAfter = 10;
                        doc.Add(produtosHeader);

                        PdfPTable produtosTable = new PdfPTable(4);
                        produtosTable.WidthPercentage = 100;
                        produtosTable.SetWidths(new float[] { 45f, 15f, 20f, 20f });

                        // Cabeçalho da tabela
                        string[] headers = { "PRODUTO", "QTD", "PREÇO UNIT.", "SUBTOTAL" };
                        foreach (string header in headers)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(header, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)));
                            headerCell.BackgroundColor = corSecundaria;
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.Padding = 8;
                            produtosTable.AddCell(headerCell);
                        }

                        decimal total = 0;
                        bool zebraRow = false;

                        var produtos = new List<dynamic>();

                        do
                        {
                            produtos.Add(new
                            {
                                Nome = reader["nome"].ToString(),
                                Qtdd = Convert.ToInt32(reader["qtdd"]),
                                Preco = Convert.ToDecimal(reader["preco"])
                            });
                        } while (reader.Read());

                        foreach (var produto in produtos)
                        {
                            decimal subtotal = produto.Preco * produto.Qtdd;
                            total += subtotal;

                            BaseColor rowColor = zebraRow ? corFundo : BaseColor.WHITE;

                            PdfPCell produtoCell = new PdfPCell(new Phrase(produto.Nome, normalFont));
                            produtoCell.BackgroundColor = rowColor;
                            produtoCell.Padding = 8;
                            produtosTable.AddCell(produtoCell);

                            PdfPCell qtddCell = new PdfPCell(new Phrase(produto.Qtdd.ToString(), normalFont));
                            qtddCell.BackgroundColor = rowColor;
                            qtddCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            qtddCell.Padding = 8;
                            produtosTable.AddCell(qtddCell);

                            PdfPCell precoCell = new PdfPCell(new Phrase($"{produto.Preco:C}", normalFont));
                            precoCell.BackgroundColor = rowColor;
                            precoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            precoCell.Padding = 8;
                            produtosTable.AddCell(precoCell);

                            PdfPCell subtotalCell = new PdfPCell(new Phrase($"{subtotal:C}", boldFont));
                            subtotalCell.BackgroundColor = rowColor;
                            subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            subtotalCell.Padding = 8;
                            produtosTable.AddCell(subtotalCell);

                            zebraRow = !zebraRow;
                        }

                        doc.Add(produtosTable);

                        // === TOTAL ===
                        PdfPTable totalTable = new PdfPTable(2);
                        totalTable.WidthPercentage = 100;
                        totalTable.SetWidths(new float[] { 70f, 30f });
                        totalTable.SpacingBefore = 15;

                        PdfPCell emptyCell = new PdfPCell(new Phrase("", normalFont));
                        emptyCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        totalTable.AddCell(emptyCell);

                        PdfPCell totalCell = new PdfPCell(new Phrase($"TOTAL: {total:C}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.WHITE)));
                        totalCell.BackgroundColor = corPrimaria;
                        totalCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        totalCell.Padding = 12;
                        totalTable.AddCell(totalCell);

                        doc.Add(totalTable);

                        // === INFORMAÇÕES DO FUNCIONÁRIO ===
                        if (Session.IsLoggedIn)
                        {
                            PdfPTable funcionarioTable = new PdfPTable(1);
                            funcionarioTable.WidthPercentage = 100;
                            funcionarioTable.SpacingBefore = 20;

                            StringBuilder funcionarioInfo = new StringBuilder();
                            funcionarioInfo.AppendLine("ATENDIDO POR:");
                            funcionarioInfo.AppendLine($"Funcionário: {Session.FuncionarioNome}");

                            PdfPCell funcionarioCell = new PdfPCell(new Phrase(funcionarioInfo.ToString(), normalFont));
                            funcionarioCell.BackgroundColor = corFundo;
                            funcionarioCell.Padding = 10;
                            funcionarioCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            funcionarioTable.AddCell(funcionarioCell);

                            doc.Add(funcionarioTable);
                        }

                        // === RODAPÉ ===
                        PdfPTable footerTable = new PdfPTable(1);
                        footerTable.WidthPercentage = 100;
                        footerTable.SpacingBefore = 30;

                        StringBuilder footerText = new StringBuilder();
                        footerText.AppendLine("OBRIGADO PELA SUA PREFERÊNCIA!");
                        footerText.AppendLine("Padaria Pão Bom - Onde o pão é bom!");
                        footerText.AppendLine("────────────────────────────────────");
                        footerText.AppendLine($"Documento gerado automaticamente em {DateTime.Now:dd/MM/yyyy às HH:mm}");
                        footerText.AppendLine("Este documento serve como comprovativo de encomenda e pagamento.");

                        PdfPCell footerCell = new PdfPCell(new Phrase(footerText.ToString(), smallFont));
                        footerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        footerCell.Padding = 15;
                        footerTable.AddCell(footerCell);

                        doc.Add(footerTable);

                        doc.Close();

                        var resultado = MessageBox.Show(
                            $"Fatura gerada com sucesso!\n\nLocalização: {caminho}\n\nDeseja abrir o documento agora?",
                            "Fatura Criada com Sucesso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (resultado == DialogResult.Yes)
                        {
                            try
                            {
                                var psi = new ProcessStartInfo
                                {
                                    FileName = caminho,
                                    UseShellExecute = true
                                };
                                Process.Start(psi);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao abrir o PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }
    }
}