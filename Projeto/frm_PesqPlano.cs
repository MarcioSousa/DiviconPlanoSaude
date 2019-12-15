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
    public partial class frm_PesqPlano : Form
    {
        public int vcodigo;
        public string vnome;
        public double vvalor;

        public frm_PesqPlano()
        {
            InitializeComponent();
            dgvPrincipal.AutoGenerateColumns = false;
        }

        private void btnPesquisaPlano_Click(object sender, EventArgs e)
        {

        }
        private void frm_PesqPlano_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }
        private void dgvPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Servico planoSaude = (dgvPrincipal.SelectedRows[0].DataBoundItem as Servico);
            vcodigo = planoSaude.Codigo;
            vnome = planoSaude.Nome;
            vvalor = Convert.ToDouble(planoSaude.Valor);
            Close();
        }
        private void txtVida_TextChanged(object sender, EventArgs e)
        {
            ServicoNegocio planoNegocios = new ServicoNegocio();
            ServicoColecao planoColecao = planoNegocios.Consultar(txtPlanoSaude.Text);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = planoColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void carregaGrid()
        {
            ServicoNegocio planoNegocios = new ServicoNegocio();
            ServicoColecao planoColecao = planoNegocios.Consultar("%");

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = planoColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
    }
}