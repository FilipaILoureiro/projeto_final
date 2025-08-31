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
        private DataTable supplierTable;
        private DataView supplierView;
        private Panel modalContainer;

        public SupplierList()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            LoadFornecedores();
        }

        private void ConfigurarEventHandlers()
        {
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            dgvSupplier.DataBindingComplete += dgvSupplier_DataBindingComplete;
            dgvSupplier.Resize += dgvSupplier_Resize;
        }

        private void dgvSupplier_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvSupplier.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvSupplier.ClientSize.Width;

                dgvSupplier.Columns["ID"].Width = (int)(larguraTotal * 0.08);
                dgvSupplier.Columns["Nome"].Width = (int)(larguraTotal * 0.30);
                dgvSupplier.Columns["Contacto"].Width = (int)(larguraTotal * 0.20);
                dgvSupplier.Columns["Email"].Width = (int)(larguraTotal * 0.25);
                dgvSupplier.Columns["TempoEntrega"].Width = (int)(larguraTotal * 0.17);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void AplicarFiltros()
        {
            if (supplierTable == null || supplierView == null) return;

            try
            {
                string filtro = "";
                if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
                {
                    string pesquisa = txtPesquisa.Text.Trim().Replace("'", "''");

                    if (int.TryParse(pesquisa, out int id))
                    {
                        filtro = $"ID = {id} OR Nome LIKE '%{pesquisa}%' OR Contacto LIKE '%{pesquisa}%' OR Email LIKE '%{pesquisa}%'";
                    }
                    else
                    {
                        filtro = $"Nome LIKE '%{pesquisa}%' OR Contacto LIKE '%{pesquisa}%' OR Email LIKE '%{pesquisa}%'";
                    }
                }

                supplierView.RowFilter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                supplierView.RowFilter = "";
            }
        }

        #region Event Handlers para Filtros
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        private void dgvSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void ConfigurarDataGridView()
        {
            dgvSupplier.Columns.Clear();
            dgvSupplier.AutoGenerateColumns = false;
            dgvSupplier.ColumnHeadersVisible = true;
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvSupplier.Columns.Add("ID", "ID");
            dgvSupplier.Columns["ID"].DataPropertyName = "ID";
            dgvSupplier.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSupplier.Columns.Add("Nome", "Nome");
            dgvSupplier.Columns["Nome"].DataPropertyName = "Nome";
            dgvSupplier.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvSupplier.Columns.Add("Contacto", "Contacto");
            dgvSupplier.Columns["Contacto"].DataPropertyName = "Contacto";
            dgvSupplier.Columns["Contacto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSupplier.Columns.Add("Email", "Email");
            dgvSupplier.Columns["Email"].DataPropertyName = "Email";
            dgvSupplier.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvSupplier.Columns.Add("TempoEntrega", "Tempo de Entrega");
            dgvSupplier.Columns["TempoEntrega"].DataPropertyName = "TempoEntrega";
            dgvSupplier.Columns["TempoEntrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurações de estilo
            dgvSupplier.EnableHeadersVisualStyles = false;
            dgvSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 148, 188); // #0094BC
            dgvSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSupplier.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvSupplier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSupplier.ColumnHeadersHeight = 45;

            dgvSupplier.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvSupplier.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 232, 231);
            dgvSupplier.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSupplier.RowTemplate.Height = 35;
            dgvSupplier.GridColor = Color.LightGray;
            dgvSupplier.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSupplier.BorderStyle = BorderStyle.Fixed3D;

            dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplier.MultiSelect = false;
            dgvSupplier.ReadOnly = true;
            dgvSupplier.ScrollBars = ScrollBars.Both;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvSupplier.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
        }

        private void LoadFornecedores()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT id AS ID, nome AS Nome, contacto AS Contacto, 
                               email AS Email, tempo_de_entrega AS TempoEntrega
                        FROM fornecedor
                        ORDER BY nome";

                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        supplierTable = new DataTable();
                        adapter.Fill(supplierTable);

                        supplierView = new DataView(supplierTable);
                        supplierView.RowFilter = ""; // Exibir tudo inicialmente
                        dgvSupplier.DataSource = supplierView;
                        dgvSupplier.Refresh();
                    }
                }

                if (dgvSupplier.Rows.Count > 0)
                {
                    AjustarLarguraColunas();
                    dgvSupplier.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverFornecedor(int id, string nome)
        {
            try
            {
                DialogResult confirm = MessageBox.Show(
                    $"Tem certeza que deseja remover o fornecedor '{nome}'?",
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
                                string query = "DELETE FROM fornecedor WHERE id = @id";
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
                                                $"Removeu fornecedor #{id} → Nome: {nome}"
                                            );
                                        }
                                        catch (Exception logEx)
                                        {
                                            Console.WriteLine($"Erro ao registar log de remoção de fornecedor: {logEx.Message}");
                                        }

                                        MessageBox.Show("Fornecedor removido com sucesso!", "Sucesso",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadFornecedores();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Não foi possível remover o fornecedor.", "Aviso",
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
                MessageBox.Show($"Erro ao remover fornecedor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Modal Container Methods
        private void CreateModalContainer()
        {
            modalContainer = new Panel
            {
                Size = new Size(837, 600),
                BackColor = Color.FromArgb(0, 148, 188), // #0094BC
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

        private void btnAddFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                CreateModalContainer();
                LoadAddSupplierInContainer();
            }
            catch (Exception ex)
            {
                CloseModalContainer();
                MessageBox.Show($"Erro ao abrir formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAddSupplierInContainer()
        {
            SupplierAdd addForm = new SupplierAdd
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(addForm);
            addForm.FormClosed += OnAddSupplierClosed;
            addForm.Show();
        }

        private void OnAddSupplierClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadFornecedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                try
                {
                    int supplierId = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["ID"].Value);
                    CreateModalContainer();
                    LoadEditSupplierInContainer(supplierId);
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
                MessageBox.Show("Selecione um fornecedor para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEditSupplierInContainer(int supplierId)
        {
            EditSupplierForm editForm = new EditSupplierForm(supplierId)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(editForm);
            editForm.FormClosed += OnEditSupplierClosed;
            editForm.Show();
        }

        private void OnEditSupplierClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadFornecedores();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                try
                {
                    int supplierId = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells["ID"].Value);
                    string nomeSupplier = dgvSupplier.SelectedRows[0].Cells["Nome"].Value?.ToString();

                    RemoverFornecedor(supplierId, nomeSupplier);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar remoção: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para remover.", "Aviso",
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
