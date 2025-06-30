using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Services;
using System.Data.SQLite;
using PadariaApp;
using Guna.UI2.WinForms;
using projetoPadariaApp.Models;
using projetoPadariaApp.Forms_Login_e_Registo;

namespace projetoPadariaApp.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthService.AuthenticateUser(username, password))
            {
                using (var conn = DatabaseManage.GetInstance().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, usar_pass_temp, id_funcao FROM funcionario WHERE username = @username";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int funcionarioId = Convert.ToInt32(reader["id"]);
                                bool usarPassTemp = Convert.ToInt32(reader["usar_pass_temp"]) == 1;
                                int idFuncao = Convert.ToInt32(reader["id_funcao"]);

                                if (usarPassTemp)
                                {
                                    MessageBox.Show("Estás a usar uma password temporária. Por favor define uma nova password.");
                                    AlterarPasswordForm alterarForm = new AlterarPasswordForm(funcionarioId);
                                    this.Hide();
                                    alterarForm.ShowDialog();
                                    this.Show();
                                    return;
                                }

                                MessageBox.Show("Login bem-sucedido!");

                                bool isAdmin = AuthService.IsAdmin(username);

                                if (isAdmin)
                                {
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.Show();
                                }
                                else
                                {
                                    EmployeeForm employeeForm = new EmployeeForm();
                                    employeeForm.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao obter dados do utilizador após autenticação.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou senha incorretos!");
            }
        }
    }
}


