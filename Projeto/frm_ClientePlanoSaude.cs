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
using Dto;
using Negocios;

namespace Projeto
{
    public partial class frm_ClientePlanoSaude : Form
    {
        public int codved;
        public int codcli;
        public string nomecli;
        public int codven;
        public string nomeven;
        public int codpsa;
        public string nomepsa;
        public DateTime datapagam;
        public decimal valor;

        //cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();

        public frm_ClientePlanoSaude()
        {
            InitializeComponent();
            dgvCliente.AutoGenerateColumns = false;
            dgvPlanoSaude.AutoGenerateColumns = false;
            dgvMensalidade.AutoGenerateColumns = false;
        }
        private void carregaGridCliente()
        {
            ClienteNegocio clienteNegocios = new ClienteNegocio();
            if(txtNome.Text.Trim() == "")
            {
                ClienteColecao clienteColecao = clienteNegocios.Consultar("%");
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = clienteColecao;
            }
            else
            {
                ClienteColecao clienteColecao = clienteNegocios.Consultar(txtNome.Text);
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = clienteColecao;
            }

            dgvCliente.Update();
            dgvCliente.Refresh();
        }
        private void carregaGridPlanoSaude(int cliente)
        {
            ClientePlanoSaudeNegocios clientePlanoSaudeNegocios = new ClientePlanoSaudeNegocios();
            ClientePlanoSaudeColecao clientePlanoSaudeColecao = clientePlanoSaudeNegocios.Consultar(cliente);

            dgvPlanoSaude.DataSource = null;
            dgvPlanoSaude.DataSource = clientePlanoSaudeColecao;

            dgvPlanoSaude.Update();
            dgvPlanoSaude.Refresh();

            if (dgvPlanoSaude.Rows.Count != 0)
            {
                carregaGridMensalidade(cliente, Convert.ToInt32(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[0].Value.ToString()));
            }
            else
            {
                carregaGridMensalidade(0, 0);
            }
        }
        private void carregaGridMensalidade(int cliente, int planosaude)
        {
            VendaNegocio vendaNegocio = new VendaNegocio();
            VendaColecao vendaColecao = vendaNegocio.Consultar(cliente, planosaude);

            dgvMensalidade.DataSource = null;
            dgvMensalidade.DataSource = vendaColecao;

            dgvMensalidade.Update();
            dgvMensalidade.Refresh();           
        }

        private void frm_ClientePlanoSaude_Load(object sender, EventArgs e)
        {
            carregaGridCliente();
        }
        private void btnPesquisaVida_Click(object sender, EventArgs e)
        {
            frm_PesqVida pesquisaVida = new frm_PesqVida();
            pesquisaVida.ShowDialog();
            txtCod.Text = Convert.ToString(pesquisaVida.vcodigo);
            txtNome.Text = pesquisaVida.vnome;
        }
        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            carregaGridPlanoSaude(Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[0].Value.ToString()));
        }
        private void btnCadPlanoCliente_Click(object sender, EventArgs e)
        {
            if(dgvCliente.Rows.Count != 0)
            {
                frm_VendaPlanoSaude vendaPlano = new frm_VendaPlanoSaude(Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[0].Value.ToString()), dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[1].Value.ToString());
                vendaPlano.ShowDialog();
                carregaGridCliente();
            }
            else
            {
                MessageBox.Show("Não há cliente(s) cadastrado no sistema." + '\n' + "Vá a página inicial e Cadastre seu Primeiro Cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnMensalidade_Click(object sender, EventArgs e)
        {
            if (dgvPlanoSaude.Rows.Count != 0)
            {
                frm_Mensalidade mensalidade = new frm_Mensalidade(0,Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[0].Value.ToString()), dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[1].Value.ToString(), Convert.ToInt32(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[0].Value.ToString()), dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[1].Value.ToString(),0,"",DateTime.Today.Date,Convert.ToDecimal(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[4].Value.ToString()));
                mensalidade.ShowDialog();
                carregaGridCliente();
            }
            else
            {
                MessageBox.Show("Primeiro cadastre um Plano de Saúde ao seu Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void dgvPlanoSaude_SelectionChanged(object sender, EventArgs e)
        {
            carregaGridMensalidade(Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[0].Value.ToString()), Convert.ToInt32(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[0].Value.ToString()));
        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            carregaGridCliente();
        }
        private void btnLimparVida_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtNome.Text = "";
        }
        private void dgvMensalidade_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(MessageBox.Show("Deseja alterar a Mensalidade o Cliente " + dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[1].Value + " ?","Alteração.", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No){
                return;
            }

            codved = Convert.ToInt32(dgvMensalidade.Rows[dgvMensalidade.CurrentRow.Index].Cells[0].Value);
            codcli = Convert.ToInt32(dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[0].Value);
            nomecli = dgvCliente.Rows[dgvCliente.CurrentRow.Index].Cells[1].Value.ToString();
            codven = Convert.ToInt32(dgvMensalidade.Rows[dgvMensalidade.CurrentRow.Index].Cells[3].Value);
            nomeven = dgvMensalidade.Rows[dgvMensalidade.CurrentRow.Index].Cells[4].Value.ToString();
            codpsa = Convert.ToInt32(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[0].Value);
            nomepsa = dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[1].Value.ToString();
            datapagam = Convert.ToDateTime(dgvMensalidade.Rows[dgvMensalidade.CurrentRow.Index].Cells[1].Value.ToString());
            valor = Convert.ToDecimal(dgvMensalidade.Rows[dgvMensalidade.CurrentRow.Index].Cells[2].Value.ToString());

            frm_Mensalidade mensalidade = new frm_Mensalidade(codved, codcli, nomecli, codpsa, nomepsa, codven, nomeven, datapagam, valor);
            mensalidade.ShowDialog();
            carregaGridCliente();
        }

        private void btnDelMens_Click(object sender, EventArgs e)
        {
            if (dgvMensalidade.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma Mensalidade Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Deseja Deletar Mensalidade?","Pergunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Venda mensalidadeSelecionado = (dgvMensalidade.SelectedRows[0].DataBoundItem as Venda);

            VendaNegocio vendaNegocios = new VendaNegocio();
            string retorno = vendaNegocios.Excluir(mensalidadeSelecionado);
            try
            {
                int idMensal = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente Excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carregaGridCliente();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}