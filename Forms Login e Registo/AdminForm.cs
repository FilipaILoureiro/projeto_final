using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Forms_Functions;

// VAI TER ACESSO TOTAL À APLICAÇÃO
namespace projetoPadariaApp.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Fecha toda a aplicação ao sair
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            DataGridViewEmployeeForm dataGridViewEmployeeForm = new DataGridViewEmployeeForm();
            dataGridViewEmployeeForm.Show();
        }
    }

}
