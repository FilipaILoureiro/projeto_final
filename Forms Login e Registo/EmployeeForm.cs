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
using Org.BouncyCastle.Asn1.X509.Qualified;
using projetoPadariaApp.Forms_Functions.OrdersManagement;
using projetoPadariaApp.Forms_Functions.ProductManagement;
using projetoPadariaApp.Forms_Functions.StockManagement;
using projetoPadariaApp.Forms_Functions.SupplierManagement;
using projetoPadariaApp.Properties.Style;

// VAI TER ACESSO APENAS A DETERMINADAS FUNÇÕES
namespace projetoPadariaApp.Forms
{
    public partial class EmployeeForm : Form
    {
        // CAMPOS
        private Guna2Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        // CONSTRUTOR
        public EmployeeForm()
        {
            InitializeComponent();
            random = new Random();
            this.Text = "Painel de Gestão";
        }

        // MÉTODOS
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Guna2Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
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

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
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
                lblTitle.Visible = false;
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
            panelTitle.BackColor = Color.FromArgb(51, 51, 76);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            lblTitle.Text = "HOME";
            panelDesktop.Visible = true;
        }

        private void btnEncomendas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "GESTÃO DE ENCOMENDAS";
            OpenChildForm(new OrderManagementForm(), sender);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "GESTÃO DE PRODUTOS";
            OpenChildForm(new ProductManagementForm(), sender);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "GESTÃO DE STOCK";
            OpenChildForm(new StockList(), sender);
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "GESTÃO DE FORNECEDORES";
            OpenChildForm(new SupplierList(), sender);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Close();
        }

        // data e hora
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            lblData.Text = DateTime.Now.ToLongDateString();
        }
    }
}
