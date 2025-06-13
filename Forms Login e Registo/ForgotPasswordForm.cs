using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnResetPass_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            if (AuthService.ResetPassword(username))
            {
                MessageBox.Show("Uma nova palavra passe foi criada. Verifique com o administrador.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Utilizador não encontrado.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
