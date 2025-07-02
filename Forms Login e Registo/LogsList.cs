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
        private DataTable logsTable;
        private DataView logsView;

        public LogsList()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            CarregarLogs();
        }

        private void ConfigurarEventHandlers()
        {
            dgvLogs.DataBindingComplete += dgvLogs_DataBindingComplete;
            dgvLogs.Resize += dgvLogs_Resize;
        }

        private void dgvLogs_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvLogs.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvLogs.ClientSize.Width;

                dgvLogs.Columns["ID"].Width = (int)(larguraTotal * 0.08);
                dgvLogs.Columns["Data"].Width = (int)(larguraTotal * 0.20);
                dgvLogs.Columns["Funcionario"].Width = (int)(larguraTotal * 0.20);
                dgvLogs.Columns["Descrição"].Width = (int)(larguraTotal * 0.52);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void dgvLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void ConfigurarDataGridView()
        {
            dgvLogs.Columns.Clear();
            dgvLogs.AutoGenerateColumns = false;
            dgvLogs.ColumnHeadersVisible = true;
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvLogs.Columns.Add("ID", "ID");
            dgvLogs.Columns["ID"].DataPropertyName = "ID";
            dgvLogs.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLogs.Columns.Add("Data", "Data");
            dgvLogs.Columns["Data"].DataPropertyName = "Data";
            dgvLogs.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLogs.Columns.Add("Funcionario", "Funcionário");
            dgvLogs.Columns["Funcionario"].DataPropertyName = "Funcionario";
            dgvLogs.Columns["Funcionario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvLogs.Columns.Add("Descrição", "Descrição");
            dgvLogs.Columns["Descrição"].DataPropertyName = "Descrição";
            dgvLogs.Columns["Descrição"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Configurações de estilo
            dgvLogs.EnableHeadersVisualStyles = false;
            dgvLogs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 135, 44); 
            dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLogs.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvLogs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLogs.ColumnHeadersHeight = 45;

            dgvLogs.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvLogs.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D9FFCC");
            dgvLogs.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#44731E");
            dgvLogs.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLogs.RowTemplate.Height = 35;
            dgvLogs.GridColor = Color.LightGray;
            dgvLogs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLogs.BorderStyle = BorderStyle.Fixed3D;

            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.MultiSelect = false;
            dgvLogs.ReadOnly = true;
            dgvLogs.ScrollBars = ScrollBars.Both;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
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
