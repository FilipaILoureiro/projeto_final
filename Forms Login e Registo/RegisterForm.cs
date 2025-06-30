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
using System.Text.RegularExpressions;
using Guna.UI2.WinForms;
using PadariaApp;
using projetoPadariaApp.Models;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            LoadFuncoes();
            SetupValidation();
        }

        private static readonly string connectionString = "Data Source=projetoPadariaApp.db;Version=3;";

        private void SetupValidation()
        {
            txtNome.Leave += ValidateNome;
            txtContacto.Leave += ValidateContacto;
            txtUsername.Leave += ValidateUsername;
            txtPass.Leave += ValidatePassword;
            txtConfirmarPass.Leave += ValidateConfirmPassword;
        }

        private void LoadFuncoes()
        {
            try
            {
                cbFuncao.Items.Clear();

                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id_funcao, funcao FROM funcao ORDER BY funcao";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var funcaoItem = new FuncaoItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                };
                                cbFuncao.Items.Add(funcaoItem);
                            }
                        }
                    }
                }

                cbFuncao.DisplayMember = "Name";
                cbFuncao.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar funções: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class FuncaoItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        #region Validações
        private void ValidateNome(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                ShowFieldError(txtNome, "Nome é obrigatório");
                return;
            }
            if (nome.Length < 2)
            {
                ShowFieldError(txtNome, "Nome deve ter pelo menos 2 caracteres");
                return;
            }
            if (CheckIfNameExists(nome))
            {
                ShowFieldError(txtNome, "Este nome já está registado");
                return;
            }
            ClearFieldError(txtNome);
        }

        private void ValidateContacto(object sender, EventArgs e)
        {
            string contacto = txtContacto.Text.Trim();
            if (string.IsNullOrWhiteSpace(contacto))
            {
                ShowFieldError(txtContacto, "Contacto é obrigatório");
                return;
            }

            if (IsValidEmail(contacto))
            {
                if (CheckIfContactExists(contacto))
                {
                    ShowFieldError(txtContacto, "Este contacto já está registado");
                    return;
                }
                ClearFieldError(txtContacto);
            }
        }

        private void ValidateUsername(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowFieldError(txtUsername, "Nome de utilizador é obrigatório");
                return;
            }
            if (username.Length < 3)
            {
                ShowFieldError(txtUsername, "Nome de utilizador deve ter pelo menos 3 caracteres");
                return;
            }
            if (CheckIfUsernameExists(username))
            {
                ShowFieldError(txtUsername, "Este nome de utilizador já existe");
                return;
            }
            ClearFieldError(txtUsername);
        }

        private void ValidatePassword(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                ShowFieldError(txtPass, "Palavra-passe é obrigatória");
                return;
            }
            if (password.Length < 6)
            {
                ShowFieldError(txtPass, "Palavra-passe deve ter pelo menos 6 caracteres");
                return;
            }
            ClearFieldError(txtPass);

            if (!string.IsNullOrWhiteSpace(txtConfirmarPass.Text))
            {
                ValidateConfirmPassword(txtConfirmarPass, EventArgs.Empty);
            }
        }

        private void ValidateConfirmPassword(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            string confirmPassword = txtConfirmarPass.Text;

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowFieldError(txtConfirmarPass, "Confirmação de palavra-passe é obrigatória");
                return;
            }

            if (password != confirmPassword)
            {
                ShowFieldError(txtConfirmarPass, "As palavras-passe não coincidem");
                return;
            }

            ClearFieldError(txtConfirmarPass);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckIfNameExists(string nome)
        {
            try
            {
                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM funcionario WHERE LOWER(nome) = LOWER(@nome)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar nome: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckIfContactExists(string contacto)
        {
            try
            {
                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM funcionario WHERE LOWER(contacto) = LOWER(@contacto)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@contacto", contacto);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar email: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckIfUsernameExists(string username)
        {
            try
            {
                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM funcionario WHERE LOWER(username) = LOWER(@username)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar nome de utilizador: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ShowFieldError(Control control, string message)
        {
            if (control is Guna2TextBox gunaTextBox)
            {
                gunaTextBox.BorderColor = Color.Red;
            }

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(control, message);
            toolTip.Show(message, control, control.Width, 0, 3000);
        }

        private void ClearFieldError(Control control)
        {
            if (control is Guna2TextBox gunaTextBox)
            {
                gunaTextBox.BorderColor = Color.FromArgb(213, 218, 223);
            }
        }
        #endregion

        private bool ValidateAllFields()
        {
            bool isValid = true;

            string nome = txtNome.Text.Trim();
            string contacto = txtContacto.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text;
            string confirmPassword = txtConfirmarPass.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ShowFieldError(txtNome, "Nome é obrigatório");
                isValid = false;
            }
            else if (nome.Length < 2)
            {
                ShowFieldError(txtNome, "Nome deve ter pelo menos 2 caracteres");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(contacto))
            {
                ShowFieldError(txtContacto, "Email é obrigatório");
                isValid = false;
            }
            else if (!IsValidEmail(contacto))
            {
                ShowFieldError(txtContacto, "Formato de email inválido");
                isValid = false;
            }
            else if (CheckIfContactExists(contacto))
            {
                ShowFieldError(txtContacto, "Este email já está registado");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowFieldError(txtUsername, "Nome de utilizador é obrigatório");
                isValid = false;
            }
            else if (username.Length < 3)
            {
                ShowFieldError(txtUsername, "Nome de utilizador deve ter pelo menos 3 caracteres");
                isValid = false;
            }
            else if (CheckIfUsernameExists(username))
            {
                ShowFieldError(txtUsername, "Este nome de utilizador já existe");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowFieldError(txtPass, "Palavra passe é obrigatória");
                isValid = false;
            }
            else if (password.Length < 6)
            {
                ShowFieldError(txtPass, "Palavra passe deve ter pelo menos 6 caracteres");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowFieldError(txtConfirmarPass, "Confirmação de palavra-passe é obrigatória");
                isValid = false;
            }
            else if (password != confirmPassword)
            {
                ShowFieldError(txtConfirmarPass, "As palavras-passe não coincidem");
                isValid = false;
            }

            if (cbFuncao.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma função.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtNome.Clear();
            txtContacto.Clear();
            txtUsername.Clear();
            txtPass.Clear();
            txtConfirmarPass.Clear();
            cbFuncao.SelectedIndex = -1;
            chkIsAdmin.Checked = false;

            ClearFieldError(txtNome);
            ClearFieldError(txtContacto);
            ClearFieldError(txtUsername);
            ClearFieldError(txtPass);
            ClearFieldError(txtConfirmarPass);
        }

        private void lblNome_Click(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void lblContacto_Click(object sender, EventArgs e)
        {
            txtContacto.Focus();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtPass.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateAllFields())
                {
                    return;
                }

                string nome = txtNome.Text.Trim();
                string contacto = txtContacto.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPass.Text;

                FuncaoItem selectedItem = cbFuncao.SelectedItem as FuncaoItem;
                int funcaoID = selectedItem.Id;
                bool isAdmin = chkIsAdmin.Checked;

                DialogResult result = MessageBox.Show(
                    $"Confirma o registo do utilizador '{nome}'?",
                    "Confirmar Registo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool success = AuthService.RegisterUser(nome, contacto, username, password, funcaoID, isAdmin);

                    if (success)
                    {
                        MessageBox.Show("Utilizador registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao registar utilizador. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HasDataFilled())
            {
                DialogResult result = MessageBox.Show(
                    "Tem dados preenchidos. Tem certeza que quer sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else 
            {
                this.Close();
            }
        }

        private bool HasDataFilled()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) ||
                   !string.IsNullOrWhiteSpace(txtContacto.Text) ||
                   !string.IsNullOrWhiteSpace(txtUsername.Text) ||
                   !string.IsNullOrWhiteSpace(txtPass.Text) ||
                   !string.IsNullOrWhiteSpace(txtConfirmarPass.Text) ||
                   cbFuncao.SelectedIndex != -1 ||
                   chkIsAdmin.Checked;
        }
    }
}