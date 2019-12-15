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
    public class EmpresaNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) cliente(s) usando StoreProcedure
        public string Inserir(Empresa empresa)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@emp_Acao", 0);
                acessoDadosSql.AdicionarParametros("@emp_Codigo", empresa.Codigo);
                acessoDadosSql.AdicionarParametros("@emp_Nome", empresa.Nome);
                acessoDadosSql.AdicionarParametros("@emp_Filial", empresa.Filial);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudEmpresa").ToString();
                 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Empresa empresa)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@emp_Acao", 2);
                acessoDadosSql.AdicionarParametros("@emp_Codigo", 1);
                acessoDadosSql.AdicionarParametros("@emp_Nome", empresa.Nome);
                acessoDadosSql.AdicionarParametros("@emp_Filial", empresa.Filial);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudEmpresa").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir()
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@emp_Acao", 3);
                acessoDadosSql.AdicionarParametros("@emp_Codigo", 1);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudEmpresa").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public EmpresaColecao Consultar()
        {
            try
            {
                EmpresaColecao empresaColecao = new EmpresaColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@emp_Acao", 1);
                DataTable dataTableEmpresa = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudEmpresa");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTableEmpresa.Rows)
                {
                    //Criar um cliente vazio
                    Empresa empresa = new Empresa();

                    //Colocar os dados da linha nele                                              
                    empresa.Codigo = Convert.ToInt32(linha["emp_cod"]);
                    empresa.Nome = Convert.ToString(linha["emp_nome"]);
                    empresa.Filial = Convert.ToString(linha["emp_filial"]);


                    //Adicionar ele na coleção                                                    
                    empresaColecao.Add(empresa);
                }

                return empresaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar.\nDetalhes: " + ex.Message);
            }
        }
    }
}

