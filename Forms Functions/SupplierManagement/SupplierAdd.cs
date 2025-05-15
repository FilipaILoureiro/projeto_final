using PadariaApp;
using projetoPadariaApp.Services;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    public partial class SupplierAdd : Form
    {
        // Para adicionar o caminho para o ficheiro database
        private static readonly string connectionString = "Data Source=projetoPadariaApp.db;Version=3;";

        public static bool RegisterSupplier(string nome, string contacto, string email, string tempoDeEntrega)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(contacto) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(tempoDeEntrega))
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
                        string query = "INSERT INTO fornecedor (nome, contacto, email, tempo_de_entrega) VALUES (@nome, @contacto, @email, @tempoDeEntrega)";

                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@contacto", contacto);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@tempoDeEntrega", tempoDeEntrega);

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

        public SupplierAdd()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string contacto = txtContacto.Text;
            string email = txtEmail.Text;
            string tempoDeEntrega = txtTempodeEntrega.Text;

            bool success = RegisterSupplier(nome, contacto, email, tempoDeEntrega);

            if (success)
            {
                MessageBox.Show("Fornecedor registado com sucesso!");

                // Verificar se a sessão está configurada corretamente
                if (Session.FuncionarioId.HasValue && Session.FuncionarioId.Value > 0)
                {
                    LogsService.RegistarLog(Session.FuncionarioId.Value, $"Fornecedor '{nome}' registado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro: Funcionário não autenticado.");
                }

                // Limpar campos após registro bem-sucedido
                txtNome.Clear();
                txtContacto.Clear();
                txtEmail.Clear();
                txtTempodeEntrega.Clear();
            }
            else
            {
                MessageBox.Show("Erro ao registar fornecedor.");

                // Log de falha na tentativa de registrar fornecedor
                if (Session.FuncionarioId.HasValue && Session.FuncionarioId.Value > 0)
                {
                    LogsService.RegistarLog(Session.FuncionarioId.Value, $"Tentativa falhada de registar o fornecedor '{nome}'.");
                }
            }
        }
    }
}
