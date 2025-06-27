using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using BCrypt.Net;
using PadariaApp;
using projetoPadariaApp.Forms;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    public partial class EmployeeManagementForm : Form
    {
        private DataTable employeesTable;
        private DataView employeesView;
        private string currentUserUsername;

        public EmployeeManagementForm(string loggedUsername = "")
        {
            currentUserUsername = loggedUsername;
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            ConfigurarComboBoxes();
            LoadEmployees();
        }

        private void ConfigurarEventHandlers()
        {
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            dgvEmployees.DataBindingComplete += dgvEmployees_DataBindingComplete;
            dgvEmployees.Resize += dgvEmployees_Resize;
            cbAtivo.SelectedIndexChanged += cbAtivo_SelectedIndexChanged;
        }

        private void ConfigurarComboBoxes()
        {
            cbAtivo.Items.Clear();
            cbAtivo.Items.Add("Todos");
            cbAtivo.Items.Add("Ativos");
            cbAtivo.Items.Add("Desativos");
            cbAtivo.SelectedIndex = 1;
        }

        private void dgvEmployees_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvEmployees.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvEmployees.ClientSize.Width;

                if (dgvEmployees.Columns.Contains("Id"))
                    dgvEmployees.Columns["Id"].Width = (int)(larguraTotal * 0.08);
                if (dgvEmployees.Columns.Contains("Nome"))
                    dgvEmployees.Columns["Nome"].Width = (int)(larguraTotal * 0.25);
                if (dgvEmployees.Columns.Contains("Contacto"))
                    dgvEmployees.Columns["Contacto"].Width = (int)(larguraTotal * 0.15);
                if (dgvEmployees.Columns.Contains("Username"))
                    dgvEmployees.Columns["Username"].Width = (int)(larguraTotal * 0.15);
                if (dgvEmployees.Columns.Contains("Funcao"))
                    dgvEmployees.Columns["Funcao"].Width = (int)(larguraTotal * 0.15);
                if (dgvEmployees.Columns.Contains("Status"))
                    dgvEmployees.Columns["Status"].Width = (int)(larguraTotal * 0.10);
                if (dgvEmployees.Columns.Contains("Admin"))
                    dgvEmployees.Columns["Admin"].Width = (int)(larguraTotal * 0.12);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void AplicarFiltros()
        {
            if (employeesTable == null || employeesView == null) return;

            try
            {
                string filtro = "";

                // Filtro por pesquisa
                if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
                {
                    string pesquisa = txtPesquisa.Text.Trim().Replace("'", "''");

                    if (int.TryParse(pesquisa, out int id))
                    {
                        filtro = $"Id = {id} OR Nome LIKE '%{pesquisa}%' OR Contacto LIKE '%{pesquisa}%' OR Username LIKE '%{pesquisa}%' OR Funcao LIKE '%{pesquisa}%'";
                    }
                    else
                    {
                        filtro = $"Nome LIKE '%{pesquisa}%' OR Contacto LIKE '%{pesquisa}%' OR Username LIKE '%{pesquisa}%' OR Funcao LIKE '%{pesquisa}%'";
                    }
                }

                // Filtro por status (Ativo/Desativo)
                string statusFilter = "";
                if (cbAtivo.SelectedItem != null)
                {
                    switch (cbAtivo.SelectedItem.ToString())
                    {
                        case "Ativos":
                            statusFilter = "Ativo = 'S'";
                            break;
                        case "Desativos":
                            statusFilter = "Ativo = 'N'";
                            break;
                        case "Todos":
                            statusFilter = "";
                            break;
                    }
                }

                // Combinar filtros
                if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(statusFilter))
                {
                    filtro = $"({filtro}) AND ({statusFilter})";
                }
                else if (!string.IsNullOrEmpty(statusFilter))
                {
                    filtro = statusFilter;
                }

                employeesView.RowFilter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                employeesView.RowFilter = "";
            }
        }

        #region Event Handlers para Filtros
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cbAtivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        #endregion

        private void dgvEmployees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
            FormatarLinhasDesativas();
        }

        private void FormatarLinhasDesativas()
        {
            try
            {
                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    if (row.Cells["Ativo"].Value != null)
                    {
                        bool isAtivo = Convert.ToBoolean(row.Cells["Ativo"].Value);
                        if (!isAtivo)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao formatar linhas: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvEmployees.Columns.Clear();
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.ColumnHeadersVisible = true;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvEmployees.Columns.Add("Id", "ID");
            dgvEmployees.Columns["Id"].DataPropertyName = "Id";
            dgvEmployees.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmployees.Columns.Add("Nome", "Nome");
            dgvEmployees.Columns["Nome"].DataPropertyName = "Nome";
            dgvEmployees.Columns["Nome"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvEmployees.Columns.Add("Contacto", "Contacto");
            dgvEmployees.Columns["Contacto"].DataPropertyName = "Contacto";
            dgvEmployees.Columns["Contacto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmployees.Columns.Add("Username", "Username");
            dgvEmployees.Columns["Username"].DataPropertyName = "Username";
            dgvEmployees.Columns["Username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvEmployees.Columns.Add("Funcao", "Função");
            dgvEmployees.Columns["Funcao"].DataPropertyName = "Funcao";
            dgvEmployees.Columns["Funcao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Coluna Status (Ativo/Desativo)
            dgvEmployees.Columns.Add("Status", "Status");
            dgvEmployees.Columns["Status"].DataPropertyName = "StatusText";
            dgvEmployees.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Coluna Admin (Sim/Não)
            dgvEmployees.Columns.Add("Admin", "Admin");
            dgvEmployees.Columns["Admin"].DataPropertyName = "AdminText";
            dgvEmployees.Columns["Admin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Colunas ocultas para controle
            dgvEmployees.Columns.Add("Ativo", "Ativo");
            dgvEmployees.Columns["Ativo"].DataPropertyName = "Ativo";
            dgvEmployees.Columns["Ativo"].Visible = false;

            dgvEmployees.Columns.Add("IsAdmin", "IsAdmin");
            dgvEmployees.Columns["IsAdmin"].DataPropertyName = "IsAdmin";
            dgvEmployees.Columns["IsAdmin"].Visible = false;

            // Configurações de estilo - seguindo o padrão do ProductManagementForm
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(183, 28, 70);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployees.ColumnHeadersHeight = 45;

            dgvEmployees.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 232, 231);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.GridColor = Color.LightGray;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvEmployees.BorderStyle = BorderStyle.Fixed3D;

            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.ScrollBars = ScrollBars.Both;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
        }

        private void LoadEmployees()
        {
            try
            {
                using (var connection = DatabaseManage.GetInstance().GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                        f.id as Id,
                                        f.nome as Nome,
                                        f.contacto as Contacto,
                                        f.username as Username,
                                        func.funcao as Funcao,
                                        COALESCE(f.ativo, 'S') as Ativo,
                                        CASE WHEN COALESCE(f.ativo, 'S') = 'S' THEN 'Ativo' ELSE 'Desativo' END as StatusText,
                                        COALESCE(t.admin, 'N') as IsAdmin,
                                        CASE WHEN COALESCE(t.admin, 'N') = 'S' THEN 'Sim' ELSE 'Não' END as AdminText
                                    FROM funcionario f
                                    LEFT JOIN funcao func ON f.id_funcao = func.id_funcao
                                    LEFT JOIN tipo_de_func t ON f.id = t.id_funcionario
                                    ORDER BY f.nome";

                    using (var adapter = new SQLiteDataAdapter(query, connection))
                    {
                        employeesTable = new DataTable();
                        adapter.Fill(employeesTable);

                        employeesView = new DataView(employeesTable);
                        dgvEmployees.DataSource = employeesView;
                        dgvEmployees.Refresh();
                    }
                }

                if (dgvEmployees.Rows.Count > 0)
                {
                    AjustarLarguraColunas();
                    dgvEmployees.ClearSelection();
                }

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeactivateEmployee(int employeeId)
        {
            try
            {
                using (var connection = DatabaseManage.GetInstance().GetConnection())
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verificar se a coluna 'ativo' existe
                            string checkColumnQuery = "PRAGMA table_info(funcionario)";
                            using (var checkCmd = new SQLiteCommand(checkColumnQuery, connection, transaction))
                            {
                                var reader = checkCmd.ExecuteReader();
                                bool hasAtivoColumn = false;
                                while (reader.Read())
                                {
                                    if (reader["name"].ToString() == "ativo")
                                    {
                                        hasAtivoColumn = true;
                                        break;
                                    }
                                }
                                reader.Close();

                                if (!hasAtivoColumn)
                                {
                                    string addColumnQuery = "ALTER TABLE funcionario ADD COLUMN ativo INTEGER DEFAULT 1";
                                    using (var addCmd = new SQLiteCommand(addColumnQuery, connection, transaction))
                                    {
                                        addCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            string updateQuery = "UPDATE funcionario SET ativo = 0 WHERE id = @id";
                            using (var cmd = new SQLiteCommand(updateQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", employeeId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Funcionário desativado com sucesso!", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadEmployees();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Não foi possível desativar o funcionário.", "Aviso",
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
                MessageBox.Show($"Erro ao desativar funcionário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActivateEmployee(int employeeId)
        {
            try
            {
                using (var connection = DatabaseManage.GetInstance().GetConnection())
                {
                    connection.Open();
                    string updateQuery = "UPDATE funcionario SET ativo = 1 WHERE id = @id";
                    using (var cmd = new SQLiteCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Funcionário ativado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ativar funcionário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Botões de Ação - Seguindo padrão do ProductManagementForm
        private Panel modalContainer;

        private void btnAddFunc_Click(object sender, EventArgs e)
        {
            try
            {
                CreateModalContainer();
                LoadAddEmployeeInContainer();
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

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != modalContainer)
                    ctrl.Enabled = false;
            }
        }

        private void LoadAddEmployeeInContainer()
        {
            RegisterForm registerForm = new RegisterForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(registerForm);
            registerForm.FormClosed += OnAddEmployeeClosed;
            registerForm.Show();
        }

        private void OnAddEmployeeClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadEmployees();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                try
                {
                    int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
                    CreateModalContainer();
                    LoadEditEmployeeInContainer(employeeId);
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
                MessageBox.Show("Selecione um funcionário para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadEditEmployeeInContainer(int employeeId)
        {
            EditEmployeeForm editForm = new EditEmployeeForm(employeeId)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            modalContainer.Controls.Add(editForm);
            editForm.FormClosed += OnEditEmployeeClosed;
            editForm.Show();
        }

        private void OnEditEmployeeClosed(object sender, FormClosedEventArgs e)
        {
            CloseModalContainer();
            LoadEmployees();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                try
                {
                    int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
                    string nomeEmployee = dgvEmployees.SelectedRows[0].Cells["Nome"].Value?.ToString();
                    bool isAtivo = Convert.ToBoolean(dgvEmployees.SelectedRows[0].Cells["Ativo"].Value);

                    string action = isAtivo ? "desativar" : "ativar";
                    string confirmMsg = $"Tem a certeza que deseja {action} o funcionário '{nomeEmployee}'?";

                    if (MessageBox.Show(confirmMsg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (isAtivo)
                        {
                            DeactivateEmployee(employeeId);
                        }
                        else
                        {
                            ActivateEmployee(employeeId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar alteração: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para alterar o status.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPromover_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                try
                {
                    string employeeUsername = dgvEmployees.SelectedRows[0].Cells["Username"].Value?.ToString();
                    string nomeEmployee = dgvEmployees.SelectedRows[0].Cells["Nome"].Value?.ToString();
                    bool isAdmin = dgvEmployees.SelectedRows[0].Cells["IsAdmin"].Value?.ToString() == "S";

                    if (isAdmin)
                    {
                        MessageBox.Show("Este funcionário já é administrador.", "Informação",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show($"Tem a certeza que deseja promover '{nomeEmployee}' a administrador?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool success = AuthService.PromoteToAdmin(currentUserUsername, employeeUsername);

                        if (success)
                        {
                            LoadEmployees();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar promoção: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para promover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            /*if (dgvEmployees.SelectedRows.Count > 0)
            {
                try
                {
                    string employeeUsername = dgvEmployees.SelectedRows[0].Cells["Username"].Value?.ToString();
                    string nomeEmployee = dgvEmployees.SelectedRows[0].Cells["Nome"].Value?.ToString();

                    if (MessageBox.Show($"Tem a certeza que deseja redefinir a senha de '{nomeEmployee}'?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Usar o método do AuthService para redefinir senha
                        bool success = AuthService.ResetPassword(employeeUsername);

                        if (!success)
                        {
                            MessageBox.Show("Erro ao redefinir a senha.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao processar redefinição de senha: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para redefinir a senha.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtPesquisa.Text = "";
                cbAtivo.SelectedIndex = 1; // Voltar para "Ativos"
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
