using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using projetoPadariaApp.Forms_Functions;
using projetoPadariaApp.Forms_Functions.EmployeeManagement;
using projetoPadariaApp.Forms_Functions.OrdersManagement;
using projetoPadariaApp.Forms_Functions.ProductManagement;
using projetoPadariaApp.Forms_Functions.StockManagement;
using projetoPadariaApp.Forms_Functions.SupplierManagement;
using projetoPadariaApp.Forms_Login_e_Registo;
using projetoPadariaApp.Properties.Style;
using projetoPadariaApp.Services;

// VAI TER ACESSO TOTAL À APLICAÇÃO
namespace projetoPadariaApp.Forms
{
    public partial class AdminForm : Form
    {
        // CAMPOS
        private Guna2Button currentButton;
        private Form activeForm;

        // CONSTRUTOR
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            this.Text = "Painel de Gestão";
            btnLogs.Text = "Registo\nde Atividade";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (Session.FuncionarioNome != null)
            {
                lblSaudacao.Text = $"Olá, {Session.FuncionarioNome}!";
                lblSaudacao.Visible = true;
            }
            else
            {
                lblSaudacao.Text = "Olá estranho!";
                lblSaudacao.Visible = true;
            }
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
            if (activeForm != null)
                activeForm.Close();

            DisableButton();
            currentButton = null;

            panelTitle.BackColor = Color.FromArgb(51, 51, 76);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            lblTitle.Text = "HOME";
            panelDesktop.Visible = true;
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

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Gestão de Funcionários";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new EmployeeManagementForm(), sender, "Funcionarios");
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Registo de Atividade";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new LogsList(), sender, "Logs");
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Pasta de Documentos";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            OpenChildForm(new DocumentListForm(), sender, "Documentos");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            Session.ClearSession();
            this.Close();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.ClearSession();
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        
    }
}
