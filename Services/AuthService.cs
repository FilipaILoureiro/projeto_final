using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Properties.Style;

namespace projetoPadariaApp.Services
{
    public class AuthService
    {
        /// <summary>
        /// Autentica um utilizador verificando se a password está correta e se tem uma password temporária
        /// </summary>
        /// <param name="username">Nome de utilizador</param>
        /// <param name="password">Password fornecida</param>
        /// <param name="needsPasswordChange">Indica se o utilizador precisa de alterar a password</param>
        /// <param name="userId">ID do utilizador (se autenticado com sucesso)</param>
        /// <returns>True se a autenticação foi bem-sucedida</returns>
        public static bool AuthenticateUser(string username, string password, out bool needsPasswordChange, out int userId)
        {
            needsPasswordChange = false;
            userId = 0;

            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    // Verificar se o utilizador existe e está ativo
                    string query = @"SELECT id, pass, COALESCE(usar_pass_temp, 'N') as usar_temp, COALESCE(ativo, 'S') as ativo 
                           FROM funcionario 
                           WHERE username = @username";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ativo = reader["ativo"].ToString();
                                if (ativo == "N" || ativo == "0")
                                {
                                    MessageBox.Show("Esta conta está desativada. Contacte o administrador.", "Acesso Negado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                                userId = Convert.ToInt32(reader["id"]);
                                string storedPassword = reader["pass"].ToString();

                                // CORREÇÃO: Converter corretamente 'S'/'N' para boolean
                                string usarTempStr = reader["usar_temp"].ToString();
                                bool usarTemp = usarTempStr == "S" || usarTempStr == "1";

                                if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                                {
                                    needsPasswordChange = usarTemp;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a autenticação: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Versão simplificada para compatibilidade com código existente
        /// </summary>
        public static bool AuthenticateUser(string username, string password)
        {
            return AuthenticateUser(username, password, out _, out _);
        }

        /// <summary>
        /// Regista um novo utilizador no sistema
        /// </summary>
        public static bool RegisterUser(string nome, string contacto, string username, string password, int id_funcao, bool isAdmin = false)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(contacto))
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro de Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("A password deve ter pelo menos 6 caracteres.", "Erro de Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM funcionario WHERE username = @username";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Este nome de utilizador já existe. Escolha outro.", "Username Duplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                            string insertQuery = @"INSERT INTO funcionario (nome, contacto, username, pass, id_funcao, ativo) 
                                                 VALUES (@nome, @contacto, @username, @pass, @id_funcao, 'S')";

                            using (var cmd = new SQLiteCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", nome);
                                cmd.Parameters.AddWithValue("@contacto", contacto);
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@pass", hashedPassword);
                                cmd.Parameters.AddWithValue("@id_funcao", id_funcao);

                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    int userId = (int)conn.LastInsertRowId;

                                    string adminValue = isAdmin ? "S" : "N";
                                    string adminQuery = "INSERT INTO tipo_de_func (id_funcionario, admin) VALUES (@userId, @admin)";

                                    using (var adminCmd = new SQLiteCommand(adminQuery, conn, transaction))
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
                            MessageBox.Show($"Erro durante o registo: {ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar à base de dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Verifica se um utilizador é administrador
        /// </summary>
        public static bool IsAdmin(string username)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT t.admin 
                                   FROM tipo_de_func t
                                   INNER JOIN funcionario f ON t.id_funcionario = f.id
                                   WHERE f.username = @username AND COALESCE(f.ativo, 'S') = 'S'";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var result = cmd.ExecuteScalar();
                        return result != null && result.ToString() == "S";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar privilégios de admin: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Promove um utilizador a administrador
        /// </summary>
        public static bool PromoteToAdmin(string loggedUsername, string targetUsername)
        {
            if (!Session.IsLoggedIn || !Session.IsAdmin)
            {
                MessageBox.Show("Apenas administradores podem realizar esta ação.", "Acesso Negado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string checkQuery = @"SELECT f.id, t.admin 
                                        FROM funcionario f
                                        LEFT JOIN tipo_de_func t ON f.id = t.id_funcionario
                                        WHERE f.username = @username AND COALESCE(f.ativo, 'S') = 'S'";

                    using (var cmd = new SQLiteCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", targetUsername);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["id"]);
                                string currentAdmin = reader["admin"]?.ToString();

                                reader.Close();

                                if (currentAdmin == "S")
                                {
                                    MessageBox.Show("Este utilizador já é administrador.", "Informação",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }

                                // Atualizar ou inserir registo de admin
                                string updateQuery;
                                if (string.IsNullOrEmpty(currentAdmin))
                                {
                                    updateQuery = "INSERT INTO tipo_de_func (id_funcionario, admin) VALUES (@userId, 'S')";
                                }
                                else
                                {
                                    updateQuery = "UPDATE tipo_de_func SET admin = 'S' WHERE id_funcionario = @userId";
                                }

                                using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@userId", userId);
                                    int rows = updateCmd.ExecuteNonQuery();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show($"Utilizador '{targetUsername}' promovido a administrador com sucesso!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Utilizador não encontrado ou está desativo.", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao promover utilizador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Redefine a password de um utilizador, gerando uma password temporária
        /// </summary>
        public static bool ResetPassword(string username)
        {
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();

                string checkQuery = "SELECT id, nome, COALESCE(ativo, 'S') as ativo FROM funcionario WHERE username = @username";
                using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    var reader = checkCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string nome = reader["nome"].ToString();
                        string ativo = reader["ativo"].ToString();
                        reader.Close();

                        if (ativo == "N")
                        {
                            MessageBox.Show("Não é possível redefinir a senha de um funcionário desativado.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        string newPassword = GenerateTemporaryPassword();
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                        string updateQuery = @"UPDATE funcionario 
                                        SET pass = @newPass, usar_pass_temp = 'S' 
                                        WHERE username = @username";

                        using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@newPass", hashedPassword);
                            updateCmd.Parameters.AddWithValue("@username", username);
                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                using (var dialog = new PasswordTempDialog(newPassword, nome, username))
                                {
                                    dialog.ShowDialog();
                                }
                                return true;
                            }
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Utilizador não encontrado.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gera uma password temporária segura
        /// </summary>
        private static string GenerateTemporaryPassword(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%&*";
            Random rand = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Verifica se um utilizador tem uma password temporária ativa
        /// </summary>
        public static bool HasTemporaryPassword(string username)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COALESCE(usar_pass_temp, 'N') FROM funcionario WHERE username = @username";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var result = cmd.ExecuteScalar();

                        string resultStr = result?.ToString() ?? "N";
                        return resultStr == "S" || resultStr == "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar password temporária: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtém informações básicas do utilizador
        /// </summary>
        public static UserInfo GetUserInfo(string username)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT f.id, f.nome, f.username, f.contacto, 
                                           func.funcao, COALESCE(t.admin, 'N') as admin,
                                           COALESCE(f.ativo, 'S') as ativo
                                   FROM funcionario f
                                   LEFT JOIN funcao func ON f.id_funcao = func.id_funcao
                                   LEFT JOIN tipo_de_func t ON f.id = t.id_funcionario
                                   WHERE f.username = @username";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserInfo
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Nome = reader["nome"].ToString(),
                                    Username = reader["username"].ToString(),
                                    Contacto = reader["contacto"].ToString(),
                                    Funcao = reader["funcao"]?.ToString() ?? "N/A",
                                    IsAdmin = reader["admin"].ToString() == "S",
                                    IsAtivo = reader["ativo"].ToString() == "S"
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter informações do utilizador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }

    /// <summary>
    /// Classe para armazenar informações do utilizador
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Contacto { get; set; }
        public string Funcao { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAtivo { get; set; }
    }
}