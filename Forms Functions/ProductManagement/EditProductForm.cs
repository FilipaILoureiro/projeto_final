using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Models;
using System.Data.SQLite;

namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    public partial class EditProductForm : Form
    {
        private Product _produto;
        private Product _produtoOriginal;
        private string _imagemOriginal = "";
        private string _imagemSelecionada = "";

        public EditProductForm(int produtoId)
        {
            InitializeComponent();

            _produto = new Product();
            CarregarProdutoCompleto(produtoId);

            _produtoOriginal = new Product
            {
                Id = _produto.Id,
                Nome = _produto.Nome,
                Quantidade = _produto.Quantidade,
                Preco = _produto.Preco,
                Iva = _produto.Iva,
                Imagem = _produto.Imagem
            };

            ConfigurarComboBoxes();
            ConfigurarValidacoes();
            PreencherCampos();
        }

        private void ConfigurarComboBoxes()
        {
            cbIVA.Items.Clear();
            cbIVA.Items.AddRange(new object[] { 6, 13, 23 });
            cbIVA.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarValidacoes()
        {
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

            numQuantidade.Minimum = 0;
            numQuantidade.Maximum = 999999;
            txtNome.MaxLength = 100;
        }

        private void CarregarProdutoCompleto(int produtoId)
        {
            try
            {
                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT id, nome, quantidade, preco, iva, imagem FROM produtos WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", produtoId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _produto.Id = reader.GetInt32(0);
                            _produto.Nome = reader.GetString(1);
                            _produto.Quantidade = reader.GetInt32(2);
                            _produto.Preco = reader.GetDouble(3);
                            _produto.Iva = reader.GetInt32(4);
                            _produto.Imagem = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void PreencherCampos()
        {
            try
            {
                txtNome.Text = _produto.Nome;
                numQuantidade.Value = _produto.Quantidade;
                txtPreco.Text = _produto.Preco.ToString("0.00");
                cbIVA.SelectedItem = _produto.Iva;

                _imagemOriginal = _produto.Imagem ?? "";
                _imagemSelecionada = _imagemOriginal;
                CarregarImagem(_imagemOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher campos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarImagem(string nomeFicheiroImagem)
        {
            try
            {
                if (!string.IsNullOrEmpty(nomeFicheiroImagem))
                {
                    string caminhoCompleto = Path.Combine(Application.StartupPath, "Resources", Path.GetFileName(nomeFicheiroImagem));

                    if (File.Exists(caminhoCompleto))
                    {
                        using (var img = Image.FromFile(caminhoCompleto))
                        {
                            pictureBoxProduto.Image = new Bitmap(img);
                        }
                        pictureBoxProduto.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBoxProduto.BackColor = Color.Transparent;
                        return;
                    }
                }

                pictureBoxProduto.Image = null;
                pictureBoxProduto.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pictureBoxProduto.Image = null;
                pictureBoxProduto.BackColor = Color.LightGray;
            }
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Selecionar Imagem do Produto";
                    openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos os Arquivos|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string caminhoArquivo = openFileDialog.FileName;

                        FileInfo fileInfo = new FileInfo(caminhoArquivo);
                        if (fileInfo.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("A imagem selecionada é muito grande. Por favor, selecione uma imagem menor que 5MB.",
                                "Arquivo Muito Grande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _imagemSelecionada = caminhoArquivo;
                        CarregarImagem(caminhoArquivo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Deseja realmente remover a imagem do produto?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                _imagemSelecionada = "";
                pictureBoxProduto.Image = null;
                pictureBoxProduto.BackColor = Color.LightGray;
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar nome do produto
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome do produto é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome do produto deve ter pelo menos 2 caracteres");
            }

            // Validar preço
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                erros.Add("• Preço é obrigatório");
            }
            else if (!double.TryParse(txtPreco.Text.Replace("€", "").Replace(" ", "").Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double preco) || preco < 0)
            {
                erros.Add("• Preço deve ser um valor válido e não negativo");
            }
            else if (preco > 999999.99)
            {
                erros.Add("• Preço não pode ser superior a 999.999,99€");
            }

            // Validar quantidade
            if (numQuantidade.Value < 0)
            {
                erros.Add("• Quantidade não pode ser negativa");
            }

            // Validar IVA
            if (cbIVA.SelectedIndex == -1)
            {
                erros.Add("• Taxa de IVA é obrigatória");
            }

            // Verificar se nome já existe (exceto para o produto atual)
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (VerificarNomeExistente(txtNome.Text.Trim()))
                {
                    erros.Add("• Já existe um produto com este nome");
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
                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT COUNT(*) FROM produtos WHERE LOWER(nome) = LOWER(@nome) AND id != @id", conn);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@id", _produto.Id);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar nome do produto: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool PossuiAlteracoes()
        {
            if (txtNome.Text.Trim() != _produtoOriginal.Nome)
                return true;

            if ((int)numQuantidade.Value != _produtoOriginal.Quantidade)
                return true;

            if (double.TryParse(txtPreco.Text.Replace(',', '.'), out double precoAtual))
            {
                if (Math.Abs(precoAtual - _produtoOriginal.Preco) > 0.001)
                    return true;
            }

            if (cbIVA.SelectedItem != null && (int)cbIVA.SelectedItem != _produtoOriginal.Iva)
                return true;

            if (_imagemSelecionada != _imagemOriginal)
                return true;

            return false;
        }

        private string CopiarImagemParaPastaProdutos(string caminhoOriginal)
        {
            try
            {
                if (string.IsNullOrEmpty(caminhoOriginal))
                    return "";

                string pastaResources = Path.Combine(Application.StartupPath, "Resources");
                if (!Directory.Exists(pastaResources))
                {
                    Directory.CreateDirectory(pastaResources);
                }

                string nomeFicheiro = Path.GetFileName(caminhoOriginal);
                string caminhoDestino = Path.Combine(pastaResources, nomeFicheiro);

                using (var imagemOriginal = Image.FromFile(caminhoOriginal))
                {
                    Image imagemFinal = imagemOriginal;

                    if (imagemOriginal.Width > 800 || imagemOriginal.Height > 600)
                    {
                        int novaLargura = imagemOriginal.Width > 800 ? 800 : imagemOriginal.Width;
                        int novaAltura = imagemOriginal.Height > 600 ? 600 : imagemOriginal.Height;

                        double ratio = Math.Min((double)novaLargura / imagemOriginal.Width,
                                                (double)novaAltura / imagemOriginal.Height);

                        novaLargura = (int)(imagemOriginal.Width * ratio);
                        novaAltura = (int)(imagemOriginal.Height * ratio);

                        imagemFinal = new Bitmap(imagemOriginal, novaLargura, novaAltura);
                    }

                    imagemFinal.Save(caminhoDestino, System.Drawing.Imaging.ImageFormat.Png);

                    if (imagemFinal != imagemOriginal)
                    {
                        imagemFinal.Dispose();
                    }
                }

                return nomeFicheiro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao copiar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return caminhoOriginal;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_imagemSelecionada) && !string.IsNullOrEmpty(_imagemOriginal))
            {
                _imagemSelecionada = _imagemOriginal;
            }

            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                string caminhoImagemFinal;

                // Caso a imagem não tenha sido alterada, usa a original
                if (string.IsNullOrEmpty(_imagemSelecionada))
                {
                    caminhoImagemFinal = _imagemOriginal;
                }
                else if (_imagemSelecionada != _imagemOriginal && File.Exists(_imagemSelecionada))
                {
                    caminhoImagemFinal = CopiarImagemParaPastaProdutos(_imagemSelecionada);
                }
                else
                {
                    caminhoImagemFinal = Path.GetFileName(_imagemSelecionada);
                }

                // Atualizar os valores do produto com os dados do formulário
                _produto.Nome = txtNome.Text.Trim();
                _produto.Quantidade = (int)numQuantidade.Value;

                if (double.TryParse(txtPreco.Text.Replace("€", "").Replace(" ", "").Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double preco))
                {
                    _produto.Preco = Math.Round(preco, 2);
                }
                else
                {
                    _produto.Preco = 0;
                }

                _produto.Iva = (int)cbIVA.SelectedItem;
                _produto.Imagem = caminhoImagemFinal;

                // Atualizar na base de dados
                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            var cmd = new SQLiteCommand(@"UPDATE produtos SET nome = @nome, quantidade = @quantidade, 
                                                        preco = @preco, iva = @iva, imagem = @imagem WHERE id = @id", conn, transaction);

                            cmd.Parameters.AddWithValue("@nome", _produto.Nome);
                            cmd.Parameters.AddWithValue("@quantidade", _produto.Quantidade);
                            cmd.Parameters.AddWithValue("@preco", _produto.Preco);
                            cmd.Parameters.AddWithValue("@iva", _produto.Iva);
                            cmd.Parameters.AddWithValue("@imagem", _produto.Imagem ?? "");
                            cmd.Parameters.AddWithValue("@id", _produto.Id);

                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            // Remover imagem antiga se foi alterada
                            if (!string.IsNullOrEmpty(_imagemOriginal) && _imagemOriginal != caminhoImagemFinal &&
                                File.Exists(_imagemOriginal) && _imagemOriginal.Contains("Resources"))
                            {
                                try
                                {
                                    File.Delete(_imagemOriginal);
                                }
                                catch
                                {
                                    // Ignorar erro ao deletar imagem antiga
                                }
                            }

                            MessageBox.Show($"Produto '{_produto.Nome}' atualizado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
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
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
