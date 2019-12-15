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
    public partial class frm_Cliente : Form
    {
        cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();

        public frm_Cliente()
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
            txtEmpresa.Text = Cliente.Empresa.ToString();
            mtbCpf.Text = Cliente.Cpf.ToString();
            txtRg.Text = Cliente.Rg.ToString();
            dtpNascimento.Value = Cliente.DataNascimento;
            cbxSexo.Text = Cliente.Sexo;
            cbxPessoa.Text = Cliente.TipoPessoa;
            txtCategoria.Text = Cliente.Categoria;
            txtPotencial.Text = Cliente.Potencial;
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
            acaoNaTela = cls_AcaoNaTela.Consultar;

            ClienteNegocio clienteNegocios = new ClienteNegocio();
            ClienteColecao clienteColecao = clienteNegocios.Consultar(txtPesquisa.Text);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = clienteColecao;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }
        private void limpaCampos()
        {
            txtCod.Text = "";
            txtNome.Text = "";
            dtpCadastro.Value = DateTime.Today;
            txtEmpresa.Text = "";
            mtbCpf.Text = "";
            txtRg.Text = "";
            dtpNascimento.Value = DateTime.Today;
            cbxSexo.Text = "Masculino";
            cbxPessoa.Text = "Física";
            txtCategoria.Text = "";
            txtPotencial.Text = "";

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
            dtpCadastro.Enabled = true;
            txtEmpresa.ReadOnly = false;
            mtbCpf.ReadOnly = false;
            txtRg.ReadOnly = false;
            txtCategoria.ReadOnly = false;
            dtpNascimento.Enabled = true;
            cbxSexo.Enabled = true;
            cbxPessoa.Enabled = true;
            txtPotencial.ReadOnly = false;

            txtEndereco.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtComplem.ReadOnly = false;
            txtApart.ReadOnly = false;
            txtBairro.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtEmail.ReadOnly = false;
            mtbTelCom.ReadOnly = false;
            mtbTelCel.ReadOnly = false;
            txtObserv.ReadOnly = false;


            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbxUf.Enabled = true;
            mtbCep.ReadOnly = false;

            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = true;
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
            txtEmpresa.ReadOnly = true;
            txtRg.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtPotencial.ReadOnly = true;

            dtpCadastro.Enabled = false;
            dtpNascimento.Enabled = false;

            cbxSexo.Enabled = false;
            cbxPessoa.Enabled = false;

            mtbCpf.ReadOnly = true;
            //----------------------------
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
            //---------------------------

            btnConfirmar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpar.Enabled = false;
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
        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
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
                MessageBox.Show("Nenhum Cliente Selecionado", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            acaoNaTela = cls_AcaoNaTela.Alterar;
            habilitarCampos();

        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Cliente Selecionado","Caixa de Mensagem",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja Excluir o Cliente selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultado == DialogResult.No)
            {
                return;
            }

            //Pegar Cliente Selecionado
            Pessoa clienteSelecionado = (dgvPrincipal.SelectedRows[0].DataBoundItem as Pessoa);

            //Instânciar a regra de negócio
            ClienteNegocio clienteNegocios = new ClienteNegocio();

            //Chama o método de excluir
            string retorno = clienteNegocios.Excluir(clienteSelecionado);

            //verifica se excluir com sucesso
            //se for número, deu certo, senão, mensagem de erro
            try
            {
                int idCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente Excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizaGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Digite, no mínimo, o Nome do Cliente", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            if(acaoNaTela == cls_AcaoNaTela.Inserir)
            {
                try
                {
                    Pessoa cliente = new Pessoa();
                    cliente.Nome = txtNome.Text;
                    cliente.Cadastro = dtpCadastro.Value;
                    cliente.Empresa = txtEmpresa.Text;
                    cliente.Cpf = mtbCpf.Text;
                    cliente.Rg = txtRg.Text;
                    cliente.DataNascimento = dtpNascimento.Value;
                    cliente.Sexo = cbxSexo.Text;
                    cliente.TipoPessoa = cbxPessoa.Text;
                    cliente.Categoria = txtCategoria.Text;
                    cliente.Potencial = txtPotencial.Text;
                    cliente.Logradouro = txtEndereco.Text;
                    cliente.Numero = txtNumero.Text;
                    cliente.Complemento = txtComplem.Text;
                    cliente.Apartamento = txtApart.Text;
                    cliente.Bairro = txtBairro.Text;
                    cliente.Cidade = txtCidade.Text;
                    cliente.Uf = cbxUf.Text;
                    cliente.Cep = mtbCep.Text.Replace("-", "");
                    cliente.Email = txtEmail.Text;
                    cliente.ContatoFixo = mtbTelCom.Text;
                    cliente.Celular = mtbTelCel.Text;
                    cliente.Observacao = txtObserv.Text;
                    cliente.Ativo = true;

                    ClienteNegocio clienteNegocios = new ClienteNegocio();
                    string retorno = clienteNegocios.Inserir(cliente);

                    try
                    {
                        int idcliente = Convert.ToInt32(retorno);
                        MessageBox.Show("Cliente Inserido com Sucesso. \nCódigo do cliente: " + idcliente, "Código do cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar o cliente.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar um novo cliente.\nPreencha todos os campos Corretamente.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (acaoNaTela == cls_AcaoNaTela.Alterar)
            {
                try
                {
                    Pessoa cliente = new Pessoa();
                    cliente.Codigo = Convert.ToInt32(txtCod.Text);
                    cliente.Nome = txtNome.Text;
                    cliente.Cadastro = dtpCadastro.Value;
                    cliente.Empresa = txtEmpresa.Text;
                    cliente.Cpf = mtbCpf.Text;
                    cliente.Rg = txtRg.Text;
                    cliente.DataNascimento = dtpNascimento.Value;
                    cliente.Sexo = cbxSexo.Text;
                    cliente.TipoPessoa = cbxPessoa.Text;
                    cliente.Categoria = txtCategoria.Text;
                    cliente.Potencial = txtPotencial.Text;
                    cliente.Logradouro = txtEndereco.Text;
                    cliente.Numero = txtNumero.Text;
                    cliente.Complemento = txtComplem.Text;
                    cliente.Apartamento = txtApart.Text;
                    cliente.Bairro = txtBairro.Text;
                    cliente.Cidade = txtCidade.Text;
                    cliente.Uf = cbxUf.Text;
                    cliente.Cep = mtbCep.Text.Replace("-", "");
                    cliente.Email = txtEmail.Text;
                    cliente.ContatoFixo = mtbTelCom.Text;
                    cliente.Celular = mtbTelCel.Text;
                    cliente.Observacao = txtObserv.Text;
                    cliente.Ativo = true;

                    ClienteNegocio clienteNegocios = new ClienteNegocio();
                    string retorno = clienteNegocios.Alterar(cliente);

                    try
                    {
                        int idcliente = Convert.ToInt32(retorno);
                        MessageBox.Show("Cliente Alterado com Sucesso. \nCódigo do cliente: " + idcliente, "Código do cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                        atualizaGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível alterar o cliente.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar o cliente.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }
        private void btnDuvida_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui encotra-se os dados do Cliente Selecionado.\nAqui encontran-se 3 botões:\n\nO botão ao lado serve para limpar os campos\ncaso estejam habilitados.\nO próximo botão serve para cancelar o cadastro ou uma edição.\nO último botão é usado para confirmar um cadastro.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na parte de cima, há um campo para procura de um cliente\ndigitando o nome do mesmo.\nLogo abaixo, uma lista de todos os clientes que há cadastrado.\n\nOs botões:\n1º)Voltar a Tela Inicial\n2º)Dúvidas.\n3º)Adicionar um novo Cliente.\n4º)Editar um Cliente Selecionado acima.\n5º)Excluir Cliente Selecionado acima.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            carregaGrid();
        }
    }
}