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
using TheArtOfDevHtmlRenderer.Adapters;

namespace projetoPadariaApp.Forms_Functions.ProductManagement
{
    public partial class EditProductForm : Form
    {
        private Product _produto;
        public EditProductForm(Product produto)
        {
            InitializeComponent();
            _produto = produto;

            // Já tens as opções de IVA configuradas no ComboBox, não é necessário adicionar novamente
            cbIVA.Items.AddRange(new object[] { 0, 6, 13, 23 }); // Só precisamos fazer isso uma vez

            PreencherCampos();
        }

        private void PreencherCampos()
        {
            // Preenche os campos com as informações do produto
            txtNome.Text = _produto.Nome;
            numQuantidade.Value = _produto.Quantidade;
            txtPreco.Text = _produto.Preco.ToString("0.00");
            cbIVA.SelectedItem = _produto.Iva;  // Preenche o ComboBox com o valor correto de IVA
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Atualizar os valores do produto com os dados do formulário
            _produto.Nome = txtNome.Text;
            _produto.Quantidade = (int)numQuantidade.Value;
            _produto.Preco = double.TryParse(txtPreco.Text, out double preco) ? preco : 0;
            _produto.Iva = (int)cbIVA.SelectedItem;

            // Atualizar na base de dados
            using (var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE produtos SET nome = @nome, quantidade = @quantidade, preco = @preco, iva = @iva WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@nome", _produto.Nome);
                cmd.Parameters.AddWithValue("@quantidade", _produto.Quantidade);
                cmd.Parameters.AddWithValue("@preco", _produto.Preco);
                cmd.Parameters.AddWithValue("@iva", _produto.Iva);
                cmd.Parameters.AddWithValue("@id", _produto.Id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Produto atualizado com sucesso!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
