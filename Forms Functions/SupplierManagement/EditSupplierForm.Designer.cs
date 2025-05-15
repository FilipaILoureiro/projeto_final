namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    partial class EditSupplierForm
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
            txtEmail = new MaterialSkin.Controls.MaterialTextBox2();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            btnAlterar = new MaterialSkin.Controls.MaterialButton();
            lblPass = new MaterialSkin.Controls.MaterialLabel();
            lblContacto = new MaterialSkin.Controls.MaterialLabel();
            lblNome = new MaterialSkin.Controls.MaterialLabel();
            txtTempodeEntrega = new MaterialSkin.Controls.MaterialTextBox2();
            txtContacto = new MaterialSkin.Controls.MaterialTextBox2();
            txtNome = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BackgroundImageLayout = ImageLayout.None;
            txtEmail.CharacterCasing = CharacterCasing.Normal;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.HideSelection = true;
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(255, 213);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.MaxLength = 32767;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PrefixSuffixText = null;
            txtEmail.ReadOnly = false;
            txtEmail.RightToLeft = RightToLeft.No;
            txtEmail.SelectedText = "";
            txtEmail.SelectionLength = 0;
            txtEmail.SelectionStart = 0;
            txtEmail.ShortcutsEnabled = true;
            txtEmail.Size = new Size(438, 48);
            txtEmail.TabIndex = 34;
            txtEmail.TabStop = false;
            txtEmail.TextAlign = HorizontalAlignment.Left;
            txtEmail.TrailingIcon = null;
            txtEmail.UseSystemPasswordChar = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Depth = 0;
            lblUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(185, 227);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(45, 19);
            lblUsername.TabIndex = 33;
            lblUsername.Text = "E-mail";
            // 
            // btnAlterar
            // 
            btnAlterar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAlterar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAlterar.Depth = 0;
            btnAlterar.HighEmphasis = true;
            btnAlterar.Icon = null;
            btnAlterar.Location = new Point(361, 371);
            btnAlterar.Margin = new Padding(4);
            btnAlterar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAlterar.Name = "btnAlterar";
            btnAlterar.NoAccentTextColor = Color.Empty;
            btnAlterar.Size = new Size(84, 36);
            btnAlterar.TabIndex = 31;
            btnAlterar.Text = "Alterar";
            btnAlterar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAlterar.UseAccentColor = false;
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(100, 316);
            lblPass.MouseState = MaterialSkin.MouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(130, 19);
            lblPass.TabIndex = 30;
            lblPass.Text = "Tempo de Entrega";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Depth = 0;
            lblContacto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContacto.Location = new Point(165, 147);
            lblContacto.MouseState = MaterialSkin.MouseState.HOVER;
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(65, 19);
            lblContacto.TabIndex = 29;
            lblContacto.Text = "Contacto";
            lblContacto.Click += lblContacto_Click;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Depth = 0;
            lblNome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNome.Location = new Point(187, 55);
            lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 19);
            lblNome.TabIndex = 28;
            lblNome.Text = "Nome";
            // 
            // txtTempodeEntrega
            // 
            txtTempodeEntrega.AnimateReadOnly = false;
            txtTempodeEntrega.BackgroundImageLayout = ImageLayout.None;
            txtTempodeEntrega.CharacterCasing = CharacterCasing.Normal;
            txtTempodeEntrega.Depth = 0;
            txtTempodeEntrega.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTempodeEntrega.HideSelection = true;
            txtTempodeEntrega.LeadingIcon = null;
            txtTempodeEntrega.Location = new Point(255, 302);
            txtTempodeEntrega.Margin = new Padding(3, 2, 3, 2);
            txtTempodeEntrega.MaxLength = 32767;
            txtTempodeEntrega.MouseState = MaterialSkin.MouseState.OUT;
            txtTempodeEntrega.Name = "txtTempodeEntrega";
            txtTempodeEntrega.PasswordChar = '\0';
            txtTempodeEntrega.PrefixSuffixText = null;
            txtTempodeEntrega.ReadOnly = false;
            txtTempodeEntrega.RightToLeft = RightToLeft.No;
            txtTempodeEntrega.SelectedText = "";
            txtTempodeEntrega.SelectionLength = 0;
            txtTempodeEntrega.SelectionStart = 0;
            txtTempodeEntrega.ShortcutsEnabled = true;
            txtTempodeEntrega.Size = new Size(438, 48);
            txtTempodeEntrega.TabIndex = 26;
            txtTempodeEntrega.TabStop = false;
            txtTempodeEntrega.TextAlign = HorizontalAlignment.Left;
            txtTempodeEntrega.TrailingIcon = null;
            txtTempodeEntrega.UseSystemPasswordChar = false;
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
            txtContacto.Location = new Point(255, 135);
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
            txtContacto.TabIndex = 25;
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
            txtNome.Location = new Point(255, 43);
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
            txtNome.TabIndex = 24;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // EditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEmail);
            Controls.Add(lblUsername);
            Controls.Add(btnAlterar);
            Controls.Add(lblPass);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(txtTempodeEntrega);
            Controls.Add(txtContacto);
            Controls.Add(txtNome);
            Name = "EditSupplierForm";
            Text = "EditSupplierForm";
            Load += EditSupplierForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtEmail;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialButton btnAlterar;
        private MaterialSkin.Controls.MaterialLabel lblPass;
        private MaterialSkin.Controls.MaterialLabel lblContacto;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialTextBox2 txtTempodeEntrega;
        private MaterialSkin.Controls.MaterialTextBox2 txtContacto;
        private MaterialSkin.Controls.MaterialTextBox2 txtNome;
    }
}