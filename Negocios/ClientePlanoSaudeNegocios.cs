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
    public class ClientePlanoSaudeNegocios
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        public string Inserir(ClientePlanoSaude clientePlanoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cpl_Acao", 0);
                acessoDadosSql.AdicionarParametros("@cpl_CodigoPlanoSaude", clientePlanoSaude.CodigoPlanoSaude);
                acessoDadosSql.AdicionarParametros("@cpl_CodigoCliente", clientePlanoSaude.CodigoCliente);
                acessoDadosSql.AdicionarParametros("@cpl_Vigencia", clientePlanoSaude.Vigencia);
                acessoDadosSql.AdicionarParametros("@cpl_Emissao", clientePlanoSaude.Emissao);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudClientePlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(ClientePlanoSaude clientePlanoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cpl_Acao", 2);
                acessoDadosSql.AdicionarParametros("@cpl_Codigo", clientePlanoSaude.Codigo);
                acessoDadosSql.AdicionarParametros("@cpl_Vigencia", clientePlanoSaude.Vigencia);
                acessoDadosSql.AdicionarParametros("@cpl_Emissao", clientePlanoSaude.Emissao);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudClientePlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(ClientePlanoSaude clientePlanoSaude)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cpl_Acao", 3);
                acessoDadosSql.AdicionarParametros("@cpl_Codigo", clientePlanoSaude.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudClientePlanoSaude").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ClientePlanoSaudeColecao Consultar(int cod)
        {
            try
            {
                ClientePlanoSaudeColecao clientePlanoSaudeColecao = new ClientePlanoSaudeColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cpl_Acao", 1);
                acessoDadosSql.AdicionarParametros("@cpl_CodigoCliente", cod);

                DataTable dataTableclienteplanosaude = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudClientePlanoSaude");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTableclienteplanosaude.Rows)
                {
                    //Criar um cliente vazio
                    ClientePlanoSaude clientePlanoSaude = new ClientePlanoSaude();

                    //Colocar os dados da linha nele  
                    clientePlanoSaude.Codigo = Convert.ToInt32(linha["cpl_cod"]);                                            
                    clientePlanoSaude.CodigoPlanoSaude = Convert.ToInt32(linha["cpl_codpsa"]);
                    clientePlanoSaude.Nome = Convert.ToString(linha["psa_nome"]);
                    clientePlanoSaude.Vigencia = Convert.ToDateTime(linha["cpl_vigencia"]);
                    clientePlanoSaude.Emissao = Convert.ToDateTime(linha["cpl_emissao"]);
                    clientePlanoSaude.Valor = Convert.ToDecimal(linha["psa_valor"]);

                    //Adicionar ele na coleção                                                    
                    clientePlanoSaudeColecao.Add(clientePlanoSaude);
                }
                return clientePlanoSaudeColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os dados.\nDetalhes: " + ex.Message);
            }
        }

    }
}