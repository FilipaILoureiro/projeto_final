namespace projetoPadariaApp.Forms_Functions
{
    partial class HomeForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            lblData = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblHora = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            lblSaudacao = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel1 = new Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            picLogo = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.Teal;
            guna2Panel2.Controls.Add(lblData);
            guna2Panel2.Controls.Add(lblHora);
            guna2Panel2.CustomizableEdges = customizableEdges1;
            guna2Panel2.Location = new Point(55, 35);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel2.Size = new Size(478, 189);
            guna2Panel2.TabIndex = 1;
            // 
            // lblData
            // 
            lblData.BackColor = Color.Transparent;
            lblData.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lblData.ForeColor = Color.FromArgb(224, 224, 224);
            lblData.Location = new Point(20, 111);
            lblData.Name = "lblData";
            lblData.Size = new Size(116, 61);
            lblData.TabIndex = 6;
            lblData.Text = "DATA";
            // 
            // lblHora
            // 
            lblHora.BackColor = Color.Transparent;
            lblHora.Font = new Font("Segoe UI", 42.2F, FontStyle.Bold);
            lblHora.ForeColor = Color.White;
            lblHora.Location = new Point(20, 12);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(205, 95);
            lblHora.TabIndex = 5;
            lblHora.Text = "HORA";
            // 
            // guna2Panel3
            // 
            guna2Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel3.BackColor = Color.LightSeaGreen;
            guna2Panel3.Controls.Add(lblSaudacao);
            guna2Panel3.CustomizableEdges = customizableEdges3;
            guna2Panel3.Location = new Point(543, 35);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel3.Size = new Size(566, 189);
            guna2Panel3.TabIndex = 2;
            // 
            // lblSaudacao
            // 
            lblSaudacao.Anchor = AnchorStyles.None;
            lblSaudacao.AutoSize = false;
            lblSaudacao.BackColor = Color.Transparent;
            lblSaudacao.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblSaudacao.ForeColor = Color.White;
            lblSaudacao.Location = new Point(-4, 26);
            lblSaudacao.Name = "lblSaudacao";
            lblSaudacao.Size = new Size(580, 133);
            lblSaudacao.TabIndex = 7;
            lblSaudacao.Text = "Bom dia, Funcionário!";
            lblSaudacao.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(50, 52, 76);
            panel1.Location = new Point(55, 249);
            panel1.Name = "panel1";
            panel1.Size = new Size(1052, 24);
            panel1.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Black", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(57, 294);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1052, 45);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "PAINEL DE GESTÃO";
            lblTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.BackColor = Color.FromArgb(50, 52, 76);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.Controls.Add(guna2HtmlLabel2);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(55, 658);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1052, 82);
            guna2Panel1.TabIndex = 5;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(20, 33);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(36, 25);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "v.1.0";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(412, 33);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(226, 25);
            guna2HtmlLabel2.TabIndex = 0;
            guna2HtmlLabel2.Text = "Todos os Direitos Reservados";
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(352, 345);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(457, 305);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1169, 752);
            Controls.Add(picLogo);
            Controls.Add(guna2Panel1);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Name = "HomeForm";
            Text = "HomeForm";
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            guna2Panel3.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblData;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHora;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSaudacao;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}