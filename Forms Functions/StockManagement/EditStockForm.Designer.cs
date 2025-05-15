namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    partial class EditStockForm
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
            btnAlterar = new MaterialSkin.Controls.MaterialButton();
            cbIva = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            cbFornecedor = new MaterialSkin.Controls.MaterialComboBox();
            txtPreco = new MaterialSkin.Controls.MaterialTextBox2();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            lblPass = new MaterialSkin.Controls.MaterialLabel();
            lblContacto = new MaterialSkin.Controls.MaterialLabel();
            lblNome = new MaterialSkin.Controls.MaterialLabel();
            txtQuantidade = new MaterialSkin.Controls.MaterialTextBox2();
            txtNome = new MaterialSkin.Controls.MaterialTextBox2();
            SuspendLayout();
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
            // cbIva
            // 
            cbIva.AutoResize = false;
            cbIva.BackColor = Color.FromArgb(255, 255, 255);
            cbIva.Depth = 0;
            cbIva.DrawMode = DrawMode.OwnerDrawVariable;
            cbIva.DropDownHeight = 174;
            cbIva.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIva.DropDownWidth = 121;
            cbIva.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbIva.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbIva.FormattingEnabled = true;
            cbIva.IntegralHeight = false;
            cbIva.ItemHeight = 43;
            cbIva.Location = new Point(221, 319);
            cbIva.Margin = new Padding(3, 2, 3, 2);
            cbIva.MaxDropDownItems = 4;
            cbIva.MouseState = MaterialSkin.MouseState.OUT;
            cbIva.Name = "cbIva";
            cbIva.Size = new Size(439, 49);
            cbIva.StartIndex = 0;
            cbIva.TabIndex = 41;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(170, 323);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(25, 19);
            materialLabel1.TabIndex = 40;
            materialLabel1.Text = "IVA";
            // 
            // cbFornecedor
            // 
            cbFornecedor.AutoResize = false;
            cbFornecedor.BackColor = Color.FromArgb(255, 255, 255);
            cbFornecedor.Depth = 0;
            cbFornecedor.DrawMode = DrawMode.OwnerDrawVariable;
            cbFornecedor.DropDownHeight = 174;
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFornecedor.DropDownWidth = 121;
            cbFornecedor.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbFornecedor.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbFornecedor.FormattingEnabled = true;
            cbFornecedor.IntegralHeight = false;
            cbFornecedor.ItemHeight = 43;
            cbFornecedor.Location = new Point(221, 85);
            cbFornecedor.Margin = new Padding(3, 2, 3, 2);
            cbFornecedor.MaxDropDownItems = 4;
            cbFornecedor.MouseState = MaterialSkin.MouseState.OUT;
            cbFornecedor.Name = "cbFornecedor";
            cbFornecedor.Size = new Size(439, 49);
            cbFornecedor.StartIndex = 0;
            cbFornecedor.TabIndex = 39;
            // 
            // txtPreco
            // 
            txtPreco.AnimateReadOnly = false;
            txtPreco.BackgroundImageLayout = ImageLayout.None;
            txtPreco.CharacterCasing = CharacterCasing.Normal;
            txtPreco.Depth = 0;
            txtPreco.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPreco.HideSelection = true;
            txtPreco.LeadingIcon = null;
            txtPreco.Location = new Point(221, 167);
            txtPreco.Margin = new Padding(3, 2, 3, 2);
            txtPreco.MaxLength = 32767;
            txtPreco.MouseState = MaterialSkin.MouseState.OUT;
            txtPreco.Name = "txtPreco";
            txtPreco.PasswordChar = '\0';
            txtPreco.PrefixSuffixText = null;
            txtPreco.ReadOnly = false;
            txtPreco.RightToLeft = RightToLeft.No;
            txtPreco.SelectedText = "";
            txtPreco.SelectionLength = 0;
            txtPreco.SelectionStart = 0;
            txtPreco.ShortcutsEnabled = true;
            txtPreco.Size = new Size(438, 48);
            txtPreco.TabIndex = 38;
            txtPreco.TabStop = false;
            txtPreco.TextAlign = HorizontalAlignment.Left;
            txtPreco.TrailingIcon = null;
            txtPreco.UseSystemPasswordChar = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Depth = 0;
            lblUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(154, 167);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(41, 19);
            lblUsername.TabIndex = 37;
            lblUsername.Text = "Preço";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Depth = 0;
            lblPass.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPass.Location = new Point(112, 255);
            lblPass.MouseState = MaterialSkin.MouseState.HOVER;
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(83, 19);
            lblPass.TabIndex = 36;
            lblPass.Text = "Quantidade";
            // 
            // lblContacto
            // 
            lblContacto.AutoSize = true;
            lblContacto.Depth = 0;
            lblContacto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblContacto.Location = new Point(117, 90);
            lblContacto.MouseState = MaterialSkin.MouseState.HOVER;
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(80, 19);
            lblContacto.TabIndex = 35;
            lblContacto.Text = "Fornecedor";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Depth = 0;
            lblNome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNome.Location = new Point(154, 24);
            lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(43, 19);
            lblNome.TabIndex = 34;
            lblNome.Text = "Nome";
            // 
            // txtQuantidade
            // 
            txtQuantidade.AnimateReadOnly = false;
            txtQuantidade.BackgroundImageLayout = ImageLayout.None;
            txtQuantidade.CharacterCasing = CharacterCasing.Normal;
            txtQuantidade.Depth = 0;
            txtQuantidade.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQuantidade.HideSelection = true;
            txtQuantidade.LeadingIcon = null;
            txtQuantidade.Location = new Point(221, 245);
            txtQuantidade.Margin = new Padding(3, 2, 3, 2);
            txtQuantidade.MaxLength = 32767;
            txtQuantidade.MouseState = MaterialSkin.MouseState.OUT;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PasswordChar = '\0';
            txtQuantidade.PrefixSuffixText = null;
            txtQuantidade.ReadOnly = false;
            txtQuantidade.RightToLeft = RightToLeft.No;
            txtQuantidade.SelectedText = "";
            txtQuantidade.SelectionLength = 0;
            txtQuantidade.SelectionStart = 0;
            txtQuantidade.ShortcutsEnabled = true;
            txtQuantidade.Size = new Size(438, 48);
            txtQuantidade.TabIndex = 33;
            txtQuantidade.TabStop = false;
            txtQuantidade.TextAlign = HorizontalAlignment.Left;
            txtQuantidade.TrailingIcon = null;
            txtQuantidade.UseSystemPasswordChar = false;
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
            txtNome.Location = new Point(221, 11);
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
            txtNome.TabIndex = 32;
            txtNome.TabStop = false;
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;
            // 
            // EditStockForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbIva);
            Controls.Add(materialLabel1);
            Controls.Add(cbFornecedor);
            Controls.Add(txtPreco);
            Controls.Add(lblUsername);
            Controls.Add(lblPass);
            Controls.Add(lblContacto);
            Controls.Add(lblNome);
            Controls.Add(txtQuantidade);
            Controls.Add(txtNome);
            Controls.Add(btnAlterar);
            Name = "EditStockForm";
            Text = "EditSupplierForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnAlterar;
        private MaterialSkin.Controls.MaterialComboBox cbIva;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox cbFornecedor;
        private MaterialSkin.Controls.MaterialTextBox2 txtPreco;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialLabel lblPass;
        private MaterialSkin.Controls.MaterialLabel lblContacto;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialTextBox2 txtQuantidade;
        private MaterialSkin.Controls.MaterialTextBox2 txtNome;
    }
}