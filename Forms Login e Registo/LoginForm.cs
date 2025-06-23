using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Services;
using System.Data.SQLite;
using PadariaApp;

namespace projetoPadariaApp.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Autenticar e, de caminho, obter ID + Nome
            if (AuthService.AuthenticateUser(username, password))
            {
                // Estes dois métodos DEVEM receber o username (ou o id), não o nome que ainda não existe
                int funcionarioId = AuthService.GetFuncionarioId(username);
                string funcionarioNome = AuthService.GetFuncionarioNome(username);

                if (funcionarioId == 0)              // sanity-check
                {
                    MessageBox.Show("Falha a obter o ID do funcionário.");
                    return;
                }

                // Guardar na sessão
                Session.FuncionarioId = funcionarioId;
                Session.FuncionarioNome = funcionarioNome;

                // Registar quem entrou
                LogsService.RegistarLog(funcionarioId, $"Login efectuado ({DateTime.Now:dd/MM/yyyy HH:mm})");

                // Abrir o painel certo
                if (AuthService.IsAdmin(username))
                    new AdminForm().Show();
                else
                    new EmployeeForm().Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou senha incorretos!");
            }
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.Show();
        }

        private void linkRegisto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }
    }
}
