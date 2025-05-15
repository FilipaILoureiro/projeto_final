using PadariaApp;
using System.Data.SQLite;

namespace projetoPadariaApp.Services
{
    public static class LogsService
    {
        public static void RegistarLog(int? idFuncionario, string descricao)
        {
            try
            {
                if (idFuncionario == null || idFuncionario == 0)
                {
                    Console.WriteLine("Erro: ID do funcionário não encontrado.");
                    return;  // Se o idFuncionario for nulo ou 0, não registra o log
                }

                var conn = DatabaseManage.GetInstance().GetConnection();
                conn.Open();

                string query = @"INSERT INTO log (id_funcionario, descricao) 
                                 VALUES (@id_funcionario, @descricao)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_funcionario", idFuncionario);
                    cmd.Parameters.AddWithValue("@descricao", descricao);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                // Log de erro
                Console.WriteLine("Erro ao gravar log: " + ex.Message);
            }
        }
    }
}
