namespace projetoPadariaApp.Forms
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            labelTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            linkEsqueceu = new LinkLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            lbl2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnRegister = new Guna.UI2.WinForms.Guna2Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblLogo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblPass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(46, 46, 46);
            lblTitle.Location = new Point(450, 30);
            lblTitle.Margin = new Padding(450, 30, 3, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(161, 83);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Login";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = false;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(646, 40);
            labelTitle.Margin = new Padding(300, 0, 0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(213, 83);
            labelTitle.TabIndex = 26;
            labelTitle.Text = "Login";
            labelTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // linkEsqueceu
            // 
            linkEsqueceu.ActiveLinkColor = Color.White;
            linkEsqueceu.AutoSize = true;
            linkEsqueceu.BackColor = Color.Transparent;
            linkEsqueceu.DisabledLinkColor = Color.PowderBlue;
            linkEsqueceu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkEsqueceu.ForeColor = Color.SteelBlue;
            linkEsqueceu.LinkColor = Color.White;
            linkEsqueceu.Location = new Point(513, 451);
            linkEsqueceu.Margin = new Padding(0);
            linkEsqueceu.Name = "linkEsqueceu";
            linkEsqueceu.Size = new Size(245, 23);
            linkEsqueceu.TabIndex = 21;
            linkEsqueceu.TabStop = true;
            linkEsqueceu.Text = "Esqueceu-se da palavra passe?";
            linkEsqueceu.VisitedLinkColor = Color.SkyBlue;
            linkEsqueceu.LinkClicked += linkEsqueceu_LinkClicked;
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.BorderColor = Color.White;
            txtPassword.BorderRadius = 10;
            txtPassword.BorderThickness = 2;
            txtPassword.CustomizableEdges = customizableEdges1;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(35, 37, 54);
            txtPassword.FocusedState.BorderColor = Color.DarkCyan;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.ControlDark;
            txtPassword.HoverState.BorderColor = Color.Teal;
            txtPassword.Location = new Point(504, 389);
            txtPassword.Margin = new Padding(0);
            txtPassword.MinimumSize = new Size(500, 50);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderForeColor = Color.Gray;
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPassword.Size = new Size(500, 50);
            txtPassword.TabIndex = 23;
            txtPassword.TextOffset = new Point(10, 0);
            // 
            // txtUsername
            // 
            txtUsername.AutoSize = true;
            txtUsername.BorderColor = Color.White;
            txtUsername.BorderRadius = 10;
            txtUsername.BorderThickness = 2;
            txtUsername.CustomizableEdges = customizableEdges3;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FillColor = Color.FromArgb(35, 37, 54);
            txtUsername.FocusedState.BorderColor = Color.DarkCyan;
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = SystemColors.ControlDark;
            txtUsername.HoverState.BorderColor = Color.Teal;
            txtUsername.Location = new Point(504, 235);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.MinimumSize = new Size(500, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderForeColor = Color.Gray;
            txtUsername.PlaceholderText = "";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtUsername.Size = new Size(500, 50);
            txtUsername.TabIndex = 22;
            txtUsername.TextOffset = new Point(10, 0);
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 10;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.DarkCyan;
            btnLogin.FocusedColor = Color.DarkSlateGray;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.FillColor = Color.Black;
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.Location = new Point(629, 532);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(8, 0, 0, 0);
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(246, 56);
            btnLogin.TabIndex = 24;
            btnLogin.Text = "Entrar";
            btnLogin.Click += btnLogin_Click;
            // 
            // lbl2
            // 
            lbl2.AutoSize = false;
            lbl2.BackColor = Color.Transparent;
            lbl2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.ForeColor = Color.White;
            lbl2.Location = new Point(95, 470);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(251, 70);
            lbl2.TabIndex = 25;
            lbl2.Text = "Ainda não tem conta?";
            lbl2.TextAlignment = ContentAlignment.MiddleCenter;
            lbl2.UseGdiPlusTextRendering = true;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Black;
            guna2Panel1.Controls.Add(btnRegister);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.Controls.Add(lblLogo);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(lbl2);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Left;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(434, 699);
            guna2Panel1.TabIndex = 28;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Black;
            btnRegister.BorderRadius = 20;
            btnRegister.CustomizableEdges = customizableEdges7;
            btnRegister.DisabledState.BorderColor = Color.DarkGray;
            btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegister.FillColor = Color.White;
            btnRegister.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(141, 532);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegister.Size = new Size(163, 56);
            btnRegister.TabIndex = 26;
            btnRegister.Text = "Registe-se!";
            btnRegister.Click += btnRegister_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(149, 248);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(175, 33);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Painel de Gestão";
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(149, 199);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(245, 43);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "Padaria Pão-Bom";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 187);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblUsername.ForeColor = Color.Gainsboro;
            lblUsername.Location = new Point(547, 190);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(180, 30);
            lblUsername.TabIndex = 29;
            lblUsername.Text = "Nome de Utilizador";
            // 
            // lblPass
            // 
            lblPass.BackColor = Color.Transparent;
            lblPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPass.ForeColor = Color.Gainsboro;
            lblPass.Location = new Point(547, 346);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(124, 30);
            lblPass.TabIndex = 30;
            lblPass.Text = "Palavra passe";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(504, 186);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 31;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(504, 346);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 32;
            pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.CustomizableEdges = customizableEdges11;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.FromArgb(50, 52, 76);
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageSize = new Size(30, 30);
            btnClose.Location = new Point(999, 0);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnClose.Size = new Size(47, 40);
            btnClose.TabIndex = 33;
            btnClose.Click += btnClose_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.FromArgb(50, 52, 76);
            ClientSize = new Size(1049, 699);
            Controls.Add(btnClose);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(lblPass);
            Controls.Add(lblUsername);
            Controls.Add(guna2Panel1);
            Controls.Add(labelTitle);
            Controls.Add(linkEsqueceu);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(600, 400);
            Name = "loginForm";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private HelpProvider helpProvider1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelTitle;
        private LinkLabel linkEsqueceu;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogo;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPass;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}