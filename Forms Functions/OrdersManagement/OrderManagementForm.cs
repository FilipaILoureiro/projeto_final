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
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using projetoPadariaApp.Properties.Style;
using projetoPadariaApp.Services;
using TheArtOfDevHtmlRenderer.Adapters;

namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    public partial class OrderManagementForm : Form
    {
        private DataTable ordersTable;
        private DataView ordersView;

        public OrderManagementForm()
        {
            InitializeComponent();
            ConfigurarDataGridViewOrder();
            ConfigurarComboBoxes();
            ConfigurarEventHandlers();
            LoadOrders();
        }

        private void ConfigurarComboBoxes()
        {
            cbPago.Items.Clear();
            cbPago.Items.Add("Todos");
            cbPago.Items.Add("Pago");
            cbPago.Items.Add("Não Pago");
            cbPago.SelectedIndex = 0;

            cbEntregue.Items.Clear();
            cbEntregue.Items.Add("Todos");
            cbEntregue.Items.Add("Sim");
            cbEntregue.Items.Add("Não");
            cbEntregue.SelectedIndex = 0;
        }

        private void ConfigurarEventHandlers()
        {
            txtNIF.TextChanged += txtNIF_TextChanged;
            datePickerEnc.ValueChanged += datePickerEnc_ValueChanged;
            datePickerRecolha.ValueChanged += datePickerRecolha_ValueChanged;
            cbPago.SelectedIndexChanged += cbPago_SelectedIndexChanged;
            cbEntregue.SelectedIndexChanged += cbEntregue_SelectedIndexChanged;
            dgvOrders.DataBindingComplete += dgvOrders_DataBindingComplete;
        }

        private void AplicarFiltros()
        {
            if (ordersTable == null) return;

            try
            {
                List<string> filtros = new List<string>();

                if (!string.IsNullOrWhiteSpace(txtNIF.Text))
                {
                    string nif = txtNIF.Text.Trim().Replace("'", "''"); // Escape aspas simples
                    filtros.Add($"nif_clientes LIKE '{nif}%'");
                }

                if (datePickerEnc.Checked)
                {
                    string dataEnc = datePickerEnc.Value.ToString("yyyy-MM-dd");
                    filtros.Add($"data_encomenda = '{dataEnc}'");
                }

                if (datePickerRecolha.Checked)
                {
                    string dataRecolha = datePickerRecolha.Value.ToString("yyyy-MM-dd");
                    filtros.Add($"data_recolha = '{dataRecolha}'");
                }

                string pagoSelecionado = cbPago.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(pagoSelecionado) && pagoSelecionado != "Todos")
                {
                    if (pagoSelecionado == "Pago")
                    {
                        filtros.Add("pago = 'pago'");
                    }
                    else if (pagoSelecionado == "Não Pago")
                    {
                        filtros.Add("pago <> 'pago'");
                    }
                }

                string entregueSelecionado = cbEntregue.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(entregueSelecionado) && entregueSelecionado != "Todos")
                {
                    if (entregueSelecionado == "Sim")
                    {
                        filtros.Add("entregue = 'Sim'");
                    }
                    else if (entregueSelecionado == "Não")
                    {
                        filtros.Add("entregue = 'Não'");
                    }
                }

                string filtroFinal = filtros.Count > 0 ? string.Join(" AND ", filtros) : "";

                if (ordersView == null)
                {
                    ordersView = new DataView(ordersTable);
                    dgvOrders.DataSource = ordersView;
                }

                ordersView.RowFilter = filtroFinal;

                System.Diagnostics.Debug.WriteLine($"Filtro aplicado: {filtroFinal}");
                System.Diagnostics.Debug.WriteLine($"Registros após filtro: {ordersView.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ordersView != null)
                {
                    ordersView.RowFilter = "";
                }
            }
        }

        #region Event Handlers para Filtros
        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void datePickerEnc_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void datePickerRecolha_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cbEntregue_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AplicarCoresLinhas();
        }

        private void AplicarCoresLinhas()
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    string pagoStr = row.Cells["Pago"].Value?.ToString()?.ToLower();
                    string entregueStr = row.Cells["Entregue"].Value?.ToString()?.ToLower();

                    bool pago = pagoStr == "pago";
                    bool entregue = entregueStr == "sim";

                    if (pago && entregue)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (!pago && !entregue)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Khaki;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro ao aplicar cores: {ex.Message}");
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
            dgvOrders.AllowUserToAddRows = false;

            dgvOrders.Columns.Add("ID", "ID");
            dgvOrders.Columns["ID"].DataPropertyName = "id";
            dgvOrders.Columns["ID"].Visible = false;

            dgvOrders.Columns.Add("Cliente", "NIF Cliente");
            dgvOrders.Columns["Cliente"].DataPropertyName = "nif_clientes";
            dgvOrders.Columns["Cliente"].Width = 120;

            dgvOrders.Columns.Add("Data", "Data Encomenda");
            dgvOrders.Columns["Data"].DataPropertyName = "data_encomenda";
            dgvOrders.Columns["Data"].Width = 120;

            dgvOrders.Columns.Add("Recolha", "Data Recolha");
            dgvOrders.Columns["Recolha"].DataPropertyName = "data_recolha";
            dgvOrders.Columns["Recolha"].Width = 120;

            dgvOrders.Columns.Add("Total", "Total (€)");
            dgvOrders.Columns["Total"].DataPropertyName = "preco";
            dgvOrders.Columns["Total"].Width = 100;
            dgvOrders.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvOrders.Columns.Add("Pago", "Pago");
            dgvOrders.Columns["Pago"].DataPropertyName = "pago";
            dgvOrders.Columns["Pago"].Width = 80;

            dgvOrders.Columns.Add("Entregue", "Entregue");
            dgvOrders.Columns["Entregue"].DataPropertyName = "entregue";
            dgvOrders.Columns["Entregue"].Width = 80;

            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrders.ColumnHeadersHeight = 50;

            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
        }

        private void LoadOrders()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    connection.Open();
                    string query = @"SELECT * FROM enc ORDER BY data_encomenda DESC";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        ordersTable = new DataTable();
                        adapter.Fill(ordersTable);

                        System.Diagnostics.Debug.WriteLine($"Registros carregados: {ordersTable.Rows.Count}");

                        foreach (DataRow row in ordersTable.Rows)
                        {
                            if (row["data_encomenda"] != DBNull.Value)
                                row["data_encomenda"] = Convert.ToDateTime(row["data_encomenda"]).ToString("yyyy-MM-dd");
                            if (row["data_recolha"] != DBNull.Value)
                                row["data_recolha"] = Convert.ToDateTime(row["data_recolha"]).ToString("yyyy-MM-dd");
                            if (row["entregue"] != DBNull.Value)
                                row["entregue"] = row["entregue"].ToString().ToUpper() == "S" ? "Sim" : "Não";
                        }

                        ordersView = new DataView(ordersTable);

                        dgvOrders.DataSource = ordersView;

                        dgvOrders.Refresh();

                        System.Diagnostics.Debug.WriteLine($"DataView count: {ordersView.Count}");
                    }
                }

                if (dgvOrders.Rows.Count > 0)
                {
                    AplicarCoresLinhas();
                    dgvOrders.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar encomendas: {ex.Message}\n\nDetalhes: {ex.StackTrace}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int id = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                string colName = dgvOrders.Columns[e.ColumnIndex].Name;

                switch (colName)
                {
                    case "Editar":
                        EditOrderForm editForm = new EditOrderForm(id);
                        editForm.FormClosed += (s, args) => LoadOrders();
                        editForm.ShowDialog();
                        break;

                    case "Remover":
                        if (MessageBox.Show("Tem a certeza que quer apagar esta encomenda?",
                            "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DeleteOrder(id);
                        }
                        break;

                    case "PDF":
                        OrderPDFGenerator.GerarPDFEncomenda(id);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar ação: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteAssoc = "DELETE FROM enc_prod WHERE id_enc = @id";
                            using (var cmd = new SQLiteCommand(deleteAssoc, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteEnc = "DELETE FROM enc WHERE id = @id";
                            using (var cmd = new SQLiteCommand(deleteEnc, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Encomenda removida com sucesso!", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadOrders();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Não foi possível remover a encomenda.", "Aviso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover encomenda: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Botões de Ação
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderForm addOrderForm = new AddOrderForm();
                addOrderForm.FormClosed += (s, args) => LoadOrders();
                addOrderForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de adição: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    EditOrderForm editForm = new EditOrderForm(id);
                    editForm.FormClosed += (s, args) => LoadOrders();
                    editForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir formulário de edição: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    if (MessageBox.Show("Tem a certeza que deseja apagar esta encomenda?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteOrder(id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar remoção: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    OrderPDFGenerator.GerarPDFEncomenda(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para gerar o PDF.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtNIF.Text = "";
                datePickerEnc.Value = DateTime.Now;
                datePickerEnc.Checked = false;
                datePickerRecolha.Value = DateTime.Now;
                datePickerRecolha.Checked = false;
                cbPago.SelectedIndex = 0;
                cbEntregue.SelectedIndex = 0;

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}