namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    partial class AddOrderForm
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
            txtNIF = new Guna.UI2.WinForms.Guna2TextBox();
            lblNIF = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtpDataRecolha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lblDataRecolha = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbPago = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPago = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbEntregue = new Guna.UI2.WinForms.Guna2ComboBox();
            lblEntregue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnProdutos = new Guna.UI2.WinForms.Guna2Button();
            lblProduto = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // txtNIF
            // 
            txtNIF.CustomizableEdges = customizableEdges1;
            txtNIF.DefaultText = "";
            txtNIF.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNIF.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNIF.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNIF.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNIF.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNIF.Font = new Font("Segoe UI", 9F);
            txtNIF.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNIF.Location = new Point(333, 82);
            txtNIF.Margin = new Padding(3, 4, 3, 4);
            txtNIF.Name = "txtNIF";
            txtNIF.PlaceholderText = "";
            txtNIF.SelectedText = "";
            txtNIF.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtNIF.Size = new Size(475, 61);
            txtNIF.TabIndex = 0;
            // 
            // lblNIF
            // 
            lblNIF.BackColor = Color.Transparent;
            lblNIF.Location = new Point(245, 105);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(25, 22);
            lblNIF.TabIndex = 1;
            lblNIF.Text = "NIF";
            // 
            // dtpDataRecolha
            // 
            dtpDataRecolha.Checked = true;
            dtpDataRecolha.CustomizableEdges = customizableEdges3;
            dtpDataRecolha.Font = new Font("Segoe UI", 9F);
            dtpDataRecolha.Format = DateTimePickerFormat.Long;
            dtpDataRecolha.Location = new Point(334, 186);
            dtpDataRecolha.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDataRecolha.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDataRecolha.Name = "dtpDataRecolha";
            dtpDataRecolha.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpDataRecolha.Size = new Size(474, 71);
            dtpDataRecolha.TabIndex = 2;
            dtpDataRecolha.Value = new DateTime(2025, 4, 22, 16, 39, 38, 306);
            // 
            // lblDataRecolha
            // 
            lblDataRecolha.BackColor = Color.Transparent;
            lblDataRecolha.Location = new Point(208, 217);
            lblDataRecolha.Name = "lblDataRecolha";
            lblDataRecolha.Size = new Size(109, 22);
            lblDataRecolha.TabIndex = 3;
            lblDataRecolha.Text = "Data de recolha";
            // 
            // cbPago
            // 
            cbPago.BackColor = Color.Transparent;
            cbPago.CustomizableEdges = customizableEdges5;
            cbPago.DrawMode = DrawMode.OwnerDrawFixed;
            cbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPago.FocusedColor = Color.FromArgb(94, 148, 255);
            cbPago.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbPago.Font = new Font("Segoe UI", 10F);
            cbPago.ForeColor = Color.FromArgb(68, 88, 112);
            cbPago.ItemHeight = 30;
            cbPago.Location = new Point(334, 307);
            cbPago.Name = "cbPago";
            cbPago.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbPago.Size = new Size(474, 36);
            cbPago.TabIndex = 4;
            // 
            // lblPago
            // 
            lblPago.BackColor = Color.Transparent;
            lblPago.Location = new Point(167, 315);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(150, 22);
            lblPago.TabIndex = 5;
            lblPago.Text = "Estado de pagamento";
            // 
            // cbEntregue
            // 
            cbEntregue.BackColor = Color.Transparent;
            cbEntregue.CustomizableEdges = customizableEdges7;
            cbEntregue.DrawMode = DrawMode.OwnerDrawFixed;
            cbEntregue.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEntregue.FocusedColor = Color.FromArgb(94, 148, 255);
            cbEntregue.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbEntregue.Font = new Font("Segoe UI", 10F);
            cbEntregue.ForeColor = Color.FromArgb(68, 88, 112);
            cbEntregue.ItemHeight = 30;
            cbEntregue.Location = new Point(333, 379);
            cbEntregue.Name = "cbEntregue";
            cbEntregue.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cbEntregue.Size = new Size(475, 36);
            cbEntregue.TabIndex = 6;
            // 
            // lblEntregue
            // 
            lblEntregue.BackColor = Color.Transparent;
            lblEntregue.Location = new Point(193, 393);
            lblEntregue.Name = "lblEntregue";
            lblEntregue.Size = new Size(124, 22);
            lblEntregue.TabIndex = 7;
            lblEntregue.Text = "Estado de entrega";
            // 
            // btnProdutos
            // 
            btnProdutos.CustomizableEdges = customizableEdges9;
            btnProdutos.DisabledState.BorderColor = Color.DarkGray;
            btnProdutos.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProdutos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProdutos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProdutos.Font = new Font("Segoe UI", 9F);
            btnProdutos.ForeColor = Color.White;
            btnProdutos.Location = new Point(334, 456);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnProdutos.Size = new Size(474, 42);
            btnProdutos.TabIndex = 8;
            btnProdutos.Text = "Catálogo";
            btnProdutos.Click += btnProdutos_Click;
            // 
            // lblProduto
            // 
            lblProduto.BackColor = Color.Transparent;
            lblProduto.Location = new Point(195, 467);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(122, 22);
            lblProduto.TabIndex = 9;
            lblProduto.Text = "Escolher produtos";
            // 
            // btnGuardar
            // 
            btnGuardar.CustomizableEdges = customizableEdges11;
            btnGuardar.DisabledState.BorderColor = Color.DarkGray;
            btnGuardar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardar.Font = new Font("Segoe UI", 9F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(902, 550);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnGuardar.Size = new Size(167, 53);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // AddOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 633);
            Controls.Add(btnGuardar);
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
            Name = "AddOrderForm";
            Text = "AddOrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtNIF;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNIF;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDataRecolha;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDataRecolha;
        private Guna.UI2.WinForms.Guna2ComboBox cbPago;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPago;
        private Guna.UI2.WinForms.Guna2ComboBox cbEntregue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEntregue;
        private Guna.UI2.WinForms.Guna2Button btnProdutos;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblProduto;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
    }
}