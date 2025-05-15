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

            if (AuthService.AuthenticateUser(username, password))
            {
                MessageBox.Show("Login bem-sucedido!");

                // Obter o ID e nome do funcionário após autenticação bem-sucedida
                int funcionarioId = AuthService.GetFuncionarioId(Session.FuncionarioNome);
                // Supondo que o método GetFuncionarioId existe
                string funcionarioNome = AuthService.GetFuncionarioNome(username);  // E o método GetFuncionarioNome também

                // Armazenar as informações do usuário na sessão
                Session.FuncionarioId = funcionarioId;
                Session.FuncionarioNome = funcionarioNome;

                bool isAdmin = AuthService.IsAdmin(username);

                if (isAdmin)
                {
                    AdminForm adminPanel = new AdminForm();
                    adminPanel.Show();
                }
                else
                {
                    EmployeeForm employeePanel = new EmployeeForm();
                    employeePanel.Show();
                }

                this.Hide(); // Esconde o LoginForm após autenticação
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
