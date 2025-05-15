namespace projetoPadariaApp.Forms
{
    partial class registerForm
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
            txtNome = new MaterialSkin.Controls.MaterialTextBox2();
            txtContacto = new MaterialSkin.Controls.MaterialTextBox2();
            txtPass = new MaterialSkin.Controls.MaterialTextBox2();
            cbFuncao = new MaterialSkin.Controls.MaterialComboBox();
            lblNome = new MaterialSkin.Controls.MaterialLabel();
            lblContacto = new MaterialSkin.Controls.MaterialLabel();
            lblPass = new MaterialSkin.Controls.MaterialLabel();
            btnRegister = new MaterialSkin.Controls.MaterialButton();
            lblFuncao = new MaterialSkin.Controls.MaterialLabel();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            chkIsAdmin = new MaterialSkin.Controls.MaterialCheckbox();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.AnimateReadOnly = false;
            txtNome.BackgroundImageLayout = ImageLayout.None;
            txtNome.CharacterCasing = CharacterCasing.Normal;
            txtNome.Depth = 0;
            txtNome.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNome.HideSelection = true;
            txtNome.LeadingIcon = null;
            txtNome.Location = new Point(182, 42);
            txtNome.Margin = new Padding(3, 2, 3, 2);
            txtNome.MaxLength = 32767;
            txtNome.MouseState = MaterialSkin.MouseState.OUT;
            txtNome.Name = "txtNome";
            txtNome.PasswordChar = '\0';
            txtNome.PrefixSuffixText = null;
            txtNome.ReadOnly = false;
            txtNome.RightToLeft = RightToLeft.No;
            txtNome.SelectedText = "";
            txtNome.SelectionLength = 0;
            txtNome.SelectionStart = 0;
            txtNome.ShortcutsEnabled = true;
            txtNome.Size = new Size(438, 48);
            txtNome.TabIndex = 0;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // txtContacto
            // 
            txtContacto.AnimateReadOnly = false;
            txtContacto.BackgroundImageLayout = ImageLayout.None;
            txtContacto.CharacterCasing = CharacterCasing.Normal;
            txtContacto.Depth = 0;
            txtContacto.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtContacto.HideSelection = true;
            txtContacto.LeadingIcon = null;
            txtContacto.Location = new Point(182, 107);
            txtContacto.Margin = new Padding(3, 2, 3, 2);
            txtContacto.MaxLength = 32767;
            txtContacto.MouseState = MaterialSkin.MouseState.OUT;
            txtContacto.Name = "txtContacto";
            txtContacto.PasswordChar = '\0';
            txtContacto.PrefixSuffixText = null;
            txtContacto.ReadOnly = false;
            txtContacto.RightToLeft = RightToLeft.No;
            txtContacto.SelectedText = "";
            txtContacto.SelectionLength = 0;
            txtContacto.SelectionStart = 0;
            txtContacto.ShortcutsEnabled = true;
            txtContacto.Size = new Size(438, 48);
            txtContacto.TabIndex = 1;
            txtContacto.TabStop = false;
            txtContacto.TextAlign = HorizontalAlignment.Left;
            txtContacto.TrailingIcon = null;
            txtContacto.UseSystemPasswordChar = false;
            // 
            // txtPass
            // 
            txtPass.AnimateReadOnly = false;
            txtPass.BackgroundImageLayout = ImageLayout.None;
            txtPass.CharacterCasing = CharacterCasing.Normal;
            txtPass.Depth = 0;
            txtPass.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPass.HideSelection = true;
            txtPass.LeadingIcon = null;
            txtPass.Location = new Point(182, 232);
            txtPass.Margin = new Padding(3, 2, 3, 2);
            txtPass.MaxLength = 32767;
            txtPass.MouseState = MaterialSkin.MouseState.OUT;
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.PrefixSuffixText = null;
            txtPass.ReadOnly = false;
            txtPass.RightToLeft = RightToLeft.No;
            txtPass.SelectedText = "";
            txtPass.SelectionLength = 0;
            txtPass.SelectionStart = 0;
            txtPass.ShortcutsEnabled = true;
            txtPass.Size = new Size(438, 48);
            txtPass.TabIndex = 2;
            txtPass.TabStop = false;
            txtPass.TextAlign = HorizontalAlignment.Left;
            txtPass.TrailingIcon = null;
            txtPass.UseSystemPasswordChar = false;
            // 
            // cbFuncao
            // 
            cbFuncao.AutoResize = false;
            cbFuncao.BackColor = Color.FromArgb(255, 255, 255);
            cbFuncao.Depth = 0;
            cbFuncao.DrawMode = DrawMode.OwnerDrawVariable;
            cbFuncao.DropDownHeight = 174;
            cbFuncao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFuncao.DropDownWidth = 121;
            cbFuncao.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbFuncao.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbFuncao.FormattingEnabled = true;
            cbFuncao.IntegralHeight = false;
            cbFuncao.ItemHeight = 43;
            cbFuncao.Location = new Point(182, 292);
            cbFuncao.Margin = new Padding(3, 2, 3, 2);
            cbFuncao.MaxDropDownItems = 4;
            cbFuncao.MouseState = MaterialSkin.MouseState.OUT;
            cbFuncao.Name = "cbFuncao";
            cbFuncao.Size = new Size(439, 49);
            cbFuncao.StartIndex = 0;
            cbFuncao.TabIndex = 3;
            cbFuncao.SelectedIndexChanged += cbFuncao_SelectedIndexChanged;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Depth = 0;
            lblNome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNome.Location = new Point(115, 55);
            lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 19);
            lblNome.TabIndex = 4;
            lblNome.Text = "Nome";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Depth = 0;
            lblContacto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContacto.Location = new Point(95, 121);
            lblContacto.MouseState = MaterialSkin.MouseState.HOVER;
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(65, 19);
            lblContacto.TabIndex = 5;
            lblContacto.Text = "Contacto";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(64, 245);
            lblPass.MouseState = MaterialSkin.MouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(101, 19);
            lblPass.TabIndex = 6;
            lblPass.Text = "Palavra-passe";
            // 
            // btnRegister
            // 
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.Location = new Point(289, 399);
            btnRegister.Margin = new Padding(4, 4, 4, 4);
            btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(99, 36);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Registrar";
            btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblFuncao
            // 
            lblFuncao.AutoSize = true;
            lblFuncao.Depth = 0;
            lblFuncao.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFuncao.Location = new Point(105, 305);
            lblFuncao.MouseState = MaterialSkin.MouseState.HOVER;
            lblFuncao.Name = "lblFuncao";
            lblFuncao.Size = new Size(54, 19);
            lblFuncao.TabIndex = 8;
            lblFuncao.Text = "Função";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Depth = 0;
            lblUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(35, 177);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(134, 19);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Nome de utilizador";
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.BackgroundImageLayout = ImageLayout.None;
            txtUsername.CharacterCasing = CharacterCasing.Normal;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.HideSelection = true;
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(182, 168);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
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
            txtUsername.Size = new Size(438, 48);
            txtUsername.TabIndex = 10;
            txtUsername.TabStop = false;
            txtUsername.TextAlign = HorizontalAlignment.Left;
            txtUsername.TrailingIcon = null;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // chkIsAdmin
            // 
            chkIsAdmin.AutoSize = true;
            chkIsAdmin.Depth = 0;
            chkIsAdmin.Location = new Point(471, 358);
            chkIsAdmin.Margin = new Padding(0);
            chkIsAdmin.MouseLocation = new Point(-1, -1);
            chkIsAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            chkIsAdmin.Name = "chkIsAdmin";
            chkIsAdmin.ReadOnly = false;
            chkIsAdmin.Ripple = true;
            chkIsAdmin.Size = new Size(135, 37);
            chkIsAdmin.TabIndex = 12;
            chkIsAdmin.Text = "Administrador";
            chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // registerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 448);
            Controls.Add(chkIsAdmin);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblFuncao);
            Controls.Add(btnRegister);
            Controls.Add(lblPass);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(cbFuncao);
            Controls.Add(txtPass);
            Controls.Add(txtContacto);
            Controls.Add(txtNome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "registerForm";
            Text = "registerForm";
            Load += registerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtNome;
        private MaterialSkin.Controls.MaterialTextBox2 txtContacto;
        private MaterialSkin.Controls.MaterialTextBox2 txtPass;
        private MaterialSkin.Controls.MaterialComboBox cbFuncao;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialLabel lblContacto;
        private MaterialSkin.Controls.MaterialLabel lblPass;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialLabel lblFuncao;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialCheckbox chkIsAdmin;
    }
}