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
    public partial class frm_PesqVida : Form
    {
        public int vcodigo;
        public string vnome;

        public frm_PesqVida()
        {
            InitializeComponent();
            dgvPrincipal.AutoGenerateColumns = false;
        }
        private void dgvPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Pessoa Cliente = (dgvPrincipal.SelectedRows[0].DataBoundItem as Pessoa);
            vcodigo = Cliente.Codigo;
            vnome = Cliente.Nome;
            Close();
        }
        private void carregaGrid()
        {
            ClienteNegocio clienteNegocios = new ClienteNegocio();
            ClienteColecao clienteColecao = clienteNegocios.Consultar("%");

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = clienteColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void frm_PesqVida_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }
        private void txtVida_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocios = new ClienteNegocio();
            ClienteColecao clienteColecao = clienteNegocios.Consultar(txtVida.Text);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = clienteColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
    }
}