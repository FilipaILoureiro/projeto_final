using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPadariaApp.Forms_Functions
{
    public partial class DocumentListForm : Form
    {
        private DataTable documentsTable;
        private DataView documentsView;
        private string pdfFolderPath;

        public DocumentListForm()
        {
            InitializeComponent();
            pdfFolderPath = Path.Combine(Application.StartupPath, "PDFs");
            ConfigurarDataGridView();
            ConfigurarEventHandlers();
            ConfigurarFiltros();
            LoadDocuments();
        }

        private void ConfigurarEventHandlers()
        {
            cbTipo.SelectedIndexChanged += cmbTipoDocumento_SelectedIndexChanged;
            cbOrdem.SelectedIndexChanged += cmbOrdenacao_SelectedIndexChanged;
            dgvDocumentos.DataBindingComplete += dgvDocumentos_DataBindingComplete;
            dgvDocumentos.Resize += dgvDocumentos_Resize;
            dgvDocumentos.CellDoubleClick += dgvDocumentos_CellDoubleClick;
        }

        private void dgvDocumentos_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void AjustarLarguraColunas()
        {
            if (dgvDocumentos.Columns.Count == 0) return;

            try
            {
                int larguraTotal = dgvDocumentos.ClientSize.Width;

                dgvDocumentos.Columns["NomeDocumento"].Width = (int)(larguraTotal * 0.45);
                dgvDocumentos.Columns["DataCriacao"].Width = (int)(larguraTotal * 0.25);
                dgvDocumentos.Columns["TipoDocumento"].Width = (int)(larguraTotal * 0.20);
                dgvDocumentos.Columns["Tamanho"].Width = (int)(larguraTotal * 0.10);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao ajustar largura das colunas: {ex.Message}");
            }
        }

        private void ConfigurarFiltros()
        {
            // Configurar ComboBox de Tipo de Documento
            cbTipo.Items.Clear();
            cbTipo.Items.Add("Todos");
            cbTipo.Items.Add("Encomendas");
            cbTipo.Items.Add("Logs");
            cbTipo.Items.Add("Outros");
            cbTipo.SelectedIndex = 0;

            // Configurar ComboBox de Ordenação
            cbOrdem.Items.Clear();
            cbOrdem.Items.Add("Data (Mais Recente)");
            cbOrdem.Items.Add("Data (Mais Antigo)");
            cbOrdem.Items.Add("Nome (A-Z)");
            cbOrdem.Items.Add("Nome (Z-A)");
            cbOrdem.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            if (documentsTable == null || documentsView == null) return;

            try
            {
                string filtro = "";

                if (cbTipo.SelectedIndex > 0)
                {
                    string tipoSelecionado = cbTipo.SelectedItem.ToString();
                    filtro = $"TipoDocumento = '{tipoSelecionado}'";
                }

                documentsView.RowFilter = filtro;

                // Aplicar ordenação
                AplicarOrdenacao();

                // Atualizar contagem de documentos filtrados
                lblTotalDocumentos.Text = $"Total de documentos: {documentsView.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar filtros: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                documentsView.RowFilter = "";
                lblTotalDocumentos.Text = $"Total de documentos: {documentsTable?.Rows.Count ?? 0}";
            }
        }

        private void AplicarOrdenacao()
        {
            if (documentsView == null) return;

            try
            {
                string ordenacao = "";
                switch (cbOrdem.SelectedIndex)
                {
                    case 0:
                        ordenacao = "DataCriacao DESC";
                        break;
                    case 1:
                        ordenacao = "DataCriacao ASC";
                        break;
                    case 2:
                        ordenacao = "NomeDocumento ASC";
                        break;
                    case 3:
                        ordenacao = "NomeDocumento DESC";
                        break;
                }

                documentsView.Sort = ordenacao;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao aplicar ordenação: {ex.Message}");
            }
        }

        #region Event Handlers para Filtros
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbOrdenacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarOrdenacao();
        }
        #endregion

        private void dgvDocumentos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AjustarLarguraColunas();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirDocumento();
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvDocumentos.Columns.Clear();
            dgvDocumentos.AutoGenerateColumns = false;
            dgvDocumentos.ColumnHeadersVisible = true;
            dgvDocumentos.AllowUserToAddRows = false;
            dgvDocumentos.AllowUserToDeleteRows = false;

            // Configurar colunas
            dgvDocumentos.Columns.Add("NomeDocumento", "Nome do Documento");
            dgvDocumentos.Columns["NomeDocumento"].DataPropertyName = "NomeDocumento";
            dgvDocumentos.Columns["NomeDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvDocumentos.Columns.Add("DataCriacao", "Data de Criação");
            dgvDocumentos.Columns["DataCriacao"].DataPropertyName = "DataCriacao";
            dgvDocumentos.Columns["DataCriacao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvDocumentos.Columns["DataCriacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentos.Columns.Add("TipoDocumento", "Tipo");
            dgvDocumentos.Columns["TipoDocumento"].DataPropertyName = "TipoDocumento";
            dgvDocumentos.Columns["TipoDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDocumentos.Columns.Add("Tamanho", "Tamanho");
            dgvDocumentos.Columns["Tamanho"].DataPropertyName = "Tamanho";
            dgvDocumentos.Columns["Tamanho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Coluna oculta para o caminho completo do arquivo
            dgvDocumentos.Columns.Add("CaminhoCompleto", "Caminho");
            dgvDocumentos.Columns["CaminhoCompleto"].DataPropertyName = "CaminhoCompleto";
            dgvDocumentos.Columns["CaminhoCompleto"].Visible = false;

            dgvDocumentos.EnableHeadersVisualStyles = false;
            dgvDocumentos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#435761");
            dgvDocumentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDocumentos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);
            dgvDocumentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocumentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDocumentos.ColumnHeadersHeight = 45;

            dgvDocumentos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvDocumentos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B3CACC");
            dgvDocumentos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#607D8B");
            dgvDocumentos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDocumentos.RowTemplate.Height = 35;
            dgvDocumentos.GridColor = Color.LightGray;
            dgvDocumentos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDocumentos.BorderStyle = BorderStyle.Fixed3D;

            dgvDocumentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocumentos.MultiSelect = false;
            dgvDocumentos.ReadOnly = true;
            dgvDocumentos.ScrollBars = ScrollBars.Both;
            dgvDocumentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvDocumentos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            AjustarLarguraColunas();
        }

        private void LoadDocuments()
        {
            try
            {
                documentsTable = new DataTable();
                documentsTable.Columns.Add("NomeDocumento", typeof(string));
                documentsTable.Columns.Add("DataCriacao", typeof(DateTime));
                documentsTable.Columns.Add("TipoDocumento", typeof(string));
                documentsTable.Columns.Add("Tamanho", typeof(string));
                documentsTable.Columns.Add("CaminhoCompleto", typeof(string));

                if (!Directory.Exists(pdfFolderPath))
                {
                    Directory.CreateDirectory(pdfFolderPath);
                }

                // Carregar arquivos PDF da pasta
                string[] pdfFiles = Directory.GetFiles(pdfFolderPath, "*.pdf");

                foreach (string filePath in pdfFiles)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string fileName = Path.GetFileNameWithoutExtension(fileInfo.Name);

                    // Determinar o tipo de documento baseado no nome do arquivo
                    string tipoDocumento = DeterminarTipoDocumento(fileName);

                    // Formatar o tamanho do arquivo
                    string tamanhoFormatado = FormatarTamanhoArquivo(fileInfo.Length);

                    DataRow row = documentsTable.NewRow();
                    row["NomeDocumento"] = fileName;
                    row["DataCriacao"] = fileInfo.CreationTime;
                    row["TipoDocumento"] = tipoDocumento;
                    row["Tamanho"] = tamanhoFormatado;
                    row["CaminhoCompleto"] = filePath;

                    documentsTable.Rows.Add(row);
                }

                documentsView = new DataView(documentsTable);
                dgvDocumentos.DataSource = documentsView;

                AplicarOrdenacao();

                dgvDocumentos.Refresh();

                if (dgvDocumentos.Rows.Count > 0)
                {
                    AjustarLarguraColunas();
                    dgvDocumentos.ClearSelection();
                }

                // Atualizar label com contagem
                lblTotalDocumentos.Text = $"Total de documentos: {documentsTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar documentos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DeterminarTipoDocumento(string nomeArquivo)
        {
            string nomeUpper = nomeArquivo.ToUpper();

            if (nomeUpper.Contains("FATURA_ENCOMENDA") || nomeUpper.Contains("ENCOMENDA"))
            {
                return "Encomendas";
            }
            else if (nomeUpper.Contains("LOGS") || nomeUpper.Contains("LOG"))
            {
                return "Logs";
            }

            return "Outros";
        }

        private string FormatarTamanhoArquivo(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        #region Botões de Ação
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirDocumento();
        }

        private void AbrirDocumento()
        {
            if (dgvDocumentos.SelectedRows.Count > 0)
            {
                try
                {
                    string caminhoArquivo = dgvDocumentos.SelectedRows[0].Cells["CaminhoCompleto"].Value?.ToString();

                    if (!string.IsNullOrEmpty(caminhoArquivo) && File.Exists(caminhoArquivo))
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = caminhoArquivo,
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                    else
                    {
                        MessageBox.Show("Arquivo não encontrado!", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadDocuments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir documento: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um documento para abrir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAbrirPasta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(pdfFolderPath))
                {
                    Process.Start("explorer.exe", pdfFolderPath);
                }
                else
                {
                    MessageBox.Show("Pasta de documentos não encontrada!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir pasta: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
            cbOrdem.SelectedIndex = 0; 

            LoadDocuments();

            MessageBox.Show("Lista de documentos atualizada e filtros limpos!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
