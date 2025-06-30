using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPadariaApp.Properties.Style
{
    public partial class PasswordTempDialog : Form
    {
        private string tempPassword;

        public PasswordTempDialog(string password, string nome, string username)
        {
            InitializeComponent();
            tempPassword = password;

            lblUsername.Text = $"{username}";
            txtPassword.Text = password;

            txtPassword.ReadOnly = true;
            txtPassword.Font = new Font("Consolas", 16, FontStyle.Bold);
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.Red;
            txtPassword.SelectAll();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tempPassword);
            MessageBox.Show("Senha copiada para a área de transferência!", "Copiar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
