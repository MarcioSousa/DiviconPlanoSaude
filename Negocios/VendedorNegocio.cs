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
    public class VendedorNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) vendedor(s) usando StoreProcedure
        public string Inserir(Pessoa vendedor)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ven_Acao", 0);
                acessoDadosSql.AdicionarParametros("@ven_Nome", vendedor.Nome);
                acessoDadosSql.AdicionarParametros("@ven_Cpf", vendedor.Cpf);
                acessoDadosSql.AdicionarParametros("@ven_Cadastro", vendedor.Cadastro);
                acessoDadosSql.AdicionarParametros("@ven_Inscricao", vendedor.Inscricao);
                acessoDadosSql.AdicionarParametros("@ven_Fundacao", vendedor.Funcacao);
                acessoDadosSql.AdicionarParametros("@ven_Capital", vendedor.Capital);
                acessoDadosSql.AdicionarParametros("@ven_Logradouro", vendedor.Logradouro);
                acessoDadosSql.AdicionarParametros("@ven_Numero", vendedor.Numero);
                acessoDadosSql.AdicionarParametros("@ven_Complemento", vendedor.Complemento);
                acessoDadosSql.AdicionarParametros("@ven_Apartamento", vendedor.Apartamento);
                acessoDadosSql.AdicionarParametros("@ven_Bairro", vendedor.Bairro);
                acessoDadosSql.AdicionarParametros("@ven_Cidade", vendedor.Cidade);
                acessoDadosSql.AdicionarParametros("@ven_Uf", vendedor.Uf);
                acessoDadosSql.AdicionarParametros("@ven_Cep", vendedor.Cep);
                acessoDadosSql.AdicionarParametros("@ven_Email", vendedor.Email);
                acessoDadosSql.AdicionarParametros("@ven_ContatoFixo", vendedor.ContatoFixo);
                acessoDadosSql.AdicionarParametros("@ven_Celular", vendedor.Celular);
                acessoDadosSql.AdicionarParametros("@ven_Observacao", vendedor.Observacao);
                acessoDadosSql.AdicionarParametros("@ven_Ativo", vendedor.Ativo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVendedor").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Pessoa vendedor)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ven_Acao", 2);
                acessoDadosSql.AdicionarParametros("@ven_Codigo", vendedor.Codigo);
                acessoDadosSql.AdicionarParametros("@ven_Nome", vendedor.Nome);
                acessoDadosSql.AdicionarParametros("@ven_Cpf", vendedor.Cpf);
                acessoDadosSql.AdicionarParametros("@ven_Cadastro", vendedor.Cadastro);
                acessoDadosSql.AdicionarParametros("@ven_Inscricao", vendedor.Inscricao);
                acessoDadosSql.AdicionarParametros("@ven_Fundacao", vendedor.Funcacao);
                acessoDadosSql.AdicionarParametros("@ven_Capital", vendedor.Capital);
                acessoDadosSql.AdicionarParametros("@ven_Logradouro", vendedor.Logradouro);
                acessoDadosSql.AdicionarParametros("@ven_Numero", vendedor.Numero);
                acessoDadosSql.AdicionarParametros("@ven_Complemento", vendedor.Complemento);
                acessoDadosSql.AdicionarParametros("@ven_Apartamento", vendedor.Apartamento);
                acessoDadosSql.AdicionarParametros("@ven_Bairro", vendedor.Bairro);
                acessoDadosSql.AdicionarParametros("@ven_Cidade", vendedor.Cidade);
                acessoDadosSql.AdicionarParametros("@ven_Uf", vendedor.Uf);
                acessoDadosSql.AdicionarParametros("@ven_Cep", vendedor.Cep);
                acessoDadosSql.AdicionarParametros("@ven_Email", vendedor.Email);
                acessoDadosSql.AdicionarParametros("@ven_ContatoFixo", vendedor.ContatoFixo);
                acessoDadosSql.AdicionarParametros("@ven_Celular", vendedor.Celular);
                acessoDadosSql.AdicionarParametros("@ven_Observacao", vendedor.Observacao);
                acessoDadosSql.AdicionarParametros("@ven_Ativo", vendedor.Ativo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVendedor").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Pessoa vendedor)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ven_Acao", 3);
                acessoDadosSql.AdicionarParametros("@ven_Codigo", vendedor.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudVendedor").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public VendedorColecao Consultar(string nome)
        {
            try
            {
                //Criação de uma coleão nova de vendedors (aqui está vazio)
                VendedorColecao vendedorColecao = new VendedorColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@ven_Acao", 1);
                acessoDadosSql.AdicionarParametros("@ven_Nome", nome);


                DataTable dataTablevendedor = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudVendedor");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTablevendedor.Rows)
                {
                    //Criar um vendedor vazio
                    Pessoa vendedor = new Pessoa();

                    //Colocar os dados da linha nele                                              
                    vendedor.Codigo = Convert.ToInt32(linha["ven_cod"]);
                    vendedor.Nome = Convert.ToString(linha["ven_nome"]);
                    vendedor.Cpf = Convert.ToString(linha["ven_cpf"]);
                    vendedor.Cadastro = Convert.ToDateTime(linha["ven_cadastro"]);
                    vendedor.Inscricao = Convert.ToString(linha["ven_Inscricao"]);
                    vendedor.Funcacao = Convert.ToString(linha["ven_Fundacao"]);
                    vendedor.Capital = Convert.ToString(linha["ven_Capital"]);
                    vendedor.Logradouro = Convert.ToString(linha["ven_logradouro"]);
                    vendedor.Numero = Convert.ToString(linha["ven_Numero"]);
                    vendedor.Complemento = Convert.ToString(linha["ven_complemento"]);
                    vendedor.Apartamento = Convert.ToString(linha["ven_apartamento"]);
                    vendedor.Bairro = Convert.ToString(linha["ven_Bairro"]);
                    vendedor.Cidade = Convert.ToString(linha["ven_cidade"]);
                    vendedor.Uf = Convert.ToString(linha["ven_uf"]);
                    vendedor.Cep = Convert.ToString(linha["ven_cep"]);
                    vendedor.Email = Convert.ToString(linha["ven_email"]);
                    vendedor.ContatoFixo = Convert.ToString(linha["ven_telcon"]);
                    vendedor.Celular = Convert.ToString(linha["ven_telcel"]);
                    vendedor.Observacao = Convert.ToString(linha["ven_observacao"]);
                    vendedor.Ativo = Convert.ToBoolean(linha["ven_ativo"]);

                    //Adicionar ele na coleção                                                    
                    vendedorColecao.Add(vendedor);
                }

                return vendedorColecao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Consultar Vendedor.\nDetalhes: " + ex.Message);
            }
        }
    }
}
