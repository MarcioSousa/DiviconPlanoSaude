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
    public class ServicoNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) cliente(s) usando StoreProcedure
        public string Inserir(Servico planoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@psa_Acao", 0);
                acessoDadosSql.AdicionarParametros("@psa_Nome",planoSaude.Nome);
                acessoDadosSql.AdicionarParametros("@psa_Tipo", planoSaude.Tipo);
                acessoDadosSql.AdicionarParametros("@psa_Valor", planoSaude.Valor);
                acessoDadosSql.AdicionarParametros("@psa_Comissao", planoSaude.Comissao);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudPlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Servico planoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@psa_Acao", 2);
                acessoDadosSql.AdicionarParametros("@psa_Codigo", planoSaude.Codigo);
                acessoDadosSql.AdicionarParametros("@psa_Nome", planoSaude.Nome);
                acessoDadosSql.AdicionarParametros("@psa_Tipo", planoSaude.Tipo);
                acessoDadosSql.AdicionarParametros("@psa_Valor", planoSaude.Valor);
                acessoDadosSql.AdicionarParametros("@psa_Comissao", planoSaude.Comissao);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudPlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Servico planoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@psa_Acao", 3);
                acessoDadosSql.AdicionarParametros("@psa_Codigo", planoSaude.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudPlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ServicoColecao Consultar(string nome)
        {
            try
            {
                //Criação de uma coleão nova de clientes (aqui está vazio)
                ServicoColecao servicoColecao = new ServicoColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@psa_Acao", 1);
                acessoDadosSql.AdicionarParametros("@psa_Nome", nome);

                DataTable dataTableServico = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudPlanoSaude");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTableServico.Rows)
                {
                    //Criar um cliente vazio
                    Servico planoSaude = new Servico();

                    //Colocar os dados da linha nele                                              
                    planoSaude.Codigo = Convert.ToInt32(linha["psa_cod"]);
                    planoSaude.Nome = Convert.ToString(linha["psa_nome"]);
                    planoSaude.Tipo = Convert.ToString(linha["psa_tipo"]);
                    planoSaude.Valor = Convert.ToDecimal(linha["psa_valor"]);
                    planoSaude.Comissao = Convert.ToDecimal(linha["psa_comissao"]);

                    //Adicionar ele na coleção                                                    
                    servicoColecao.Add(planoSaude);
                }

                return servicoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar Plano de Saúde.\nDetalhes: " + ex.Message);
            }
        }
    }
}
