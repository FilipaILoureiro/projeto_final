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
        private DataTable stockTable;
        private DataView stockView;
        private Panel modalContainer;

        public StockList()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            LoadMaterias();
        }

        private void ConfigurarEventHandlers()
        {
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            dgvStock.DataBindingComplete += dgvStock_DataBindingComplete;
            dgvStock.Resize += dgvStock_Resize;
        }

        private void dgvStock_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvStock.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvStock.ClientSize.Width;

                dgvStock.Columns["ID"].Width = (int)(larguraTotal * 0.08);
                dgvStock.Columns["Nome"].Width = (int)(larguraTotal * 0.25);
                dgvStock.Columns["Fornecedor"].Width = (int)(larguraTotal * 0.25);
                dgvStock.Columns["Preco"].Width = (int)(larguraTotal * 0.15);
                dgvStock.Columns["Quantidade"].Width = (int)(larguraTotal * 0.12);
                dgvStock.Columns["IVA"].Width = (int)(larguraTotal * 0.15);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void AplicarFiltros()
        {
            if (stockTable == null || stockView == null) return;

            try
            {
                string filtro = "";
                if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
                {
                    string pesquisa = txtPesquisa.Text.Trim().Replace("'", "''");

                    if (int.TryParse(pesquisa, out int id))
                    {
                        filtro = $"ID = {id} OR Nome LIKE '%{pesquisa}%' OR Fornecedor LIKE '%{pesquisa}%'";
                    }
                    else
                    {
                        filtro = $"Nome LIKE '%{pesquisa}%' OR Fornecedor LIKE '%{pesquisa}%'";
                    }
                }

                stockView.RowFilter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                stockView.RowFilter = "";
            }
        }

        #region Event Handlers para Filtros
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        private void dgvStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void ConfigurarDataGridView()
        {
            dgvStock.Columns.Clear();
            dgvStock.AutoGenerateColumns = false;
            dgvStock.ColumnHeadersVisible = true;
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvStock.Columns.Add("ID", "ID");
            dgvStock.Columns["ID"].DataPropertyName = "ID";
            dgvStock.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStock.Columns.Add("Nome", "Nome da Matéria");
            dgvStock.Columns["Nome"].DataPropertyName = "Nome";
            dgvStock.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvStock.Columns.Add("Fornecedor", "Fornecedor");
            dgvStock.Columns["Fornecedor"].DataPropertyName = "Fornecedor";
            dgvStock.Columns["Fornecedor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvStock.Columns.Add("Preco", "Preço (€)");
            dgvStock.Columns["Preco"].DataPropertyName = "Preco";
            dgvStock.Columns["Preco"].DefaultCellStyle.Format = "C2";
            dgvStock.Columns["Preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvStock.Columns.Add("Quantidade", "Quantidade");
            dgvStock.Columns["Quantidade"].DataPropertyName = "Quantidade";
            dgvStock.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvStock.Columns.Add("IVA", "IVA (%)");
            dgvStock.Columns["IVA"].DataPropertyName = "IVA";
            dgvStock.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurações de estilo
            dgvStock.EnableHeadersVisualStyles = false;
            dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176); // #9C27B0
            dgvStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvStock.ColumnHeadersHeight = 45;

            dgvStock.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvStock.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F5BBFF");
            dgvStock.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#6D1B7B");
            dgvStock.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvStock.RowTemplate.Height = 35;
            dgvStock.GridColor = Color.LightGray;
            dgvStock.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvStock.BorderStyle = BorderStyle.Fixed3D;

            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.ReadOnly = true;
            dgvStock.ScrollBars = ScrollBars.Both;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
        }

        private void LoadMaterias()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT m.id AS ID, m.nome AS Nome, f.nome AS Fornecedor, 
                               m.preco AS Preco, m.quantidade AS Quantidade, m.iva AS IVA
                        FROM materia m
                        INNER JOIN fornecedor f ON m.id_fornecedor = f.id
                        ORDER BY m.nome";

                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        stockTable = new DataTable();
                        adapter.Fill(stockTable);

                        stockView = new DataView(stockTable);
                        stockView.RowFilter = ""; // Exibir tudo inicialmente
                        dgvStock.DataSource = stockView;
                        dgvStock.Refresh();
                    }
                }

                if (dgvStock.Rows.Count > 0)
                {
                    AjustarLarguraColunas();
                    dgvStock.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar matérias-primas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverMateria(int id, string nomeMaterial, string fornecedorNome)
        {
            try
            {
                DialogResult confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover a matéria-prima '{nomeMaterial}' do fornecedor '{fornecedorNome}'?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DatabaseManage.GetInstance().GetConnection())
                    {
                        conn.Open();

                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string query = "DELETE FROM materia WHERE id = @id";
                                using (var cmd = new SQLiteCommand(query, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    int rows = cmd.ExecuteNonQuery();

                                    if (rows > 0)
                                    {
                                        // Primeiro confirma a transação
                                        transaction.Commit();

                                        // ✅ Só depois regista o log
                                        try
                                        {
                                            LogsService.RegistarLog(
                                                Session.FuncionarioId,
                                                $"Removeu matéria-prima #{id} '{nomeMaterial}' (Fornecedor «{fornecedorNome}»)"
                                            );
                                        }
                                        catch (Exception logEx)
                                        {
                                            Console.WriteLine($"Erro ao registar log de remoção de matéria-prima: {logEx.Message}");
                                        }

                                        MessageBox.Show("Matéria-prima removida com sucesso!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadMaterias();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Não foi possível remover a matéria-prima.", "Aviso",
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover matéria-prima: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        #region Modal Container Methods
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

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != modalContainer)
                    ctrl.Enabled = false;
            }
        }

        private void CloseModalContainer()
        {
            if (modalContainer != null)
            {
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
        #endregion

        #region Botões de Ação
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                CreateModalContainer();
                LoadAddStockInContainer();
            }
            catch (Exception ex)
            {
                CloseModalContainer();
                MessageBox.Show($"Erro ao abrir formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAddStockInContainer()
        {
            StockAdd addForm = new StockAdd
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(addForm);
            addForm.FormClosed += OnAddStockClosed;
            addForm.Show();
        }

        private void OnAddStockClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadMaterias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                try
                {
                    int materiaId = Convert.ToInt32(dgvStock.SelectedRows[0].Cells["ID"].Value);
                    CreateModalContainer();
                    LoadEditStockInContainer(materiaId);
                }
                catch (Exception ex)
                {
                    CloseModalContainer();
                    MessageBox.Show($"Erro ao abrir formulário de edição: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma matéria-prima para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEditStockInContainer(int materiaId)
        {
            EditStockForm editForm = new EditStockForm(materiaId)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(editForm);
            editForm.FormClosed += OnEditStockClosed;
            editForm.Show();
        }

        private void OnEditStockClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadMaterias();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                try
                {
                    int materiaId = Convert.ToInt32(dgvStock.SelectedRows[0].Cells["ID"].Value);
                    string nomeMaterial = dgvStock.SelectedRows[0].Cells["Nome"].Value?.ToString();
                    string nomeFornecedor = dgvStock.SelectedRows[0].Cells["Fornecedor"].Value?.ToString();

                    RemoverMateria(materiaId, nomeMaterial, nomeFornecedor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar remoção: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma matéria-prima para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtPesquisa.Text = "";
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
