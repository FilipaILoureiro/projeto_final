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

namespace projetoPadariaApp.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthService.AuthenticateUser(username, password))
            {
                MessageBox.Show("Login bem-sucedido!");

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

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou senha incorretos!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Close();
            registerForm registerForm = new registerForm();
            registerForm.Show();
        }

        private void linkEsqueceu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}


