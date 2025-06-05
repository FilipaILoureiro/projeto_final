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
using Guna.UI2.WinForms;
using PadariaApp;
using projetoPadariaApp.Models;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            LoadFuncoes();
        }


        //para adicionar o caminho para o ficheiro database
        private static readonly string connectionString = "Data Source=projetoPadariaApp.db;Version=3;";

        private void LoadFuncoes()
        {
            // Limpar o ComboBox
            cbFuncao.Items.Clear();

            // Usar a instância singleton do DatabaseManage
            var dbManager = DatabaseManage.GetInstance();
            using (var connection = dbManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT id_funcao, funcao FROM funcao";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Criar um objeto para armazenar ID e nome da função
                            var funcaoItem = new FuncaoItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            cbFuncao.Items.Add(funcaoItem);
                        }
                    }
                }
            }

            // Configurar o ComboBox para mostrar apenas o nome
            cbFuncao.DisplayMember = "Name";
            cbFuncao.ValueMember = "Id";
        }

        // Classe auxiliar para itens do ComboBox
        public class FuncaoItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string contacto = txtContacto.Text;
            string username = txtUsername.Text;
            string password = txtPass.Text;

            // Obter a função selecionada do ComboBox
            FuncaoItem selectedItem = cbFuncao.SelectedItem as FuncaoItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma função.");
                return;
            }

            int funcaoID = selectedItem.Id;
            bool isAdmin = chkIsAdmin.Checked;

            // Use o nome como username para simplificar
            bool success = AuthService.RegisterUser(nome, contacto, username, password, funcaoID, isAdmin);

            if (success)
            {
                MessageBox.Show("Utilizador registado com sucesso!");
                txtNome.Clear();
                txtContacto.Clear();
                txtUsername.Clear();
                txtPass.Clear();
                cbFuncao.SelectedIndex = -1;
                chkIsAdmin.Checked = false;
            }
            else
            {
                MessageBox.Show("Erro ao registar utilizador.");
            }
        }
    }
}