using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Services;
using static System.Collections.Specialized.BitVector32;

namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    public partial class SupplierAdd : Form
    {
        public SupplierAdd()
        {
            InitializeComponent();
            ConfigurarControlos();
            ConfigurarValidacoes();
        }

        private void ConfigurarControlos()
        {
            txtNome.MaxLength = 100;        
            txtContacto.MaxLength = 9;      
            txtEmail.MaxLength = 100;        
            txtTempodeEntrega.MaxLength = 3; 
        }

        private void ConfigurarValidacoes()
        {
            txtContacto.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números são permitidos", txtContacto, 0, -20, 2000);
                }
            };

            txtEmail.Leave += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                {
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Formato de email inválido", txtEmail, 0, -20, 3000);
                }
            };

            txtTempodeEntrega.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números são permitidos", txtTempodeEntrega, 0, -20, 2000);
                }
            };
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                return emailRegex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar nome (igual ao EditSupplier)
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome do fornecedor é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome deve ter pelo menos 2 caracteres");
            }

            // Validar contacto (igual ao EditSupplier)
            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                erros.Add("• Contacto é obrigatório");
            }
            else if (txtContacto.Text.Trim().Length != 9)
            {
                erros.Add("• Contacto deve ter exatamente 9 dígitos");
            }
            else if (!txtContacto.Text.All(char.IsDigit))
            {
                erros.Add("• Contacto deve conter apenas números");
            }

            // Validar email (igual ao EditSupplier)
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                erros.Add("• Email é obrigatório");
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                erros.Add("• Email deve ter um formato válido");
            }

            // Validar tempo de entrega (igual ao EditSupplier)
            if (string.IsNullOrWhiteSpace(txtTempodeEntrega.Text))
            {
                erros.Add("• Tempo de entrega é obrigatório");
            }
            else if (!int.TryParse(txtTempodeEntrega.Text, out int tempo) || tempo <= 0)
            {
                erros.Add("• Tempo de entrega deve ser um número válido maior que 0");
            }
            else if (tempo > 365)
            {
                erros.Add("• Tempo de entrega não pode ser superior a 365 dias");
            }

            // Verificar se nome já existe
            if (!string.IsNullOrWhiteSpace(txtNome.Text) && FornecedorJaExiste(txtNome.Text.Trim()))
            {
                erros.Add("• Já existe um fornecedor com este nome");
            }

            // Verificar se email já existe
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && IsValidEmail(txtEmail.Text.Trim()) && EmailJaExiste(txtEmail.Text.Trim()))
            {
                erros.Add("• Já existe um fornecedor com este email");
            }

            if (erros.Count > 0)
            {
                string mensagem = "Por favor, corrija os seguintes erros:\n\n" + string.Join("\n", erros);
                MessageBox.Show(mensagem, "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool FornecedorJaExiste(string nome)
        {
            try
            {
                var db = DatabaseManage.GetInstance();
                using var conn = db.GetConnection();
                conn.Open();
                using var cmd = new SQLiteCommand("SELECT COUNT(*) FROM fornecedor WHERE LOWER(nome) = LOWER(@nome)", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool EmailJaExiste(string email)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT COUNT(*) FROM fornecedor WHERE LOWER(email) = LOWER(@email)", conn);
                    cmd.Parameters.AddWithValue("@email", email);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar email: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool PossuiDadosNaoGuardados()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) ||
                   !string.IsNullOrWhiteSpace(txtContacto.Text) ||
                   !string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   !string.IsNullOrWhiteSpace(txtTempodeEntrega.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK && PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show("Tem dados não guardados. Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        public static bool RegisterSupplier(string nome, string contacto, string email, int tempoDeEntrega)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = "INSERT INTO fornecedor (nome, contacto, email, tempo_de_entrega) VALUES (@nome, @contacto, @email, @tempo)";

                            using (var cmd = new SQLiteCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", nome);
                                cmd.Parameters.AddWithValue("@contacto", contacto);
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@tempo", tempoDeEntrega);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();

                                    // Registar log fora da transaction do fornecedor
                                    try
                                    {
                                        LogsService.RegistarLog(
                                            Session.FuncionarioId,
                                            $"Registou novo fornecedor → " +
                                            $"Nome: {nome}, Contacto: {contacto}, Email: {email}, Tempo entrega: {tempoDeEntrega} dias"
                                        );
                                    }
                                    catch (Exception logEx)
                                    {
                                        Console.WriteLine($"Erro ao registar log de fornecedor: {logEx.Message}");
                                    }

                                    return true;
                                }

                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registar fornecedor: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            string nome = txtNome.Text.Trim();
            string contacto = txtContacto.Text.Trim();
            string email = txtEmail.Text.Trim();
            int tempoDeEntrega = int.Parse(txtTempodeEntrega.Text);

            bool sucesso = RegisterSupplier(nome, contacto, email, tempoDeEntrega);

            if (sucesso)
            {
                DialogResult result = MessageBox.Show($"Fornecedor '{nome}' registado com sucesso!\n\nDeseja adicionar outro fornecedor?",
                    "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtNome.Clear();
                    txtContacto.Clear();
                    txtEmail.Clear();
                    txtTempodeEntrega.Clear();
                    txtNome.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show("Tem dados não guardados. Deseja sair?", "Confirmar Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No) return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
