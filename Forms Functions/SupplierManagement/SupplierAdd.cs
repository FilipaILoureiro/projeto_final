using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PadariaApp;
using projetoPadariaApp.Services;
using static System.Collections.Specialized.BitVector32;

namespace projetoPadariaApp.Forms_Functions.SupplierManagement
{
    public partial class SupplierAdd : Form
    {
        public SupplierAdd()
        {
            InitializeComponent();
            ConfigurarControlos();
            ConfigurarValidacoes();
        }

        private void ConfigurarControlos()
        {
            txtNome.MaxLength = 50;
            txtContacto.MaxLength = 9;
            txtEmail.MaxLength = 50;
            txtTempodeEntrega.MaxLength = 3;
        }

        private void ConfigurarValidacoes()
        {
            txtContacto.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '+' && e.KeyChar != ' ')
                {
                    e.Handled = true;
                    new ToolTip().Show("Apenas números, espaços e '+' permitidos", txtContacto, 0, -20, 2000);
                }
            };

            txtEmail.TextChanged += (s, e) =>
            {
                if (txtEmail.Text.Length > 50)
                {
                    txtEmail.Text = txtEmail.Text.Substring(0, 50);
                    txtEmail.SelectionStart = txtEmail.Text.Length;
                    new ToolTip().Show("Máximo de 50 caracteres", txtEmail, 0, -20, 2000);
                }
            };
        }

        private bool ValidarFormulario()
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Trim().Length < 2)
                erros.Add("• Nome do fornecedor deve ter pelo menos 2 caracteres");

            if (string.IsNullOrWhiteSpace(txtContacto.Text) || !Regex.IsMatch(txtContacto.Text, @"^\d{9}$"))
                erros.Add("• Contacto deve conter exatamente 9 dígitos numéricos");

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                erros.Add("• Email inválido");

            if (string.IsNullOrWhiteSpace(txtTempodeEntrega.Text))
                erros.Add("• Tempo de entrega é obrigatório");

            if (FornecedorJaExiste(txtNome.Text.Trim()))
                erros.Add("• Já existe um fornecedor com este nome");

            if (erros.Count > 0)
            {
                MessageBox.Show("Corrija os seguintes erros:\n\n" + string.Join("\n", erros), "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool FornecedorJaExiste(string nome)
        {
            try
            {
                var db = DatabaseManage.GetInstance();
                using var conn = db.GetConnection();
                conn.Open();
                using var cmd = new SQLiteCommand("SELECT COUNT(*) FROM fornecedor WHERE LOWER(nome) = LOWER(@nome)", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool PossuiDadosNaoGuardados()
        {
            return !string.IsNullOrWhiteSpace(txtNome.Text) ||
                   !string.IsNullOrWhiteSpace(txtContacto.Text) ||
                   !string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   !string.IsNullOrWhiteSpace(txtTempodeEntrega.Text);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.DialogResult != DialogResult.OK && PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show("Tem dados não guardados. Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtContacto.Clear();
            txtEmail.Clear();
            txtTempodeEntrega.Clear();
            txtNome.Focus();
        }

        public static bool RegisterSupplier(string nome, string contacto, string email, string tempoDeEntrega)
        {
            var db = DatabaseManage.GetInstance();
            using var conn = db.GetConnection();

            try
            {
                conn.Open();
                using var tx = conn.BeginTransaction();
                var query = "INSERT INTO fornecedor (nome, contacto, email, tempo_de_entrega) VALUES (@nome, @contacto, @email, @tempo)";
                using var cmd = new SQLiteCommand(query, conn, tx);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@contacto", contacto);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@tempo", tempoDeEntrega);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    tx.Commit();
                    LogsService.RegistarLog(Session.FuncionarioId ?? 0, $"Fornecedor «{nome}» registado com sucesso.");
                    return true;
                }
                tx.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            bool sucesso = RegisterSupplier(txtNome.Text.Trim(), txtContacto.Text.Trim(), txtEmail.Text.Trim(), txtTempodeEntrega.Text.Trim());

            if (sucesso)
            {
                MessageBox.Show(
                    $"Fornecedor «{txtNome.Text.Trim()}» registado com sucesso!\n" +
                    $"Contacto: {txtContacto.Text.Trim()}\n" +
                    $"Email: {txtEmail.Text.Trim()}\n" +
                    $"Tempo de entrega: {txtTempodeEntrega.Text.Trim()}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao registar fornecedor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PossuiDadosNaoGuardados())
            {
                var resultado = MessageBox.Show("Tem dados não guardados. Deseja sair?", "Confirmar Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No) return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
