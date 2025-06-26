using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Data.SQLite;
using projetoPadariaApp.Models;

namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    public partial class ProductGalleryForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<(int productId, string nome, int quantidade)> ProdutosSelecionados { get; set; } = new();

        private List<(int productId, int quantidade)> produtosIniciais = new();
        private List<(int productId, string nome, int quantidade)> produtosEncomenda = new List<(int productId, string nome, int quantidade)>();

        public ProductGalleryForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        public ProductGalleryForm(List<(int productId, int quantidade)> produtosSelecionados)
        {
            InitializeComponent();
            produtosIniciais = produtosSelecionados;
            LoadProducts();
        }

        private void LoadProducts()
        {
            var produtos = new List<(int productId, string nome, Image imagem)>();

            string pastaImagens = Path.Combine(Application.StartupPath, "Resources");
            string caminhoDefault = Path.Combine(pastaImagens, "default.png");

            using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT id, nome, imagem FROM produtos", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);
                        string nomeImagem = reader["imagem"] != DBNull.Value ? reader["imagem"].ToString() : "default.png";
                        string caminhoImagem = Path.Combine(pastaImagens, nomeImagem);

                        Image imagem;

                        if (!File.Exists(caminhoImagem))
                        {
                            if (File.Exists(caminhoDefault))
                                imagem = Image.FromFile(caminhoDefault);
                            else
                                imagem = SystemIcons.Warning.ToBitmap();
                        }
                        else
                        {
                            imagem = Image.FromFile(caminhoImagem);
                        }

                        produtos.Add((id, nome, imagem));
                    }
                }
            }


            using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                conn.Open();

                foreach (var produto in produtos)
                {
                    // Verifica se o produto já existe na base de dados
                    var cmdCheckProduto = new SQLiteCommand("SELECT COUNT(*) FROM produtos WHERE id = @id", conn);
                    cmdCheckProduto.Parameters.AddWithValue("@id", produto.productId);
                    var existe = Convert.ToInt32(cmdCheckProduto.ExecuteScalar()) > 0;

                    // Se não existir, insere o produto na tabela
                    if (!existe)
                    {
                        var cmdInsertProduto = new SQLiteCommand(
                            "INSERT INTO produtos (id, nome, quantidade, preco) VALUES (@id, @nome, @quantidade, @preco)", conn);
                        cmdInsertProduto.Parameters.AddWithValue("@id", produto.productId);
                        cmdInsertProduto.Parameters.AddWithValue("@nome", produto.nome);
                        cmdInsertProduto.Parameters.AddWithValue("@quantidade", 0);  // Definir quantidade inicial
                        cmdInsertProduto.Parameters.AddWithValue("@preco", 1.0);  // Definir um preço padrão
                        cmdInsertProduto.ExecuteNonQuery();
                    }
                }
            }

            // Agora carrega os produtos na galeria
            foreach (var produto in produtos)
            {
                var panel = new Panel
                {
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                var picture = new PictureBox
                {
                    Image = produto.imagem,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 130,
                    Height = 100,
                    Top = 10,
                    Left = 10,
                    Tag = produto.productId // Vamos adicionar o ID do produto para identificar o produto clicado
                };

                // Adiciona o evento de clique na imagem para adicionar o produto à encomenda
                picture.Click += (sender, e) =>
                {
                    AdicionarProdutoEncomenda((int)((PictureBox)sender).Tag);
                };

                var label = new Label
                {
                    Text = produto.nome,
                    Top = 120,
                    Width = 130,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var numeric = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = 100,
                    Top = 150,
                    Left = 35,
                    Width = 80,
                    Tag = produto.productId
                };

                // Adicionar o evento de mudança na quantidade
                numeric.ValueChanged += (sender, e) =>
                {
                    AtualizarQuantidadeEncomenda((int)((NumericUpDown)sender).Tag, (int)((NumericUpDown)sender).Value);
                };

                panel.Controls.Add(picture);
                panel.Controls.Add(label);
                panel.Controls.Add(numeric);
                gallery.Controls.Add(panel);
            }
        }

        private void AdicionarProdutoEncomenda(int produtoId)
        {
            // Verifica se o produto já foi adicionado à lista de encomenda
            var produtoExistente = produtosEncomenda.FirstOrDefault(p => p.productId == produtoId);

            // Se o produto já foi adicionado, apenas aumenta a quantidade
            if (produtoExistente != default)
            {
                produtoExistente.quantidade++;
            }
            else
            {
                var produto = (produtoId, string.Empty, 1);  // Inicializa a tupla com a quantidade 1

                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT nome FROM produtos WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", produtoId);
                    var nomeProduto = cmd.ExecuteScalar().ToString();

                    produto = (produtoId, nomeProduto, 1); // Definir a quantidade inicial como 1
                }

                produtosEncomenda.Add(produto);
            }

            MessageBox.Show($"Produto {produtosEncomenda.FirstOrDefault(p => p.productId == produtoId).nome} adicionado à encomenda.");
        }


        private void AtualizarQuantidadeEncomenda(int produtoId, decimal quantidade)
        {
            // Atualiza a quantidade de produto na encomenda
            var produtoEncomenda = produtosEncomenda.FirstOrDefault(p => p.productId == produtoId);
            if (produtoEncomenda != default)
            {
                produtoEncomenda.quantidade = (int)quantidade;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ProdutosSelecionados.Clear();

            // Adiciona os produtos selecionados à lista ProdutosSelecionados
            foreach (Panel panel in gallery.Controls)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is NumericUpDown numeric && numeric.Value > 0)
                    {
                        int productId = (int)numeric.Tag;
                        string nome = ((Label)panel.Controls[1]).Text;
                        int quantidade = (int)numeric.Value;

                        ProdutosSelecionados.Add((productId, nome, quantidade));
                    }
                }
            }

            // Retorna para o formulário principal
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
