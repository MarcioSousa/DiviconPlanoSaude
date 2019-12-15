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
    public partial class frm_VendaPlanoSaude : Form
    {
        public frm_VendaPlanoSaude(int cod, string nomeCliente)
        {
            InitializeComponent();
            dgvLista.AutoGenerateColumns = false;
            dgvPlanoSaude.AutoGenerateColumns = false;
            txtCodCliente.Text = cod.ToString();
            txtNomeCliente.Text = nomeCliente;
            carregaPlanoSaude();
        }
        private void btnPesquisaVida_Click(object sender, EventArgs e)
        {
            frm_PesqVida pesquisaVida = new frm_PesqVida();
            pesquisaVida.ShowDialog();
            txtCodCliente.Text = Convert.ToString(pesquisaVida.vcodigo);
            txtNomeCliente.Text = pesquisaVida.vnome;
        }
        private void btnPesqPlano_Click(object sender, EventArgs e)
        {
            frm_PesqPlano pesquisaPlano = new frm_PesqPlano();
            pesquisaPlano.ShowDialog();
            txtCodPlano.Text = Convert.ToString(pesquisaPlano.vcodigo);
            txtNomePlano.Text = pesquisaPlano.vnome;
        }
        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            carregaLista();
        }
        private void carregaPlanoSaude()
        {
            ServicoNegocio planoSaudeNegocio = new ServicoNegocio();

            if (txtNomePlano.Text.Trim() != "")
            {
                ServicoColecao planoSaudeColecao = planoSaudeNegocio.Consultar(txtNomePlano.Text);
                dgvPlanoSaude.DataSource = null;
                dgvPlanoSaude.DataSource = planoSaudeColecao;
            }
            else
            {
                ServicoColecao planoSaudeColecao = planoSaudeNegocio.Consultar("");
                dgvPlanoSaude.DataSource = null;
                dgvPlanoSaude.DataSource = planoSaudeColecao;
            }

            dgvPlanoSaude.Update();
            dgvPlanoSaude.Refresh();
        }
        private void carregaLista()
        {
            double valorTotal = 0;
            ClientePlanoSaudeNegocios clientePlanoSaudeNegocios = new ClientePlanoSaudeNegocios();

            if (txtCodCliente.Text.Trim() != "")
            {

                ClientePlanoSaudeColecao clientePlanoSaudeColecao = clientePlanoSaudeNegocios.Consultar(Convert.ToInt32(txtCodCliente.Text));
                dgvLista.DataSource = null;
                dgvLista.DataSource = clientePlanoSaudeColecao;

                for (int t = 0; t < dgvLista.Rows.Count; t++)
                {
                    valorTotal = valorTotal + Convert.ToDouble(dgvLista.Rows[t].Cells[3].Value);
                }
            }

            dgvLista.Update();
            dgvLista.Refresh();
            txtValorMensal.Text = valorTotal.ToString("c");
        }

        private void txtNomePlano_TextChanged(object sender, EventArgs e)
        {
            carregaPlanoSaude();
        }
        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            dtpEmissao.Text = (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[4].Value).ToString();
            dtpVigencia.Text = (dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[5].Value).ToString();
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if(dgvPlanoSaude.Rows.Count == 0)
            {
                MessageBox.Show("Cadastre seu primeiro Plano de Saúde na tela principal clicando no botão 'Plano de Saúde'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (txtCodCliente.Text.ToString() == "0")
                {
                    MessageBox.Show("Escolha um Cliente usando a LUPA ao lado do campo do Nome do Cliente!", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ClientePlanoSaude clientePlanoSaude = new ClientePlanoSaude();
                clientePlanoSaude.CodigoPlanoSaude = Convert.ToInt32(dgvPlanoSaude.Rows[dgvPlanoSaude.CurrentRow.Index].Cells[0].Value);
                clientePlanoSaude.CodigoCliente = Convert.ToInt32(txtCodCliente.Text);
                clientePlanoSaude.Vigencia = DateTime.Today.Date;
                clientePlanoSaude.Emissao = DateTime.Today.Date;

                ClientePlanoSaudeNegocios clientePlanoSaudeNegocios = new ClientePlanoSaudeNegocios();
                string retorno = clientePlanoSaudeNegocios.Inserir(clientePlanoSaude);

                try
                {
                    int idcliplano = Convert.ToInt32(retorno);
                    MessageBox.Show("Cadastrado com sucesso.\nSerá adicionado na lista ao lado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregaLista();
                }
                catch (Exception)
                {
                    MessageBox.Show("Houve erro ao cadastrar o Plano ao Cliente!\nTente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Houve erro ao cadastrar o Plano ao Cliente!\nTente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 0)
            {
                MessageBox.Show("Não há Item a ser Excluído!", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Cuidado ao alterar o valor da Vigência e da Emissão", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dgvLista.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnInserir.Enabled = false;

            dtpEmissao.Enabled = true;
            dtpVigencia.Enabled = true;

            dtpVigencia.Focus();
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(dtpVigencia.Enabled == true)
            {
                try
                {
                    ClientePlanoSaude clientePlanoSaude = new ClientePlanoSaude();
                    clientePlanoSaude.Codigo = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells[0].Value);
                    clientePlanoSaude.Vigencia = dtpVigencia.Value;
                    clientePlanoSaude.Emissao = dtpEmissao.Value;

                    ClientePlanoSaudeNegocios clientePlanoSaudeNegocios = new ClientePlanoSaudeNegocios();
                    string retorno = clientePlanoSaudeNegocios.Alterar(clientePlanoSaude);

                    try
                    {
                        int idcliplano = Convert.ToInt32(retorno);
                        MessageBox.Show("Alterado com sucesso.\nA lista será atualizada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregaLista();

                        dgvLista.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnAlterar.Enabled = true;
                        btnInserir.Enabled = true;
                        btnCancelar.Enabled = false;

                        dtpEmissao.Enabled = false;
                        dtpVigencia.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve erro ao alterar o Plano ao Cliente!\nTente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Houve erro ao alterar o Plano ao Cliente!\nTente novamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Processo Finalizado e Salvo no Sistema!", "Finalização", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 0)
            {
                MessageBox.Show("Não há serviços a ser Excluído!", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja Excluir o Item selecionado da Lista de Planos de Saúde do Cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            //Pegar Cliente Selecionado
            ClientePlanoSaude clientePlanoSaudeSelecionado = (dgvLista.SelectedRows[0].DataBoundItem as ClientePlanoSaude);

            //Instânciar a regra de negócio
            ClientePlanoSaudeNegocios clientePlanoSaudeNegocios = new ClientePlanoSaudeNegocios();

            //Chama o método de excluir
            string retorno = clientePlanoSaudeNegocios.Excluir(clientePlanoSaudeSelecionado);

            //verifica se excluir com sucesso
            //se for número, deu certo, senão, mensagem de erro
            try
            {
                int idCliente = Convert.ToInt32(retorno);
                MessageBox.Show("O Item selecionado da Lista foi Excluído com Sucesso!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carregaLista();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesses campos se faz a atualização da lista de cadastros\nPassos\nClique na primeira LUPA para escolher um Cliente\nEscolha um plano de Saúde que esse Cliente deseja Adquirir usando a lista abaixo\nClique em Inserir para Inserir o Plano de Saúde selecionado!\nExcluir: Exclui o Plano de Saúde que o Cliente tem.\nAlterar: Altera a Vigência e a Emissão do Plano de Saúde do Cliente\nCancelar: Cancela a Alteração da Vigência e da Emissão.\nFinalizar: Finaliza todo o processo Salvando-o em seu computador.\nVoltar: Volta a Tela anterior encerrando a atual.","Passo a Passo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}