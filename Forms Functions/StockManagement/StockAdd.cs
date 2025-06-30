using PadariaApp;
using projetoPadariaApp.Services;
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
using static projetoPadariaApp.Forms.RegisterForm;

namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    public partial class StockAdd : Form
    {
        public StockAdd()
        {
            InitializeComponent();
            ConfigurarControlos();
            ConfigurarValidacoes();
            LoadFornecedores();
        }

        private void ConfigurarControlos()
        {
            cbIva.Items.Clear();
            cbIva.Items.AddRange(new object[] { 6, 13, 23 });
            cbIva.SelectedIndex = 0; 
            cbIva.DropDownStyle = ComboBoxStyle.DropDownList;

            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;

            txtNome.MaxLength = 50;
            txtPreco.MaxLength = 10;
            txtQuantidade.MaxLength = 10;
        }

        private void ConfigurarValidacoes()
        {
            // Validação para o campo Nome
            txtNome.TextChanged += (sender, e) =>
            {
                if (txtNome.Text.Length > 50)
                {
                    txtNome.Text = txtNome.Text.Substring(0, 50);
                    txtNome.SelectionStart = txtNome.Text.Length;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Máximo 50 caracteres permitidos", txtNome, 0, -20, 2000);
                }
            };

            // Validação para o campo Preço
            txtPreco.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' &&
                    e.KeyChar != (char)Keys.Delete && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números e vírgula/ponto decimal são permitidos", txtPreco, 0, -20, 2000);
                }

                if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                    (txtPreco.Text.Contains(",") || txtPreco.Text.Contains(".")))
                {
                    e.Handled = true;
                }
            };

            // Validação para o campo Quantidade
            txtQuantidade.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' &&
                    e.KeyChar != (char)Keys.Delete && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números e vírgula/ponto decimal são permitidos", txtQuantidade, 0, -20, 2000);
                }

                if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                    (txtQuantidade.Text.Contains(",") || txtQuantidade.Text.Contains(".")))
                {
                    e.Handled = true;
                }
            };
        }

        private void LoadFornecedores()
        {
            try
            {
                cbFornecedor.Items.Clear();

                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, nome FROM fornecedor ORDER BY nome";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var fornecedorItem = new FuncaoItem
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("nome")
                                };
                                cbFornecedor.Items.Add(fornecedorItem);
                            }
                        }
                    }
                }

                cbFornecedor.DisplayMember = "Name";
                cbFornecedor.ValueMember = "Id";

                if (cbFornecedor.Items.Count == 0)
                {
                    MessageBox.Show("Não existem fornecedores cadastrados. Por favor, cadastre um fornecedor primeiro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome da matéria-prima é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome da matéria-prima deve ter pelo menos 2 caracteres");
            }

            // Validar Preço
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                erros.Add("• Preço é obrigatório");
            }
            else if (!double.TryParse(txtPreco.Text.Replace('.', ','), out double preco))
            {
                erros.Add("• Preço deve ser um valor numérico válido");
            }
            else if (preco <= 0)
            {
                erros.Add("• Preço deve ser maior que zero");
            }
            else if (preco > 99999.99)
            {
                erros.Add("• Preço não pode exceder 99.999,99€");
            }

            // Validar Quantidade
            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                erros.Add("• Quantidade é obrigatória");
            }
            else if (!double.TryParse(txtQuantidade.Text.Replace('.', ','), out double quantidade))
            {
                erros.Add("• Quantidade deve ser um valor numérico válido");
            }
            else if (quantidade < 0)
            {
                erros.Add("• Quantidade não pode ser negativa");
            }
            else if (quantidade > 999999)
            {
                erros.Add("• Quantidade não pode exceder 999.999");
            }

            // Validar Fornecedor
            if (cbFornecedor.SelectedItem == null)
            {
                erros.Add("• Fornecedor é obrigatório");
            }

            // Validar IVA
            if (cbIva.SelectedItem == null)
            {
                erros.Add("• Taxa de IVA é obrigatória");
            }

            // Verificar se já existe matéria-prima com o mesmo nome
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (MateriaPrimaJaExiste(txtNome.Text.Trim()))
                {
                    erros.Add("• Já existe uma matéria-prima com este nome");
                }
            }

            if (erros.Count > 0)
            {
                string mensagem = "Por favor, corrija os seguintes erros:\n\n" + string.Join("\n", erros);
                MessageBox.Show(mensagem, "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool MateriaPrimaJaExiste(string nome)
        {
            try
            {
                var dbManager = DatabaseManage.GetInstance();
                using (var conn = dbManager.GetConnection())
                {
                    conn.Open();
                    using var cmd = new SQLiteCommand(
                        "SELECT COUNT(*) FROM materia WHERE LOWER(nome) = LOWER(@nome)", conn);
                    cmd.Parameters.AddWithValue("@nome", nome);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar duplicação: {ex.Message}");
                return false;
            }
        }

        public static bool RegisterStock(string nome, double preco, double quantidade, int id_fornecedor, int iva)
        {
            var dbManager = DatabaseManage.GetInstance();
            using var conn = dbManager.GetConnection();

            try
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO materia (nome, id_fornecedor, preco, quantidade, iva) 
                                       VALUES (@nome, @id_fornecedor, @preco, @quantidade, @iva)";

                        using (var cmd = new SQLiteCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome.Trim());
                            cmd.Parameters.AddWithValue("@preco", Math.Round(preco, 2));
                            cmd.Parameters.AddWithValue("@quantidade", Math.Round(quantidade, 3));
                            cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);
                            cmd.Parameters.AddWithValue("@iva", iva);

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                transaction.Commit();

                                // Registar log da operação
                                LogsService.RegistarLog(
                                    Session.FuncionarioId,
                                    $"Adicionou matéria-prima «{nome}» (Fornecedor #{id_fornecedor}, " +
                                    $"Qtd={quantidade:F3}, Preço={preco:C2}, IVA={iva}%)");

                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw; 
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool PossuiDadosNaoGuardados()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) ||
                   !string.IsNullOrWhiteSpace(txtPreco.Text) ||
                   !string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                   cbFornecedor.SelectedIndex != -1 ||
                   cbIva.SelectedIndex != 0; // 0 é o índice padrão (6%)
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

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
            cbIva.SelectedIndex = 0; 
            cbFornecedor.SelectedIndex = -1;
            txtNome.Focus(); 
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                string nome = txtNome.Text.Trim();
                double preco = double.Parse(txtPreco.Text.Replace('.', ','));
                double quantidade = double.Parse(txtQuantidade.Text.Replace('.', ','));

                FuncaoItem selectedItem = cbFornecedor.SelectedItem as FuncaoItem;
                int fornecedorID = selectedItem.Id;
                int iva = (int)cbIva.SelectedItem;

                bool success = RegisterStock(nome, preco, quantidade, fornecedorID, iva);

                if (success)
                {
                    DialogResult result = MessageBox.Show($"Matéria-prima '{nome}' registada com sucesso!\n" +
                                      $"Fornecedor: {selectedItem.Name}\n" +
                                      $"Quantidade: {quantidade:F3}\n" +
                                      $"Preço: {preco:C2}\n" +
                                      $"IVA: {iva}%\n\nDeseja adicionar outra matéria-prima?",
                            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        LimparFormulario();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, verifique se os valores numéricos estão corretos.",
                    "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao registar matéria-prima: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
