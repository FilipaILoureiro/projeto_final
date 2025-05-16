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
    public partial class AddOrderForm : Form
    {
        private List<(int idProduto, int quantidade)> produtosSelecionados = new();
        public AddOrderForm()
        {
            InitializeComponent();
            cbEntregue.Items.AddRange(new string[] { "Sim", "Não" });
            cbPago.Items.AddRange(new string[] { "Pago", "Não pago" });

        }


        private void btnProdutos_Click(object sender, EventArgs e)
        {
            var galeria = new ProductGalleryForm();
            if (galeria.ShowDialog() == DialogResult.OK)
            {
                produtosSelecionados = galeria.ProdutosSelecionados
                    .Select(p => (p.productId, p.quantidade))
                    .ToList();

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using var conn = new SQLiteConnection("Data Source=projetoPadariaApp.db");
            conn.Open();
            string query = @"INSERT INTO enc (nif_clientes, preco, data_recolha, pago, entregue) 
             VALUES (@nif, @preco, @dataRecolha, @pago, @entregue)";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nif", txtNIF.Text);
            cmd.Parameters.AddWithValue("@dataRecolha", dtpDataRecolha.Value);
            cmd.Parameters.AddWithValue("@pago", cbPago.SelectedItem.ToString().ToLower());

            // Converter "Sim" para "S" e "Não" para "N"
            string valorEntregue = cbEntregue.SelectedItem.ToString() == "Sim" ? "S" : "N";
            cmd.Parameters.AddWithValue("@entregue", valorEntregue);

            // Calcula o total dos produtos
            double total = 0;
            foreach (var (id, qtdd) in produtosSelecionados)
            {
                using var cmdProduto = new SQLiteCommand("SELECT preco FROM produtos WHERE id = @id", conn);
                cmdProduto.Parameters.AddWithValue("@id", id);
                var preco = Convert.ToDouble(cmdProduto.ExecuteScalar());
                total += preco * qtdd;
            }
            cmd.Parameters.AddWithValue("@preco", total);
            cmd.ExecuteNonQuery();

            long lastId = conn.LastInsertRowId;

            foreach (var (idProduto, qtdd) in produtosSelecionados)
            {
                var cmdInsertProd = new SQLiteCommand(
                    "INSERT INTO enc_prod (id_enc, id_prod, qtdd) VALUES (@idEnc, @idProd, @qtdd)", conn);
                cmdInsertProd.Parameters.AddWithValue("@idEnc", lastId);
                cmdInsertProd.Parameters.AddWithValue("@idProd", idProduto);
                cmdInsertProd.Parameters.AddWithValue("@qtdd", qtdd);
                cmdInsertProd.ExecuteNonQuery();
            }

            MessageBox.Show("Encomenda adicionada com sucesso!");
            this.Close();
        }
    }
}
