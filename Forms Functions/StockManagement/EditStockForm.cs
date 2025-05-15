using PadariaApp;
using projetoPadariaApp.Services;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static projetoPadariaApp.Forms.registerForm;

namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    public partial class EditStockForm : Form
    {
        private int stockId;

        public EditStockForm(int id)
        {
            InitializeComponent();
            stockId = id;
            cbIva.Items.AddRange(new object[] { 6, 13, 23 });
            LoadFornecedores();
            LoadDadosStock();
        }

        private void LoadFornecedores()
        {
            cbFornecedor.Items.Clear();
            var dbManager = DatabaseManage.GetInstance();
            using (var connection = dbManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT id, nome FROM fornecedor";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var funcaoItem = new FuncaoItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            cbFornecedor.Items.Add(funcaoItem);
                        }
                    }
                }
            }

            cbFornecedor.DisplayMember = "Name";
            cbFornecedor.ValueMember = "Id";
        }

        private void LoadDadosStock()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT nome, preco, quantidade, id_fornecedor, iva FROM materia WHERE id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", stockId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNome.Text = reader["nome"].ToString();
                                txtPreco.Text = reader["preco"].ToString();
                                txtQuantidade.Text = reader["quantidade"].ToString();

                                int fornecedorId = Convert.ToInt32(reader["id_fornecedor"]);
                                int iva = Convert.ToInt32(reader["iva"]);

                                cbIva.SelectedItem = iva;

                                foreach (FuncaoItem item in cbFornecedor.Items)
                                {
                                    if (item.Id == fornecedorId)
                                    {
                                        cbFornecedor.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Stock não encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do stock: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string preco = txtPreco.Text;
            string quantidade = txtQuantidade.Text;

            FuncaoItem selectedFornecedor = cbFornecedor.SelectedItem as FuncaoItem;
            if (selectedFornecedor == null)
            {
                MessageBox.Show("Por favor, selecione um fornecedor.");
                return;
            }

            if (cbIva.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma taxa de IVA.");
                return;
            }

            int fornecedorId = selectedFornecedor.Id;
            int iva = Convert.ToInt32(cbIva.SelectedItem);

            bool sucesso = UpdateStock(nome, preco, quantidade, fornecedorId, iva);

            if (sucesso)
            {
                MessageBox.Show("Stock atualizado com sucesso!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar stock.");
            }
        }

        public bool UpdateStock(string nome, string preco, string quantidade, int id_fornecedor, int iva)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE materia 
                                     SET nome = @nome, 
                                         preco = @preco, 
                                         quantidade = @quantidade, 
                                         id_fornecedor = @id_fornecedor, 
                                         iva = @iva 
                                     WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);
                        cmd.Parameters.AddWithValue("@iva", iva);
                        cmd.Parameters.AddWithValue("@id", stockId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar stock: " + ex.Message);
                return false;
            }
        }
    }
}
