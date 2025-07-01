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
using PadariaApp;

namespace projetoPadariaApp.Forms_Login_e_Registo
{
    public partial class AlterarPasswordForm : Form
    {
        private int funcionarioId;

        public AlterarPasswordForm(int id)
        {
            InitializeComponent();
            funcionarioId = id;
        }

        private void btnAlterarPass_Click(object sender, EventArgs e)
        {
            string novaPass = txtPass.Text.Trim();
            string confirmarPass = txtConfirmarPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(novaPass) || string.IsNullOrWhiteSpace(confirmarPass))
            {
                MessageBox.Show("Por favor, preencha ambos os campos.", "Campos Obrigatórios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaPass.Length < 6)
            {
                MessageBox.Show("A nova senha deve ter pelo menos 6 caracteres.", "Senha Fraca",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (!ValidarComplexidadeSenha(novaPass))
            {
                MessageBox.Show("A senha deve conter pelo menos:\n• Uma letra maiúscula\n• Uma letra minúscula\n• Um número",
                    "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (novaPass != confirmarPass)
            {
                MessageBox.Show("As senhas não coincidem.", "Erro de Confirmação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPass.Focus();
                return;
            }

            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(novaPass);

                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE funcionario SET pass = @novaPass, usar_pass_temp = 'N' WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@novaPass", hashedPassword);
                        cmd.Parameters.AddWithValue("@id", funcionarioId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Senha alterada com sucesso!\nPode agora fazer login normalmente.",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar a senha. Tente novamente.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar senha: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarComplexidadeSenha(string senha)
        {
            bool temMaiuscula = senha.Any(char.IsUpper);
            bool temMinuscula = senha.Any(char.IsLower);
            bool temNumero = senha.Any(char.IsDigit);

            return temMaiuscula && temMinuscula && temNumero;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                    "Tem a certeza que pretende sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
