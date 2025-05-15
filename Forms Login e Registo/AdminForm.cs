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
using projetoPadariaApp.Forms_Functions.EmployeeManagement;
using projetoPadariaApp.Forms_Functions.StockManagement;
using projetoPadariaApp.Forms_Functions.SupplierManagement;
using projetoPadariaApp.Forms_Login_e_Registo;

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
            EmployeeManagementForm employeeManagementForm = new EmployeeManagementForm();
            employeeManagementForm.Show();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            SupplierList supplierList = new SupplierList();
            supplierList.Show();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            StockList stockList = new StockList();
            stockList.Show();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            LogsList logslist = new LogsList();
            logslist.Show();
        }
    }

}
