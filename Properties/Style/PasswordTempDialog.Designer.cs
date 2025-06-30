namespace projetoPadariaApp.Properties.Style
{
    partial class PasswordTempDialog
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordTempDialog));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnCopiar = new Guna.UI2.WinForms.Guna2Button();
            btnOk = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = false;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfo.Location = new Point(0, 52);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(628, 33);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Palavra passe temporária para o utilizador";
            lblInfo.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges17;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.Red;
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Location = new Point(135, 157);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.ReadOnly = true;
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtPassword.Size = new Size(367, 71);
            txtPassword.TabIndex = 1;
            // 
            // btnCopiar
            // 
            btnCopiar.BorderRadius = 10;
            btnCopiar.CustomizableEdges = customizableEdges19;
            btnCopiar.DisabledState.BorderColor = Color.DarkGray;
            btnCopiar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCopiar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCopiar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCopiar.FillColor = Color.Teal;
            btnCopiar.FocusedColor = Color.DarkCyan;
            btnCopiar.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnCopiar.ForeColor = Color.White;
            btnCopiar.HoverState.FillColor = Color.DarkCyan;
            btnCopiar.Image = (Image)resources.GetObject("btnCopiar.Image");
            btnCopiar.ImageSize = new Size(40, 40);
            btnCopiar.Location = new Point(46, 269);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnCopiar.Size = new Size(175, 56);
            btnCopiar.TabIndex = 2;
            btnCopiar.Text = "Copiar";
            btnCopiar.Click += btnCopiar_Click;
            // 
            // btnOk
            // 
            btnOk.BorderRadius = 10;
            btnOk.CustomizableEdges = customizableEdges21;
            btnOk.DisabledState.BorderColor = Color.DarkGray;
            btnOk.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOk.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOk.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOk.FillColor = Color.Teal;
            btnOk.FocusedColor = Color.DarkCyan;
            btnOk.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.HoverState.FillColor = Color.DarkCyan;
            btnOk.Image = Resources.Visto;
            btnOk.ImageSize = new Size(40, 40);
            btnOk.Location = new Point(374, 269);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnOk.Size = new Size(196, 56);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            btnOk.Click += btnOk_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Silver;
            guna2Panel1.CustomizableEdges = customizableEdges23;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges24;
            guna2Panel1.Size = new Size(628, 34);
            guna2Panel1.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = false;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUsername.ForeColor = Color.RoyalBlue;
            lblUsername.Location = new Point(0, 96);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(628, 30);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";
            lblUsername.TextAlignment = ContentAlignment.TopCenter;
            // 
            // PasswordTempDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(628, 352);
            Controls.Add(lblUsername);
            Controls.Add(guna2Panel1);
            Controls.Add(btnOk);
            Controls.Add(btnCopiar);
            Controls.Add(txtPassword);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PasswordTempDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PasswordTempDialog";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnCopiar;
        private Guna.UI2.WinForms.Guna2Button btnOk;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
    }
}