using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using PadariaApp;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions.EmployeeManagement
{
    public partial class EditEmployeeForm : Form
    {
        private int funcionarioID;
        private string nomeOriginal;
        private string contactoOriginal;
        private string usernameOriginal;
        private int funcaoOriginal;

        public EditEmployeeForm(int id)
        {
            InitializeComponent();
            funcionarioID = id;
            ConfigurarValidacoes();
            LoadFuncoes();
            LoadDadosFuncionario();
        }

        private void ConfigurarValidacoes()
        {
            // Limitar comprimento dos campos
            txtNome.MaxLength = 100;
            txtContacto.MaxLength = 100;
            txtUsername.MaxLength = 50;

            // Configurar eventos para limpar erros quando o usuário começar a digitar
            txtNome.TextChanged += (s, e) => LimparErro(txtNome);
            txtContacto.TextChanged += (s, e) => LimparErro(txtContacto);
            txtUsername.TextChanged += (s, e) => LimparErro(txtUsername);

            // Validação em tempo real para username (apenas letras, números e underscore)
            txtUsername.KeyPress += (sender, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '\b' && e.KeyChar != (char)Keys.Delete)
                {
                    e.Handled = true;
                    ToolTip tooltip = new ToolTip();
                    tooltip.Show("Apenas letras, números e underscore são permitidos", txtUsername, 0, -20, 2000);
                }
            };
        }

        private void LoadFuncoes()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT [id_funcao], [funcao] FROM [funcao] ORDER BY [funcao]";

                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        cbFuncao.DataSource = dt;
                        cbFuncao.DisplayMember = "funcao";
                        cbFuncao.ValueMember = "id_funcao";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar funções: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDadosFuncionario()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT f.id, f.nome, f.contacto, f.username, f.id_funcao, func.funcao
                        FROM funcionario f
                        INNER JOIN funcao func ON f.id_funcao = func.id_funcao
                        WHERE f.id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", funcionarioID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Carregar dados atuais
                                txtNome.Text = reader["nome"].ToString();
                                txtContacto.Text = reader["contacto"].ToString();
                                txtUsername.Text = reader["username"].ToString();

                                int idFuncao = Convert.ToInt32(reader["id_funcao"]);
                                cbFuncao.SelectedValue = idFuncao;

                                // Armazenar valores originais para comparação
                                nomeOriginal = txtNome.Text;
                                contactoOriginal = txtContacto.Text;
                                usernameOriginal = txtUsername.Text;
                                funcaoOriginal = idFuncao;

                                // Verificar se a função foi selecionada corretamente
                                if (cbFuncao.SelectedValue == null)
                                {
                                    throw new Exception("A função do funcionário não foi encontrada no sistema.");
                                }
                            }
                            else
                            {
                                throw new Exception($"Funcionário com ID {funcionarioID} não foi encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do funcionário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();
            bool temErros = false;

            // Validar Nome
            string nome = txtNome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                erros.Add("• Nome é obrigatório");
                MostrarErro(txtNome);
                temErros = true;
            }
            else if (nome.Length < 2)
            {
                erros.Add("• Nome deve ter pelo menos 2 caracteres");
                MostrarErro(txtNome);
                temErros = true;
            }
            else if (!Regex.IsMatch(nome, @"^[a-zA-ZÀ-ÿ\s\-'\.]+$"))
            {
                erros.Add("• Nome contém caracteres inválidos");
                MostrarErro(txtNome);
                temErros = true;
            }
            else
            {
                LimparErro(txtNome);
            }

            // Validar Email (contacto)
            string email = txtContacto.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                erros.Add("• Email é obrigatório");
                MostrarErro(txtContacto);
                temErros = true;
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                erros.Add("• Email deve ter um formato válido");
                MostrarErro(txtContacto);
                temErros = true;
            }
            else
            {
                LimparErro(txtContacto);
            }

            // Validar Username
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                erros.Add("• Nome de utilizador é obrigatório");
                MostrarErro(txtUsername);
                temErros = true;
            }
            else if (username.Length < 3)
            {
                erros.Add("• Nome de utilizador deve ter pelo menos 3 caracteres");
                MostrarErro(txtUsername);
                temErros = true;
            }
            else if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                erros.Add("• Nome de utilizador pode conter apenas letras, números e underscore");
                MostrarErro(txtUsername);
                temErros = true;
            }
            else
            {
                LimparErro(txtUsername);
            }

            // Validar Função
            if (cbFuncao.SelectedValue == null)
            {
                erros.Add("• Deve selecionar uma função");
                cbFuncao.Focus();
                temErros = true;
            }

            // Verificar se username é único (apenas se foi alterado)
            if (username != usernameOriginal && !string.IsNullOrEmpty(username))
            {
                if (!VerificarUsernameUnico(username))
                {
                    erros.Add("• Este nome de utilizador já está em uso");
                    MostrarErro(txtUsername);
                    temErros = true;
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

        private bool VerificarUsernameUnico(string username)
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM funcionario WHERE username = @username AND id != @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@id", funcionarioID);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar username: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MostrarErro(Control control)
        {
            control.BackColor = Color.FromArgb(255, 235, 235); // Fundo rosa claro
            control.ForeColor = Color.DarkRed;
        }

        private void LimparErro(Control control)
        {
            control.BackColor = SystemColors.Window;
            control.ForeColor = SystemColors.WindowText;
        }

        private bool HouveAlteracoes()
        {
            return txtNome.Text.Trim() != nomeOriginal ||
                   txtContacto.Text.Trim() != contactoOriginal ||
                   txtUsername.Text.Trim() != usernameOriginal ||
                   Convert.ToInt32(cbFuncao.SelectedValue) != funcaoOriginal;
        }

        private void AtualizarFuncionario()
        {
            try
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();

                    string query = @"
                        UPDATE funcionario 
                        SET nome = @nome, 
                            contacto = @contacto, 
                            username = @username, 
                            id_funcao = @id_funcao
                        WHERE id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@contacto", txtContacto.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_funcao", cbFuncao.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", funcionarioID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Registar log das alterações
                            RegistarLog();

                            MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Nenhum registro foi atualizado. Verifique se o funcionário ainda existe.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar funcionário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistarLog()
        {
            try
            {
                List<string> alteracoes = new List<string>();

                if (txtNome.Text.Trim() != nomeOriginal)
                    alteracoes.Add($"Nome: '{nomeOriginal}' → '{txtNome.Text.Trim()}'");

                if (txtContacto.Text.Trim() != contactoOriginal)
                    alteracoes.Add($"Email: '{contactoOriginal}' → '{txtContacto.Text.Trim()}'");

                if (txtUsername.Text.Trim() != usernameOriginal)
                    alteracoes.Add($"Username: '{usernameOriginal}' → '{txtUsername.Text.Trim()}'");

                if (Convert.ToInt32(cbFuncao.SelectedValue) != funcaoOriginal)
                    alteracoes.Add($"Função: {cbFuncao.Text}");

                string detalhesAlteracoes = string.Join("; ", alteracoes);

                LogsService.RegistarLog(
                    Session.FuncionarioId,
                    $"Atualizou funcionário #{funcionarioID} → {detalhesAlteracoes}"
                );
            }
            catch (Exception ex)
            {
                // Log do erro, mas não impedir a operação principal
                Console.WriteLine($"Erro ao registar log: {ex.Message}");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            // Verificar se houve alterações
            if (!HouveAlteracoes())
            {
                MessageBox.Show("Nenhuma alteração foi detectada.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmar alterações
            var resultado = MessageBox.Show(
                "Tem certeza que deseja salvar as alterações?",
                "Confirmar Alterações",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            // Executar atualização
            AtualizarFuncionario();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HouveAlteracoes())
            {
                var resultado = MessageBox.Show(
                    "Existem alterações não guardadas. Tem certeza que deseja sair?",
                    "Confirmar Saída",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK)
            {
                if (HouveAlteracoes())
                {
                    var resultado = MessageBox.Show(
                        "Existem alterações não guardadas. Tem certeza que deseja sair?",
                        "Confirmar Saída",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            base.OnFormClosing(e);
        }
    }
}
