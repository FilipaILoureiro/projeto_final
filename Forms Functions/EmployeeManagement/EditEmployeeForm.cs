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
using PadariaApp;
using BCrypt.Net;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    public partial class EditEmployeeForm : Form
    {
        private int funcionarioID;
        private string senhaAtual;

        public EditEmployeeForm(int id)
        {
            InitializeComponent();
            funcionarioID = id;
            LoadFuncoes();
            LoadDadosFuncionario();
        }

        private void LoadFuncoes()
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT [id_funcao], [funcao] FROM [funcao]";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cbFuncao.DataSource = dt;
                    cbFuncao.DisplayMember = "funcao";
                    cbFuncao.ValueMember = "id_funcao";

                    Console.WriteLine("Funções carregadas na ComboBox:");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"ID: {row["id_funcao"]}, Função: {row["funcao"]}");
                    }
                }
            }
        }

        private void LoadDadosFuncionario()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    Console.WriteLine($"Carregando dados para o funcionário com ID: {funcionarioID}");

                    string query = @"SELECT id, nome, contacto, username, pass, id_funcao FROM funcionario WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", funcionarioID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNome.Text = reader["nome"].ToString();
                                txtContacto.Text = reader["contacto"].ToString();
                                txtUsername.Text = reader["username"].ToString();
                                senhaAtual = reader["pass"].ToString();

                                // Certificar que o ID da função é um inteiro e está presente na ComboBox
                                int idFuncao = Convert.ToInt32(reader["id_funcao"]);
                                cbFuncao.SelectedValue = idFuncao;
                                Console.WriteLine($"ID da função definida na ComboBox: {idFuncao}");

                                // Verificar se a função foi selecionada corretamente
                                if (cbFuncao.SelectedValue == null)
                                {
                                    MessageBox.Show("Erro: A função do funcionário não foi definida corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Nenhum funcionário encontrado com ID {funcionarioID}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados do funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Log inicial
                Console.WriteLine("Iniciando atualização de funcionário");
                Console.WriteLine($"ID do Funcionário: {funcionarioID}");

                // Verificações de campos
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("O nome não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("O username não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar se a função foi selecionada corretamente
                if (cbFuncao.SelectedValue == null)
                {
                    MessageBox.Show("Erro: Nenhuma função foi selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Log dos valores
                Console.WriteLine($"Nome: {txtNome.Text}");
                Console.WriteLine($"Contacto: {txtContacto.Text}");
                Console.WriteLine($"Username: {txtUsername.Text}");
                Console.WriteLine($"ID Função Selecionada: {cbFuncao.SelectedValue}");

                // Conexão e atualização
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    // Log da conexão
                    Console.WriteLine("Conexão com banco de dados estabelecida");

                    // Verificação de username único
                    string checkUsernameQuery = "SELECT COUNT(*) FROM funcionario WHERE username = @username AND id != @id";
                    using (var checkCmd = new SQLiteCommand(checkUsernameQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        checkCmd.Parameters.AddWithValue("@id", funcionarioID);

                        int existingUserCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existingUserCount > 0)
                        {
                            MessageBox.Show("Username já existe. Escolha outro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Preparação da query de update
                    string query = @"UPDATE funcionario SET nome=@nome, contacto=@contacto, username=@username, pass=@pass, id_funcao=@id_funcao WHERE id=@id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        // Log da query
                        Console.WriteLine($"Query de atualização: {query}");

                        // Preparação dos parâmetros
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@contacto", txtContacto.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);

                        // Tratamento da senha
                        string senhaFinal = string.IsNullOrEmpty(txtPass.Text)
                            ? senhaAtual
                            : BCrypt.Net.BCrypt.HashPassword(txtPass.Text);
                        cmd.Parameters.AddWithValue("@pass", senhaFinal);

                        cmd.Parameters.AddWithValue("@id_funcao", cbFuncao.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", funcionarioID);

                        // Execução do update
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Log do resultado
                        Console.WriteLine($"Linhas afetadas: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            // LOGS AQUI!!
                            LogsService.RegistarLog(
                            Session.FuncionarioId,
                             $"Actualizou funcionário #{funcionarioID} → " +
                             $"Nome: {txtNome.Text}, Contacto: {txtContacto.Text}, " +
                             $"Username: {txtUsername.Text}, Função: {cbFuncao.Text}" +
                               (string.IsNullOrEmpty(txtPass.Text) ? "" : ", Senha alterada"));

                            MessageBox.Show("Funcionário actualizado com sucesso!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do funcionário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log detalhado do erro
                Console.WriteLine($"Erro completo: {ex}");
                MessageBox.Show($"Erro inesperado: {ex.Message}\n\nDetalhes:\n{ex.StackTrace}",
                    "Erro Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtNome_Click(object sender, EventArgs e)
        {

        }
    }
}
