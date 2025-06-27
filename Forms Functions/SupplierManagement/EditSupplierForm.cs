using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    public partial class EditSupplierForm : Form
    {
        private int fornecedorID;
        private SupplierData _supplierOriginal;

        // Classe auxiliar para armazenar dados do fornecedor
        private class SupplierData
        {
            public string Nome { get; set; }
            public string Contacto { get; set; }
            public string Email { get; set; }
            public int TempodeEntrega { get; set; }
        }

        public EditSupplierForm(int id)
        {
            InitializeComponent();
            fornecedorID = id;

            ConfigurarValidacoes();
            LoadDadosSupplier();
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

            // Validação para tempo de entrega - só números
            txtTempodeEntrega.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números são permitidos", txtTempodeEntrega, 0, -20, 2000);
                }
            };

            // Validação para email em tempo real
            txtEmail.Leave += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                {
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Formato de email inválido", txtEmail, 0, -20, 3000);
                }
            };

            // Definir comprimentos máximos
            txtNome.MaxLength = 100;
            txtContacto.MaxLength = 9;
            txtEmail.MaxLength = 100;
            txtTempodeEntrega.MaxLength = 3;
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

        private void LoadDadosSupplier()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT nome, contacto, email, tempo_de_entrega FROM fornecedor WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", fornecedorID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Carregar dados originais
                                _supplierOriginal = new SupplierData
                                {
                                    Nome = reader["nome"].ToString(),
                                    Contacto = reader["contacto"].ToString(),
                                    Email = reader["email"].ToString(),
                                    TempodeEntrega = Convert.ToInt32(reader["tempo_de_entrega"])
                                };

                                // Preencher campos do formulário
                                PreencherCampos();
                            }
                            else
                            {
                                MessageBox.Show("Fornecedor não encontrado!", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do fornecedor: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void PreencherCampos()
        {
            try
            {
                txtNome.Text = _supplierOriginal.Nome;
                txtContacto.Text = _supplierOriginal.Contacto;
                txtEmail.Text = _supplierOriginal.Email;
                txtTempodeEntrega.Text = _supplierOriginal.TempodeEntrega.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher campos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome do fornecedor é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome deve ter pelo menos 2 caracteres");
            }

            // Validar contacto
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

            // Validar email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                erros.Add("• Email é obrigatório");
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                erros.Add("• Email deve ter um formato válido");
            }

            // Validar tempo de entrega
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

            // Verificar se email já existe (exceto para o fornecedor atual)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && IsValidEmail(txtEmail.Text.Trim()))
            {
                if (VerificarEmailExistente(txtEmail.Text.Trim()))
                {
                    erros.Add("• Já existe um fornecedor com este email");
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

        private bool VerificarEmailExistente(string email)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT COUNT(*) FROM fornecedor WHERE LOWER(email) = LOWER(@email) AND id != @id", conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", fornecedorID);

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

        private bool PossuiAlteracoes()
        {
            if (_supplierOriginal == null ||
                string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtContacto.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTempodeEntrega.Text))
            {
                return false;
            }

            if (txtNome.Text.Trim() != _supplierOriginal.Nome)
                return true;

            if (txtContacto.Text.Trim() != _supplierOriginal.Contacto)
                return true;

            if (txtEmail.Text.Trim() != _supplierOriginal.Email)
                return true;

            if (int.TryParse(txtTempodeEntrega.Text, out int tempoAtual))
            {
                if (tempoAtual != _supplierOriginal.TempodeEntrega)
                    return true;
            }

            return false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                string nome = txtNome.Text.Trim();
                string contacto = txtContacto.Text.Trim();
                string email = txtEmail.Text.Trim();
                int tempodeEntrega = int.Parse(txtTempodeEntrega.Text);

                bool sucesso = UpdateSupplier(nome, contacto, email, tempodeEntrega);

                if (sucesso)
                {
                    MessageBox.Show($"Fornecedor '{nome}' atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar fornecedor.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar dados: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateSupplier(string nome, string contacto, string email, int tempodeEntrega)
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
                            string query = @"UPDATE fornecedor 
                                           SET nome = @nome, 
                                               contacto = @contacto, 
                                               email = @email, 
                                               tempo_de_entrega = @tempo 
                                           WHERE id = @id";

                            using (var cmd = new SQLiteCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", nome);
                                cmd.Parameters.AddWithValue("@contacto", contacto);
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.Parameters.AddWithValue("@tempo", tempodeEntrega);
                                cmd.Parameters.AddWithValue("@id", fornecedorID);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Registar log
                                    LogsService.RegistarLog(
                                        Session.FuncionarioId,
                                        $"Editou fornecedor #{fornecedorID} → " +
                                        $"Nome: {nome}, Contacto: {contacto}, Email: {email}, Tempo entrega: {tempodeEntrega} dias");

                                    transaction.Commit();
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
                MessageBox.Show($"Erro ao atualizar fornecedor: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

