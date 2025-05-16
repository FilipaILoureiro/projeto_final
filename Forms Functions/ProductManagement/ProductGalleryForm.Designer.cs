namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    partial class ProductGalleryForm
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

        private void InitializeComponent()
        {
            gallery = new FlowLayoutPanel();
            btnConfirmar = new Button();
            SuspendLayout();
            // 
            // gallery
            // 
            gallery.AutoScroll = true;
            gallery.Location = new Point(12, 12);
            gallery.Name = "gallery";
            gallery.Size = new Size(1065, 400);
            gallery.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(454, 440);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(218, 53);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // ProductGalleryForm
            // 
            ClientSize = new Size(1104, 516);
            Controls.Add(gallery);
            Controls.Add(btnConfirmar);
            Name = "ProductGalleryForm";
            Text = "Escolher Produtos";
            ResumeLayout(false);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private FlowLayoutPanel gallery;
        private Button btnConfirmar;
    }
}