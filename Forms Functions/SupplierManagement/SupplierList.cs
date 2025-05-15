using PadariaApp;
using projetoPadariaApp.Forms_Functions.EmployeeManagement;
using projetoPadariaApp.Services;
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
    public partial class SupplierList : Form
    {
        public SupplierList()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            LoadFornecedores();
        }

        private void ConfigurarDataGridView()
        {
            dgvSupplier.Columns.Clear();

            dgvSupplier.Columns.Add("ID", "ID");
            dgvSupplier.Columns["ID"].Visible = false;
            dgvSupplier.Columns.Add("Nome", "Nome");
            dgvSupplier.Columns.Add("Contacto", "Contacto");
            dgvSupplier.Columns.Add("Email", "Email");
            dgvSupplier.Columns.Add("TempoEntrega", "Tempo de Entrega");

            var btnEditar = new DataGridViewButtonColumn { Text = "✏ Editar", UseColumnTextForButtonValue = true, Name = "Editar" };
            var btnRemover = new DataGridViewButtonColumn { Text = "❌ Remover", UseColumnTextForButtonValue = true, Name = "Remover" };

            dgvSupplier.Columns.Add(btnEditar);
            dgvSupplier.Columns.Add(btnRemover);

            dgvSupplier.CellClick += dgvSupplier_CellClick;
        }

        private void LoadFornecedores()
        {
            dgvSupplier.Rows.Clear();
            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM fornecedor";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvSupplier.Rows.Add(reader["id"], reader["nome"], reader["contacto"], reader["email"], reader["tempo_de_entrega"]);
                    }
                }
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idFornecedor = Convert.ToInt32(dgvSupplier.Rows[e.RowIndex].Cells["ID"].Value);
            string nomeFornecedor = dgvSupplier.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

            if (dgvSupplier.Columns[e.ColumnIndex].Name == "Editar")
            {
                EditSupplierForm editForm = new EditSupplierForm(idFornecedor);
                editForm.ShowDialog();
                LoadFornecedores();
            }
            else if (dgvSupplier.Columns[e.ColumnIndex].Name == "Remover")
            {
                RemoverFornecedor(idFornecedor, nomeFornecedor);
            }
        }

        private void RemoverFornecedor(int id, string nome)
        {
            DialogResult confirm = MessageBox.Show($"Tem certeza que deseja remover o fornecedor {nome}?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM fornecedor WHERE id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Registrar a remoção no log
                string descricao = $"Fornecedor {nome} removido.";
                LogsService.RegistarLog(Session.FuncionarioId, descricao);


                MessageBox.Show("Fornecedor removido com sucesso!");
                LoadFornecedores();
            }
        }



        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            SupplierAdd supplierAdd = new SupplierAdd();
            supplierAdd.Show();
        }
    }
}
