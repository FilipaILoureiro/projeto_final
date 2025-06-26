namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    partial class ProductGalleryForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductGalleryForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            titlePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            searchPanel = new Guna.UI2.WinForms.Guna2Panel();
            btnLimpar = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblSearch = new Guna.UI2.WinForms.Guna2HtmlLabel();
            bottomPanel = new Guna.UI2.WinForms.Guna2Panel();
            btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            gallery = new FlowLayoutPanel();
            titlePanel.SuspendLayout();
            searchPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titlePanel
            // 
            titlePanel.Controls.Add(lblTitle);
            titlePanel.Controls.Add(btnClose);
            titlePanel.CustomizableEdges = customizableEdges3;
            titlePanel.Dock = DockStyle.Top;
            titlePanel.FillColor = Color.FromArgb(0, 103, 131);
            titlePanel.Location = new Point(0, 0);
            titlePanel.Name = "titlePanel";
            titlePanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            titlePanel.Size = new Size(1291, 117);
            titlePanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(42, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1123, 83);
            lblTitle.TabIndex = 27;
            lblTitle.Text = "Catálogo de Produtos";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.CustomizableEdges = customizableEdges1;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageSize = new Size(40, 40);
            btnClose.Location = new Point(1252, 3);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClose.Size = new Size(36, 34);
            btnClose.TabIndex = 26;
            btnClose.Click += btnClose_Click;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(btnLimpar);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(lblSearch);
            searchPanel.CustomizableEdges = customizableEdges9;
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(0, 117);
            searchPanel.Name = "searchPanel";
            searchPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            searchPanel.Size = new Size(1291, 88);
            searchPanel.TabIndex = 3;
            // 
            // btnLimpar
            // 
            btnLimpar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpar.BorderRadius = 10;
            btnLimpar.CustomizableEdges = customizableEdges5;
            btnLimpar.DisabledState.BorderColor = Color.DarkGray;
            btnLimpar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLimpar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLimpar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLimpar.FillColor = Color.DarkGray;
            btnLimpar.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Image = (Image)resources.GetObject("btnLimpar.Image");
            btnLimpar.Location = new Point(1097, 13);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLimpar.Size = new Size(170, 60);
            btnLimpar.TabIndex = 7;
            btnLimpar.Text = "Limpar Seleção";
            btnLimpar.Click += btnLimpar_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(0, 103, 131);
            txtSearch.BorderRadius = 10;
            txtSearch.BorderThickness = 2;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(182, 24);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.Gray;
            txtSearch.PlaceholderText = "";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(368, 49);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.ForeColor = Color.FromArgb(64, 64, 64);
            lblSearch.Location = new Point(34, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(141, 43);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Pesquisar:";
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(btnConfirmar);
            bottomPanel.Controls.Add(lblTotal);
            bottomPanel.CustomizableEdges = customizableEdges13;
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 790);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            bottomPanel.Size = new Size(1291, 89);
            bottomPanel.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.BorderRadius = 10;
            btnConfirmar.CustomizableEdges = customizableEdges11;
            btnConfirmar.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmar.FillColor = Color.FromArgb(0, 148, 188);
            btnConfirmar.FocusedColor = Color.FromArgb(0, 103, 131);
            btnConfirmar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.HoverState.FillColor = Color.FromArgb(0, 103, 131);
            btnConfirmar.Image = (Image)resources.GetObject("btnConfirmar.Image");
            btnConfirmar.ImageSize = new Size(30, 30);
            btnConfirmar.Location = new Point(1097, 19);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnConfirmar.Size = new Size(170, 56);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotal.Location = new Point(34, 19);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(53, 30);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total: ";
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(gallery);
            mainPanel.CustomizableEdges = customizableEdges15;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 205);
            mainPanel.Name = "mainPanel";
            mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges16;
            mainPanel.Size = new Size(1291, 585);
            mainPanel.TabIndex = 5;
            // 
            // gallery
            // 
            gallery.AutoScroll = true;
            gallery.Dock = DockStyle.Fill;
            gallery.Location = new Point(0, 0);
            gallery.Name = "gallery";
            gallery.Size = new Size(1291, 585);
            gallery.TabIndex = 1;
            // 
            // ProductGalleryForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1291, 879);
            Controls.Add(mainPanel);
            Controls.Add(bottomPanel);
            Controls.Add(searchPanel);
            Controls.Add(titlePanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductGalleryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Escolher Produtos";
            titlePanel.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna.UI2.WinForms.Guna2Panel titlePanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel searchPanel;
        private Guna.UI2.WinForms.Guna2Panel bottomPanel;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private FlowLayoutPanel gallery;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSearch;
        private Guna.UI2.WinForms.Guna2Button btnLimpar;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotal;
    }
}