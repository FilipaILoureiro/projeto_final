using PadariaApp;
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

namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    public partial class EditSupplierForm : Form
    {
        private int fornecedorID;
        private string senhaAtual;
        public EditSupplierForm(int id)
        {
            InitializeComponent();
            fornecedorID = id;
            LoadDadosSupplier();
        }
        private void LoadDadosSupplier()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    Console.WriteLine($"Carregando dados para o fornecedor com ID: {fornecedorID}");

                    string query = @"SELECT id, nome, contacto, email, tempo_de_entrega FROM fornecedor WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", fornecedorID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNome.Text = reader["nome"].ToString();
                                txtContacto.Text = reader["contacto"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtTempodeEntrega.Text = reader["tempo_de_entrega"].ToString();


                            }
                            else
                            {
                                MessageBox.Show($"Nenhum funcionário encontrado com ID {fornecedorID}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados do fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EditSupplierForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Log inicial
                Console.WriteLine("Iniciando atualização de fornecedor");
                Console.WriteLine($"ID do Fornecedor: {fornecedorID}");

                // Verificações de campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("O nome não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContacto.Text))
                {
                    MessageBox.Show("O contacto não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("O email não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTempodeEntrega.Text))
                {
                    MessageBox.Show("O tempo de entrega não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Log dos valores
                Console.WriteLine($"Nome: {txtNome.Text}");
                Console.WriteLine($"Contacto: {txtContacto.Text}");
                Console.WriteLine($"Email: {txtEmail.Text}");
                Console.WriteLine($"Tempo de Entrega: {txtTempodeEntrega.Text}");

                // Conexão e atualização
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("Conexão com banco de dados estabelecida");

                    // Verificação de email único (opcional, dependendo do projeto)
                    string checkEmailQuery = "SELECT COUNT(*) FROM fornecedor WHERE email = @Email AND id != @id";
                    using (var checkCmd = new SQLiteCommand(checkEmailQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        checkCmd.Parameters.AddWithValue("@id", fornecedorID);

                        int existingEmailCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existingEmailCount > 0)
                        {
                            MessageBox.Show("Este email já está cadastrado. Escolha outro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Preparar e executar a query de atualização
                    string query = @"UPDATE fornecedor 
                         SET nome = @nome, 
                             contacto = @contacto, 
                             email = @email, 
                             tempo_de_entrega = @tempo 
                         WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        Console.WriteLine($"Query de atualização: {query}");

                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@contacto", txtContacto.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@tempo", txtTempodeEntrega.Text);
                        cmd.Parameters.AddWithValue("@id", fornecedorID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        Console.WriteLine($"Linhas afetadas: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Fornecedor atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro completo: {ex}");
                MessageBox.Show($"Erro inesperado: {ex.Message}\n\nDetalhes:\n{ex.StackTrace}",
                    "Erro Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
