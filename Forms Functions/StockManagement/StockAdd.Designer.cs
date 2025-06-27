namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    partial class StockAdd
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockAdd));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRegister = new Guna.UI2.WinForms.Guna2CircleButton();
            lblNome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblQuantidade = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblIVA = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPreco = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtQuantidade = new Guna.UI2.WinForms.Guna2TextBox();
            txtPreco = new Guna.UI2.WinForms.Guna2TextBox();
            txtNome = new Guna.UI2.WinForms.Guna2TextBox();
            cbFornecedor = new Guna.UI2.WinForms.Guna2ComboBox();
            cbIva = new Guna.UI2.WinForms.Guna2ComboBox();
            panelTitle = new Guna.UI2.WinForms.Guna2Panel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblFornecedor = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegister.DisabledState.BorderColor = Color.DarkGray;
            btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegister.FillColor = Color.FromArgb(215, 54, 242);
            btnRegister.FocusedColor = Color.FromArgb(109, 27, 123);
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.ForeColor = Color.White;
            btnRegister.HoverState.BorderColor = Color.FromArgb(109, 27, 123);
            btnRegister.Image = (Image)resources.GetObject("btnRegister.Image");
            btnRegister.ImageSize = new Size(50, 50);
            btnRegister.Location = new Point(685, 413);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnRegister.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnRegister.Size = new Size(84, 74);
            btnRegister.TabIndex = 28;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblNome
            // 
            lblNome.BackColor = Color.Transparent;
            lblNome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(64, 64, 64);
            lblNome.Location = new Point(153, 143);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(60, 30);
            lblNome.TabIndex = 29;
            lblNome.Text = "Nome";
            // 
            // lblQuantidade
            // 
            lblQuantidade.BackColor = Color.Transparent;
            lblQuantidade.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuantidade.ForeColor = Color.FromArgb(64, 64, 64);
            lblQuantidade.Location = new Point(100, 340);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(113, 30);
            lblQuantidade.TabIndex = 31;
            lblQuantidade.Text = "Quantidade";
            // 
            // lblIVA
            // 
            lblIVA.BackColor = Color.Transparent;
            lblIVA.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblIVA.ForeColor = Color.FromArgb(64, 64, 64);
            lblIVA.Location = new Point(177, 404);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(36, 30);
            lblIVA.TabIndex = 33;
            lblIVA.Text = "IVA";
            // 
            // lblPreco
            // 
            lblPreco.BackColor = Color.Transparent;
            lblPreco.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPreco.ForeColor = Color.FromArgb(64, 64, 64);
            lblPreco.Location = new Point(157, 273);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(56, 30);
            lblPreco.TabIndex = 32;
            lblPreco.Text = "Preço";
            // 
            // txtQuantidade
            // 
            txtQuantidade.BorderColor = Color.FromArgb(109, 27, 123);
            txtQuantidade.BorderRadius = 10;
            txtQuantidade.BorderThickness = 2;
            txtQuantidade.CustomizableEdges = customizableEdges2;
            txtQuantidade.DefaultText = "";
            txtQuantidade.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtQuantidade.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtQuantidade.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtQuantidade.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtQuantidade.FocusedState.BorderColor = Color.FromArgb(215, 54, 242);
            txtQuantidade.Font = new Font("Segoe UI", 9F);
            txtQuantidade.HoverState.BorderColor = Color.FromArgb(215, 54, 242);
            txtQuantidade.Location = new Point(240, 337);
            txtQuantidade.Margin = new Padding(3, 4, 3, 4);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PlaceholderText = "";
            txtQuantidade.SelectedText = "";
            txtQuantidade.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtQuantidade.Size = new Size(371, 41);
            txtQuantidade.TabIndex = 34;
            // 
            // txtPreco
            // 
            txtPreco.BorderColor = Color.FromArgb(109, 27, 123);
            txtPreco.BorderRadius = 10;
            txtPreco.BorderThickness = 2;
            txtPreco.CustomizableEdges = customizableEdges4;
            txtPreco.DefaultText = "";
            txtPreco.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPreco.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPreco.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPreco.FocusedState.BorderColor = Color.FromArgb(215, 54, 242);
            txtPreco.Font = new Font("Segoe UI", 9F);
            txtPreco.HoverState.BorderColor = Color.FromArgb(215, 54, 242);
            txtPreco.Location = new Point(240, 270);
            txtPreco.Margin = new Padding(3, 4, 3, 4);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "";
            txtPreco.SelectedText = "";
            txtPreco.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtPreco.Size = new Size(371, 41);
            txtPreco.TabIndex = 35;
            // 
            // txtNome
            // 
            txtNome.BorderColor = Color.FromArgb(109, 27, 123);
            txtNome.BorderRadius = 10;
            txtNome.BorderThickness = 2;
            txtNome.CustomizableEdges = customizableEdges6;
            txtNome.DefaultText = "";
            txtNome.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNome.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNome.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNome.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNome.FocusedState.BorderColor = Color.FromArgb(215, 54, 242);
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.HoverState.BorderColor = Color.FromArgb(215, 54, 242);
            txtNome.Location = new Point(240, 139);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "";
            txtNome.SelectedText = "";
            txtNome.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtNome.Size = new Size(371, 41);
            txtNome.TabIndex = 36;
            // 
            // cbFornecedor
            // 
            cbFornecedor.BackColor = Color.Transparent;
            cbFornecedor.BorderColor = Color.FromArgb(109, 27, 123);
            cbFornecedor.BorderRadius = 10;
            cbFornecedor.BorderThickness = 2;
            cbFornecedor.CustomizableEdges = customizableEdges8;
            cbFornecedor.DrawMode = DrawMode.OwnerDrawFixed;
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFornecedor.FocusedColor = Color.FromArgb(94, 148, 255);
            cbFornecedor.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbFornecedor.Font = new Font("Segoe UI", 10F);
            cbFornecedor.ForeColor = Color.FromArgb(68, 88, 112);
            cbFornecedor.ItemHeight = 30;
            cbFornecedor.Location = new Point(240, 208);
            cbFornecedor.Name = "cbFornecedor";
            cbFornecedor.ShadowDecoration.CustomizableEdges = customizableEdges9;
            cbFornecedor.Size = new Size(371, 36);
            cbFornecedor.TabIndex = 37;
            // 
            // cbIva
            // 
            cbIva.BackColor = Color.Transparent;
            cbIva.BorderColor = Color.FromArgb(109, 27, 123);
            cbIva.BorderRadius = 10;
            cbIva.BorderThickness = 2;
            cbIva.CustomizableEdges = customizableEdges10;
            cbIva.DrawMode = DrawMode.OwnerDrawFixed;
            cbIva.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIva.FocusedColor = Color.FromArgb(94, 148, 255);
            cbIva.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbIva.Font = new Font("Segoe UI", 10F);
            cbIva.ForeColor = Color.FromArgb(68, 88, 112);
            cbIva.ItemHeight = 30;
            cbIva.Location = new Point(240, 402);
            cbIva.Name = "cbIva";
            cbIva.ShadowDecoration.CustomizableEdges = customizableEdges11;
            cbIva.Size = new Size(371, 36);
            cbIva.TabIndex = 38;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(109, 27, 123);
            panelTitle.Controls.Add(btnClose);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.CustomizableEdges = customizableEdges14;
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.ShadowDecoration.CustomizableEdges = customizableEdges15;
            panelTitle.Size = new Size(801, 91);
            panelTitle.TabIndex = 39;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.CustomizableEdges = customizableEdges12;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageSize = new Size(40, 40);
            btnClose.Location = new Point(762, 3);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges13;
            btnClose.Size = new Size(36, 34);
            btnClose.TabIndex = 28;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(34, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(733, 52);
            lblTitle.TabIndex = 27;
            lblTitle.Text = "Criar Nova Matéria Prima";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblFornecedor
            // 
            lblFornecedor.BackColor = Color.Transparent;
            lblFornecedor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFornecedor.ForeColor = Color.FromArgb(64, 64, 64);
            lblFornecedor.Location = new Point(104, 208);
            lblFornecedor.Name = "lblFornecedor";
            lblFornecedor.Size = new Size(109, 30);
            lblFornecedor.TabIndex = 40;
            lblFornecedor.Text = "Fornecedor";
            // 
            // StockAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(801, 506);
            Controls.Add(lblFornecedor);
            Controls.Add(panelTitle);
            Controls.Add(cbIva);
            Controls.Add(cbFornecedor);
            Controls.Add(txtNome);
            Controls.Add(txtPreco);
            Controls.Add(txtQuantidade);
            Controls.Add(lblIVA);
            Controls.Add(lblPreco);
            Controls.Add(lblQuantidade);
            Controls.Add(lblNome);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "StockAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplierAdd";
            panelTitle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2CircleButton btnRegister;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNome;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuantidade;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIVA;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPreco;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantidade;
        private Guna.UI2.WinForms.Guna2TextBox txtPreco;
        private Guna.UI2.WinForms.Guna2TextBox txtNome;
        private Guna.UI2.WinForms.Guna2ComboBox cbFornecedor;
        private Guna.UI2.WinForms.Guna2ComboBox cbIva;
        private Guna.UI2.WinForms.Guna2Panel panelTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFornecedor;
    }
}