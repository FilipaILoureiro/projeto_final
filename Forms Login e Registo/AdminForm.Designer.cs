namespace projetoPadariaApp.Forms
{
    partial class AdminForm
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
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            btnManageEmployees = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(172, 200);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(473, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Colocar aqui os botões/ícones para as funções que ele tem acesso";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(132, 273);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(617, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Lembrar de na gestão dos funcionarios, add funçao promover admin (já existe no auth)";
            // 
            // btnManageEmployees
            // 
            btnManageEmployees.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnManageEmployees.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnManageEmployees.Depth = 0;
            btnManageEmployees.HighEmphasis = true;
            btnManageEmployees.Icon = null;
            btnManageEmployees.Location = new Point(51, 63);
            btnManageEmployees.Margin = new Padding(4, 6, 4, 6);
            btnManageEmployees.MouseState = MaterialSkin.MouseState.HOVER;
            btnManageEmployees.Name = "btnManageEmployees";
            btnManageEmployees.NoAccentTextColor = Color.Empty;
            btnManageEmployees.Size = new Size(171, 36);
            btnManageEmployees.TabIndex = 3;
            btnManageEmployees.Text = "Gerir funcionários";
            btnManageEmployees.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnManageEmployees.UseAccentColor = false;
            btnManageEmployees.UseVisualStyleBackColor = true;
            btnManageEmployees.Click += btnManageEmployees_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageEmployees);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnManageEmployees;
    }
}