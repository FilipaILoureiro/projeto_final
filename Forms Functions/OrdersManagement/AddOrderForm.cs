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

namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    public partial class AddOrderForm : Form
    {
        private List<(int idProduto, int quantidade)> produtosSelecionados = new();

        public AddOrderForm()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            ConfigurarValidacoes();
        }

        private void ConfigurarComboBoxes()
        {
            // Configurar ComboBox Entregue
            cbEntregue.Items.Clear();
            cbEntregue.Items.AddRange(new string[] { "Não", "Sim" });
            cbEntregue.SelectedIndex = 0;
            cbEntregue.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar ComboBox Pago
            cbPago.Items.Clear();
            cbPago.Items.AddRange(new string[] { "Não pago", "Pago" });
            cbPago.SelectedIndex = 0;
            cbPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar DateTimePicker
            dtpDataRecolha.MinDate = DateTime.Today;
            dtpDataRecolha.Value = DateTime.Today;
        }

        private void ConfigurarValidacoes()
        {
            // Configurar validação para NIF (apenas números)
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


        private void btnProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                var galeria = new ProductGalleryForm();
                if (galeria.ShowDialog() == DialogResult.OK)
                {
                    produtosSelecionados = galeria.ProdutosSelecionados
                        .Select(p => (p.productId, p.quantidade))
                        .ToList();

                    if (produtosSelecionados.Count > 0)
                    {
                        btnProdutos.Text = $"Produtos Selecionados ({produtosSelecionados.Count})";
                    }
                    else
                    {
                        btnProdutos.Text = "Selecionar Produtos";
                    }
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

            // Validar data de recolha
            if (dtpDataRecolha.Value.Date < DateTime.Today)
            {
                erros.Add("• Data de recolha não pode ser anterior a hoje");
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

        private void btnGuardar_Click(object sender, EventArgs e)
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
                    string query = @"INSERT INTO enc (nif_clientes, preco, data_recolha, pago, entregue) 
                                   VALUES (@nif, @preco, @dataRecolha, @pago, @entregue)";

                    using var cmd = new SQLiteCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@nif", txtNIF.Text.Trim());
                    cmd.Parameters.AddWithValue("@dataRecolha", dtpDataRecolha.Value.Date);

                    string valorPago = cbPago.SelectedItem.ToString() == "Pago" ? "pago" : "não pago";
                    cmd.Parameters.AddWithValue("@pago", valorPago);

                    string valorEntregue = cbEntregue.SelectedItem.ToString() == "Sim" ? "S" : "N";
                    cmd.Parameters.AddWithValue("@entregue", valorEntregue);

                    double total = CalcularTotalProdutos(conn, transaction);
                    cmd.Parameters.AddWithValue("@preco", Math.Round(total, 2));

                    cmd.ExecuteNonQuery();
                    long lastId = conn.LastInsertRowId;

                    InserirProdutosEncomenda(conn, transaction, lastId);

                    transaction.Commit();

                    MessageBox.Show($"Encomenda #{lastId} adicionada com sucesso!\nTotal: {total:C2}",
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
                MessageBox.Show($"Erro ao guardar encomenda: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool PossuiDadosNaoGuardados()
        {
            return !string.IsNullOrWhiteSpace(txtNIF.Text) ||
                   produtosSelecionados.Count > 0 ||
                   dtpDataRecolha.Value.Date != DateTime.Today ||
                   cbPago.SelectedIndex != 0 ||
                   cbEntregue.SelectedIndex != 0;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                if (PossuiDadosNaoGuardados())
                {
                    var resultado = MessageBox.Show(
                        "Tem dados não guardados. Deseja realmente sair?",
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
            if (PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show(
                    "Tem dados não guardados. Deseja realmente sair?",
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
