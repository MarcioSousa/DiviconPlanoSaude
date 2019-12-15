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
    public partial class frm_PesqVendedor : Form
    {
        public int vcodigo;
        public string vnome;

        public frm_PesqVendedor()
        {
            InitializeComponent();
            dgvPrincipal.AutoGenerateColumns = false;
        }
        private void carregaGrid()
        {
            VendedorNegocio vendedorNegocios = new VendedorNegocio();
            VendedorColecao vendedorColecao = vendedorNegocios.Consultar("%");

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = vendedorColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void dgvPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Pessoa Vendedor = (dgvPrincipal.SelectedRows[0].DataBoundItem as Pessoa);
            vcodigo = Vendedor.Codigo;
            vnome = Vendedor.Nome;
            Close();
        }
        private void frm_PesqVendedor_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }
    }
}