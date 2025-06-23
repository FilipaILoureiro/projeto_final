using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PadariaApp;
using System.Xml;

// vai gerir todos os serviços de autenticação (login, registro e redefinição de senha)

namespace projetoPadariaApp.Services
{
    public class AuthService
    {
        // Função para autenticar o usuário (login)
        public static bool AuthenticateUser(string username, string password)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT pass FROM funcionario WHERE username = @username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string storedPassword = result.ToString();
                        return BCrypt.Net.BCrypt.Verify(password, storedPassword);
                    }
                }
            }
            return false;
        }

        // Função para registrar um novo usuário
        public static bool RegisterUser(string nome, string contacto, string username, string password, int id_funcao, bool isAdmin = false)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(password))
                return false;

            // Criptografar a senha
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var dbManager = DatabaseManage.GetInstance();
            var conn = dbManager.GetConnection();

            try
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Inserir novo usuário na tabela 'funcionario'
                        string query = "INSERT INTO funcionario (nome, contacto, username, pass, id_funcao) VALUES (@nome, @contacto, @username, @pass, @id_funcao)";

                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@contacto", contacto);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@pass", hashedPassword);
                            cmd.Parameters.AddWithValue("@id_funcao", id_funcao);

                            int rows = cmd.ExecuteNonQuery();

                            // Se a inserção for bem-sucedida, adicionar o tipo de usuário à tabela 'tipo_de_func'
                            if (rows > 0)
                            {
                                int userId = (int)conn.LastInsertRowId; // Pega o ID do novo usuário

                                string adminValue = isAdmin ? "S" : "N"; // Se for Admin, "S"; caso contrário, "N"
                                string adminQuery = "INSERT INTO tipo_de_func (id_funcionario, admin) VALUES (@userId, @admin)";

                                using (var adminCmd = new SQLiteCommand(adminQuery, conn))
                                {
                                    adminCmd.Parameters.AddWithValue("@userId", userId);
                                    adminCmd.Parameters.AddWithValue("@admin", adminValue);

                                    adminCmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                return true;
                            }
                        }

                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro durante o registro: " + ex.Message);
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
                // Certifique-se de que a conexão está fechada após o uso
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // Função para verificar se o usuário é admin
        public static bool IsAdmin(string username)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT admin 
                    FROM tipo_de_func 
                    WHERE id_funcionario = (SELECT id FROM funcionario WHERE username = @username)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();

                    return result != null && result.ToString() == "S"; // 'S' indica Admin
                }
            }
        }

        // Função para promover um usuário a admin
        public static bool PromoteToAdmin(string loggedUsername, string username)
        {
            if (IsAdmin(loggedUsername)) // Verifica se o usuário logado é admin
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string query = "SELECT id FROM funcionario WHERE username = @username";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);

                            // Atualiza o tipo de usuário para admin
                            string updateQuery = "UPDATE tipo_de_func SET admin = 'S' WHERE id_funcionario = @userId";
                            using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@userId", userId);
                                int rows = updateCmd.ExecuteNonQuery();

                                return rows > 0; // Retorna true se a atualização foi bem-sucedida
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Apenas administradores podem realizar essa ação.");
            }

            return false;
        }

        // Função para redefinir a senha do usuário
        public static bool ResetPassword(string username)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT id FROM funcionario WHERE nome = @nome";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null) // Usuário encontrado
                    {
                        string newPassword = GenerateTemporaryPassword();
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                        string updateQuery = "UPDATE funcionario SET pass = @newPass WHERE nome = @nome";
                        using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@newPass", hashedPassword);
                            updateCmd.Parameters.AddWithValue("@nome", username);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Nova senha: {newPassword}"); // Em produção, enviaria por email/sms
                        return true;
                    }
                }
            }
            return false;
        }

        // Função para gerar uma senha temporária
        private static string GenerateTemporaryPassword()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Função para manter a sessão do usuário (retorna o ID do funcionário)
        public static int GetFuncionarioId(string username)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT id FROM funcionario WHERE username = @username";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        return id; // Retorna o ID do funcionário
                    }

                    return 000; // Retorna null se não encontrar o usuário
                }
            }
        }
        public static string GetFuncionarioNome(string username)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT nome FROM funcionario WHERE username = @username";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString(); // Retorna o nome do funcionário
                    }

                    return null; // Retorna null se não encontrar o usuário
                }
            }
        }
        public void Login(string nomeFuncionario)
        {
            // Após validar as credenciais
            int funcionarioId = AuthService.GetFuncionarioId(nomeFuncionario); // Retorna o ID do funcionário

            if (funcionarioId > 0)
            {
                // Atribui o ID e o nome na sessão
                Session.FuncionarioId = funcionarioId;
                Session.FuncionarioNome = nomeFuncionario;
            }
            else
            {
                MessageBox.Show("Credenciais inválidas.");
            }
        }

    }
}