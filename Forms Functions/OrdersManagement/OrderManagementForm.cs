using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using projetoPadariaApp.Forms;
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
            datePickerEnc.Checked = false;
            datePickerRecolha.Checked = false;
            ConfigurarDataGridViewOrder();
            ConfigurarComboBoxes();
            ConfigurarEventHandlers();
            LoadOrders();
            this.dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
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
            dgvOrders.Resize += dgvOrders_Resize;
        }

        private void dgvOrders_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvOrders.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvOrders.ClientSize.Width;

                dgvOrders.Columns["Cliente"].Width = (int)(larguraTotal * 0.12);
                dgvOrders.Columns["Data"].Width = (int)(larguraTotal * 0.22);
                dgvOrders.Columns["Recolha"].Width = (int)(larguraTotal * 0.22);
                dgvOrders.Columns["Total"].Width = (int)(larguraTotal * 0.15);
                dgvOrders.Columns["Pago"].Width = (int)(larguraTotal * 0.14);
                dgvOrders.Columns["Entregue"].Width = (int)(larguraTotal * 0.15);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void AplicarFiltros()
        {
            if (ordersTable == null || ordersView == null) return;

            try
            {
                List<string> filtros = new List<string>();

                if (!string.IsNullOrWhiteSpace(txtNIF.Text))
                {
                    string nif = txtNIF.Text.Trim().Replace("'", "''");
                    filtros.Add($"nif_clientes LIKE '{nif}%'");
                }

                if (datePickerEnc.Checked)
                {
                    string dataEnc = datePickerEnc.Value.ToString("yyyy-MM-dd");
                    filtros.Add($"data_encomenda_original = '{dataEnc}'");
                }

                if (datePickerRecolha.Checked)
                {
                    string dataRecolha = datePickerRecolha.Value.ToString("yyyy-MM-dd");
                    filtros.Add($"data_recolha_original = '{dataRecolha}'");
                }

                string pagoSelecionado = cbPago.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(pagoSelecionado) && pagoSelecionado != "Todos")
                {
                    if (pagoSelecionado == "Pago")
                        filtros.Add("pago_original = 'pago'");
                    else if (pagoSelecionado == "Não Pago")
                        filtros.Add("pago_original <> 'pago'");
                }

                string entregueSelecionado = cbEntregue.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(entregueSelecionado) && entregueSelecionado != "Todos")
                {
                    if (entregueSelecionado == "Sim")
                        filtros.Add("entregue_original = 'S'");
                    else if (entregueSelecionado == "Não")
                        filtros.Add("entregue_original <> 'S'");
                }

                string filtroFinal = filtros.Count > 0 ? string.Join(" AND ", filtros) : "";
                ordersView.RowFilter = filtroFinal;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ordersView.RowFilter = "";
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
            AjustarLarguraColunas();
        }

        private void AplicarCoresLinhas()
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    string pagoStr = row.Cells["pago_original"].Value?.ToString()?.ToLower();
                    string entregueStr = row.Cells["entregue_original"].Value?.ToString()?.ToLower();

                    bool pago = pagoStr == "pago";
                    bool entregue = entregueStr == "s";

                    if (pago && entregue)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(155, 214, 156);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (!pago && !entregue)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 121, 136);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 242, 157);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro ao aplicar cores: {ex.Message}");
                }
            }

            if (dgvOrders.Rows.Count > 0)
                dgvOrders.ClearSelection();
        }

        private void ConfigurarDataGridViewOrder()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.ColumnHeadersVisible = true;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;

            dgvOrders.Columns.Add("ID", "ID");
            dgvOrders.Columns["ID"].DataPropertyName = "id";
            dgvOrders.Columns["ID"].Visible = false;

            dgvOrders.Columns.Add("Cliente", "NIF Cliente");
            dgvOrders.Columns["Cliente"].DataPropertyName = "nif_clientes";
            dgvOrders.Columns["Cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.Add("Data", "Data Encomenda");
            dgvOrders.Columns["Data"].DataPropertyName = "data_encomenda";
            dgvOrders.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.Add("Recolha", "Data Recolha");
            dgvOrders.Columns["Recolha"].DataPropertyName = "data_recolha";
            dgvOrders.Columns["Recolha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.Add("Total", "Total (€)");
            dgvOrders.Columns["Total"].DataPropertyName = "preco";
            dgvOrders.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvOrders.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvOrders.Columns.Add("Pago", "Pago");
            dgvOrders.Columns["Pago"].DataPropertyName = "pago";
            dgvOrders.Columns["Pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.Add("Entregue", "Entregue");
            dgvOrders.Columns["Entregue"].DataPropertyName = "entregue";
            dgvOrders.Columns["Entregue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.Add("data_encomenda_original", "Data Enc Original");
            dgvOrders.Columns["data_encomenda_original"].DataPropertyName = "data_encomenda_original";
            dgvOrders.Columns["data_encomenda_original"].Visible = false;

            dgvOrders.Columns.Add("data_recolha_original", "Data Rec Original");
            dgvOrders.Columns["data_recolha_original"].DataPropertyName = "data_recolha_original";
            dgvOrders.Columns["data_recolha_original"].Visible = false;

            dgvOrders.Columns.Add("pago_original", "Pago Original");
            dgvOrders.Columns["pago_original"].DataPropertyName = "pago_original";
            dgvOrders.Columns["pago_original"].Visible = false;

            dgvOrders.Columns.Add("entregue_original", "Entregue Original");
            dgvOrders.Columns["entregue_original"].DataPropertyName = "entregue_original";
            dgvOrders.Columns["entregue_original"].Visible = false;

            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOrders.ColumnHeadersHeight = 45;

            dgvOrders.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 232, 231);
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOrders.RowTemplate.Height = 35;
            dgvOrders.GridColor = Color.LightGray;
            dgvOrders.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvOrders.BorderStyle = BorderStyle.Fixed3D;

            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.ScrollBars = ScrollBars.Both;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
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

                        foreach (string col in new[] {
                    "data_encomenda_original", "data_recolha_original",
                    "pago_original", "entregue_original"
                })
                        {
                            if (ordersTable.Columns.Contains(col))
                                ordersTable.Columns.Remove(col);
                            ordersTable.Columns.Add(col, typeof(string));
                        }

                        foreach (DataRow row in ordersTable.Rows)
                        {
                            // Data Encomenda
                            if (row["data_encomenda"] != DBNull.Value)
                            {
                                DateTime dataEnc = Convert.ToDateTime(row["data_encomenda"]);
                                row["data_encomenda_original"] = dataEnc.ToString("yyyy-MM-dd");
                                row["data_encomenda"] = dataEnc.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                row["data_encomenda_original"] = string.Empty;
                                row["data_encomenda"] = string.Empty;
                            }

                            // Data Recolha
                            if (row["data_recolha"] != DBNull.Value)
                            {
                                DateTime dataRecolha = Convert.ToDateTime(row["data_recolha"]);
                                row["data_recolha_original"] = dataRecolha.ToString("yyyy-MM-dd");
                                row["data_recolha"] = dataRecolha.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                row["data_recolha_original"] = string.Empty;
                                row["data_recolha"] = string.Empty;
                            }

                            // Entregue
                            if (row["entregue"] != DBNull.Value)
                            {
                                string entregue = row["entregue"].ToString().ToUpper();
                                row["entregue_original"] = entregue;
                                row["entregue"] = entregue == "S" ? "Sim" : "Não";
                            }
                            else
                            {
                                row["entregue_original"] = "N";
                                row["entregue"] = "Não";
                            }

                            // Pago
                            if (row["pago"] != DBNull.Value)
                            {
                                string pago = row["pago"].ToString().ToLower();
                                row["pago_original"] = pago;
                                row["pago"] = pago == "pago" ? "Pago" : "Pendente";
                            }
                            else
                            {
                                row["pago_original"] = "pendente";
                                row["pago"] = "Pendente";
                            }
                        }

                        ordersView = new DataView(ordersTable);
                        ordersView.RowFilter = ""; // Exibir tudo inicialmente
                        dgvOrders.DataSource = ordersView;
                        dgvOrders.Refresh();
                    }
                }

                if (dgvOrders.Rows.Count > 0)
                {
                    AplicarCoresLinhas();
                    AjustarLarguraColunas();
                    dgvOrders.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar encomendas: {ex.Message}", "Erro",
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
                        CreateModalContainer();
                        LoadEditOrderInContainer(id);
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
        // para adicionar nova encomenda e corrigir o fundo
        private Panel modalContainer;
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                CreateModalContainer();
                LoadAddOrderInContainer();
            }
            catch (Exception ex)
            {
                CloseModalContainer();
                MessageBox.Show($"Erro ao abrir formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateModalContainer()
        {
            modalContainer = new Panel
            {
                Size = new Size(837, 600),
                BackColor = Color.FromArgb(0, 89, 89),
                Anchor = AnchorStyles.None,
                BorderStyle = BorderStyle.FixedSingle
            };

            Screen currentScreen = Screen.FromControl(this);
            System.Drawing.Rectangle screenBounds = currentScreen.WorkingArea;
            Point screenCenter = new Point(
                screenBounds.X + (screenBounds.Width - modalContainer.Width) / 2,
                screenBounds.Y + (screenBounds.Height - modalContainer.Height) / 2
            );
            Point relativeLocation = this.PointToClient(screenCenter);
            modalContainer.Location = relativeLocation;

            this.Controls.Add(modalContainer);
            modalContainer.BringToFront();

            // Desativar outros controles
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != modalContainer)
                    ctrl.Enabled = false;
            }
        }

        private void LoadAddOrderInContainer()
        {
            AddOrderForm addForm = new AddOrderForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(addForm);
            addForm.FormClosed += OnAddOrderClosed;
            addForm.Show();
        }

        private void OnAddOrderClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadOrders();
        }

        private void CloseModalContainer()
        {
            if (modalContainer != null)
            {
                // Reativar outros controles
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl != modalContainer)
                        ctrl.Enabled = true;
                }

                this.Controls.Remove(modalContainer);
                modalContainer.Dispose();
                modalContainer = null;
            }
        }

        // botão de editar encomenda e editar fundo
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    CreateModalContainer();
                    LoadEditOrderInContainer(id);
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

        private void LoadEditOrderInContainer(int id)
        {
            EditOrderForm editForm = new EditOrderForm(id)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(editForm);
            editForm.FormClosed += OnEditOrderClosed;
            editForm.Show();
        }

        private void OnEditOrderClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadOrders();
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


        // para pdf
        private string VerificarPDFExistente(int idEncomenda)
        {
            string pastaPDF = Path.Combine(Application.StartupPath, "PDFs");

            if (!Directory.Exists(pastaPDF))
                return null;

            string padraoNome = $"Fatura_Encomenda_{idEncomenda}_*";
            string[] arquivosPDF = Directory.GetFiles(pastaPDF, padraoNome);

            return arquivosPDF.Length > 0 ? arquivosPDF.OrderByDescending(f => File.GetCreationTime(f)).First() : null;
        }

        private void AbrirPDFExistente(string caminhoArquivo)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = caminhoArquivo,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o PDF: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTextoBotaoPDF()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {

                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    string pdfExistente = VerificarPDFExistente(id);

                    btnPDF.BorderRadius = 10;
                    btnPDF.AutoSize = false;
                    btnPDF.Width = 156;
                    btnPDF.Height = 63;

                    if (pdfExistente != null)
                    {
                        btnPDF.Text = "Ver PDF";
                        btnPDF.FillColor = Color.FromArgb(46, 125, 50); 
                    }
                    else
                    {
                        btnPDF.Text = "Gerar PDF";
                        btnPDF.FillColor = Color.FromArgb(41, 128, 185); 
                    }
                }
                catch
                {
                    btnPDF.Text = "Gerar PDF";
                    btnPDF.FillColor = Color.FromArgb(41, 128, 185);
                }
            }
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);
                    string pdfExistente = VerificarPDFExistente(id);

                    if (pdfExistente != null)
                    {
                        // Verificar se pode estar desatualizado
                        DateTime dataPDF = File.GetCreationTime(pdfExistente);

                        var resultado = MessageBox.Show(
                            $"PDF existente encontrado!\n\n" +
                            $"📄 Arquivo: {Path.GetFileName(pdfExistente)}\n" +
                            $"📅 Criado em: {dataPDF:dd/MM/yyyy às HH:mm}\n\n" +
                            $"⚠️ ATENÇÃO: Se editou a encomenda após esta data,\n" +
                            $"o PDF pode estar desatualizado!\n\n" +
                            $"• SIM = Abrir PDF existente\n" +
                            $"• NÃO = Gerar novo PDF atualizado\n" +
                            $"• CANCELAR = Cancelar",
                            "PDF Existente - Verificar Data! ⚠️",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        switch (resultado)
                        {
                            case DialogResult.Yes:
                                AbrirPDFExistente(pdfExistente);
                                break;

                            case DialogResult.No:
                                OrderPDFGenerator.GerarPDFEncomenda(id);
                                AtualizarTextoBotaoPDF(); 
                                break;

                            case DialogResult.Cancel:
                                break;
                        }
                    }
                    else
                    {
                        OrderPDFGenerator.GerarPDFEncomenda(id);
                        AtualizarTextoBotaoPDF(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para gerar o PDF.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarTextoBotaoPDF();
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

        private void btnCheckPago_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);

                    using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                    {
                        connection.Open();

                        string checkQuery = "SELECT pago FROM enc WHERE id = @id";
                        using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@id", id);
                            var currentStatus = checkCmd.ExecuteScalar()?.ToString();

                            if (currentStatus == "pago")
                            {
                                MessageBox.Show("Encomenda já se encontra paga!", "Informação",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string updateQuery = "UPDATE enc SET pago = 'pago' WHERE id = @id";
                                using (var cmd = new SQLiteCommand(updateQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Encomenda marcada como paga!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadOrders();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Nenhuma encomenda foi atualizada.", "Aviso",
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
                    MessageBox.Show($"Erro ao confirmar pagamento: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para confirmar pagamento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckEntrega_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["ID"].Value);

                    using (var connection = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                    {
                        connection.Open();

                        string checkQuery = "SELECT entregue FROM enc WHERE id = @id";
                        using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@id", id);
                            var currentStatus = checkCmd.ExecuteScalar()?.ToString();

                            // Verificar se já está entregue
                            if (currentStatus == "S")
                            {
                                MessageBox.Show("Encomenda já se encontra entregue!", "Informação",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string updateQuery = "UPDATE enc SET entregue = 'S' WHERE id = @id";
                                using (var cmd = new SQLiteCommand(updateQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Encomenda marcada como entregue!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadOrders();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Nenhuma encomenda foi atualizada.", "Aviso",
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
                    MessageBox.Show($"Erro ao confirmar entrega: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para confirmar entrega.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}