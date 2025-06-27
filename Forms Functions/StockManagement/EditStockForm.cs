using PadariaApp;
using projetoPadariaApp.Services;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static projetoPadariaApp.Forms.RegisterForm;

namespace projetoPadariaApp.Forms_Functions.StockManagement
{
    public partial class EditStockForm : Form
    {
        private int stockId;
        private StockData _stockOriginal;
        private StockData _stockAtual;

        // Classe auxiliar para armazenar dados do stock
        private class StockData
        {
            public string Nome { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }
            public int FornecedorId { get; set; }
            public int Iva { get; set; }
        }

        public EditStockForm(int id)
        {
            InitializeComponent();
            stockId = id;

            ConfigurarComboBoxes();
            ConfigurarValidacoes();
            LoadFornecedores();
            LoadDadosStock();
        }

        private void ConfigurarComboBoxes()
        {
            cbIva.Items.Clear();
            cbIva.Items.AddRange(new object[] { 6, 13, 23 });
            cbIva.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarValidacoes()
        {
            // Validação para preço - só números, vírgula e ponto
            txtPreco.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' &&
                    e.KeyChar != (char)Keys.Delete && e.KeyChar != '.' && e.KeyChar != ',')
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números e vírgula/ponto decimal são permitidos", txtPreco, 0, -20, 2000);
                }
            };

            // Validação para quantidade - só números
            txtQuantidade.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números são permitidos", txtQuantidade, 0, -20, 2000);
                }
            };

            txtNome.MaxLength = 100;
            txtPreco.MaxLength = 10;
            txtQuantidade.MaxLength = 6;
        }

        private void LoadFornecedores()
        {
            try
            {
                cbFornecedor.Items.Clear();
                var dbManager = DatabaseManage.GetInstance();
                using (var connection = dbManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, nome FROM fornecedor ORDER BY nome";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var funcaoItem = new FuncaoItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                };
                                cbFornecedor.Items.Add(funcaoItem);
                            }
                        }
                    }
                }

                cbFornecedor.DisplayMember = "Name";
                cbFornecedor.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDadosStock()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT nome, preco, quantidade, id_fornecedor, iva FROM materia WHERE id = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", stockId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Carregar dados originais
                                _stockOriginal = new StockData
                                {
                                    Nome = reader["nome"].ToString(),
                                    Preco = Convert.ToDouble(reader["preco"]),
                                    Quantidade = Convert.ToInt32(reader["quantidade"]),
                                    FornecedorId = Convert.ToInt32(reader["id_fornecedor"]),
                                    Iva = Convert.ToInt32(reader["iva"])
                                };

                                // Preencher campos do formulário
                                PreencherCampos();
                            }
                            else
                            {
                                MessageBox.Show("Stock não encontrado!", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do stock: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void PreencherCampos()
        {
            try
            {
                txtNome.Text = _stockOriginal.Nome;
                txtPreco.Text = _stockOriginal.Preco.ToString("0.00");
                txtQuantidade.Text = _stockOriginal.Quantidade.ToString();
                cbIva.SelectedItem = _stockOriginal.Iva;

                // Selecionar fornecedor
                foreach (FuncaoItem item in cbFornecedor.Items)
                {
                    if (item.Id == _stockOriginal.FornecedorId)
                    {
                        cbFornecedor.SelectedItem = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher campos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome da matéria-prima é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome deve ter pelo menos 2 caracteres");
            }

            // Validar preço
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                erros.Add("• Preço é obrigatório");
            }
            else if (!double.TryParse(txtPreco.Text.Replace("€", "").Replace(" ", "").Replace(',', '.'),
                System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double preco) || preco < 0)
            {
                erros.Add("• Preço deve ser um valor válido e não negativo");
            }
            else if (preco > 999999.99)
            {
                erros.Add("• Preço não pode ser superior a 999.999,99€");
            }

            // Validar quantidade
            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                erros.Add("• Quantidade é obrigatória");
            }
            else if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
            {
                erros.Add("• Quantidade deve ser um número válido e não negativo");
            }
            else if (quantidade > 999999)
            {
                erros.Add("• Quantidade não pode ser superior a 999.999");
            }

            // Validar fornecedor
            if (cbFornecedor.SelectedItem == null)
            {
                erros.Add("• Fornecedor é obrigatório");
            }

            // Validar IVA
            if (cbIva.SelectedItem == null)
            {
                erros.Add("• Taxa de IVA é obrigatória");
            }

            // Verificar se nome já existe (exceto para o item atual)
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (VerificarNomeExistente(txtNome.Text.Trim()))
                {
                    erros.Add("• Já existe uma matéria-prima com este nome");
                }
            }

            if (erros.Count > 0)
            {
                string mensagem = "Por favor, corrija os seguintes erros:\n\n" + string.Join("\n", erros);
                MessageBox.Show(mensagem, "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool VerificarNomeExistente(string nome)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT COUNT(*) FROM materia WHERE LOWER(nome) = LOWER(@nome) AND id != @id", conn);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@id", stockId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar nome da matéria-prima: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool PossuiAlteracoes()
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtPreco.Text) ||
                string.IsNullOrEmpty(txtQuantidade.Text) || cbFornecedor.SelectedItem == null ||
                cbIva.SelectedItem == null)
            {
                return false;
            }

            if (txtNome.Text.Trim() != _stockOriginal.Nome)
                return true;

            if (double.TryParse(txtPreco.Text.Replace(',', '.'), out double precoAtual))
            {
                if (Math.Abs(precoAtual - _stockOriginal.Preco) > 0.001)
                    return true;
            }

            if (int.TryParse(txtQuantidade.Text, out int quantidadeAtual))
            {
                if (quantidadeAtual != _stockOriginal.Quantidade)
                    return true;
            }

            var fornecedorSelecionado = cbFornecedor.SelectedItem as FuncaoItem;
            if (fornecedorSelecionado != null && fornecedorSelecionado.Id != _stockOriginal.FornecedorId)
                return true;

            if (cbIva.SelectedItem != null && (int)cbIva.SelectedItem != _stockOriginal.Iva)
                return true;

            return false;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                string nome = txtNome.Text.Trim();
                double preco = double.Parse(txtPreco.Text.Replace("€", "").Replace(" ", "").Replace(',', '.'),
                    System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                int quantidade = int.Parse(txtQuantidade.Text);

                FuncaoItem selectedFornecedor = cbFornecedor.SelectedItem as FuncaoItem;
                int fornecedorId = selectedFornecedor.Id;
                int iva = (int)cbIva.SelectedItem;

                bool sucesso = UpdateStock(nome, Math.Round(preco, 2), quantidade, fornecedorId, iva);

                if (sucesso)
                {
                    MessageBox.Show($"Matéria-prima '{nome}' atualizada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar matéria-prima.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar dados: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool UpdateStock(string nome, double preco, int quantidade, int id_fornecedor, int iva)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = @"UPDATE materia 
                                           SET nome = @nome, 
                                               preco = @preco, 
                                               quantidade = @quantidade, 
                                               id_fornecedor = @id_fornecedor, 
                                               iva = @iva 
                                           WHERE id = @id";

                            using (var cmd = new SQLiteCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", nome);
                                cmd.Parameters.AddWithValue("@preco", preco);
                                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                                cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);
                                cmd.Parameters.AddWithValue("@iva", iva);
                                cmd.Parameters.AddWithValue("@id", stockId);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Registar log
                                    LogsService.RegistarLog(
                                        Session.FuncionarioId,
                                        $"Editou matéria-prima #{stockId} → " +
                                        $"Nome: {nome}, Preço: {preco:F2}€, Qtd: {quantidade}, IVA: {iva}%, Fornecedor #{id_fornecedor}");

                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar matéria-prima: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                if (PossuiAlteracoes())
                {
                    var resultado = MessageBox.Show(
                        "Tem alterações não guardadas. Deseja realmente sair?",
                        "Confirmar Saída",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            base.OnFormClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PossuiAlteracoes())
            {
                var resultado = MessageBox.Show(
                    "Tem alterações não guardadas. Deseja realmente sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
