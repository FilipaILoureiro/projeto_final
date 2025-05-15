using PadariaApp;
using projetoPadariaApp.Services;
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
using static projetoPadariaApp.Forms.registerForm;

namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    public partial class StockAdd : Form
    {
        private void LoadFornecedores()
        {
            // Limpar o ComboBox
            cbFornecedor.Items.Clear();

            // Usar a instância singleton do DatabaseManage
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
                            // Criar um objeto para armazenar ID e nome da função
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

            // Configurar o ComboBox para mostrar apenas o nome
            cbFornecedor.DisplayMember = "Name";
            cbFornecedor.ValueMember = "Id";
        }
        //para adicionar o caminho para o ficheiro database
        private static readonly string connectionString = "Data Source=projetoPadariaApp.db;Version=3;";
        public static bool RegisterStock(string nome, string preco, string quantidade, int id_fornecedor , int iva)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(preco) ||
                string.IsNullOrWhiteSpace(quantidade))
                return false;

            var dbManager = DatabaseManage.GetInstance();
            var conn = dbManager.GetConnection();

            try
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO materia (nome, id_fornecedor, preco, quantidade, iva) VALUES (@nome, @id_fornecedor, @preco, @quantidade, @iva)";

                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@preco", preco);
                            cmd.Parameters.AddWithValue("@quantidade", quantidade);
                            cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);
                            cmd.Parameters.AddWithValue("@iva", iva);

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                transaction.Commit();  // Confirma a transação apenas se a inserção foi bem-sucedida
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro durante o registo: " + ex.Message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir conexão: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public StockAdd()
        {
            InitializeComponent();
            cbIva.Items.AddRange(new object[] { 6, 13, 23 }); // <- aqui sim
            LoadFornecedores(); // já podes carregar os fornecedores também logo aqui
        }


        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string preco = txtPreco.Text;
            string quantidade = txtQuantidade.Text;

            FuncaoItem selectedItem = cbFornecedor.SelectedItem as FuncaoItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um fornecedor.");
                return;
            }

            if (cbIva.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma taxa de IVA.");
                return;
            }

            int fornecedorID = selectedItem.Id;
            int iva = Convert.ToInt32(cbIva.SelectedItem);

            bool success = RegisterStock(nome, preco, quantidade, fornecedorID, iva);

            if (success)
            {
                MessageBox.Show("Stock registado com sucesso!");
                txtNome.Clear();
                txtPreco.Clear();
                txtQuantidade.Clear();
                cbIva.SelectedIndex = -1;
                cbFornecedor.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Erro ao registar stock.");
            }
        }


        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void cbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
