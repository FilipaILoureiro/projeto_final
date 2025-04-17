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
            txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            lblFuncao = new MaterialSkin.Controls.MaterialLabel();
            btnAlterar = new MaterialSkin.Controls.MaterialButton();
            lblPass = new MaterialSkin.Controls.MaterialLabel();
            lblContacto = new MaterialSkin.Controls.MaterialLabel();
            lblNome = new MaterialSkin.Controls.MaterialLabel();
            cbFuncao = new MaterialSkin.Controls.MaterialComboBox();
            txtPass = new MaterialSkin.Controls.MaterialTextBox2();
            txtContacto = new MaterialSkin.Controls.MaterialTextBox2();
            txtNome = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
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
            txtUsername.Location = new Point(228, 221);
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
            txtUsername.Size = new Size(501, 48);
            txtUsername.TabIndex = 23;
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
            lblUsername.Location = new Point(60, 233);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(134, 19);
            lblUsername.TabIndex = 22;
            lblUsername.Text = "Nome de utilizador";
            // 
            // lblFuncao
            // 
            lblFuncao.AutoSize = true;
            lblFuncao.Depth = 0;
            lblFuncao.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFuncao.Location = new Point(140, 404);
            lblFuncao.MouseState = MaterialSkin.MouseState.HOVER;
            lblFuncao.Name = "lblFuncao";
            lblFuncao.Size = new Size(54, 19);
            lblFuncao.TabIndex = 21;
            lblFuncao.Text = "Função";
            // 
            // btnAlterar
            // 
            btnAlterar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAlterar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAlterar.Depth = 0;
            btnAlterar.HighEmphasis = true;
            btnAlterar.Icon = null;
            btnAlterar.Location = new Point(350, 491);
            btnAlterar.Margin = new Padding(4, 6, 4, 6);
            btnAlterar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAlterar.Name = "btnAlterar";
            btnAlterar.NoAccentTextColor = Color.Empty;
            btnAlterar.Size = new Size(84, 36);
            btnAlterar.TabIndex = 20;
            btnAlterar.Text = "Alterar";
            btnAlterar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAlterar.UseAccentColor = false;
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click_1;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(93, 324);
            lblPass.MouseState = MaterialSkin.MouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(101, 19);
            lblPass.TabIndex = 19;
            lblPass.Text = "Palavra-passe";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Depth = 0;
            lblContacto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContacto.Location = new Point(153, 159);
            lblContacto.MouseState = MaterialSkin.MouseState.HOVER;
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(41, 19);
            lblContacto.TabIndex = 18;
            lblContacto.Text = "Email";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Depth = 0;
            lblNome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNome.Location = new Point(151, 70);
            lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 19);
            lblNome.TabIndex = 17;
            lblNome.Text = "Nome";
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
            cbFuncao.Location = new Point(228, 386);
            cbFuncao.MaxDropDownItems = 4;
            cbFuncao.MouseState = MaterialSkin.MouseState.OUT;
            cbFuncao.Name = "cbFuncao";
            cbFuncao.Size = new Size(501, 49);
            cbFuncao.StartIndex = 0;
            cbFuncao.TabIndex = 16;
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
            txtPass.Location = new Point(228, 307);
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
            txtPass.Size = new Size(501, 48);
            txtPass.TabIndex = 15;
            txtPass.TabStop = false;
            txtPass.TextAlign = HorizontalAlignment.Left;
            txtPass.TrailingIcon = null;
            txtPass.UseSystemPasswordChar = false;
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
            txtContacto.Location = new Point(228, 140);
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
            txtContacto.Size = new Size(501, 48);
            txtContacto.TabIndex = 14;
            txtContacto.TabStop = false;
            txtContacto.TextAlign = HorizontalAlignment.Left;
            txtContacto.TrailingIcon = null;
            txtContacto.UseSystemPasswordChar = false;
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
            txtNome.Location = new Point(228, 53);
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
            txtNome.Size = new Size(501, 48);
            txtNome.TabIndex = 13;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 570);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblFuncao);
            Controls.Add(btnAlterar);
            Controls.Add(lblPass);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(cbFuncao);
            Controls.Add(txtPass);
            Controls.Add(txtContacto);
            Controls.Add(txtNome);
            Name = "EditEmployeeForm";
            Text = "EditEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialLabel lblFuncao;
        private MaterialSkin.Controls.MaterialButton btnAlterar;
        private MaterialSkin.Controls.MaterialLabel lblPass;
        private MaterialSkin.Controls.MaterialLabel lblContacto;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialComboBox cbFuncao;
        private MaterialSkin.Controls.MaterialTextBox2 txtPass;
        private MaterialSkin.Controls.MaterialTextBox2 txtContacto;
        private MaterialSkin.Controls.MaterialTextBox2 txtNome;
    }
}