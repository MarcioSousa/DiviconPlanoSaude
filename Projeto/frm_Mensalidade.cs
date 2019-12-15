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
using System.Drawing.Printing;
using System.IO;

namespace Projeto
{
    public partial class frm_Mensalidade : Form
    {
        //cls_AcaoNaTela acaoNaTela = new cls_AcaoNaTela();
        PageSettings PrintPageSettings = new PageSettings();
        string StringToPrint;
        string sLeitura;
        Font printFont = new Font("Consolas", 12);
        Font printFont2 = new Font("Consolas", 7);

        public frm_Mensalidade(int cod, int codcli, string nomeCliente, int codPlanoSaude, string nomePlanoSaude, int codVend, string nomeVend, DateTime dataPagam, decimal valor)
        {
            InitializeComponent();
            AplicarEventos(txtValor);
            txtCodcli.Text = codcli.ToString();
            txtCliente.Text = nomeCliente;
            txtCodpls.Text = codPlanoSaude.ToString();
            txtVida.Text = nomePlanoSaude;
            txtValor.Text = valor.ToString("C");
            if(cod != 0)
            {
                txtCod.Text = cod.ToString();
                txtVendedor.Text = nomeVend;
                txtCodven.Text = codVend.ToString();
            }
        }
        private void btnPesqVendedor_Click(object sender, EventArgs e)
        {
            frm_PesqVendedor pesqVendedor = new frm_PesqVendedor();
            pesqVendedor.ShowDialog();

            txtVendedor.Text = pesqVendedor.vnome;
            txtCodven.Text = Convert.ToString(pesqVendedor.vcodigo);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtCodven.Text == "")
            {
                MessageBox.Show("Preencha o nome do Vendedor clicando na Lupa e clicando duas vezes no vendedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCod.Text == "")
            {
                try
                {
                    Venda mensalidade = new Venda();
                    mensalidade.CodigoCliente =Convert.ToInt32(txtCodcli.Text);
                    mensalidade.CodigoPlanoSaude = Convert.ToInt32(txtCodpls.Text);
                    mensalidade.CodigoVendedor = Convert.ToInt32(txtCodven.Text);
                    mensalidade.DataPagamento = dtpPagamento.Value;
                    mensalidade.Valor =Convert.ToDecimal(txtValor.Text.Replace("R$","").Trim());

                    VendaNegocio vendaNegocios = new VendaNegocio();
                    string retorno = vendaNegocios.Inserir(mensalidade);

                    try
                    {
                        int idmensalidade = Convert.ToInt32(retorno);
                        MessageBox.Show("Mensalidade Inserido com Sucesso.", "Nova Mensalidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBox.Show("Deseja Imprimir um comprovante de pagamento?","Nova Mensalidade Paga",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            imprime_nota(idmensalidade);
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar a Mensalidade.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível adicionar uma nova Mensalidade.\nPreencha todos os campos Corretamente.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    Venda mensalidade = new Venda();
                    mensalidade.Codigo = Convert.ToInt32(txtCod.Text);
                    mensalidade.CodigoCliente = Convert.ToInt32(txtCodcli.Text);
                    mensalidade.CodigoPlanoSaude = Convert.ToInt32(txtCodpls.Text);
                    mensalidade.CodigoVendedor = Convert.ToInt32(txtCodven.Text);
                    mensalidade.DataPagamento = dtpPagamento.Value;
                    mensalidade.Valor = Convert.ToDecimal(txtValor.Text.Replace("R$", "").Trim());

                    VendaNegocio vendaNegocios = new VendaNegocio();
                    string retorno = vendaNegocios.Alterar(mensalidade);

                    try
                    {
                        int idmensalidade = Convert.ToInt32(retorno);
                        MessageBox.Show("Mensalidade Alterada com Sucesso.", "Mensalidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível alterar a Mensalidade.\nTente novamente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível alterar a Mensalidade.\nErro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        private void RetornarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = double.Parse(txt.Text).ToString("C2");
        }
        private void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }
        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }
        private void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasValorNumerico;
        }
        private void imprime_nota(int idmensalidade)
        {
            int qEspaco, qCaracters, qResult;

            try
            {
                //====================================================================================================
                //===============================================SLEITURA=============================================
                sLeitura = "DIVICOM" + '\n';
                sLeitura = sLeitura + "MENSALIDADE Nº: " + idmensalidade + "     " + DateTime.Today.Date.Day + "/" + DateTime.Today.Date.Month + "/" + DateTime.Today.Date.Year + '\n';
                sLeitura = sLeitura + "------------------------------------------------------------------------------------------------------" + '\n';
                sLeitura = sLeitura + "CODIGO DO VENDEDOR: " + txtCodven.Text + ", NOME DO VENDEDOR: " + txtVendedor.Text + '\n';
                sLeitura = sLeitura + "------------------------------------------------------------------------------------------------------" + '\n';
                sLeitura = sLeitura + "CODIGO DO CLIENTE : " + txtCodcli.Text + ", NOME DO CLIENTE: " + txtCliente.Text + '\n';
                sLeitura = sLeitura + "------------------------------------------------------------------------------------------------------" + '\n';
                sLeitura = sLeitura + "---------------------------------- PLANO DE SAÙDE ----------------------------------------------------" + '\n';
                sLeitura = sLeitura + "CÓDIGO        VIDA                                      DATA PAGAMENTO                  VALOR R$      " + '\n';
                for (int t = 1; t <= 4; t++)
                {
                    if(t == 1){
                        sLeitura = sLeitura + txtCodpls.Text;
                        qEspaco = 12;
                        qCaracters = txtCodpls.Text.Length;
                        qResult = qEspaco - qCaracters;
                        for(int u = 0; u < qResult; u++)
                        {
                            sLeitura = sLeitura + " ";
                        }
                    } else if(t == 2){
                        sLeitura = sLeitura + txtVida.Text;
                        qEspaco = 44;
                        qCaracters = txtVida.Text.Length;
                        qResult = qEspaco - qCaracters;
                        for (int u = 0; u < qResult; u++)
                        {
                            sLeitura = sLeitura + " ";
                        }
                    } else if(t == 3){
                        sLeitura = sLeitura + dtpPagamento.Text; ;
                        qEspaco = 32;
                        qCaracters = dtpPagamento.Text.Length;
                        qResult = qEspaco - qCaracters;
                        for (int u = 0; u < qResult; u++)
                        {
                            sLeitura = sLeitura + " ";
                        }
                    } else if(t == 4){
                        sLeitura = sLeitura + txtValor.Text;
                        qEspaco = 20;
                        qCaracters = txtValor.Text.Length;
                        qResult = qEspaco - qCaracters;
                        for (int u = 0; u < qResult; u++)
                        {
                            sLeitura = sLeitura + " ";
                        }
                    }
                }
                sLeitura = sLeitura + '\n';
                sLeitura = sLeitura + "------------------------------------------------------------------------------------------------------" + '\n' + '\n';
                sLeitura = sLeitura + "                                                 Ass: ________________________________________________";

                printDocument1.DefaultPageSettings = PrintPageSettings;
                StringToPrint = sLeitura;
                printDialog1.Document = printDocument1;

                DialogResult result = printDialog1.ShowDialog();

                if(result == DialogResult.OK)
                {
                    printDocument1.Print();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir Nota do Cliente" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int numChars;
            int numLines;
            string stringForPage;

            StringFormat strFormat = new StringFormat();
            Rectangle rectDraw = new Rectangle(e.MarginBounds.Left, 60, e.MarginBounds.Width, e.MarginBounds.Height);
            Rectangle rect = new Rectangle(100, 60, 500, 120);

            //e.Graphics.DrawImage()
            //e.Graphics.DrawImage(pbxLogo.Image, Rect)

            try
            {
                if (rectDraw.Width == 969)
                {
                    SizeF sizeMeasure = new SizeF(e.MarginBounds.Width, e.MarginBounds.Height - printFont2.GetHeight(e.Graphics));
                    strFormat.Trimming = StringTrimming.Word;
                    e.Graphics.MeasureString(StringToPrint, printFont, sizeMeasure, strFormat, out numChars, out numLines);
                    stringForPage = StringToPrint.Substring(0, numChars);
                    e.Graphics.DrawString(stringForPage, printFont, Brushes.Black, rectDraw, strFormat);

                    if (numChars < StringToPrint.Length)
                    {
                        StringToPrint = StringToPrint.Substring(numChars);
                        e.HasMorePages = true;
                    }
                    else
                    {
                        e.HasMorePages = false;
                        StringToPrint = sLeitura;
                    }
                }
                else
                {
                    SizeF sizeMeasure = new SizeF(e.MarginBounds.Width, e.MarginBounds.Height - printFont2.GetHeight(e.Graphics));
                    strFormat.Trimming = StringTrimming.Word;
                    e.Graphics.MeasureString(StringToPrint, printFont2, sizeMeasure, strFormat, out numChars, out numLines);
                    stringForPage = StringToPrint.Substring(0, numChars);
                    e.Graphics.DrawString(stringForPage, printFont2, Brushes.Black, rectDraw, strFormat);
                    if (numChars < StringToPrint.Length)
                    {
                        StringToPrint = StringToPrint.Substring(numChars);
                        e.HasMorePages = true;
                    }
                    else
                    {
                        e.HasMorePages = false;
                        StringToPrint = sLeitura;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao Iniciar Impressão!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}