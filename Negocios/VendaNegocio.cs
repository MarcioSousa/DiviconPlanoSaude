using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dal;
using Dto;

namespace Negocios
{
    public class VendaNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) vendas) usando StoreProcedure
        public string Inserir(Venda venda)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ved_Acao", 0);
                acessoDadosSql.AdicionarParametros("@ved_CodigoCliente", venda.CodigoCliente);
                acessoDadosSql.AdicionarParametros("@ved_CodigoVendedor", venda.CodigoVendedor);
                acessoDadosSql.AdicionarParametros("@ved_CodigoPlanoSaude", venda.CodigoPlanoSaude);
                acessoDadosSql.AdicionarParametros("@ved_DataPagamento", venda.DataPagamento);
                acessoDadosSql.AdicionarParametros("@ved_Valor", venda.Valor);

                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVenda").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Venda venda)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ved_Acao", 2);
                acessoDadosSql.AdicionarParametros("@ved_Codigo", venda.Codigo);
                acessoDadosSql.AdicionarParametros("@ved_CodigoCliente", venda.CodigoCliente);
                acessoDadosSql.AdicionarParametros("@ved_CodigoVendedor", venda.CodigoVendedor);
                acessoDadosSql.AdicionarParametros("@ved_CodigoPlanoSaude", venda.CodigoPlanoSaude);
                acessoDadosSql.AdicionarParametros("@ved_DataPagamento", venda.DataPagamento);
                acessoDadosSql.AdicionarParametros("@ved_Valor", venda.Valor);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVenda").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Venda venda)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ved_Acao", 3);
                acessoDadosSql.AdicionarParametros("@ved_Codigo", venda.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVenda").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public VendaColecao Consultar(int codcli, int codpsa)
        {
            try
            {
                //Criação de uma coleão nova de clientes (aqui está vazio)
                VendaColecao vendaColecao = new VendaColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ved_Acao", 1);
                acessoDadosSql.AdicionarParametros("@ved_CodigoCliente", codcli);
                acessoDadosSql.AdicionarParametros("@ved_CodigoPlanoSaude", codpsa);

                DataTable dataTableMensalidade = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudVenda");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTableMensalidade.Rows)
                {
                    //Criar um cliente vazio
                    Venda venda = new Venda();

                    //Colocar os dados da linha nele       
                    venda.Codigo = Convert.ToInt32(linha["ved_cod"]);
                    venda.DataPagamento = Convert.ToDateTime(linha["ved_dataPagam"]);
                    venda.Valor = Convert.ToDecimal(linha["ved_valor"]);
                    venda.CodigoVendedor = Convert.ToInt32(linha["ved_codven"]);
                    venda.NomeVendedor = Convert.ToString(linha["ven_nome"]);


                    //Adicionar ele na coleção                                                    
                    vendaColecao.Add(venda);
                }

                return vendaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar.\nDetalhes: " + ex.Message);
            }
        }
        public VendaColecao CarregaMes(int mes)
        {
            try
            {
                //Criação de uma coleão nova de clientes (aqui está vazio)
                VendaColecao vendaColecao = new VendaColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ved_mes", mes);

                DataTable dataTableMensalidade = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_GraficoVenda");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTableMensalidade.Rows)
                {
                    //Criar um cliente vazio
                    Venda venda = new Venda();
                    //Colocar os dados da linha nele       
                    venda.Valor = Convert.ToDecimal(linha["Valor"]);
                    //Adicionar ele na coleção                                                    
                    vendaColecao.Add(venda);
                }

                return vendaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar.\nDetalhes: " + ex.Message);
            }
        }
    }
}
