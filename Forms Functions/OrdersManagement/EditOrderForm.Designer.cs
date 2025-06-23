namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    partial class EditOrderForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAlterar = new Guna.UI2.WinForms.Guna2Button();
            lblProduto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnProdutos = new Guna.UI2.WinForms.Guna2Button();
            lblEntregue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbEntregue = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPago = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbPago = new Guna.UI2.WinForms.Guna2ComboBox();
            lblDataRecolha = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtpDataRecolha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblNIF = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtNIF = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // btnAlterar
            // 
            btnAlterar.CustomizableEdges = customizableEdges1;
            btnAlterar.DisabledState.BorderColor = Color.DarkGray;
            btnAlterar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAlterar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAlterar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAlterar.Font = new Font("Segoe UI", 9F);
            btnAlterar.ForeColor = Color.White;
            btnAlterar.Location = new Point(826, 528);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAlterar.Size = new Size(167, 53);
            btnAlterar.TabIndex = 21;
            btnAlterar.Text = "Alterar";
            btnAlterar.Click += btnAlterar_Click;
            // 
            // lblProduto
            // 
            lblProduto.BackColor = Color.Transparent;
            lblProduto.Location = new Point(119, 445);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(122, 22);
            lblProduto.TabIndex = 20;
            lblProduto.Text = "Escolher produtos";
            // 
            // btnProdutos
            // 
            btnProdutos.CustomizableEdges = customizableEdges3;
            btnProdutos.DisabledState.BorderColor = Color.DarkGray;
            btnProdutos.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProdutos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProdutos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProdutos.Font = new Font("Segoe UI", 9F);
            btnProdutos.ForeColor = Color.White;
            btnProdutos.Location = new Point(258, 434);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnProdutos.Size = new Size(474, 42);
            btnProdutos.TabIndex = 19;
            btnProdutos.Text = "Catálogo";
            btnProdutos.Click += btnProdutos_Click;
            // 
            // lblEntregue
            // 
            lblEntregue.BackColor = Color.Transparent;
            lblEntregue.Location = new Point(117, 371);
            lblEntregue.Name = "lblEntregue";
            lblEntregue.Size = new Size(124, 22);
            lblEntregue.TabIndex = 18;
            lblEntregue.Text = "Estado de entrega";
            // 
            // cbEntregue
            // 
            cbEntregue.BackColor = Color.Transparent;
            cbEntregue.CustomizableEdges = customizableEdges5;
            cbEntregue.DrawMode = DrawMode.OwnerDrawFixed;
            cbEntregue.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEntregue.FocusedColor = Color.FromArgb(94, 148, 255);
            cbEntregue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbEntregue.Font = new Font("Segoe UI", 10F);
            cbEntregue.ForeColor = Color.FromArgb(68, 88, 112);
            cbEntregue.ItemHeight = 30;
            cbEntregue.Location = new Point(257, 357);
            cbEntregue.Name = "cbEntregue";
            cbEntregue.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbEntregue.Size = new Size(475, 36);
            cbEntregue.TabIndex = 17;
            // 
            // lblPago
            // 
            lblPago.BackColor = Color.Transparent;
            lblPago.Location = new Point(91, 293);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(150, 22);
            lblPago.TabIndex = 16;
            lblPago.Text = "Estado de pagamento";
            // 
            // cbPago
            // 
            cbPago.BackColor = Color.Transparent;
            cbPago.CustomizableEdges = customizableEdges7;
            cbPago.DrawMode = DrawMode.OwnerDrawFixed;
            cbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPago.FocusedColor = Color.FromArgb(94, 148, 255);
            cbPago.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbPago.Font = new Font("Segoe UI", 10F);
            cbPago.ForeColor = Color.FromArgb(68, 88, 112);
            cbPago.ItemHeight = 30;
            cbPago.Location = new Point(258, 285);
            cbPago.Name = "cbPago";
            cbPago.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbPago.Size = new Size(474, 36);
            cbPago.TabIndex = 15;
            // 
            // lblDataRecolha
            // 
            lblDataRecolha.BackColor = Color.Transparent;
            lblDataRecolha.Location = new Point(132, 195);
            lblDataRecolha.Name = "lblDataRecolha";
            lblDataRecolha.Size = new Size(109, 22);
            lblDataRecolha.TabIndex = 14;
            lblDataRecolha.Text = "Data de recolha";
            // 
            // dtpDataRecolha
            // 
            dtpDataRecolha.Checked = true;
            dtpDataRecolha.CustomizableEdges = customizableEdges9;
            dtpDataRecolha.Font = new Font("Segoe UI", 9F);
            dtpDataRecolha.Format = DateTimePickerFormat.Long;
            dtpDataRecolha.Location = new Point(258, 164);
            dtpDataRecolha.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDataRecolha.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDataRecolha.Name = "dtpDataRecolha";
            dtpDataRecolha.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpDataRecolha.Size = new Size(474, 71);
            dtpDataRecolha.TabIndex = 13;
            dtpDataRecolha.Value = new DateTime(2025, 4, 22, 16, 39, 38, 306);
            // 
            // lblNIF
            // 
            lblNIF.BackColor = Color.Transparent;
            lblNIF.Location = new Point(169, 83);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(25, 22);
            lblNIF.TabIndex = 12;
            lblNIF.Text = "NIF";
            // 
            // txtNIF
            // 
            txtNIF.CustomizableEdges = customizableEdges11;
            txtNIF.DefaultText = "";
            txtNIF.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNIF.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNIF.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNIF.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNIF.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNIF.Font = new Font("Segoe UI", 9F);
            txtNIF.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNIF.Location = new Point(257, 60);
            txtNIF.Margin = new Padding(3, 4, 3, 4);
            txtNIF.Name = "txtNIF";
            txtNIF.PlaceholderText = "";
            txtNIF.SelectedText = "";
            txtNIF.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtNIF.Size = new Size(475, 61);
            txtNIF.TabIndex = 11;
            // 
            // EditOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 640);
            Controls.Add(btnAlterar);
            Controls.Add(lblProduto);
            Controls.Add(btnProdutos);
            Controls.Add(lblEntregue);
            Controls.Add(cbEntregue);
            Controls.Add(lblPago);
            Controls.Add(cbPago);
            Controls.Add(lblDataRecolha);
            Controls.Add(dtpDataRecolha);
            Controls.Add(lblNIF);
            Controls.Add(txtNIF);
            Name = "EditOrderForm";
            Text = "EditOrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAlterar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProduto;
        private Guna.UI2.WinForms.Guna2Button btnProdutos;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEntregue;
        private Guna.UI2.WinForms.Guna2ComboBox cbEntregue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPago;
        private Guna.UI2.WinForms.Guna2ComboBox cbPago;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDataRecolha;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDataRecolha;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNIF;
        private Guna.UI2.WinForms.Guna2TextBox txtNIF;
    }
}