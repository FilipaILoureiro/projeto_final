using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Forms_Functions.ProductManagement;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    public partial class EditOrderForm : Form
    {
        private int encomendaId;
        private List<(int idProduto, int quantidade)> produtosSelecionados = new();
        private List<(int idProduto, int quantidade)> produtosOriginais = new(); // Para detectar mudanças
        private string nifOriginal = "";
        private DateTime dataOriginal;
        private DateTime dataEncomenda;
        private string pagoOriginal = "";
        private string entregueOriginal = "";

        public EditOrderForm(int id)
        {
            InitializeComponent();
            encomendaId = id;
            ConfigurarComboBoxes();
            ConfigurarValidacoes();
            CarregarDadosEncomenda();
        }

        private void ConfigurarComboBoxes()
        {
            cbEntregue.Items.Clear();
            cbEntregue.Items.AddRange(new string[] { "Não", "Sim" });
            cbEntregue.DropDownStyle = ComboBoxStyle.DropDownList;

            cbPago.Items.Clear();
            cbPago.Items.AddRange(new string[] { "Não pago", "Pago" });
            cbPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarValidacoes()
        {
            txtNIF.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números são permitidos", txtNIF, 0, -20, 2000);
                }
            };
            txtNIF.MaxLength = 9;
        }

        private void CarregarDadosEncomenda()
        {
            try
            {
                using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
                conn.Open();

                var cmd = new SQLiteCommand("SELECT * FROM enc WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", encomendaId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nifOriginal = reader["nif_clientes"].ToString();
                    txtNIF.Text = nifOriginal;

                    var dataTexto = reader["data_recolha"].ToString();
                    if (DateTime.TryParse(dataTexto, out DateTime dataParsed))
                    {
                        dataOriginal = dataParsed.Date;
                    }
                    else if (reader["data_recolha"] is DateTime dataDirecta)
                    {
                        dataOriginal = dataDirecta.Date;
                    }
                    else
                    {
                        dataOriginal = DateTime.Today;
                    }

                    if (reader["data_encomenda"] != DBNull.Value)
                    {
                        dataEncomenda = DateTime.Parse(reader["data_encomenda"].ToString()).Date;
                    }
                    else
                    {
                        dataEncomenda = DateTime.Today;
                    }

                    if (dataOriginal < DateTime.Today)
                    {
                        dataOriginal = DateTime.Today;
                    }

                    dtpDataRecolha.Value = dataOriginal;

                    pagoOriginal = reader["pago"].ToString();
                    cbPago.SelectedItem = pagoOriginal == "pago" ? "Pago" : "Não pago";

                    entregueOriginal = reader["entregue"].ToString();
                    cbEntregue.SelectedItem = entregueOriginal == "S" ? "Sim" : "Não";
                }
                reader.Close();

                // Carregar produtos
                var cmdProdutos = new SQLiteCommand("SELECT id_prod, qtdd FROM enc_prod WHERE id_enc = @id", conn);
                cmdProdutos.Parameters.AddWithValue("@id", encomendaId);
                var readerProdutos = cmdProdutos.ExecuteReader();

                while (readerProdutos.Read())
                {
                    var produto = (
                        Convert.ToInt32(readerProdutos["id_prod"]),
                        Convert.ToInt32(readerProdutos["qtdd"])
                    );
                    produtosSelecionados.Add(produto);
                    produtosOriginais.Add(produto); 
                }
                readerProdutos.Close();

                AtualizarTextoBotaoProdutos();

                dtpDataRecolha.MinDate = dataEncomenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados da encomenda: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTextoBotaoProdutos()
        {
            if (produtosSelecionados.Count > 0)
            {
                int totalItens = produtosSelecionados.Sum(p => p.quantidade);
                btnProdutos.Text = $"Selecionados: {totalItens} itens";
            }
            else
            {
                btnProdutos.Text = "Selecionar Produtos";
            }
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                var galeria = new ProductGalleryForm(produtosSelecionados);
                if (galeria.ShowDialog() == DialogResult.OK)
                {
                    produtosSelecionados = galeria.ProdutosSelecionados
                        .Select(p => (p.productId, p.quantidade))
                        .ToList();

                    AtualizarTextoBotaoProdutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir galeria de produtos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar NIF
            if (string.IsNullOrWhiteSpace(txtNIF.Text))
            {
                erros.Add("• NIF é obrigatório");
            }
            else if (txtNIF.Text.Length != 9)
            {
                erros.Add("• NIF deve ter exatamente 9 dígitos");
            }
            else if (!txtNIF.Text.All(char.IsDigit))
            {
                erros.Add("• NIF deve conter apenas números");
            }

            // Validar produtos selecionados
            if (produtosSelecionados.Count == 0)
            {
                erros.Add("• Deve selecionar pelo menos um produto");
            }

            // Validar se existe quantidade válida nos produtos
            if (produtosSelecionados.Any(p => p.quantidade <= 0))
            {
                erros.Add("• Todos os produtos selecionados devem ter quantidade maior que zero");
            }

            // Validar data de recolha
            if (dtpDataRecolha.Value.Date < dataEncomenda)
            {
                erros.Add("• Data de recolha não pode ser anterior à data da encomenda");
            }

            // Validar ComboBoxes
            if (cbPago.SelectedIndex == -1)
            {
                erros.Add("• Status de pagamento é obrigatório");
            }

            if (cbEntregue.SelectedIndex == -1)
            {
                erros.Add("• Status de entrega é obrigatório");
            }

            if (erros.Count > 0)
            {
                string mensagem = "Por favor, corrija os seguintes erros:\n\n" + string.Join("\n", erros);
                MessageBox.Show(mensagem, "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private double CalcularTotalProdutos(SQLiteConnection conn, SQLiteTransaction transaction)
        {
            double total = 0;

            foreach (var (id, qtdd) in produtosSelecionados)
            {
                using var cmdProduto = new SQLiteCommand(
                    "SELECT preco FROM produtos WHERE id = @id", conn, transaction);
                cmdProduto.Parameters.AddWithValue("@id", id);

                var resultado = cmdProduto.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    double preco = Convert.ToDouble(resultado);
                    total += preco * qtdd;
                }
                else
                {
                    throw new Exception($"Produto com ID {id} não encontrado ou sem preço definido.");
                }
            }

            return total;
        }

        private void InserirProdutosEncomenda(SQLiteConnection conn, SQLiteTransaction transaction, long idEncomenda)
        {
            foreach (var (idProduto, qtdd) in produtosSelecionados)
            {
                using var cmdInsertProd = new SQLiteCommand(
                    "INSERT INTO enc_prod (id_enc, id_prod, qtdd) VALUES (@idEnc, @idProd, @qtdd)",
                    conn, transaction);

                cmdInsertProd.Parameters.AddWithValue("@idEnc", idEncomenda);
                cmdInsertProd.Parameters.AddWithValue("@idProd", idProduto);
                cmdInsertProd.Parameters.AddWithValue("@qtdd", qtdd);
                cmdInsertProd.ExecuteNonQuery();
            }
        }

        private bool PossuiAlteracoes()
        {
            // Verificar se NIF foi alterado
            if (txtNIF.Text.Trim() != nifOriginal)
                return true;

            // Verificar se data foi alterada
            if (dtpDataRecolha.Value.Date != dataOriginal.Date)
                return true;

            // Verificar se status de pagamento foi alterado
            string pagoAtual = cbPago.SelectedItem?.ToString() == "Pago" ? "pago" : "não pago";
            if (pagoAtual != pagoOriginal)
                return true;

            // Verificar se status de entrega foi alterado
            string entregueAtual = cbEntregue.SelectedItem?.ToString() == "Sim" ? "S" : "N";
            if (entregueAtual != entregueOriginal)
                return true;

            // Verificar se produtos foram alterados
            if (produtosSelecionados.Count != produtosOriginais.Count)
                return true;

            foreach (var produto in produtosSelecionados)
            {
                if (!produtosOriginais.Any(p => p.idProduto == produto.idProduto && p.quantidade == produto.quantidade))
                    return true;
            }

            foreach (var produtoOriginal in produtosOriginais)
            {
                if (!produtosSelecionados.Any(p => p.idProduto == produtoOriginal.idProduto && p.quantidade == produtoOriginal.quantidade))
                    return true;
            }

            return false;
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
                conn.Open();

                using var transaction = conn.BeginTransaction();

                try
                {
                    double total = CalcularTotalProdutos(conn, transaction);

                    string query = @"UPDATE enc SET nif_clientes = @nif, preco = @preco, data_recolha = @dataRecolha, 
                           pago = @pago, entregue = @entregue WHERE id = @id";

                    using var cmd = new SQLiteCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@nif", txtNIF.Text.Trim());
                    cmd.Parameters.AddWithValue("@preco", Math.Round(total, 2));
                    cmd.Parameters.AddWithValue("@dataRecolha", dtpDataRecolha.Value.Date);

                    string valorPago = cbPago.SelectedItem.ToString() == "Pago" ? "pago" : "não pago";
                    cmd.Parameters.AddWithValue("@pago", valorPago);

                    string valorEntregue = cbEntregue.SelectedItem.ToString() == "Sim" ? "S" : "N";
                    cmd.Parameters.AddWithValue("@entregue", valorEntregue);
                    cmd.Parameters.AddWithValue("@id", encomendaId);

                    cmd.ExecuteNonQuery();

                    // Remover produtos antigos
                    var cmdDeleteOld = new SQLiteCommand("DELETE FROM enc_prod WHERE id_enc = @id", conn, transaction);
                    cmdDeleteOld.Parameters.AddWithValue("@id", encomendaId);
                    cmdDeleteOld.ExecuteNonQuery();

                    // Inserir novos produtos
                    InserirProdutosEncomenda(conn, transaction, encomendaId);

                    // ✅ Commit da transação
                    transaction.Commit();

                    // ✅ Registar log após commit
                    try
                    {
                        LogsService.RegistarLog(
                            Session.FuncionarioId,
                            $"Editou encomenda #{encomendaId} → NIF Cliente: {txtNIF.Text.Trim()}, Total: {total:C2}, " +
                            $"Data Recolha: {dtpDataRecolha.Value:yyyy-MM-dd}, Pago: {valorPago}, Entregue: {valorEntregue}"
                        );
                    }
                    catch (Exception logEx)
                    {
                        Console.WriteLine($"Erro ao registar log de encomenda editada: {logEx.Message}");
                    }

                    MessageBox.Show($"Encomenda #{encomendaId} atualizada com sucesso!\nNovo Total: {total:C2}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar encomenda: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                if (PossuiAlteracoes())
                {
                    var resultado = MessageBox.Show(
                        "Tem alterações não guardadas. Deseja realmente sair?",
                        "Confirmar Saída",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            base.OnFormClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PossuiAlteracoes())
            {
                var resultado = MessageBox.Show(
                    "Tem alterações não guardadas. Deseja realmente sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
