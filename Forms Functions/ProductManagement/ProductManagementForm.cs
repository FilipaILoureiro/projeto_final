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
    public partial class ProductManagementForm : Form
    {
        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            ListarProdutos();
        }

        public ProductManagementForm()
        {
            InitializeComponent();
            this.Load += ProductManagementForm_Load;

        }

        private void ConfigurarDataGridView()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = true;


            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "btnEditar",
                HeaderText = "Editar",
                Text = "✏️ Editar",
                UseColumnTextForButtonValue = true
            };
            dgvProducts.Columns.Add(btnEditar);

            var btnRemover = new DataGridViewButtonColumn
            {
                Name = "btnRemover",
                HeaderText = "Remover",
                Text = "🗑️ Remover",
                UseColumnTextForButtonValue = true
            };
            dgvProducts.Columns.Add(btnRemover);

            // Configurar seleção de linha
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;  // Permitir selecionar uma linha de cada vez

            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }


        private void ListarProdutos()
        {
            List<Product> produtos = new List<Product>();

            using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM produtos", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                produtos.Add(new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nome = reader["nome"].ToString(),
                    Quantidade = Convert.ToInt32(reader["quantidade"]),
                    Preco = Convert.ToDouble(reader["preco"]),
                    Iva = Convert.ToInt32(reader["iva"])
                });
            }

            dgvProducts.DataSource = null; // limpa se já estava ligado
            dgvProducts.DataSource = produtos;

            if (!dgvProducts.Columns.Contains("btnEditar"))
            {
                var btnEditar = new DataGridViewButtonColumn
                {
                    Name = "btnEditar",
                    HeaderText = "Editar",
                    Text = "✏️ Editar",
                    UseColumnTextForButtonValue = true
                };
                dgvProducts.Columns.Add(btnEditar);
            }

            if (!dgvProducts.Columns.Contains("btnRemover"))
            {
                var btnRemover = new DataGridViewButtonColumn
                {
                    Name = "btnRemover",
                    HeaderText = "Remover",
                    Text = "🗑️ Remover",
                    UseColumnTextForButtonValue = true
                };
                dgvProducts.Columns.Add(btnRemover);
            }


            reader.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var produtoSelecionado = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
                if (produtoSelecionado == null) return;

                int produtoId = produtoSelecionado.Id;

                if (dgvProducts.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    EditarProduto(produtoId);
                }
                else if (dgvProducts.Columns[e.ColumnIndex].Name == "btnRemover")
                {
                    RemoverProduto(produtoId);
                }
            }
        }

        private void EditarProduto(int produtoId)
        {
            // Carregar os dados do produto selecionado
            var produto = CarregarProdutoPorId(produtoId);

            // Exibir os dados em um formulário de edição ou atualizar a DataGridView
            // Exemplo: abrir um formulário de edição de produto (você pode adaptar conforme seu design)
            var formEditar = new EditProductForm(produto);
            formEditar.ShowDialog();

            // Após editar, atualizar a lista de produtos na DataGridView
            ListarProdutos();
        }

        private Product CarregarProdutoPorId(int produtoId)
        {
            // Recuperar os dados do produto do banco de dados pelo ID
            // Este código pode ser adaptado conforme sua estrutura de banco de dados
            Product product = null;
            using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM produtos WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", produtoId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"].ToString(),
                        Quantidade = Convert.ToInt32(reader["quantidade"]),
                        Preco = Convert.ToDouble(reader["preco"]),
                        Iva = Convert.ToInt32(reader["iva"])
                    };
                }

                reader.Close();
            }

            return product;
        }

        private void RemoverProduto(int produtoId)
        {
            // Confirmar com o usuário antes de remover
            var resultado = MessageBox.Show("Tem certeza que deseja remover este produto?", "Confirmar remoção", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                using var conn = new SQLiteConnection("Data Source=padaria.db");
                conn.Open();

                // Comando SQL para remover o produto
                var cmd = new SQLiteCommand("DELETE FROM produtos WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", produtoId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto removido com sucesso!");

                // Atualizar a lista de produtos após a remoção
                ListarProdutos();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                ListarProdutos();
            }
        }
    }
}

