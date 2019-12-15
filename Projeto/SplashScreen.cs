using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Negocios;
using Dto;

namespace Projeto
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            decimal a, b;

            progressBar1.Visible = false;

            for(a = 0; a <= 80; a++)
            {
                b = a / 80;
                Opacity = Convert.ToDouble(b);
                Refresh();
            }

            timer1.Enabled = true;
            timer1.Interval = 5000;

            timer2.Enabled = true;
            timer2.Interval = 2000;
        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Hide();
        //    timer1.Enabled = false;
        //    frm_Principal principal = new frm_Principal();
        //    principal.ShowDialog();
        //}
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    progressBar1.Visible = true;

        //    timer2.Enabled = false;

        //    progressBar1.Minimum = 0;
        //    progressBar1.Maximum = 300;
        //    progressBar1.Value = 50;

        //    ClienteNegocio clienteNegocios = new ClienteNegocio();
        //    ClienteColecao clienteColecao = clienteNegocios.Consultar("");

        //    progressBar1.Value = 299;
        //    Controls.Add(progressBar1);
        //}
    }
}
