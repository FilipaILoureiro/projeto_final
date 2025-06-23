namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    partial class ProductManagementForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            databaseManageBindingSource = new BindingSource(components);
            btnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeight = 4;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProducts.DataSource = databaseManageBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.GridColor = Color.FromArgb(231, 229, 255);
            dgvProducts.Location = new Point(31, 63);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(930, 416);
            dgvProducts.TabIndex = 0;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvProducts.ThemeStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvProducts.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvProducts.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProducts.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProducts.ThemeStyle.HeaderStyle.Height = 4;
            dgvProducts.ThemeStyle.ReadOnly = false;
            dgvProducts.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvProducts.ThemeStyle.RowsStyle.Height = 29;
            dgvProducts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvProducts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // databaseManageBindingSource
            // 
            databaseManageBindingSource.DataSource = typeof(PadariaApp.DatabaseManage);
            // 
            // btnAddProduct
            // 
            btnAddProduct.CustomizableEdges = customizableEdges1;
            btnAddProduct.DisabledState.BorderColor = Color.DarkGray;
            btnAddProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddProduct.Font = new Font("Segoe UI", 9F);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(790, 12);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddProduct.Size = new Size(171, 35);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Novo Produto";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 497);
            Controls.Add(btnAddProduct);
            Controls.Add(dgvProducts);
            Name = "ProductManagementForm";
            Text = "ProductManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvProducts;
        private BindingSource databaseManageBindingSource;
        private Guna.UI2.WinForms.Guna2Button btnAddProduct;
    }
}