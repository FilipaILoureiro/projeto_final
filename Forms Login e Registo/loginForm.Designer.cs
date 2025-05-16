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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRegistro = new Guna.UI2.WinForms.Guna2Button();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            linkEsqueceu = new LinkLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            masterPanel = new FlowLayoutPanel();
            lbl2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            labelTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            mainTablePanel = new TableLayoutPanel();
            loginPanel = new Panel();
            smallPanel = new TableLayoutPanel();
            mainTablePanel.SuspendLayout();
            loginPanel.SuspendLayout();
            smallPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegistro
            // 
            btnRegistro.Anchor = AnchorStyles.None;
            btnRegistro.BackColor = Color.Transparent;
            btnRegistro.BorderColor = Color.Transparent;
            btnRegistro.CustomBorderColor = Color.Transparent;
            btnRegistro.CustomizableEdges = customizableEdges1;
            btnRegistro.DisabledState.BorderColor = Color.DarkGray;
            btnRegistro.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegistro.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegistro.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegistro.FillColor = Color.Transparent;
            btnRegistro.FocusedColor = Color.Transparent;
            btnRegistro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.ForeColor = Color.FromArgb(216, 108, 112);
            btnRegistro.HoverState.FillColor = Color.Transparent;
            btnRegistro.Location = new Point(447, 3);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.PressedColor = Color.Transparent;
            btnRegistro.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRegistro.Size = new Size(216, 34);
            btnRegistro.TabIndex = 15;
            btnRegistro.Text = "Registe-se";
            btnRegistro.TextAlign = HorizontalAlignment.Left;
            btnRegistro.Click += btnRegistro_Click_1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.BorderRadius = 10;
            btnLogin.CustomizableEdges = customizableEdges3;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(216, 108, 112);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverState.FillColor = Color.FromArgb(191, 94, 97);
            btnLogin.Location = new Point(203, 302);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLogin.Size = new Size(501, 50);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Entrar";
            btnLogin.Click += btnLogin_Click_1;
            // 
            // linkEsqueceu
            // 
            linkEsqueceu.ActiveLinkColor = Color.FromArgb(166, 106, 111);
            linkEsqueceu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            linkEsqueceu.AutoSize = true;
            linkEsqueceu.DisabledLinkColor = Color.FromArgb(166, 106, 111);
            linkEsqueceu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkEsqueceu.ForeColor = Color.FromArgb(166, 106, 111);
            linkEsqueceu.LinkColor = Color.FromArgb(166, 106, 111);
            linkEsqueceu.Location = new Point(203, 247);
            linkEsqueceu.Margin = new Padding(0);
            linkEsqueceu.Name = "linkEsqueceu";
            linkEsqueceu.Size = new Size(244, 23);
            linkEsqueceu.TabIndex = 6;
            linkEsqueceu.TabStop = true;
            linkEsqueceu.Text = "Esqueceu-se da palavra passe?";
            linkEsqueceu.LinkClicked += linkRegisto_LinkClicked;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.AutoSize = true;
            txtPassword.BorderColor = Color.FromArgb(229, 229, 229);
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(216, 108, 112);
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(203, 183);
            txtPassword.Margin = new Padding(0);
            txtPassword.MinimumSize = new Size(500, 50);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Palavra passe";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(500, 50);
            txtPassword.TabIndex = 13;
            txtPassword.TextOffset = new Point(10, 0);
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.AutoSize = true;
            txtUsername.BorderColor = Color.FromArgb(229, 229, 229);
            txtUsername.BorderRadius = 10;
            txtUsername.CustomizableEdges = customizableEdges7;
            txtUsername.DefaultText = "";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(216, 108, 112);
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Location = new Point(203, 102);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.MinimumSize = new Size(500, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nome de utilizador";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtUsername.Size = new Size(500, 50);
            txtUsername.TabIndex = 12;
            txtUsername.TextOffset = new Point(10, 0);
            // 
            // masterPanel
            // 
            masterPanel.AutoSize = true;
            masterPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            masterPanel.FlowDirection = FlowDirection.TopDown;
            masterPanel.Location = new Point(25, 151);
            masterPanel.Name = "masterPanel";
            masterPanel.Size = new Size(0, 0);
            masterPanel.TabIndex = 17;
            masterPanel.WrapContents = false;
            // 
            // lbl2
            // 
            lbl2.Anchor = AnchorStyles.None;
            lbl2.AutoSize = false;
            lbl2.BackColor = Color.Transparent;
            lbl2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(225, 8);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(216, 25);
            lbl2.TabIndex = 16;
            lbl2.Text = "Não tem conta?";
            lbl2.TextAlignment = ContentAlignment.TopRight;
            lbl2.UseGdiPlusTextRendering = true;
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
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(0, 0);
            labelTitle.Margin = new Padding(300, 0, 0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(889, 83);
            labelTitle.TabIndex = 18;
            labelTitle.Text = "Login";
            labelTitle.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // mainTablePanel
            // 
            mainTablePanel.AutoSize = true;
            mainTablePanel.ColumnCount = 1;
            mainTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTablePanel.Controls.Add(loginPanel, 0, 1);
            mainTablePanel.Dock = DockStyle.Fill;
            mainTablePanel.Location = new Point(0, 0);
            mainTablePanel.Name = "mainTablePanel";
            mainTablePanel.RowCount = 3;
            mainTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mainTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mainTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mainTablePanel.Size = new Size(895, 553);
            mainTablePanel.TabIndex = 19;
            // 
            // loginPanel
            // 
            loginPanel.AutoSize = true;
            loginPanel.Controls.Add(smallPanel);
            loginPanel.Controls.Add(labelTitle);
            loginPanel.Controls.Add(linkEsqueceu);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(txtUsername);
            loginPanel.Controls.Add(btnLogin);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(3, 58);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(889, 436);
            loginPanel.TabIndex = 0;
            // 
            // smallPanel
            // 
            smallPanel.ColumnCount = 4;
            smallPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            smallPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            smallPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            smallPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            smallPanel.Controls.Add(lbl2, 1, 0);
            smallPanel.Controls.Add(btnRegistro, 2, 0);
            smallPanel.Dock = DockStyle.Bottom;
            smallPanel.Location = new Point(0, 395);
            smallPanel.Name = "smallPanel";
            smallPanel.RowCount = 1;
            smallPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            smallPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            smallPanel.Size = new Size(889, 41);
            smallPanel.TabIndex = 19;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.White;
            ClientSize = new Size(895, 553);
            Controls.Add(masterPanel);
            Controls.Add(mainTablePanel);
            MinimumSize = new Size(800, 600);
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            mainTablePanel.ResumeLayout(false);
            mainTablePanel.PerformLayout();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            smallPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegister;
        private HelpProvider helpProvider1;
        private Guna.UI2.WinForms.Guna2Button btnRegistro;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl2;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private LinkLabel linkEsqueceu;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private FlowLayoutPanel masterPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelTitle;
        private TableLayoutPanel mainTablePanel;
        private Panel loginPanel;
        private TableLayoutPanel smallPanel;
    }
}