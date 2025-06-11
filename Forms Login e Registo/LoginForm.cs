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

namespace projetoPadariaApp.Forms
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Text = "Formulário de Login";
            this.Load += loginForm_Load;
            this.Resize += (s, e) => RedimensionarControlos(this.Controls);
        }

        private Dictionary<Control, ControlInfo> controlInfo = new Dictionary<Control, ControlInfo>();
        private Size originalFormSize;

        private void loginForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            GuardarValoresOriginais(this.Controls);
        }

        private void GuardarValoresOriginais(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                controlInfo[ctrl] = new ControlInfo
                {
                    OriginalBounds = ctrl.Bounds,
                    OriginalFontSize = ctrl.Font.Size
                };

                if (ctrl.HasChildren)
                {
                    GuardarValoresOriginais(ctrl.Controls);
                }
            }
        }

        private void RedimensionarControlos(Control.ControlCollection controls)
        {
            float escalaX = (float)this.Width / originalFormSize.Width;
            float escalaY = (float)this.Height / originalFormSize.Height;

            // Primeira passagem: Apenas ajustar posição e tamanho de todos os controles
            foreach (Control ctrl in controls)
            {
                if (controlInfo.TryGetValue(ctrl, out ControlInfo info))
                {
                    // Cálculo das novas dimensões e posição
                    int novoX = (int)(info.OriginalBounds.X * escalaX);
                    int novoY = (int)(info.OriginalBounds.Y * escalaY);
                    int novaLargura = (int)(info.OriginalBounds.Width * escalaX);
                    int novaAltura = (int)(info.OriginalBounds.Height * escalaY);

                    // Aplicar as novas dimensões e posição
                    ctrl.Bounds = new Rectangle(novoX, novoY, novaLargura, novaAltura);

                    // Configuração específica por tipo de controle
                    try
                    {
                        float novoTamanhoFonte = Math.Max(8, info.OriginalFontSize * Math.Min(escalaX, escalaY));
                        Font novaFonte = new Font(ctrl.Font.FontFamily, novoTamanhoFonte, ctrl.Font.Style);

                        if (ctrl is Guna2TextBox txt)
                        {
                            txt.AutoSize = false;
                            txt.Font = novaFonte;
                            txt.Bounds = new Rectangle(novoX, novoY, novaLargura, novaAltura);
                            txt.Padding = new Padding(
                                (int)(10 * Math.Min(escalaX, escalaY)),
                                (int)(5 * Math.Min(escalaX, escalaY)),
                                (int)(10 * Math.Min(escalaX, escalaY)),
                                (int)(5 * Math.Min(escalaX, escalaY))
                            );
                            txt.BorderThickness = Math.Max(1, (int)(2 * Math.Min(escalaX, escalaY)));
                            txt.AutoSize = false;
                        }
                        else if (ctrl is Guna2Button btn)
                        {
                            btn.AutoSize = false;
                            btn.Font = novaFonte;
                        }
                        else if (ctrl is Guna2HtmlLabel htmlLabel)
                        {
                            htmlLabel.AutoSize = false;
                            htmlLabel.Font = novaFonte;
                        }
                        else
                        {
                            ctrl.Font = novaFonte;
                        }
                    }
                    catch
                    {
                    }
                }

                // Processar controles filhos
                if (ctrl.HasChildren)
                {
                    RedimensionarControlos(ctrl.Controls);
                }
            }
        }

        private void linkRegisto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthService.AuthenticateUser(username, password))
            {
                MessageBox.Show("Login bem-sucedido!");

                bool isAdmin = AuthService.IsAdmin(username);

                if (isAdmin)
                {
                    AdminForm adminPanel = new AdminForm();
                    adminPanel.Show();
                }
                else
                {
                    EmployeeForm employeePanel = new EmployeeForm();
                    employeePanel.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou senha incorretos!");
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.Show();
        }
    }
}

class ControlInfo
{
    public Rectangle OriginalBounds { get; set; }
    public float OriginalFontSize { get; set; }
}

