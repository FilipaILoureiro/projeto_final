using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Login_e_Registo
{
    public partial class LogsList : Form
    {
        public LogsList()
        {
            InitializeComponent();
            CarregarLogs();
        }

        private void CarregarLogs()
        {
            try
            {
                var conn = DatabaseManage.GetInstance().GetConnection();
                conn.Open();

                string query = @"
                    SELECT 
                        log.id AS ID,
                        log.data AS Data,
                        COALESCE(funcionario.nome, 'Desconhecido') AS Funcionario,
                        log.descricao AS Descrição
                    FROM log
                    LEFT JOIN funcionario ON log.id_funcionario = funcionario.id
                    ORDER BY log.data DESC";

                using (var da = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLogs.DataSource = dt;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar logs: " + ex.Message);
            }
        }

        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento para futuros cliques se quiseres detalhes ou ações
        }
    }
}
