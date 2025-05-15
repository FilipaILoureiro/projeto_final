namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    partial class SupplierList
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
            dgvSupplier = new Guna.UI2.WinForms.Guna2DataGridView();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // dgvSupplier
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvSupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSupplier.ColumnHeadersHeight = 4;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvSupplier.DefaultCellStyle = dataGridViewCellStyle6;
            dgvSupplier.GridColor = Color.FromArgb(231, 229, 255);
            dgvSupplier.Location = new Point(40, 97);
            dgvSupplier.Margin = new Padding(3, 2, 3, 2);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.RowHeadersVisible = false;
            dgvSupplier.RowHeadersWidth = 51;
            dgvSupplier.RowTemplate.Height = 29;
            dgvSupplier.Size = new Size(989, 352);
            dgvSupplier.TabIndex = 1;
            dgvSupplier.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSupplier.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvSupplier.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvSupplier.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvSupplier.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvSupplier.ThemeStyle.BackColor = Color.White;
            dgvSupplier.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvSupplier.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvSupplier.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSupplier.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSupplier.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvSupplier.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSupplier.ThemeStyle.HeaderStyle.Height = 4;
            dgvSupplier.ThemeStyle.ReadOnly = false;
            dgvSupplier.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvSupplier.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSupplier.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSupplier.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvSupplier.ThemeStyle.RowsStyle.Height = 29;
            dgvSupplier.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvSupplier.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            materialButton1.Text = "Add suppliers";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // SupplierList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 602);
            Controls.Add(materialButton1);
            Controls.Add(dgvSupplier);
            Name = "SupplierList";
            Text = "SupplierList";
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvSupplier;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}