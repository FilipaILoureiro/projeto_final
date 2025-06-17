namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    partial class OrderManagementForm
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
            dgvOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            databaseManageBindingSource1 = new BindingSource(components);
            databaseManageBindingSource = new BindingSource(components);
            btnAddOrder = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrders.ColumnHeadersHeight = 4;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrders.DataSource = databaseManageBindingSource1;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOrders.GridColor = Color.FromArgb(231, 229, 255);
            dgvOrders.Location = new Point(38, 27);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(810, 582);
            dgvOrders.TabIndex = 0;
            dgvOrders.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvOrders.ThemeStyle.BackColor = Color.White;
            dgvOrders.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvOrders.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvOrders.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOrders.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvOrders.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrders.ThemeStyle.HeaderStyle.Height = 4;
            dgvOrders.ThemeStyle.ReadOnly = false;
            dgvOrders.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvOrders.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOrders.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvOrders.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvOrders.ThemeStyle.RowsStyle.Height = 29;
            dgvOrders.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvOrders.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // databaseManageBindingSource1
            // 
            databaseManageBindingSource1.DataSource = typeof(PadariaApp.DatabaseManage);
            // 
            // databaseManageBindingSource
            // 
            databaseManageBindingSource.DataSource = typeof(PadariaApp.DatabaseManage);
            // 
            // btnAddOrder
            // 
            btnAddOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddOrder.CustomizableEdges = customizableEdges1;
            btnAddOrder.DisabledState.BorderColor = Color.DarkGray;
            btnAddOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddOrder.Font = new Font("Segoe UI", 9F);
            btnAddOrder.ForeColor = Color.White;
            btnAddOrder.Location = new Point(907, 78);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAddOrder.Size = new Size(225, 56);
            btnAddOrder.TabIndex = 1;
            btnAddOrder.Text = "Nova Encomenda";
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // OrderManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 652);
            Controls.Add(btnAddOrder);
            Controls.Add(dgvOrders);
            Name = "OrderManagementForm";
            Text = "Gerir Encomendas";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvOrders;
        private Guna.UI2.WinForms.Guna2Button btnAddOrder;
        private BindingSource databaseManageBindingSource;
        private BindingSource databaseManageBindingSource1;
    }
}