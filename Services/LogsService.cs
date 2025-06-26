using PadariaApp;
using System.Data.SQLite;

namespace projetoPadariaApp.Services
{
    public static class LogsService
    {
        public static void RegistarLog(int? idFuncionario, string descricao)
        {
            // aceitar só null como inválido; zero nunca é chave válida em AUTOINCREMENT
            if (idFuncionario is null)
            {
                Console.WriteLine("ID do funcionário não encontrado. Log ignorado.");
                return;
            }

            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    const string sql = "INSERT INTO log (id_funcionario, descricao) VALUES (@id, @desc)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idFuncionario);
                        cmd.Parameters.AddWithValue("@desc", descricao);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar log: {ex.Message}");
            }
        }

        /* Se quiseres conveniência:
        public static void RegistarLog(string descricao) =>
            RegistarLog(Session.FuncionarioId, descricao);
        */
    }

}
