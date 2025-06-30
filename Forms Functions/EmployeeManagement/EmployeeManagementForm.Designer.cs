using System.Windows.Forms;
using Guna.UI2.WinForms;
using PadariaApp;

namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    partial class EmployeeManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeManagementForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvEmployees = new Guna2DataGridView();
            databaseManageBindingSource = new BindingSource(components);
            guna2Panel1 = new Guna2Panel();
            btnAddFunc = new Guna2Button();
            guna2Panel3 = new Guna2Panel();
            cbAtivo = new Guna2ComboBox();
            lblFiltro = new Guna2HtmlLabel();
            txtPesquisa = new Guna2TextBox();
            btnLimpar = new Guna2Button();
            guna2Panel4 = new Guna2Panel();
            lblFiltros = new Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            guna2Panel2 = new Guna2Panel();
            btnResetPass = new Guna2Button();
            btnPromover = new Guna2Button();
            btnApagar = new Guna2Button();
            btnEditar = new Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel3.SuspendLayout();
            guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeight = 4;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.DataSource = databaseManageBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.Location = new Point(27, 238);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(882, 502);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmployees.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvEmployees.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.ThemeStyle.HeaderStyle.Height = 4;
            dgvEmployees.ThemeStyle.ReadOnly = false;
            dgvEmployees.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvEmployees.ThemeStyle.RowsStyle.Height = 29;
            dgvEmployees.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // databaseManageBindingSource
            // 
            databaseManageBindingSource.DataSource = typeof(DatabaseManage);
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(btnAddFunc);
            guna2Panel1.Controls.Add(guna2Panel3);
            guna2Panel1.CustomizableEdges = customizableEdges13;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2Panel1.Size = new Size(1169, 223);
            guna2Panel1.TabIndex = 1;
            // 
            // btnAddFunc
            // 
            btnAddFunc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFunc.BorderRadius = 10;
            btnAddFunc.CustomizableEdges = customizableEdges1;
            btnAddFunc.DisabledState.BorderColor = Color.DarkGray;
            btnAddFunc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddFunc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddFunc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddFunc.FillColor = Color.FromArgb(255, 108, 20);
            btnAddFunc.FocusedColor = Color.FromArgb(163, 50, 35);
            btnAddFunc.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAddFunc.ForeColor = Color.White;
            btnAddFunc.HoverState.FillColor = Color.FromArgb(163, 50, 35);
            btnAddFunc.Image = (Image)resources.GetObject("btnAddFunc.Image");
            btnAddFunc.ImageAlign = HorizontalAlignment.Left;
            btnAddFunc.ImageSize = new Size(40, 40);
            btnAddFunc.Location = new Point(929, 83);
            btnAddFunc.Name = "btnAddFunc";
            btnAddFunc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddFunc.Size = new Size(219, 80);
            btnAddFunc.TabIndex = 3;
            btnAddFunc.Text = "Novo Funcionário";
            btnAddFunc.TextAlign = HorizontalAlignment.Left;
            btnAddFunc.Click += btnAddFunc_Click;
            // 
            // guna2Panel3
            // 
            guna2Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel3.BackColor = Color.White;
            guna2Panel3.BorderColor = Color.FromArgb(163, 50, 35);
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.BorderThickness = 2;
            guna2Panel3.Controls.Add(cbAtivo);
            guna2Panel3.Controls.Add(lblFiltro);
            guna2Panel3.Controls.Add(txtPesquisa);
            guna2Panel3.Controls.Add(btnLimpar);
            guna2Panel3.Controls.Add(guna2Panel4);
            guna2Panel3.CustomizableEdges = customizableEdges11;
            guna2Panel3.Location = new Point(27, 26);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel3.Size = new Size(882, 174);
            guna2Panel3.TabIndex = 0;
            // 
            // cbAtivo
            // 
            cbAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbAtivo.BackColor = Color.Transparent;
            cbAtivo.BorderColor = Color.FromArgb(163, 50, 35);
            cbAtivo.BorderRadius = 10;
            cbAtivo.BorderThickness = 2;
            cbAtivo.CustomizableEdges = customizableEdges3;
            cbAtivo.DrawMode = DrawMode.OwnerDrawFixed;
            cbAtivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAtivo.FocusedColor = Color.FromArgb(234, 72, 51);
            cbAtivo.FocusedState.BorderColor = Color.FromArgb(234, 72, 51);
            cbAtivo.Font = new Font("Segoe UI", 10F);
            cbAtivo.ForeColor = Color.FromArgb(68, 88, 112);
            cbAtivo.ItemHeight = 30;
            cbAtivo.Location = new Point(685, 55);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbAtivo.Size = new Size(168, 36);
            cbAtivo.TabIndex = 27;
            // 
            // lblFiltro
            // 
            lblFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFiltro.BackColor = Color.Transparent;
            lblFiltro.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltro.ForeColor = Color.FromArgb(64, 64, 64);
            lblFiltro.Location = new Point(195, 22);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(451, 30);
            lblFiltro.TabIndex = 26;
            lblFiltro.Text = "Pesquisar ID, Nome ou Contactos do Funcionário";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPesquisa.BorderColor = Color.FromArgb(163, 50, 35);
            txtPesquisa.BorderRadius = 10;
            txtPesquisa.BorderThickness = 2;
            txtPesquisa.CustomizableEdges = customizableEdges5;
            txtPesquisa.DefaultText = "";
            txtPesquisa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPesquisa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPesquisa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(234, 72, 51);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(234, 72, 51);
            txtPesquisa.Location = new Point(195, 55);
            txtPesquisa.Margin = new Padding(3, 4, 3, 4);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPesquisa.Size = new Size(463, 36);
            txtPesquisa.TabIndex = 25;
            // 
            // btnLimpar
            // 
            btnLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpar.BorderRadius = 10;
            btnLimpar.CustomizableEdges = customizableEdges7;
            btnLimpar.DisabledState.BorderColor = Color.DarkGray;
            btnLimpar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLimpar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLimpar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLimpar.FillColor = Color.FromArgb(163, 50, 35);
            btnLimpar.FocusedColor = Color.FromArgb(234, 72, 51);
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.HoverState.FillColor = Color.FromArgb(234, 72, 51);
            btnLimpar.Image = (Image)resources.GetObject("btnLimpar.Image");
            btnLimpar.Location = new Point(195, 109);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLimpar.Size = new Size(147, 47);
            btnLimpar.TabIndex = 24;
            btnLimpar.Text = "Limpar";
            btnLimpar.Click += btnLimpar_Click;
            // 
            // guna2Panel4
            // 
            guna2Panel4.BackColor = Color.FromArgb(163, 50, 35);
            guna2Panel4.Controls.Add(lblFiltros);
            guna2Panel4.Controls.Add(pictureBox1);
            guna2Panel4.CustomizableEdges = customizableEdges9;
            guna2Panel4.Dock = DockStyle.Left;
            guna2Panel4.Location = new Point(0, 0);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel4.Size = new Size(171, 174);
            guna2Panel4.TabIndex = 1;
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = false;
            lblFiltros.BackColor = Color.Transparent;
            lblFiltros.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltros.ForeColor = Color.White;
            lblFiltros.Location = new Point(43, 59);
            lblFiltros.Name = "lblFiltros";
            lblFiltros.Size = new Size(112, 52);
            lblFiltros.TabIndex = 14;
            lblFiltros.Text = "Filtros";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // guna2Panel2
            // 
            guna2Panel2.Controls.Add(btnResetPass);
            guna2Panel2.Controls.Add(btnPromover);
            guna2Panel2.Controls.Add(btnApagar);
            guna2Panel2.Controls.Add(btnEditar);
            guna2Panel2.CustomizableEdges = customizableEdges23;
            guna2Panel2.Dock = DockStyle.Right;
            guna2Panel2.Location = new Point(929, 223);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges24;
            guna2Panel2.Size = new Size(240, 529);
            guna2Panel2.TabIndex = 2;
            // 
            // btnResetPass
            // 
            btnResetPass.BorderRadius = 10;
            btnResetPass.CustomizableEdges = customizableEdges15;
            btnResetPass.DisabledState.BorderColor = Color.DarkGray;
            btnResetPass.DisabledState.CustomBorderColor = Color.DarkGray;
            btnResetPass.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnResetPass.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnResetPass.FillColor = Color.FromArgb(234, 72, 51);
            btnResetPass.FocusedColor = Color.FromArgb(163, 50, 35);
            btnResetPass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnResetPass.ForeColor = Color.White;
            btnResetPass.HoverState.FillColor = Color.FromArgb(163, 50, 35);
            btnResetPass.Image = (Image)resources.GetObject("btnResetPass.Image");
            btnResetPass.ImageAlign = HorizontalAlignment.Left;
            btnResetPass.ImageOffset = new Point(-5, 0);
            btnResetPass.ImageSize = new Size(40, 40);
            btnResetPass.Location = new Point(43, 364);
            btnResetPass.Name = "btnResetPass";
            btnResetPass.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnResetPass.Size = new Size(156, 56);
            btnResetPass.TabIndex = 11;
            btnResetPass.Text = "Redefinir Palavra Passe";
            btnResetPass.TextAlign = HorizontalAlignment.Left;
            btnResetPass.TextOffset = new Point(-10, 0);
            btnResetPass.Click += btnResetPass_Click;
            // 
            // btnPromover
            // 
            btnPromover.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPromover.BorderRadius = 10;
            btnPromover.CustomizableEdges = customizableEdges17;
            btnPromover.DisabledState.BorderColor = Color.DarkGray;
            btnPromover.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPromover.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPromover.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPromover.FillColor = Color.FromArgb(234, 72, 51);
            btnPromover.FocusedColor = Color.FromArgb(163, 50, 35);
            btnPromover.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPromover.ForeColor = Color.White;
            btnPromover.HoverState.FillColor = Color.FromArgb(163, 50, 35);
            btnPromover.Image = (Image)resources.GetObject("btnPromover.Image");
            btnPromover.ImageSize = new Size(30, 30);
            btnPromover.Location = new Point(43, 295);
            btnPromover.Name = "btnPromover";
            btnPromover.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnPromover.Size = new Size(156, 63);
            btnPromover.TabIndex = 10;
            btnPromover.Text = "Promover";
            btnPromover.Click += btnPromover_Click;
            // 
            // btnApagar
            // 
            btnApagar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnApagar.BorderRadius = 10;
            btnApagar.CustomizableEdges = customizableEdges19;
            btnApagar.DisabledState.BorderColor = Color.DarkGray;
            btnApagar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnApagar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnApagar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnApagar.FillColor = Color.FromArgb(163, 50, 35);
            btnApagar.FocusedColor = Color.FromArgb(234, 72, 51);
            btnApagar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApagar.ForeColor = Color.White;
            btnApagar.HoverState.FillColor = Color.FromArgb(234, 72, 51);
            btnApagar.Image = (Image)resources.GetObject("btnApagar.Image");
            btnApagar.ImageSize = new Size(30, 30);
            btnApagar.Location = new Point(43, 204);
            btnApagar.Name = "btnApagar";
            btnApagar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnApagar.Size = new Size(156, 63);
            btnApagar.TabIndex = 9;
            btnApagar.Text = "Desativar";
            btnApagar.TextOffset = new Point(3, 0);
            btnApagar.Click += btnApagar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEditar.BorderRadius = 10;
            btnEditar.CustomizableEdges = customizableEdges21;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.FromArgb(163, 50, 35);
            btnEditar.FocusedColor = Color.FromArgb(234, 72, 51);
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.FillColor = Color.FromArgb(234, 72, 51);
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageSize = new Size(30, 30);
            btnEditar.Location = new Point(43, 135);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnEditar.Size = new Size(156, 63);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // EmployeeManagementForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1169, 752);
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            Controls.Add(dgvEmployees);
            Name = "EmployeeManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel2.ResumeLayout(false);
            ResumeLayout(false);

        }


        private BindingSource databaseManageBindingSource;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEmployees;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFiltros;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFiltro;
        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;
        private Guna.UI2.WinForms.Guna2Button btnLimpar;
        private Guna.UI2.WinForms.Guna2Button btnAddFunc;
        private Guna.UI2.WinForms.Guna2Button btnApagar;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2ComboBox cbAtivo;
        private Guna.UI2.WinForms.Guna2Button btnPromover;
        private Guna2Button btnResetPass;
    }
}