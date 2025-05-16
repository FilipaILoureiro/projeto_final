using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Models;

namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    public partial class AddProductForm : Form
    {
        private string imagePath = "";
        public AddProductForm()
        {
            InitializeComponent();
            cbIVA.Items.AddRange(new object[] { 0, 6, 13, 23 });
        }

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    pictureBoxProduto.Image = Image.FromFile(imagePath);
                    pictureBoxProduto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int quantidade = (int)numQuantidade.Value;
            double preco = double.TryParse(txtPreco.Text, out double p) ? p : 0;
            int iva = (int)cbIVA.SelectedItem;

            // Inserir na base de dados
            int novoId = -1;
            using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO produtos (nome, quantidade, preco, iva) VALUES (@nome, @quantidade, @preco, @iva); SELECT last_insert_rowid();", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@iva", iva);
                novoId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Guardar imagem na pasta resources com o nome do novo ID
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                string destino = Path.Combine("resources", $"{novoId}.png");
                Directory.CreateDirectory("resources"); // Garante que a pasta existe
                File.Copy(imagePath, destino, true);
            }

            MessageBox.Show("Produto adicionado com sucesso!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

