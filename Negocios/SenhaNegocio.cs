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
    public class SenhaNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) senhas(s) usando StoreProcedure
        public string Inserir(Senha senha)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@sen_Acao", 0);
                acessoDadosSql.AdicionarParametros("@sen_Nome", senha.Nome);
                acessoDadosSql.AdicionarParametros("@sen_Senha", senha.SenhaPessoa);
                acessoDadosSql.AdicionarParametros("@sen_Recuperacao", senha.Recuperacao);
          
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudSenha").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Senha senha)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@sen_Acao", 2);
                acessoDadosSql.AdicionarParametros("@sen_Codigo", senha.Codigo);
                acessoDadosSql.AdicionarParametros("@sen_Nome", senha.Nome);
                acessoDadosSql.AdicionarParametros("@sen_Senha", senha.SenhaPessoa);
                acessoDadosSql.AdicionarParametros("@sen_Recuperacao", senha.Recuperacao);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudSenha").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Senha senha)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@sen_Acao", 3);
                acessoDadosSql.AdicionarParametros("@sen_Codigo", senha.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudSenha").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public SenhaColecao Consultar(string nome)
        {
            try
            {
                //Criação de uma coleão nova de clientes (aqui está vazio)
                SenhaColecao senhaColecao = new SenhaColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@sen_Acao", 1);
                acessoDadosSql.AdicionarParametros("@sen_Nome", nome);

                DataTable dataTablesenha = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudSenha");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTablesenha.Rows)
                {
                    //Criar um cliente vazio
                    Senha senha = new Senha();

                    //Colocar os dados da linha nele                                              
                    senha.Codigo = Convert.ToInt32(linha["sen_cod"]);
                    senha.Nome = Convert.ToString(linha["sen_nome"]);
                    senha.SenhaPessoa = Convert.ToString(linha["sen_senha"]);
                    senha.Recuperacao = Convert.ToString(linha["sen_recuperacao"]);

                    //Adicionar ele na coleção                                                    
                    senhaColecao.Add(senha);
                }

                return senhaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar Cliente.\nDetalhes: " + ex.Message);
            }
        }
    }
}