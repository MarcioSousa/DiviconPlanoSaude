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
    public partial class frm_Empresa : Form
    {
        cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();

        public frm_Empresa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manipulação dos Objetos do Formulário
        /// </summary>
        private void carregaCampos()
        {
            //Empresa empresa = new Empresa();
            EmpresaNegocio empresaNegocio = new EmpresaNegocio();
            EmpresaColecao empresaColecao = empresaNegocio.Consultar();

            if(empresaColecao.Count != 0)
            {
                txtNome.Text = empresaColecao[0].Nome.ToString();
                txtFilial.Text = empresaColecao[0].Filial.ToString();
            }
            else
            {
                txtNome.Text = "";
                txtFilial.Text = "";
            }
            
        }
        private void limpaCampos()
        {
            txtNome.Text = "";
            txtFilial.Text = "";

            txtNome.Focus();
        }
        private void habilitarCampos()
        {
            txtNome.ReadOnly = false;
            txtFilial.ReadOnly = false;

            txtNome.Enabled = true;
            txtFilial.Enabled = true;

            btnLimpar.Enabled = true;
            btnCancelar.Enabled = true;
            btnConfirmar.Enabled = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            txtNome.Focus();
        }
        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtFilial.Enabled = false;

            btnLimpar.Enabled = false;
            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        /// <summary>
        /// Eventos do Formulário
        /// </summary>
        private void frm_Empresa_Load(object sender, EventArgs e)
        {
            carregaCampos();
        }
        private void btnInicial_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.ToString().Trim() != "")
            {
                MessageBox.Show("Clique no botao Editar.", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            habilitarCampos();
            limpaCampos();

            acaoNaTela = cls_AcaoNaTela.Inserir;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("Não há Empresa cadastrado no Sistema.", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            acaoNaTela = cls_AcaoNaTela.Alterar;
            habilitarCampos();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Não há Empresa cadastrado no Sistema.", "Caixa de Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja Excluir a Empresa cadastrado no Sistema?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            EmpresaNegocio empresaNegocio = new EmpresaNegocio();

            string retorno = empresaNegocio.Excluir();

            try
            {
                int idEmpresa = Convert.ToInt32(retorno);
                MessageBox.Show("Empresa Excluido com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpaCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível Excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Não deixe o campo Nome da Empresa Vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (acaoNaTela == cls_AcaoNaTela.Inserir)
            {
                try
                {
                    Empresa empresa = new Empresa();
                    empresa.Codigo = 1;
                    empresa.Nome = txtNome.Text;
                    empresa.Filial = txtFilial.Text;

                    EmpresaNegocio empresaNegocios = new EmpresaNegocio();
                    string retorno = empresaNegocios.Inserir(empresa);

                    try
                    {
                        int idempresa = Convert.ToInt32(retorno);
                        MessageBox.Show("Empresa Inserido com Sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Empresa empresa = new Empresa();
                    empresa.Codigo = 1;
                    empresa.Nome = txtNome.Text;
                    empresa.Filial = txtFilial.Text;

                    EmpresaNegocio empresaNegocios = new EmpresaNegocio();
                    string retorno = empresaNegocios.Alterar(empresa);

                    try
                    {
                        int idempresa = Convert.ToInt32(retorno);
                        MessageBox.Show("Alterado com Sucesso.", "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        desabilitarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível alterar o Empresa.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar o Empresa.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastro de sua empresa:\nColoque o Nome de sua Empresa e a Filial.\n\nBotões:\n1º)Voltar a Tela Inicial.\n2º)Dúvidas.\n3º)Cadastrar uma Empresa.\n4º)Editar a Empresa cadastrada.\n5º)Excluir Empresa.\n\n6º)Limpar Campos.\n7º)Cancelar Cadastro ou Edição.\n8º)Confirmar cadastro.", "Dúvidas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            carregaCampos();
        }
    }
}

//        private void btnCancela_Click(object sender, EventArgs e)
//        {
//            desabilitarCampos();
//            carregaGrid();
//        }
//        private void txtComissao_ValueChanged(object sender, EventArgs e)
//        {
//            txtValorComissao.Text = ((Convert.ToDecimal(txtValorTotal.Text) * Convert.ToDecimal(txtComissao.Value) / 100).ToString());
//        }
//    }
//}