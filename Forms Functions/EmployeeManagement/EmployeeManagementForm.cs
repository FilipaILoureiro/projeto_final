using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Forms;
using BCrypt.Net;

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
            var btnEditar = new DataGridViewButtonColumn { Text = "Editar", UseColumnTextForButtonValue = true, Name = "Editar" };
            var btnRemover = new DataGridViewButtonColumn { Text = "Remover", UseColumnTextForButtonValue = true, Name = "Remover" };
            var btnPromover = new DataGridViewButtonColumn { Text = "Admin", UseColumnTextForButtonValue = true, Name = "Admin" };

            dgvEmployees.Columns.Add(btnEditar);
            dgvEmployees.Columns.Add(btnRemover);
            dgvEmployees.Columns.Add(btnPromover);

            dgvEmployees.CellClick += dgvEmployees_CellClick;

            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void LoadFuncionarios()
        {
            dgvEmployees.DataSource = null;
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
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Funcionário removido com sucesso!");
                LoadFuncionarios();
            }
        }

        // para promover funcionário a admin
        private void PromoverAdmin(int id, string nome)
        {
            DialogResult confirm = MessageBox.Show($"Deseja promover {nome} a administrador?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE tipo_de_func SET admin = 'S' WHERE id_funcionario = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"{nome} agora é Administrador!");
                LoadFuncionarios();
            }
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvEmployees = new Guna.UI2.WinForms.Guna2DataGridView();
            databaseManageBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvEmployees.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvEmployees.ColumnHeadersHeight = 4;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.DataSource = databaseManageBindingSource;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle6;
            dgvEmployees.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.Location = new Point(33, 34);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(949, 518);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvEmployees.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvEmployees.ThemeStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvEmployees.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmployees.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvEmployees.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.ThemeStyle.HeaderStyle.Height = 4;
            dgvEmployees.ThemeStyle.ReadOnly = false;
            dgvEmployees.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvEmployees.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvEmployees.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvEmployees.ThemeStyle.RowsStyle.Height = 29;
            dgvEmployees.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvEmployees.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // databaseManageBindingSource
            // 
            databaseManageBindingSource.DataSource = typeof(DatabaseManage);
            // 
            // EmployeeManagementForm
            // 
            ClientSize = new Size(1019, 585);
            Controls.Add(dgvEmployees);
            Name = "EmployeeManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseManageBindingSource).EndInit();
            ResumeLayout(false);

        }
    }
}

