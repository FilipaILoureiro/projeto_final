namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    partial class EditEmployeeForm
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
            btnAlterar = new Button();
            txtNome = new TextBox();
            txtContacto = new TextBox();
            txtUsername = new TextBox();
            txtPass = new TextBox();
            cbFuncao = new ComboBox();
            lblNome = new Label();
            lblContacto = new Label();
            lblUsername = new Label();
            lblPass = new Label();
            lblFuncao = new Label();
            SuspendLayout();
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(380, 501);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(94, 29);
            btnAlterar.TabIndex = 24;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(219, 62);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(487, 27);
            txtNome.TabIndex = 25;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(219, 151);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(494, 27);
            txtContacto.TabIndex = 26;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(226, 227);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(503, 27);
            txtUsername.TabIndex = 27;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(219, 316);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(523, 27);
            txtPass.TabIndex = 28;
            // 
            // cbFuncao
            // 
            cbFuncao.FormattingEnabled = true;
            cbFuncao.Location = new Point(231, 389);
            cbFuncao.Name = "cbFuncao";
            cbFuncao.Size = new Size(391, 28);
            cbFuncao.TabIndex = 29;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(128, 69);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(50, 20);
            lblNome.TabIndex = 30;
            lblNome.Text = "Nome";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Location = new Point(140, 158);
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(46, 20);
            lblContacto.TabIndex = 31;
            lblContacto.Text = "Email";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(56, 234);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(138, 20);
            lblUsername.TabIndex = 32;
            lblUsername.Text = "Nome de utilziador";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(95, 316);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(99, 20);
            lblPass.TabIndex = 33;
            lblPass.Text = "Palavra-passe";
            // 
            // lblFuncao
            // 
            lblFuncao.AutoSize = true;
            lblFuncao.Location = new Point(138, 392);
            lblFuncao.Name = "lblFuncao";
            lblFuncao.Size = new Size(56, 20);
            lblFuncao.TabIndex = 34;
            lblFuncao.Text = "Função";
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 570);
            Controls.Add(lblFuncao);
            Controls.Add(lblPass);
            Controls.Add(lblUsername);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(cbFuncao);
            Controls.Add(txtPass);
            Controls.Add(txtUsername);
            Controls.Add(txtContacto);
            Controls.Add(txtNome);
            Controls.Add(btnAlterar);
            Name = "EditEmployeeForm";
            Text = "EditEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAlterar;
        private TextBox txtNome;
        private TextBox txtContacto;
        private TextBox txtUsername;
        private TextBox txtPass;
        private ComboBox cbFuncao;
        private Label lblNome;
        private Label lblContacto;
        private Label lblUsername;
        private Label lblPass;
        private Label lblFuncao;
    }
}