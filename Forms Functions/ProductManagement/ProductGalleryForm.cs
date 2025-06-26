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
        private List<ProductControl> productControls = new();

        public ProductGalleryForm()
        {
            InitializeComponent();
            LoadProducts();
            UpdateTotalDisplay();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        public ProductGalleryForm(List<(int productId, int quantidade)> produtosSelecionados)
        {
            InitializeComponent();
            produtosIniciais = produtosSelecionados ?? new List<(int productId, int quantidade)>();
            LoadProducts();
            UpdateTotalDisplay();
        }

        private void LoadProducts()
        {
            var produtos = new List<(int productId, string nome, Image imagem, double preco)>();

            string pastaImagens = Path.Combine(Application.StartupPath, "Resources");
            string caminhoDefault = Path.Combine(pastaImagens, "default.png");

            try
            {
                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT id, nome, imagem, preco FROM produtos ORDER BY nome", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            string nomeImagem = reader["imagem"] != DBNull.Value ? reader["imagem"].ToString() : "default.png";
                            double preco = reader["preco"] != DBNull.Value ? Convert.ToDouble(reader["preco"]) : 0.0;
                            string caminhoImagem = Path.Combine(pastaImagens, nomeImagem);

                            Image imagem;
                            try
                            {
                                if (File.Exists(caminhoImagem))
                                    imagem = Image.FromFile(caminhoImagem);
                                else if (File.Exists(caminhoDefault))
                                    imagem = Image.FromFile(caminhoDefault);
                                else
                                    imagem = SystemIcons.Application.ToBitmap();
                            }
                            catch
                            {
                                imagem = SystemIcons.Application.ToBitmap();
                            }

                            produtos.Add((id, nome, imagem, preco));
                        }
                    }
                }

                foreach (var produto in produtos)
                {
                    var quantidadeInicial = produtosIniciais.FirstOrDefault(p => p.productId == produto.productId).quantidade;
                    var productControl = new ProductControl(produto.productId, produto.nome, produto.imagem, produto.preco, quantidadeInicial);
                    productControl.QuantityChanged += ProductControl_QuantityChanged;
                    productControls.Add(productControl);
                    gallery.Controls.Add(productControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductControl_QuantityChanged(object sender, EventArgs e)
        {
            UpdateTotalDisplay();
        }

        private void UpdateTotalDisplay()
        {
            int totalItems = productControls.Sum(pc => pc.Quantity);
            double totalValue = productControls.Sum(pc => pc.Quantity * pc.Price);

            lblTotal.Text = $"Total: {totalItems} itens | Valor: {totalValue:C2}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            foreach (var productControl in productControls)
            {
                bool visible = string.IsNullOrEmpty(searchTerm) ||
                              productControl.ProductName.ToLower().Contains(searchTerm);
                productControl.Visible = visible;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja limpar toda a seleção?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (var productControl in productControls)
                {
                    productControl.Quantity = 0;
                }
                UpdateTotalDisplay();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ProdutosSelecionados.Clear();

            foreach (var productControl in productControls)
            {
                if (productControl.Quantity > 0)
                {
                    ProdutosSelecionados.Add((productControl.ProductId, productControl.ProductName, productControl.Quantity));
                }
            }

            if (ProdutosSelecionados.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um produto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                    "Tem a certeza que pretende sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    public class ProductControl : Panel
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public double Price { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Quantity
        {
            get => (int)numericQuantity.Value;
            set => numericQuantity.Value = Math.Max(0, Math.Min(value, 999));
        }

        private PictureBox pictureBox;
        private Label labelName;
        private Label labelPrice;
        private NumericUpDown numericQuantity;
        private Button btnAdd;
        private Button btnRemove;

        public event EventHandler QuantityChanged;

        public ProductControl(int productId, string name, Image image, double price, int initialQuantity = 0)
        {
            ProductId = productId;
            ProductName = name;
            Price = price;

            SetupControl();
            SetupComponents(image, initialQuantity);
        }

        private void SetupControl()
        {
            Size = new Size(200, 280);
            BackColor = Color.White;
            Margin = new Padding(10);

            // Adicionar sombra com borda
            Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);
            };
        }

        private void SetupComponents(Image image, int initialQuantity)
        {
            // Imagem do produto
            pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(160, 120),
                Location = new Point(20, 15),
                Cursor = Cursors.Hand
            };
            pictureBox.Click += (s, e) => { Quantity++; };

            // Nome do produto
            labelName = new Label
            {
                Text = ProductName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                Size = new Size(160, 40),
                Location = new Point(20, 145),
                TextAlign = ContentAlignment.TopCenter
            };

            // Preço
            labelPrice = new Label
            {
                Text = Price.ToString("C2"),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(51, 122, 183),
                Size = new Size(160, 20),
                Location = new Point(20, 185),
                TextAlign = ContentAlignment.TopCenter
            };

            // Controles de quantidade
            int controlWidth = 200;
            int groupY = 215;  // Altura comum dos botões e do NumericUpDown

            // Larguras
            int btnSize = 25;
            int numericWidth = 60;
            int spacing = 5;

            // Cálculo da posição central total
            int totalWidth = btnSize + spacing + numericWidth + spacing + btnSize;
            int startX = (controlWidth - totalWidth) / 2;

            // Botão -
            btnRemove = new Button
            {
                Text = "-",
                Size = new Size(btnSize, btnSize),
                Location = new Point(startX, groupY),
                BackColor = Color.FromArgb(217, 83, 79),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.Click += (s, e) => { if (Quantity > 0) Quantity--; };

            // NumericUpDown (ao centro)
            numericQuantity = new NumericUpDown
            {
                Size = new Size(numericWidth, btnSize),
                Location = new Point(startX + btnSize + spacing, groupY),
                Minimum = 0,
                Maximum = 999,
                Value = initialQuantity,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Segoe UI", 9),
                BorderStyle = BorderStyle.FixedSingle
            };
            numericQuantity.ValueChanged += (s, e) => QuantityChanged?.Invoke(this, EventArgs.Empty);

            // Botão +
            btnAdd = new Button
            {
                Text = "+",
                Size = new Size(btnSize, btnSize),
                Location = new Point(startX + btnSize + spacing + numericWidth + spacing, groupY),
                BackColor = Color.FromArgb(92, 184, 92),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0),
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (s, e) => { Quantity++; };

            // Adicionar todos os controles
            Controls.AddRange(new Control[] { pictureBox, labelName, labelPrice, btnRemove, numericQuantity, btnAdd });

            // Efeito hover
            MouseEnter += (s, e) => BackColor = Color.FromArgb(248, 248, 248);
            MouseLeave += (s, e) => BackColor = Color.White;
        }
    }
}
