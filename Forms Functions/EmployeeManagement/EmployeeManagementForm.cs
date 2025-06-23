using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Forms;
using BCrypt.Net;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    public partial class EmployeeManagementForm : Form
    {
        public EmployeeManagementForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            LoadFuncionarios();
        }

        private void ConfigurarDataGridView()
        {
            dgvEmployees.Columns.Clear();

            dgvEmployees.Columns.Add("ID", "ID");
            dgvEmployees.Columns["ID"].Visible = false;
            dgvEmployees.Columns.Add("Nome", "Nome");
            dgvEmployees.Columns.Add("Contacto", "Contacto");
            dgvEmployees.Columns.Add("Username", "Username");
            dgvEmployees.Columns.Add("Funcao", "Função");

            // Colunas de Ações
            var btnEditar = new DataGridViewButtonColumn { Text = "✏ Editar", UseColumnTextForButtonValue = true, Name = "Editar" };
            var btnRemover = new DataGridViewButtonColumn { Text = "❌ Remover", UseColumnTextForButtonValue = true, Name = "Remover" };
            var btnPromover = new DataGridViewButtonColumn { Text = "⭐ Admin", UseColumnTextForButtonValue = true, Name = "Admin" };

            dgvEmployees.Columns.Add(btnEditar);
            dgvEmployees.Columns.Add(btnRemover);
            dgvEmployees.Columns.Add(btnPromover);

            dgvEmployees.CellClick += dgvEmployees_CellClick;
        }

        private void LoadFuncionarios()
        {
            dgvEmployees.Rows.Clear();
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT f.id, f.nome, f.contacto, f.username, f.pass, f.id_funcao, t.admin FROM funcionario f " +
               "LEFT JOIN tipo_de_func t ON f.id = t.id_funcionario";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bool isAdmin = reader["admin"] != DBNull.Value && reader["admin"].ToString() == "S";
                        dgvEmployees.Rows.Add(reader["id"], reader["nome"], reader["contacto"], reader["username"], reader["pass"], reader["id_funcao"], "✏ Editar", "❌ Remover", isAdmin ? "✅ Admin" : "⭐ Promover");
                    }
                }
            }
        }


        // para implementar a célula "Ações" de editar, remover e promover funcionarios
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idFuncionario = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["ID"].Value);
            string nomeFuncionario = dgvEmployees.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

            if (dgvEmployees.Columns[e.ColumnIndex].Name == "Editar")
            {
                EditEmployeeForm editForm = new EditEmployeeForm(idFuncionario);
                editForm.ShowDialog();
                LoadFuncionarios();
            }
            else if (dgvEmployees.Columns[e.ColumnIndex].Name == "Remover")
            {
                RemoverFuncionario(idFuncionario, nomeFuncionario);
            }
            else if (dgvEmployees.Columns[e.ColumnIndex].Name == "Admin")
            {
                PromoverAdmin(idFuncionario, nomeFuncionario);
            }
        }

        // para remover funcionário
        private void RemoverFuncionario(int id, string nome)
        {
            DialogResult confirm = MessageBox.Show($"Tem certeza que deseja remover {nome}?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM funcionario WHERE id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            // -------------- NOVO --------------
                            LogsService.RegistarLog(
                                Session.FuncionarioId,
                                $"Removeu o funcionário #{id} («{nome}»)");
                            // -----------------------------------
                        }
                    }
                }
                MessageBox.Show("Funcionário removido com sucesso!");
                LoadFuncionarios();
            }
        }

        // para promover funcionário a admin
        private void PromoverAdmin(int id, string nome)
        {
            DialogResult confirm = MessageBox.Show(
                $"Deseja promover {nome} a administrador?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    const string sql = "UPDATE tipo_de_func SET admin = 'S' WHERE id_funcionario = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            //LOGS AQUI
                            LogsService.RegistarLog(
                                Session.FuncionarioId,
                                $"Promoveu o funcionário #{id} («{nome}») a ADMIN");
                        }
                    }
                }

                MessageBox.Show($"{nome} agora é Administrador!");
                LoadFuncionarios();
            }
        }


        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

