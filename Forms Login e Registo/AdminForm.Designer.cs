namespace projetoPadariaApp.Forms
{
    partial class AdminForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            btnManageEmployees = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            btnGallery = new Guna.UI2.WinForms.Guna2Button();
            btnEncomendas = new Guna.UI2.WinForms.Guna2Button();
            btnProdutos = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(171, 200);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(473, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Colocar aqui os botões/ícones para as funções que ele tem acesso";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(133, 273);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(617, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Lembrar de na gestão dos funcionarios, add funçao promover admin (já existe no auth)";
            // 
            // btnManageEmployees
            // 
            btnManageEmployees.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnManageEmployees.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnManageEmployees.Depth = 0;
            btnManageEmployees.HighEmphasis = true;
            btnManageEmployees.Icon = null;
            btnManageEmployees.Location = new Point(51, 63);
            btnManageEmployees.Margin = new Padding(5);
            btnManageEmployees.MouseState = MaterialSkin.MouseState.HOVER;
            btnManageEmployees.Name = "btnManageEmployees";
            btnManageEmployees.NoAccentTextColor = Color.Empty;
            btnManageEmployees.Size = new Size(171, 36);
            btnManageEmployees.TabIndex = 3;
            btnManageEmployees.Text = "Gerir funcionários";
            btnManageEmployees.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnManageEmployees.UseAccentColor = false;
            btnManageEmployees.UseVisualStyleBackColor = true;
            btnManageEmployees.Click += btnManageEmployees_Click;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(368, 63);
            materialButton1.Margin = new Padding(5);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(142, 36);
            materialButton1.TabIndex = 4;
            materialButton1.Text = "Gerir suppliers";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(97, 353);
            materialButton2.Margin = new Padding(5);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(113, 36);
            materialButton2.TabIndex = 5;
            materialButton2.Text = "Gerir Stock";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialButton3
            // 
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(34, 200);
            materialButton3.Margin = new Padding(5);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(89, 36);
            materialButton3.TabIndex = 6;
            materialButton3.Text = "Ver Logs";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // btnGallery
            // 
            btnGallery.CustomizableEdges = customizableEdges1;
            btnGallery.DisabledState.BorderColor = Color.DarkGray;
            btnGallery.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGallery.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGallery.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGallery.Font = new Font("Segoe UI", 9F);
            btnGallery.ForeColor = Color.White;
            btnGallery.Location = new Point(545, 119);
            btnGallery.Name = "btnGallery";
            btnGallery.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGallery.Size = new Size(225, 56);
            btnGallery.TabIndex = 7;
            btnGallery.Text = "Galeria";
            btnGallery.Click += btnGallery_Click;
            // 
            // btnEncomendas
            // 
            btnEncomendas.CustomizableEdges = customizableEdges3;
            btnEncomendas.DisabledState.BorderColor = Color.DarkGray;
            btnEncomendas.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEncomendas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEncomendas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEncomendas.Font = new Font("Segoe UI", 9F);
            btnEncomendas.ForeColor = Color.White;
            btnEncomendas.Location = new Point(512, 353);
            btnEncomendas.Name = "btnEncomendas";
            btnEncomendas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEncomendas.Size = new Size(225, 56);
            btnEncomendas.TabIndex = 8;
            btnEncomendas.Text = "Gerir Encomendas";
            btnEncomendas.Click += btnEncomendas_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.CustomizableEdges = customizableEdges5;
            btnProdutos.DisabledState.BorderColor = Color.DarkGray;
            btnProdutos.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProdutos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProdutos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProdutos.Font = new Font("Segoe UI", 9F);
            btnProdutos.ForeColor = Color.White;
            btnProdutos.Location = new Point(268, 295);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnProdutos.Size = new Size(225, 56);
            btnProdutos.TabIndex = 9;
            btnProdutos.Text = "Gerir Produtos";
            btnProdutos.Click += btnProdutos_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(btnProdutos);
            Controls.Add(btnEncomendas);
            Controls.Add(btnGallery);
            Controls.Add(materialButton3);
            Controls.Add(materialButton2);
            Controls.Add(materialButton1);
            Controls.Add(btnManageEmployees);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnManageEmployees;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private Guna.UI2.WinForms.Guna2Button btnGallery;
        private Guna.UI2.WinForms.Guna2Button btnEncomendas;
        private Guna.UI2.WinForms.Guna2Button btnProdutos;
    }
}