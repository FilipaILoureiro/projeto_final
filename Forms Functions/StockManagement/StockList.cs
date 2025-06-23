using PadariaApp;
using projetoPadariaApp.Services;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    public partial class StockList : Form
    {
        public StockList()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            LoadMaterias();
        }

        private void ConfigurarDataGridView()
        {
            dgvStock.Columns.Clear();

            dgvStock.Columns.Add("ID", "ID");
            dgvStock.Columns["ID"].Visible = false;
            dgvStock.Columns.Add("Nome", "Nome");
            dgvStock.Columns.Add("Fornecedor", "Fornecedor");
            dgvStock.Columns.Add("Preco", "Preço");
            dgvStock.Columns.Add("Quantidade", "Quantidade");
            dgvStock.Columns.Add("IVA", "IVA");

            var btnEditar = new DataGridViewButtonColumn
            {
                Text = "✏ Editar",
                UseColumnTextForButtonValue = true,
                Name = "Editar"
            };

            var btnRemover = new DataGridViewButtonColumn
            {
                Text = "❌ Remover",
                UseColumnTextForButtonValue = true,
                Name = "Remover"
            };

            dgvStock.Columns.Add(btnEditar);
            dgvStock.Columns.Add(btnRemover);

            dgvStock.CellClick += dgvStock_CellClick;
        }

        private void LoadMaterias()
        {
            dgvStock.Rows.Clear();

            using (var conn = DatabaseManage.GetInstance().GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT m.id, m.nome, f.nome AS fornecedor_nome, m.preco, m.quantidade, m.iva
                    FROM materia m
                    INNER JOIN fornecedor f ON m.id_fornecedor = f.id";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvStock.Rows.Add(
                            reader["id"],
                            reader["nome"],
                            reader["fornecedor_nome"],
                            reader["preco"],
                            reader["quantidade"],
                            reader["iva"]
                        );
                    }
                }
            }
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idMateria = Convert.ToInt32(dgvStock.Rows[e.RowIndex].Cells["ID"].Value);
            string nomeFornecedor = dgvStock.Rows[e.RowIndex].Cells["Fornecedor"].Value.ToString();

            if (dgvStock.Columns[e.ColumnIndex].Name == "Editar")
            {
                EditStockForm editForm = new EditStockForm(idMateria);
                editForm.ShowDialog();
                LoadMaterias();
            }
            else if (dgvStock.Columns[e.ColumnIndex].Name == "Remover")
            {
                RemoverMateria(idMateria, nomeFornecedor);
            }
        }

        private void RemoverMateria(int id, string fornecedorNome)
        {
            DialogResult confirm = MessageBox.Show(
                $"Tem certeza que deseja remover a matéria-prima do fornecedor {fornecedorNome}?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM materia WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            //LOGS AQUI
                            LogsService.RegistarLog(
                                Session.FuncionarioId,
                                $"Removeu matéria-prima #{id} (Fornecedor «{fornecedorNome}»)");
                        }
                    }
                }

                MessageBox.Show("Matéria-prima removida com sucesso!");
                LoadMaterias();
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            StockAdd stockAdd = new StockAdd();
            stockAdd.ShowDialog();
            LoadMaterias(); // Atualiza a lista após adicionar
        }
    }
}
