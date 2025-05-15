namespace projetoPadariaApp.Forms_Login_e_Registo
{
    partial class LogsList
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
            dgvLogs = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // dgvLogs
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLogs.ColumnHeadersHeight = 4;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLogs.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLogs.GridColor = Color.FromArgb(231, 229, 255);
            dgvLogs.Location = new Point(-94, 49);
            dgvLogs.Margin = new Padding(3, 2, 3, 2);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.RowHeadersWidth = 51;
            dgvLogs.RowTemplate.Height = 29;
            dgvLogs.Size = new Size(989, 352);
            dgvLogs.TabIndex = 2;
            dgvLogs.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvLogs.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvLogs.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvLogs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvLogs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvLogs.ThemeStyle.BackColor = Color.White;
            dgvLogs.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvLogs.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvLogs.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLogs.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvLogs.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvLogs.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLogs.ThemeStyle.HeaderStyle.Height = 4;
            dgvLogs.ThemeStyle.ReadOnly = false;
            dgvLogs.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvLogs.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLogs.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLogs.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvLogs.ThemeStyle.RowsStyle.Height = 29;
            dgvLogs.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvLogs.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvLogs.CellContentClick += dgvLogs_CellContentClick;
            // 
            // LogsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 539);
            Controls.Add(dgvLogs);
            Name = "LogsList";
            Text = "LogsList";
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvLogs;
    }
}