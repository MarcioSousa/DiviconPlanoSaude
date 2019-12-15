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
using Correios.Net;

namespace Projeto
{
    public partial class frm_PlanoSaude : Form
    {
        cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();

        public frm_PlanoSaude()
        {
            InitializeComponent();
            dgvPrincipal.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Manipulação dos Objetos do Formulário
        /// </summary>
        private void carregaGrid()
        {
            //Verificar se tem algum registro selecionado
            if (dgvPrincipal.SelectedRows.Count == 0)
            {
                return;
            }

            //Pegar o registro selecionado no grid
            Servico planoSaude = (dgvPrincipal.SelectedRows[0].DataBoundItem as Servico);

            txtCod.Text = planoSaude.Codigo.ToString();
            txtNome.Text = planoSaude.Nome;
            txtTipo.Text = planoSaude.Tipo;
            txtValorTotal.Text = planoSaude.Valor.ToString();
            txtComissao.Text = planoSaude.Comissao.ToString();
            txtValorComissao.Text = ((Convert.ToDecimal(txtValorTotal.Text) * Convert.ToDecimal(txtComissao.Value) / 100).ToString());
        }
        private void atualizaGrid()
        {
            ServicoNegocio servicoNegocios = new ServicoNegocio();
            ServicoColecao servicoColecao = servicoNegocios.Consultar(txtPesquisa.Text);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = servicoColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void limpaCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            txtTipo.Text = "";
            txtValorTotal.Text = "0";
            txtComissao.Text = "0";

            txtNome.Focus();
        }
        private void habilitarCampos()
        {
            txtNome.ReadOnly = false;
            txtTipo.ReadOnly = false;
            txtValorTotal.ReadOnly = false;
            txtComissao.ReadOnly = false;

            txtNome.Enabled = true;
            txtTipo.Enabled = true;
            txtValorTotal.Enabled = true;
            txtComissao.Enabled = true;

            btnLimpa.Enabled = true;
            btnCancela.Enabled = true;
            btnConfirma.Enabled = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            dgvPrincipal.Enabled = false;
            txtPesquisa.Enabled = false;
            btnPesquisar.Enabled = false;

            txtNome.Focus();
        }
        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtTipo.Enabled = false;
            txtValorTotal.Enabled = false;
            txtComissao.Enabled = false;

            btnLimpa.Enabled = false;
            btnCancela.Enabled = false;
            btnConfirma.Enabled = false;

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            dgvPrincipal.Enabled = true;
            txtPesquisa.Enabled = true;
            btnPesquisar.Enabled = true;
        }

        /// <summary>
        /// Eventos do Formulário
        /// </summary>
        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
        {
            carregaGrid();
        }
        private void btnInicial_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limpaCampos();

            acaoNaTela = cls_AcaoNaTela.Inserir;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Plano de Saúde Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            acaoNaTela = cls_AcaoNaTela.Alterar;
            habilitarCampos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Plano de Saúde Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja Excluir o Plano de Saúde selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }
            Servico servicoSelecionado = (dgvPrincipal.SelectedRows[0].DataBoundItem as Servico);
            ServicoNegocio servicoNegocio = new ServicoNegocio();

            string retorno = servicoNegocio.Excluir(servicoSelecionado);

            try
            {
                int idPlanoSaude = Convert.ToInt32(retorno);
                MessageBox.Show("Plano de Saúde Excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (acaoNaTela == cls_AcaoNaTela.Inserir)
            {
                try
                {
                    Servico planoSaude = new Servico();
                    planoSaude.Nome = txtNome.Text;
                    planoSaude.Tipo = txtTipo.Text;
                    planoSaude.Valor = Convert.ToDecimal(txtValorTotal.Text);
                    planoSaude.Comissao =Convert.ToDecimal(txtComissao.Text);

                    ServicoNegocio servicoNegocios = new ServicoNegocio();
                    string retorno = servicoNegocios.Inserir(planoSaude);

                    try
                    {
                        int idplanoSaude = Convert.ToInt32(retorno);
                        MessageBox.Show("Plano de Saúde Inserido com Sucesso. \nCódigo do Plano de Saúde: " + idplanoSaude, "Código do Plano de Saúde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar o Plano de Saúde.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar um novo Plano de Saúde.\nPreencha todos os campos Corretamente.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (acaoNaTela == cls_AcaoNaTela.Alterar)
            {
                try
                {
                    Servico planoSaude = new Servico();
                    planoSaude.Codigo = Convert.ToInt32(txtCod.Text);
                    planoSaude.Nome = txtNome.Text;
                    planoSaude.Tipo = txtTipo.Text;
                    planoSaude.Valor = Convert.ToDecimal(txtValorTotal.Text);
                    planoSaude.Comissao = Convert.ToDecimal(txtComissao.Text);

                    ServicoNegocio servicoNegocios = new ServicoNegocio();
                    string retorno = servicoNegocios.Alterar(planoSaude);

                    try
                    {
                        int idplanoSaude = Convert.ToInt32(retorno);
                        MessageBox.Show("Plano de Saúde Alterado com Sucesso. \nCódigo do Plano de Saúde: " + idplanoSaude, "Código do vendedor: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível alterar o Plano de Saúde.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar o Plano de Saúde.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnLimpa_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }
        private void btnAjudadois_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui encotra-se os dados do Plano de Saúde Selecionado.\nAqui encontran-se 3 botões:\n\nO botão ao lado serve para limpar os campos\ncaso estejam habilitados.\nO próximo botão serve para cancelar o cadastro ou uma edição.\nO último botão é usado para confirmar um cadastro.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na parte de cima, há um campo para procura de um Plano de Saúde\ndigitando o nome do mesmo.\nLogo abaixo, uma lista de todos os Planos de Saúde que há cadastrado.\n\nOs botões:\n1º)Voltar a Tela Inicial\n2º)Dúvidas.\n3º)Adicionar um novo Plano de Saúde.\n4º)Editar um Plano de Saúde Selecionado acima.\n5º)Excluir Plano de Saúde Selecionado acima.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCancela_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            carregaGrid();
        }
        private void txtComissao_ValueChanged(object sender, EventArgs e)
        {
            txtValorComissao.Text = ((Convert.ToDecimal(txtValorTotal.Text) * Convert.ToDecimal(txtComissao.Value) / 100).ToString());
        }
    }
}