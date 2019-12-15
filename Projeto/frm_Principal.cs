using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frm_Cliente Cliente = new frm_Cliente();
            Cliente.ShowDialog();
        }
        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            frm_Vendedor CadFornec = new frm_Vendedor();
            CadFornec.ShowDialog();
        }
        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mtsCliente_Click(object sender, EventArgs e)
        {
            frm_Cliente Cliente = new frm_Cliente();
            Cliente.ShowDialog();
        }
        private void btnPlanoSaude_Click(object sender, EventArgs e)
        {
            frm_PlanoSaude PlanoSaude = new frm_PlanoSaude();
            PlanoSaude.ShowDialog();
        }
        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            frm_Empresa Empresa = new frm_Empresa();
            Empresa.ShowDialog();
        }
        private void btnPlanoCliente_Click(object sender, EventArgs e)
        {
            frm_ClientePlanoSaude clientePlanoSaude = new frm_ClientePlanoSaude();
            clientePlanoSaude.ShowDialog();
        }
        private void btnGraficos_Click(object sender, EventArgs e)
        {
            frm_Graficos graficos = new frm_Graficos();
            graficos.ShowDialog();
        }
        private void frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mensalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_VendaPlanoSaude vendaPlanoSaude = new frm_VendaPlanoSaude(0,"");
            vendaPlanoSaude.ShowDialog();
        }

        private void mtsVendedor_Click(object sender, EventArgs e)
        {
            frm_Vendedor vendedor = new frm_Vendedor();
            vendedor.ShowDialog();
        }

        private void mtsPlanoSaude_Click(object sender, EventArgs e)
        {
            frm_PlanoSaude planoSaude = new frm_PlanoSaude();
            planoSaude.ShowDialog();
        }

        private void mtsEmpresa_Click(object sender, EventArgs e)
        {
            frm_Empresa empresa = new frm_Empresa();
            empresa.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mtsGrafico_Click(object sender, EventArgs e)
        {
            frm_Graficos grafico = new frm_Graficos();
            grafico.ShowDialog();
        }

        private void mtsSistema_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CADFácil Sistemas\nCaso necessite, entre em contato:\nhttps://www.facebook.com/cadfacilsistemas", "Informações do Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
