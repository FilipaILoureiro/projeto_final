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
using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509.Qualified;
using PadariaApp;
using projetoPadariaApp.Forms_Functions;
using projetoPadariaApp.Forms_Functions.OrdersManagement;
using projetoPadariaApp.Forms_Functions.ProductManagement;
using projetoPadariaApp.Forms_Functions.StockManagement;
using projetoPadariaApp.Forms_Functions.SupplierManagement;
using projetoPadariaApp.Properties.Style;
using projetoPadariaApp.Services;

// VAI TER ACESSO APENAS A DETERMINADAS FUNÇÕES
namespace projetoPadariaApp.Forms
{
    public partial class EmployeeForm : Form
    {
        // CAMPOS
        private Guna2Button currentButton;
        private Form activeForm;

        // CONSTRUTOR
        public EmployeeForm()
        {
            InitializeComponent();
            this.Text = "Painel de Gestão";
            this.Load += EmployeeForm_Load;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "HOME";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new HomeForm(), btnHome, "Home");
        }

        // MÉTODOS
        private void ActivateButton(object btnSender, string secao)
        {
            if (btnSender != null)
            {
                if (currentButton != (Guna2Button)btnSender)
                {
                    DisableButton();
                    string hexColor = ThemeColor.ColorList.ContainsKey(secao) ? ThemeColor.ColorList[secao] : "#607D8B";
                    Color color = ColorTranslator.FromHtml(hexColor);

                    currentButton = (Guna2Button)btnSender;
                    currentButton.FillColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold);

                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }


        private void DisableButton()
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control is Guna2Button previousBtn)
                {
                    previousBtn.FillColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender, string secçao)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender, secçao);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 210)
            {
                panelMenu.Width = 70;
            }
            else
            {
                panelMenu.Width = 210;
                picLogo.Visible = true;
                lblTitle.Visible = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "HOME";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new HomeForm(), sender, "Home");
        }

        private void btnEncomendas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestão de Encomendas";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new OrderManagementForm(), sender, "Encomendas");
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestão de Produtos";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new ProductManagementForm(), sender, "Produtos");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestão de Stock";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new StockList(), sender, "Stock");
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestão de Fornecedores";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new SupplierList(), sender, "Fornecedores");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            Session.ClearSession();
            this.Close();
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.ClearSession();
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }
    }
}
