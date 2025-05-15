namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    partial class StockList
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
            dgvStock = new Guna.UI2.WinForms.Guna2DataGridView();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStock.ColumnHeadersHeight = 4;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStock.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStock.GridColor = Color.FromArgb(231, 229, 255);
            dgvStock.Location = new Point(40, 97);
            dgvStock.Margin = new Padding(3, 2, 3, 2);
            dgvStock.Name = "dgvStock";
            dgvStock.RowHeadersVisible = false;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.RowTemplate.Height = 29;
            dgvStock.Size = new Size(989, 352);
            dgvStock.TabIndex = 1;
            dgvStock.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvStock.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvStock.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvStock.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvStock.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvStock.ThemeStyle.BackColor = Color.White;
            dgvStock.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvStock.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvStock.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStock.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvStock.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvStock.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvStock.ThemeStyle.HeaderStyle.Height = 4;
            dgvStock.ThemeStyle.ReadOnly = false;
            dgvStock.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvStock.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStock.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvStock.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvStock.ThemeStyle.RowsStyle.Height = 29;
            dgvStock.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvStock.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(690, 25);
            materialButton1.Margin = new Padding(4);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(130, 36);
            materialButton1.TabIndex = 5;
            materialButton1.Text = "Add stock";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // StockList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 602);
            Controls.Add(materialButton1);
            Controls.Add(dgvStock);
            Name = "StockList";
            Text = "StockList";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvStock;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}