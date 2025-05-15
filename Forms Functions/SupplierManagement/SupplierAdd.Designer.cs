namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    partial class SupplierAdd
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
            btnRegister = new MaterialSkin.Controls.MaterialButton();
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
            txtEmail.Location = new Point(248, 203);
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
            txtEmail.TabIndex = 23;
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
            lblUsername.Location = new Point(179, 215);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(45, 19);
            lblUsername.TabIndex = 22;
            lblUsername.Text = "E-mail";
            // 
            // btnRegister
            // 
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.Location = new Point(355, 386);
            btnRegister.Margin = new Padding(4);
            btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(99, 36);
            btnRegister.TabIndex = 20;
            btnRegister.Text = "Registrar";
            btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(95, 287);
            lblPass.MouseState = MaterialSkin.MouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(129, 19);
            lblPass.TabIndex = 19;
            lblPass.Text = "Tempo de entrega";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Depth = 0;
            lblContacto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContacto.Location = new Point(161, 126);
            lblContacto.MouseState = MaterialSkin.MouseState.HOVER;
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(65, 19);
            lblContacto.TabIndex = 18;
            lblContacto.Text = "Contacto";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Depth = 0;
            lblNome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNome.Location = new Point(181, 42);
            lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 19);
            lblNome.TabIndex = 17;
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
            txtTempodeEntrega.Location = new Point(248, 274);
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
            txtTempodeEntrega.TabIndex = 15;
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
            txtContacto.Location = new Point(248, 112);
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
            txtNome.Location = new Point(248, 29);
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
            txtNome.TabIndex = 13;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // SupplierAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 450);
            Controls.Add(txtEmail);
            Controls.Add(lblUsername);
            Controls.Add(btnRegister);
            Controls.Add(lblPass);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(txtTempodeEntrega);
            Controls.Add(txtContacto);
            Controls.Add(txtNome);
            Name = "SupplierAdd";
            Text = "SupplierAdd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 txtEmail;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialLabel lblPass;
        private MaterialSkin.Controls.MaterialLabel lblContacto;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialTextBox2 txtTempodeEntrega;
        private MaterialSkin.Controls.MaterialTextBox2 txtContacto;
        private MaterialSkin.Controls.MaterialTextBox2 txtNome;
    }
}