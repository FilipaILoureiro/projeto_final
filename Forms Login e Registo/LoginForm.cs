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
using Guna.UI2.WinForms;
using projetoPadariaApp.Models;
using projetoPadariaApp.Forms_Login_e_Registo;

namespace projetoPadariaApp.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthService.AuthenticateUser(username, password, out bool needsPasswordChange, out int userId))
            {
                if (needsPasswordChange)
                {
                    LogsService.RegistarLog(userId, "Login com password temporária");
                    MessageBox.Show("Estás a usar uma password temporária. Por favor define uma nova password.");
                    AlterarPasswordForm alterarForm = new AlterarPasswordForm(userId);
                    this.Hide();
                    alterarForm.ShowDialog();
                    this.Show();
                    return;
                }

                var userInfo = AuthService.GetUserInfo(username);
                if (userInfo != null)
                {
                    Session.InitializeSession(userInfo);

                    // Log de login bem-sucedido
                    LogsService.RegistarLog(userInfo.Id, "Login efetuado com sucesso");

                    MessageBox.Show("Login bem-sucedido!");

                    if (Session.IsAdmin)
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else
                    {
                        EmployeeForm employeeForm = new EmployeeForm();
                        employeeForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erro ao obter dados do utilizador após autenticação.");
                }
            }
            else
            {
                // Log de tentativa falhada
                LogsService.RegistarLog(null, $"Tentativa de login falhada para utilizador '{username}'");

                MessageBox.Show("Nome de utilizador, senha incorretos ou conta desativada!");
            }
        }

    }
}


