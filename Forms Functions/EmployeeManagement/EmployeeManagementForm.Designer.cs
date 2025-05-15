namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    partial class EmployeeManagementForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dgvEmployees = new Guna.UI2.WinForms.Guna2DataGridView();
            btnNewOrder = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeight = 4;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.Location = new Point(24, 54);
            dgvEmployees.Margin = new Padding(3, 2, 3, 2);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 29;
            dgvEmployees.Size = new Size(989, 352);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmployees.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvEmployees.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.ThemeStyle.HeaderStyle.Height = 4;
            dgvEmployees.ThemeStyle.ReadOnly = false;
            dgvEmployees.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvEmployees.ThemeStyle.RowsStyle.Height = 29;
            dgvEmployees.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // btnNewOrder
            // 
            btnNewOrder.CustomizableEdges = customizableEdges1;
            btnNewOrder.DisabledState.BorderColor = Color.DarkGray;
            btnNewOrder.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNewOrder.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNewOrder.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNewOrder.Font = new Font("Segoe UI", 9F);
            btnNewOrder.ForeColor = Color.White;
            btnNewOrder.Location = new Point(839, 9);
            btnNewOrder.Margin = new Padding(3, 2, 3, 2);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnNewOrder.Size = new Size(173, 34);
            btnNewOrder.TabIndex = 1;
            btnNewOrder.Text = "Nova encomenda";
            // 
            // EmployeeManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 426);
            Controls.Add(btnNewOrder);
            Controls.Add(dgvEmployees);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeeManagementForm";
            Text = "EmployeeManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnEditar;
        private MaterialSkin.Controls.MaterialButton btnRemover;
        private MaterialSkin.Controls.MaterialButton btnPromover;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEmployees;
        private Guna.UI2.WinForms.Guna2Button btnNewOrder;
    }
}