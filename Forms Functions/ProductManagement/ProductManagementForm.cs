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

            // Configurar seleção de linha
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

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
            var produto = CarregarProdutoPorId(produtoId);

            var formEditar = new EditProductForm(produto);
            formEditar.ShowDialog();

            ListarProdutos();
        }

        private Product CarregarProdutoPorId(int produtoId)
        {
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
            var resultado = MessageBox.Show("Tem certeza que deseja remover este produto?", "Confirmar remoção", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                using var conn = new SQLiteConnection("Data Source=padaria.db");
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM produtos WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", produtoId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto removido com sucesso!");

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

