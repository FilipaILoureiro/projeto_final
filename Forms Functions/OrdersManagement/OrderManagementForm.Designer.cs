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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvOrders = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvOrders.ColumnHeadersHeight = 4;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle6;
            dgvOrders.GridColor = Color.FromArgb(231, 229, 255);
            dgvOrders.Location = new Point(31, 15);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1103, 483);
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
            // OrderManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 559);
            Controls.Add(dgvOrders);
            Name = "OrderManagementForm";
            Text = "OrderManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvOrders;
    }
}