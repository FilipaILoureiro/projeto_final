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
            btnForgotPass = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            SuspendLayout();
            // 
            // btnForgotPass
            // 
            btnForgotPass.Location = new Point(261, 348);
            btnForgotPass.Name = "btnForgotPass";
            btnForgotPass.Size = new Size(283, 29);
            btnForgotPass.TabIndex = 3;
            btnForgotPass.Text = "Redefinir password";
            btnForgotPass.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(69, 163);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(138, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Nome de utilizador";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(224, 160);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(474, 27);
            txtUsername.TabIndex = 5;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(btnForgotPass);
            Name = "ForgotPasswordForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnForgotPass;
        private Label lblUsername;
        private TextBox txtUsername;
    }
}