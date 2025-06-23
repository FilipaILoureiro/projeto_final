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
using projetoPadariaApp.Forms_Functions.ProductManagement;

namespace projetoPadariaApp.Forms_Functions.OrdersManagement
{
    public partial class EditOrderForm : Form
    {
        private int encomendaId;
        private List<(int idProduto, int quantidade)> produtosSelecionados = new();
        public EditOrderForm(int id)
        {
            InitializeComponent();
            encomendaId = id;
            CarregarDadosEncomenda();
        }

        private void CarregarDadosEncomenda()
        {
            using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
            conn.Open();

            // Adicionar as opções às ComboBox
            cbPago.Items.Clear();
            cbPago.Items.AddRange(new[] { "Pago", "Não pago" });

            cbEntregue.Items.Clear();
            cbEntregue.Items.AddRange(new[] { "Sim", "Não" });

            var cmd = new SQLiteCommand("SELECT * FROM enc WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", encomendaId);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNIF.Text = reader["nif_clientes"].ToString();
                dtpDataRecolha.Value = DateTime.Parse(reader["data_recolha"].ToString());

                cbPago.SelectedItem = reader["pago"].ToString() == "pago" ? "Pago" : "Não pago";
                cbEntregue.SelectedItem = reader["entregue"].ToString() == "S" ? "Sim" : "Não";
            }
            reader.Close();

            var cmdProdutos = new SQLiteCommand("SELECT id_prod, qtdd FROM enc_prod WHERE id_enc = @id", conn);
            cmdProdutos.Parameters.AddWithValue("@id", encomendaId);
            var r = cmdProdutos.ExecuteReader();
            while (r.Read())
            {
                produtosSelecionados.Add((
                    Convert.ToInt32(r["id_prod"]),
                    Convert.ToInt32(r["qtdd"])
                ));
            }
        }
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            var galeria = new ProductGalleryForm(produtosSelecionados);
            if (galeria.ShowDialog() == DialogResult.OK)
            {
                produtosSelecionados = galeria.ProdutosSelecionados
                    .Select(p => (p.productId, p.quantidade))
                    .ToList();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
            conn.Open();

            // Atualizar os valores da encomenda, incluindo o valor das ComboBox
            var cmd = new SQLiteCommand("UPDATE enc SET nif_clientes = @nif, data_recolha = @data, pago = @pago, entregue = @entregue WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@nif", txtNIF.Text);
            cmd.Parameters.AddWithValue("@data", dtpDataRecolha.Value);
            cmd.Parameters.AddWithValue("@pago", cbPago.SelectedItem.ToString() == "Pago" ? "pago" : "não pago");
            cmd.Parameters.AddWithValue("@entregue", cbEntregue.SelectedItem.ToString() == "Sim" ? "S" : "N");
            cmd.Parameters.AddWithValue("@id", encomendaId);
            cmd.ExecuteNonQuery();

            // Remover os produtos antigos
            var cmdDeleteOld = new SQLiteCommand("DELETE FROM enc_prod WHERE id_enc = @id", conn);
            cmdDeleteOld.Parameters.AddWithValue("@id", encomendaId);
            cmdDeleteOld.ExecuteNonQuery();

            // Inserir os novos produtos
            foreach (var (idProd, qtdd) in produtosSelecionados)
            {
                var cmdInsert = new SQLiteCommand("INSERT INTO enc_prod (id_enc, id_prod, qtdd) VALUES (@idEnc, @idProd, @qtdd)", conn);
                cmdInsert.Parameters.AddWithValue("@idEnc", encomendaId);
                cmdInsert.Parameters.AddWithValue("@idProd", idProd);
                cmdInsert.Parameters.AddWithValue("@qtdd", qtdd);
                cmdInsert.ExecuteNonQuery();
            }

            MessageBox.Show("Encomenda atualizada com sucesso!");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
