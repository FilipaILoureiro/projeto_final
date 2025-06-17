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
using projetoPadariaApp.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    public partial class OrderManagementForm : Form
    {
        public OrderManagementForm()
        {
            InitializeComponent();
            ConfigurarDataGridViewOrder();
            LoadOrders();
            dgvOrders.DataBindingComplete += dgvOrders_DataBindingComplete;
        }

        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                string pagoStr = row.Cells["Pago"].Value?.ToString()?.ToLower();
                string entregueStr = row.Cells["Entregue"].Value?.ToString()?.ToLower();

                bool pago = pagoStr == "pago";
                bool entregue = entregueStr == "sim";

                if (pago && entregue)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (!pago && !entregue)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral; 
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki; 
                }
            }

            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.ClearSelection();
            }
        }


        private void ConfigurarDataGridViewOrder()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.ColumnHeadersVisible = true;

            dgvOrders.Columns.Add("ID", "ID");
            dgvOrders.Columns["ID"].DataPropertyName = "id";
            dgvOrders.Columns["ID"].Visible = false;

            dgvOrders.Columns.Add("Cliente", "NIF Cliente");
            dgvOrders.Columns["Cliente"].DataPropertyName = "nif_clientes";

            dgvOrders.Columns.Add("Data", "Data Encomenda");
            dgvOrders.Columns["Data"].DataPropertyName = "data_encomenda";

            dgvOrders.Columns.Add("Recolha", "Data Recolha");
            dgvOrders.Columns["Recolha"].DataPropertyName = "data_recolha";

            dgvOrders.Columns.Add("Total", "Total (€)");
            dgvOrders.Columns["Total"].DataPropertyName = "preco";

            dgvOrders.Columns.Add("Pago", "Pago");
            dgvOrders.Columns["Pago"].DataPropertyName = "pago";

            dgvOrders.Columns.Add("Entregue", "Entregue");
            dgvOrders.Columns["Entregue"].DataPropertyName = "entregue";

            var btnEditar = new DataGridViewButtonColumn { Text = "Editar", UseColumnTextForButtonValue = true, Name = "Editar" };
            var btnRemover = new DataGridViewButtonColumn { Text = "Remover", UseColumnTextForButtonValue = true, Name = "Remover" };
            var btnPDF = new DataGridViewButtonColumn { Text = "PDF", UseColumnTextForButtonValue = true, Name = "PDF" };

            dgvOrders.Columns.Add(btnEditar);
            dgvOrders.Columns.Add(btnRemover);
            dgvOrders.Columns.Add(btnPDF);

            dgvOrders.CellClick += dgvOrders_CellClick;

            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrders.ColumnHeadersHeight = 50;
        }

        private void LoadOrders()
        {
            using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                connection.Open();
                string query = @"SELECT * FROM enc";

                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        if (row["data_encomenda"] != DBNull.Value)
                        {
                            DateTime dataEncomenda = Convert.ToDateTime(row["data_encomenda"]);
                            row["data_encomenda"] = dataEncomenda.ToString("yyyy-MM-dd");
                        }

                        if (row["data_recolha"] != DBNull.Value)
                        {
                            DateTime dataRecolha = Convert.ToDateTime(row["data_recolha"]);
                            row["data_recolha"] = dataRecolha.ToString("yyyy-MM-dd");
                        }

                        if (row["entregue"] != DBNull.Value)
                        {
                            string entregue = row["entregue"].ToString();
                            row["entregue"] = entregue == "S" ? "Sim" : "Não";
                        }
                    }

                    dgvOrders.DataSource = table;
                }
            }

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                string pagoStr = row.Cells["Pago"].Value?.ToString()?.ToLower();
                string entregueStr = row.Cells["Entregue"].Value?.ToString()?.ToLower();

                bool pago = pagoStr == "pago";
                bool entregue = entregueStr == "sim";

                if (pago && entregue)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (!pago && !entregue)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral; 
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki; 
                }
            }


        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);

            string colName = dgvOrders.Columns[e.ColumnIndex].Name;

            if (colName == "Editar")
            {
                EditOrderForm editForm = new EditOrderForm(id);
                editForm.FormClosed += (s, args) => LoadOrders();
                editForm.ShowDialog();
            }
            else if (colName == "Remover")
            {
                if (MessageBox.Show("Tem a certeza que quer apagar esta encomenda?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteOrder(id);
                    LoadOrders();
                }
            }
            else if (colName == "PDF")
            {
                OrderPDFGenerator.GerarPDFEncomenda(id);
            }
        }

        private void DeleteOrder(int id)
        {
            using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                connection.Open();

                string deleteAssoc = "DELETE FROM enc_prod WHERE id_enc = @id";
                using (var cmd = new SQLiteCommand(deleteAssoc, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                string deleteEnc = "DELETE FROM enc WHERE id = @id";
                using (var cmd = new SQLiteCommand(deleteEnc, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadOrders();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm();
            addOrderForm.FormClosed += (s, args) => LoadOrders();
            addOrderForm.ShowDialog();
        }
    }
}
