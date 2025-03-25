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
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            btnForgotPass = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.BackgroundImageLayout = ImageLayout.None;
            txtUsername.CharacterCasing = CharacterCasing.Normal;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.HideSelection = true;
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(236, 149);
            txtUsername.MaxLength = 32767;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PrefixSuffixText = null;
            txtUsername.ReadOnly = false;
            txtUsername.RightToLeft = RightToLeft.No;
            txtUsername.SelectedText = "";
            txtUsername.SelectionLength = 0;
            txtUsername.SelectionStart = 0;
            txtUsername.ShortcutsEnabled = true;
            txtUsername.Size = new Size(424, 48);
            txtUsername.TabIndex = 0;
            txtUsername.TabStop = false;
            txtUsername.TextAlign = HorizontalAlignment.Left;
            txtUsername.TrailingIcon = null;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Depth = 0;
            lblUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(82, 166);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(134, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Nome de utilizador";
            // 
            // btnForgotPass
            // 
            btnForgotPass.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnForgotPass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnForgotPass.Depth = 0;
            btnForgotPass.HighEmphasis = true;
            btnForgotPass.Icon = null;
            btnForgotPass.Location = new Point(295, 279);
            btnForgotPass.Margin = new Padding(4, 6, 4, 6);
            btnForgotPass.MouseState = MaterialSkin.MouseState.HOVER;
            btnForgotPass.Name = "btnForgotPass";
            btnForgotPass.NoAccentTextColor = Color.Empty;
            btnForgotPass.Size = new Size(212, 36);
            btnForgotPass.TabIndex = 2;
            btnForgotPass.Text = "Redefinir palavra-passe";
            btnForgotPass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnForgotPass.UseAccentColor = false;
            btnForgotPass.UseVisualStyleBackColor = true;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnForgotPass);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Name = "ForgotPassword";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialButton btnForgotPass;
    }
}