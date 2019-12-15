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
    public partial class frm_Vendedor : Form
    {
        cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();

        public frm_Vendedor()
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
            Pessoa Cliente = (dgvPrincipal.SelectedRows[0].DataBoundItem as Pessoa);

            txtCod.Text = Cliente.Codigo.ToString();
            txtNome.Text = Cliente.Nome;
            dtpCadastro.Value = Cliente.Cadastro;
            mtbCpf.Text = Cliente.Cpf.ToString();
            txtInscricao.Text = Cliente.Inscricao.ToString();
            txtFundacao.Text = Cliente.Funcacao.ToString();
            txtCapital.Text = Cliente.Capital.ToString();

            txtEndereco.Text = Cliente.Logradouro;
            txtNumero.Text = Cliente.Numero;
            txtComplem.Text = Cliente.Complemento;
            txtApart.Text = Cliente.Apartamento;
            txtBairro.Text = Cliente.Bairro;
            txtCidade.Text = Cliente.Cidade;
            cbxUf.Text = Cliente.Uf;
            txtObserv.Text = Cliente.Observacao;

            if (Cliente.Cep != "")
            {
                mtbCep.Text = Convert.ToString(Cliente.Cep);
            }
            else
            {
                mtbCep.Text = "";
            }
            //-----------------------------
            if (Cliente.ContatoFixo != "0")
            {
                mtbTelCom.Text = Convert.ToString(Cliente.ContatoFixo);
            }
            else
            {
                mtbTelCom.Text = "";
            }
            //-----------------------------
            if (Cliente.Celular != "0")
            {
                mtbTelCel.Text = Convert.ToString(Cliente.Celular);
            }
            else
            {
                mtbTelCel.Text = "0";
            }
        }
        private void atualizaGrid()
        {
            VendedorNegocio vendedorNegocios = new VendedorNegocio();
            VendedorColecao vendedorColecao = vendedorNegocios.Consultar(txtPesquisa.Text);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = vendedorColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void limpaCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            dtpCadastro.Value = DateTime.Today;
            mtbCpf.Text = "";
            txtInscricao.Text = "";
            txtFundacao.Text = "";
            txtCapital.Text = "";

            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplem.Text = "";
            txtApart.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxUf.Text = "SP";
            mtbCep.Text = "";
            txtEmail.Text = "";
            mtbTelCom.Text = "";
            mtbTelCel.Text = "";
            txtObserv.Text = "";

            txtNome.Focus();
        }
        private void habilitarCampos()
        {
            txtNome.ReadOnly = false;
            txtInscricao.ReadOnly = false;
            txtFundacao.ReadOnly = false;
            txtCapital.ReadOnly = false;

            dtpCadastro.Enabled = true;

            mtbCpf.ReadOnly = false;
            //==========================
            txtEndereco.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtComplem.ReadOnly = false;
            txtApart.ReadOnly = false;
            txtBairro.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtObserv.ReadOnly = false;

            cbxUf.Enabled = true;

            mtbCep.ReadOnly = false;

            mtbTelCom.ReadOnly = false;
            mtbTelCel.ReadOnly = false;
            //==========================
            btnConfirma.Enabled = true;
            btnCancela.Enabled = true;
            btnLimpa.Enabled = true;
            btnPesquisarCep.Enabled = true;

            txtPesquisa.Enabled = false;
            btnPesquisar.Enabled = false;
            dgvPrincipal.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            txtNome.Focus();
        }
        private void desabilitarCampos()
        {
            txtNome.ReadOnly = true;
            txtInscricao.ReadOnly = true;
            txtFundacao.ReadOnly = true;
            txtCapital.ReadOnly = true;

            dtpCadastro.Enabled = false;
            mtbCpf.ReadOnly = true;
            //============================
            txtEndereco.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtComplem.ReadOnly = true;
            txtApart.ReadOnly = true;
            txtBairro.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtObserv.ReadOnly = true;

            cbxUf.Enabled = false;

            mtbCep.ReadOnly = true;

            mtbTelCom.ReadOnly = true;
            mtbTelCel.ReadOnly = true;
            //==========================
            btnConfirma.Enabled = false;
            btnCancela.Enabled = false;
            btnLimpa.Enabled = false;
            btnPesquisarCep.Enabled = false;

            txtPesquisa.Enabled = true;
            btnPesquisar.Enabled = true;
            dgvPrincipal.Enabled = true;
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            txtPesquisa.Focus();
        }
        private void localizarCep()
        {
            if (!string.IsNullOrWhiteSpace(mtbCep.Text))
            {
                try
                {
                    Address endereco = SearchZip.GetAddress(mtbCep.Text);

                    if (endereco.Zip != null)
                    {
                        txtEndereco.Text = endereco.Street;
                        txtBairro.Text = endereco.District;
                        txtCidade.Text = endereco.City;
                        cbxUf.Text = endereco.State;
                        txtNumero.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cep não localizado...");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Cep Inválido...");
                }


            }
            else
            {
                MessageBox.Show("Informe um Cep Válido...");
            }
        }

        /// <summary>
        /// Eventos do Formulário
        /// </summary>
        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            localizarCep();
        }
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
            if(dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Vendedor Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            acaoNaTela = cls_AcaoNaTela.Alterar;
            habilitarCampos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Vendedor Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja Excluir o Vendedor selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultado == DialogResult.No)
            {
                return;
            }
            Pessoa vendedorSelecionado = (dgvPrincipal.SelectedRows[0].DataBoundItem as Pessoa);

            VendedorNegocio vendedorNegocio = new VendedorNegocio();

            string retorno = vendedorNegocio.Excluir(vendedorSelecionado);

            try
            {
                int idVendedor = Convert.ToInt32(retorno);
                MessageBox.Show("Vendedor Excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaGrid();
            }
            catch (Exception)
            {
                     MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Digite, no mínimo, o Nome Fantasia", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            if (acaoNaTela == cls_AcaoNaTela.Inserir)
            {
                try
                {
                    Pessoa vendedor = new Pessoa();
                    vendedor.Nome = txtNome.Text;
                    vendedor.Cpf = mtbCpf.Text;
                    vendedor.Cadastro = dtpCadastro.Value;
                    vendedor.Inscricao = txtInscricao.Text;
                    vendedor.Funcacao = txtFundacao.Text;
                    vendedor.Capital = txtCapital.Text;
                    vendedor.Logradouro = txtEndereco.Text;
                    vendedor.Numero = txtNumero.Text;
                    vendedor.Complemento = txtComplem.Text;
                    vendedor.Apartamento = txtApart.Text;
                    vendedor.Bairro = txtBairro.Text;
                    vendedor.Cidade = txtCidade.Text;
                    vendedor.Uf = cbxUf.Text;
                    vendedor.Cep = mtbCep.Text.Replace("-", "");
                    vendedor.Email = txtEmail.Text;
                    vendedor.ContatoFixo = mtbTelCom.Text;
                    vendedor.Celular = mtbTelCel.Text;
                    vendedor.Observacao = txtObserv.Text;
                    vendedor.Ativo = true;

                    VendedorNegocio vendedorNegocios = new VendedorNegocio();
                    string retorno = vendedorNegocios.Inserir(vendedor);

                    try
                    {
                        int idvendedor = Convert.ToInt32(retorno);
                        MessageBox.Show("Vendedor Inserido com Sucesso. \nCódigo do vendedor: " + idvendedor, "Código do Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar o vendedor.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar um novo vendedor.\nPreencha todos os campos Corretamente.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(acaoNaTela == cls_AcaoNaTela.Alterar)
            {
                try
                {
                    Pessoa vendedor = new Pessoa();
                    vendedor.Codigo = Convert.ToInt32(txtCod.Text);
                    vendedor.Nome = txtNome.Text;
                    vendedor.Cpf = mtbCpf.Text;
                    vendedor.Cadastro = dtpCadastro.Value;
                    vendedor.Inscricao = txtInscricao.Text;
                    vendedor.Funcacao = txtFundacao.Text;
                    vendedor.Capital = txtCapital.Text;
                    vendedor.Logradouro = txtEndereco.Text;
                    vendedor.Numero = txtNumero.Text;
                    vendedor.Complemento = txtComplem.Text;
                    vendedor.Apartamento = txtApart.Text;
                    vendedor.Bairro = txtBairro.Text;
                    vendedor.Cidade = txtCidade.Text;
                    vendedor.Uf = cbxUf.Text;
                    vendedor.Cep = mtbCep.Text.Replace("-", "");
                    vendedor.Email = txtEmail.Text;
                    vendedor.ContatoFixo = mtbTelCom.Text;
                    vendedor.Celular = mtbTelCel.Text;
                    vendedor.Observacao = txtObserv.Text;
                    vendedor.Ativo = true;

                    VendedorNegocio vendedorNegocios = new VendedorNegocio();
                    string retorno = vendedorNegocios.Alterar(vendedor);

                    try
                    {
                        int idvendedor = Convert.ToInt32(retorno);
                        MessageBox.Show("Vendedor Alterado com Sucesso. \nCódigo do vendedor: " + idvendedor, "Código do vendedor: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível alterar o vendedor.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar o vendedor.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnLimpa_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }
        private void btnAjudadois_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui encotra-se os dados do Vendedor Selecionado.\nAqui encontran-se 3 botões:\n\nO botão ao lado serve para limpar os campos\ncaso estejam habilitados.\nO próximo botão serve para cancelar o cadastro ou uma edição.\nO último botão é usado para confirmar um cadastro.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na parte de cima, há um campo para procura de um vendedor\ndigitando o nome do mesmo.\nLogo abaixo, uma lista de todos os vendedores que há cadastrado.\n\nOs botões:\n1º)Voltar a Tela Inicial\n2º)Dúvidas.\n3º)Adicionar um novo Vendedor.\n4º)Editar um Vendedor Selecionado acima.\n5º)Excluir Vendedor Selecionado acima.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCancela_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            carregaGrid();
        }
    }
}