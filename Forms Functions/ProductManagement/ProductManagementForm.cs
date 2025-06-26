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
        private DataTable productsTable;
        private DataView productsView;

        public ProductManagementForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            LoadProducts();
        }

        private void ConfigurarEventHandlers()
        {
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            dgvProducts.DataBindingComplete += dgvProducts_DataBindingComplete;
            dgvProducts.Resize += dgvProducts_Resize;
        }

        private void dgvProducts_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvProducts.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvProducts.ClientSize.Width;

                dgvProducts.Columns["Id"].Width = (int)(larguraTotal * 0.08);
                dgvProducts.Columns["Nome"].Width = (int)(larguraTotal * 0.35);
                dgvProducts.Columns["Quantidade"].Width = (int)(larguraTotal * 0.15);
                dgvProducts.Columns["Preco"].Width = (int)(larguraTotal * 0.20);
                dgvProducts.Columns["Iva"].Width = (int)(larguraTotal * 0.22);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void AplicarFiltros()
        {
            if (productsTable == null || productsView == null) return;

            try
            {
                string filtro = "";
                if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
                {
                    string pesquisa = txtPesquisa.Text.Trim().Replace("'", "''");

                    if (int.TryParse(pesquisa, out int id))
                    {
                        filtro = $"Id = {id} OR Nome LIKE '%{pesquisa}%'";
                    }
                    else
                    {
                        filtro = $"Nome LIKE '%{pesquisa}%'";
                    }
                }

                productsView.RowFilter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                productsView.RowFilter = "";
            }
        }

        #region Event Handlers para Filtros
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void ConfigurarDataGridView()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersVisible = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvProducts.Columns.Add("Id", "ID");
            dgvProducts.Columns["Id"].DataPropertyName = "Id";
            dgvProducts.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Add("Nome", "Nome do Produto");
            dgvProducts.Columns["Nome"].DataPropertyName = "Nome";
            dgvProducts.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvProducts.Columns.Add("Quantidade", "Quantidade");
            dgvProducts.Columns["Quantidade"].DataPropertyName = "Quantidade";
            dgvProducts.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Add("Preco", "Preço (€)");
            dgvProducts.Columns["Preco"].DataPropertyName = "Preco";
            dgvProducts.Columns["Preco"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProducts.Columns.Add("Iva", "IVA (%)");
            dgvProducts.Columns["Iva"].DataPropertyName = "Iva";
            dgvProducts.Columns["Iva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurações de estilo
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(183, 28, 70);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProducts.ColumnHeadersHeight = 45;

            dgvProducts.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 232, 231);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.GridColor = Color.LightGray;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvProducts.BorderStyle = BorderStyle.Fixed3D;

            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.ScrollBars = ScrollBars.Both;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
        }

        private void LoadProducts()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    connection.Open();
                    string query = @"SELECT * FROM produtos ORDER BY nome";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        productsTable = new DataTable();
                        adapter.Fill(productsTable);

                        productsView = new DataView(productsTable);
                        productsView.RowFilter = ""; // Exibir tudo inicialmente
                        dgvProducts.DataSource = productsView;
                        dgvProducts.Refresh();
                    }
                }

                if (dgvProducts.Rows.Count > 0)
                {
                    AjustarLarguraColunas();
                    dgvProducts.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product CarregarProdutoPorId(int produtoId)
        {
            Product product = null;
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return product;
        }

        private void DeleteProduct(int produtoId)
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string checkQuery = "SELECT COUNT(*) FROM enc_prod WHERE id_prod = @id";
                            using (var checkCmd = new SQLiteCommand(checkQuery, connection, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@id", produtoId);
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count > 0)
                                {
                                    MessageBox.Show("Não é possível remover este produto pois está associado a encomendas.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            string deleteQuery = "DELETE FROM produtos WHERE id = @id";
                            using (var cmd = new SQLiteCommand(deleteQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", produtoId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Produto removido com sucesso!", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadProducts();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Não foi possível remover o produto.", "Aviso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover produto: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Botões de Ação
        private Panel modalContainer;
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                CreateModalContainer();
                LoadAddProductInContainer();
            }
            catch (Exception ex)
            {
                CloseModalContainer();
                MessageBox.Show($"Erro ao abrir formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateModalContainer()
        {
            modalContainer = new Panel
            {
                Size = new Size(837, 600),
                BackColor = Color.FromArgb(0, 89, 89),
                Anchor = AnchorStyles.None,
                BorderStyle = BorderStyle.FixedSingle
            };

            Screen currentScreen = Screen.FromControl(this);
            System.Drawing.Rectangle screenBounds = currentScreen.WorkingArea;
            Point screenCenter = new Point(
                screenBounds.X + (screenBounds.Width - modalContainer.Width) / 2,
                screenBounds.Y + (screenBounds.Height - modalContainer.Height) / 2
            );
            Point relativeLocation = this.PointToClient(screenCenter);
            modalContainer.Location = relativeLocation;

            this.Controls.Add(modalContainer);
            modalContainer.BringToFront();

            // Desativar outros controles
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != modalContainer)
                    ctrl.Enabled = false;
            }
        }

        private void LoadAddProductInContainer()
        {
            AddProductForm addForm = new AddProductForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(addForm);
            addForm.FormClosed += OnAddProductClosed;
            addForm.Show();
        }

        private void OnAddProductClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadProducts();
        }

        private void CloseModalContainer()
        {
            if (modalContainer != null)
            {
                // Reativar outros controles
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl != modalContainer)
                        ctrl.Enabled = true;
                }

                this.Controls.Remove(modalContainer);
                modalContainer.Dispose();
                modalContainer = null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                try
                {
                    int produtoId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                    CreateModalContainer();
                    LoadEditProductInContainer(produtoId);
                }
                catch (Exception ex)
                {
                    CloseModalContainer();
                    MessageBox.Show($"Erro ao abrir formulário de edição: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEditProductInContainer(int produtoId)
        {
            EditProductForm editForm = new EditProductForm(produtoId)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(editForm);
            editForm.FormClosed += OnEditProductClosed;
            editForm.Show();
        }

        private void OnEditProductClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadProducts();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                try
                {
                    int produtoId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                    string nomeProduto = dgvProducts.SelectedRows[0].Cells["Nome"].Value?.ToString();

                    if (MessageBox.Show($"Tem a certeza que deseja remover o produto '{nomeProduto}'?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteProduct(produtoId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar remoção: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtPesquisa.Text = "";
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

