using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoPadariaApp.Services;

namespace projetoPadariaApp.Forms_Functions
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            this.Load += EmployeeForm_Load;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            string nome = Session.FuncionarioNome ?? "Funcionário";

            string saudacao;
            int hora = DateTime.Now.Hour;

            if (hora < 12)
                saudacao = "Bom dia";
            else if (hora < 18)
                saudacao = "Boa tarde";
            else
                saudacao = "Boa noite";

            lblSaudacao.Text = $"{saudacao}, {nome}!";
            lblSaudacao.Visible = true;
        }

        // data e hora
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            lblData.Text = DateTime.Now.ToLongDateString();
        }
    }
}
