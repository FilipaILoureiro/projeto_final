namespace projetoPadariaApp.Forms
{
    partial class ForgotPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnResetPass = new Guna.UI2.WinForms.Guna2Button();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            sidePanel = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox3 = new PictureBox();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            lblUsername.ForeColor = Color.Gainsboro;
            lblUsername.Location = new Point(424, 131);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(204, 33);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Nome de utilizador";
            // 
            // btnResetPass
            // 
            btnResetPass.BorderRadius = 15;
            btnResetPass.CustomizableEdges = customizableEdges1;
            btnResetPass.DisabledState.BorderColor = Color.DarkGray;
            btnResetPass.DisabledState.CustomBorderColor = Color.DarkGray;
            btnResetPass.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnResetPass.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnResetPass.FillColor = Color.Teal;
            btnResetPass.FocusedColor = Color.DarkCyan;
            btnResetPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnResetPass.ForeColor = Color.White;
            btnResetPass.Image = (Image)resources.GetObject("btnResetPass.Image");
            btnResetPass.Location = new Point(424, 293);
            btnResetPass.Name = "btnResetPass";
            btnResetPass.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnResetPass.Size = new Size(317, 58);
            btnResetPass.TabIndex = 7;
            btnResetPass.Text = "Redefinir palavra passe";
            btnResetPass.Click += btnResetPass_Click_1;
            // 
            // txtUsername
            // 
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
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.HoverState.BorderColor = Color.Teal;
            txtUsername.Location = new Point(385, 171);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtUsername.Size = new Size(408, 65);
            txtUsername.TabIndex = 8;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = SystemColors.ActiveCaptionText;
            sidePanel.Controls.Add(lblTitle);
            sidePanel.CustomizableEdges = customizableEdges5;
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            sidePanel.Size = new Size(299, 451);
            sidePanel.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 148);
            lblTitle.Margin = new Padding(8, 8, 3, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(276, 123);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "Nova palavra passe";
            lblTitle.TextAlignment = ContentAlignment.TopCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(386, 132);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.CustomizableEdges = customizableEdges7;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.FromArgb(50, 52, 76);
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageSize = new Size(40, 40);
            btnClose.Location = new Point(808, 0);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClose.Size = new Size(45, 43);
            btnClose.TabIndex = 24;
            btnClose.Click += btnClose_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 52, 76);
            ClientSize = new Size(852, 451);
            Controls.Add(btnClose);
            Controls.Add(pictureBox3);
            Controls.Add(sidePanel);
            Controls.Add(txtUsername);
            Controls.Add(btnResetPass);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2Button btnResetPass;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2Panel sidePanel;
        private PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}