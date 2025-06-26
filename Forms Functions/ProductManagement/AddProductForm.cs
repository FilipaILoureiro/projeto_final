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
using projetoPadariaApp.Models;

namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    public partial class AddProductForm : Form
    {
        private string imagePath = "";
        private string nomeFicheiroImagem = "";

        public AddProductForm()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            ConfigurarValidacoes();
            ConfigurarControlos();
        }

        private void ConfigurarComboBoxes()
        {
            cbIVA.Items.Clear();
            cbIVA.Items.AddRange(new object[] { 6, 13, 23 });
            cbIVA.SelectedIndex = 0;
            cbIVA.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarValidacoes()
        {
            txtNome.TextChanged += (sender, e) =>
            {
                if (txtNome.Text.Length > 50)
                {
                    txtNome.Text = txtNome.Text.Substring(0, 50);
                    txtNome.SelectionStart = txtNome.Text.Length;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Máximo 50 caracteres permitidos", txtNome, 0, -20, 2000);
                }
            };

            txtPreco.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' &&
                    e.KeyChar != (char)Keys.Delete && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas números e vírgula/ponto decimal são permitidos", txtPreco, 0, -20, 2000);
                }

                // Permitir apenas uma vírgula ou ponto
                if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                    (txtPreco.Text.Contains(",") || txtPreco.Text.Contains(".")))
                {
                    e.Handled = true;
                }
            };

            numQuantidade.Minimum = 0;
            numQuantidade.Maximum = 9999;
            numQuantidade.Value = 1; 
        }

        private void ConfigurarControlos()
        {
            pictureBoxProduto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduto.BorderStyle = BorderStyle.FixedSingle;

            txtNome.MaxLength = 50;
            txtPreco.MaxLength = 10;
        }

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                    ofd.Title = "Selecionar Imagem do Produto";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(ofd.FileName))
                        {
                            MessageBox.Show("O ficheiro selecionado não foi encontrado.",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length > 5 * 1024 * 1024) 
                        {
                            MessageBox.Show("A imagem é muito grande. Por favor, selecione uma imagem menor que 5MB.",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        imagePath = ofd.FileName;

                        using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            pictureBoxProduto.Image?.Dispose(); // Libertar imagem anterior
                            pictureBoxProduto.Image = Image.FromStream(stream);
                        }

                        btnEscolherImagem.Text = "Alterar Imagem";
                    }
                }
                nomeFicheiroImagem = Path.GetFileName(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            // Validar Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                erros.Add("• Nome do produto é obrigatório");
            }
            else if (txtNome.Text.Trim().Length < 2)
            {
                erros.Add("• Nome do produto deve ter pelo menos 2 caracteres");
            }

            // Validar Preço
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                erros.Add("• Preço é obrigatório");
            }
            else if (!double.TryParse(txtPreco.Text.Replace('.', ','), out double preco))
            {
                erros.Add("• Preço deve ser um valor numérico válido");
            }
            else if (preco <= 0)
            {
                erros.Add("• Preço deve ser maior que zero");
            }
            else if (preco > 999.99)
            {
                erros.Add("• Preço não pode exceder 999,99€");
            }

            // Validar Quantidade
            if (numQuantidade.Value < 0)
            {
                erros.Add("• Quantidade não pode ser negativa");
            }

            // Validar IVA
            if (cbIVA.SelectedIndex == -1)
            {
                erros.Add("• Taxa de IVA é obrigatória");
            }

            // Verificar se já existe produto com o mesmo nome
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (ProdutoJaExiste(txtNome.Text.Trim()))
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

        private bool ProdutoJaExiste(string nome)
        {
            try
            {
                using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
                conn.Open();

                using var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM produtos WHERE LOWER(nome) = LOWER(@nome)", conn);
                cmd.Parameters.AddWithValue("@nome", nome);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao verificar duplicação: {ex.Message}");
                return false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                string nome = txtNome.Text.Trim();
                int quantidade = (int)numQuantidade.Value;
                double preco = double.Parse(txtPreco.Text.Replace('.', ','));
                int iva = (int)cbIVA.SelectedItem;

                int novoId = -1;

                using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
                {
                    conn.Open();

                    using var transaction = conn.BeginTransaction();

                    try
                    {
                        string query = @"INSERT INTO produtos (nome, quantidade, preco, iva, imagem) 
                                       VALUES (@nome, @quantidade, @preco, @iva, @imagem)";

                        using var cmd = new SQLiteCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@preco", Math.Round(preco, 2));
                        cmd.Parameters.AddWithValue("@iva", iva);
                        cmd.Parameters.AddWithValue("@imagem", nomeFicheiroImagem);

                        cmd.ExecuteNonQuery();
                        novoId = (int)conn.LastInsertRowId;

                        // Guardar imagem se foi selecionada
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            GuardarImagem(novoId);
                        }

                        transaction.Commit();

                        MessageBox.Show($"Produto '{nome}' (ID: {novoId}) adicionado com sucesso!\nPreço: {preco:C2}",
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar produto: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarImagem(int produtoId)
        {
            try
            {
                string pastaResources = "Resources";
                string destino = Path.Combine(pastaResources, nomeFicheiroImagem);

                if (!Directory.Exists(pastaResources))
                {
                    Directory.CreateDirectory(pastaResources);
                }

                using (var imagemOriginal = Image.FromFile(imagePath))
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

                    imagemFinal.Save(destino, System.Drawing.Imaging.ImageFormat.Png);

                    if (imagemFinal != imagemOriginal)
                    {
                        imagemFinal.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Produto foi criado mas houve um erro ao guardar a imagem: {ex.Message}",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool PossuiDadosNaoGuardados()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) ||
                   !string.IsNullOrWhiteSpace(txtPreco.Text) ||
                   numQuantidade.Value != 1 ||
                   cbIVA.SelectedIndex != 0 ||
                   !string.IsNullOrEmpty(imagePath);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                if (PossuiDadosNaoGuardados())
                {
                    var resultado = MessageBox.Show(
                        "Tem dados não guardados. Deseja realmente sair?",
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

            pictureBoxProduto.Image?.Dispose();
            base.OnFormClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show(
                    "Tem dados não guardados. Deseja realmente sair?",
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

