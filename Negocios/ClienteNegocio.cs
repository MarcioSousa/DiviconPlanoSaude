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
    public class ClienteNegocio
    {
        AcessoDadosSql acessoDadosSql = new AcessoDadosSql();

        //Inserir, Alterar, Excluir, Consultar um(s) cliente(s) usando StoreProcedure
        public string Inserir(Pessoa cliente)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cli_Acao", 0);
                acessoDadosSql.AdicionarParametros("@cli_Nome", cliente.Nome);
                acessoDadosSql.AdicionarParametros("@cli_Cadastro", cliente.Cadastro);
                acessoDadosSql.AdicionarParametros("@cli_Empresa", cliente.Empresa);
                acessoDadosSql.AdicionarParametros("@cli_Cpf", cliente.Cpf);
                acessoDadosSql.AdicionarParametros("@cli_Rg", cliente.Rg);
                acessoDadosSql.AdicionarParametros("@cli_Nascimento", cliente.DataNascimento);
                acessoDadosSql.AdicionarParametros("@cli_Sexo", cliente.Sexo);
                acessoDadosSql.AdicionarParametros("@cli_TipoPessoa", cliente.TipoPessoa);
                acessoDadosSql.AdicionarParametros("@cli_Categoria", cliente.Categoria);
                acessoDadosSql.AdicionarParametros("@cli_Potencial", cliente.Potencial);
                acessoDadosSql.AdicionarParametros("@cli_Logradouro", cliente.Logradouro);
                acessoDadosSql.AdicionarParametros("@cli_Numero", cliente.Numero);
                acessoDadosSql.AdicionarParametros("@cli_Complemento", cliente.Complemento);
                acessoDadosSql.AdicionarParametros("@cli_Apartamento", cliente.Apartamento);
                acessoDadosSql.AdicionarParametros("@cli_Bairro", cliente.Bairro);
                acessoDadosSql.AdicionarParametros("@cli_Cidade", cliente.Cidade);
                acessoDadosSql.AdicionarParametros("@cli_Uf", cliente.Uf);
                acessoDadosSql.AdicionarParametros("@cli_Cep", cliente.Cep);
                acessoDadosSql.AdicionarParametros("@cli_Email", cliente.Email);
                acessoDadosSql.AdicionarParametros("@cli_ContatoFixo", cliente.ContatoFixo);
                acessoDadosSql.AdicionarParametros("@cli_Celular", cliente.Celular);
                acessoDadosSql.AdicionarParametros("@cli_Observacao", cliente.Observacao);
                acessoDadosSql.AdicionarParametros("@cli_Ativo", cliente.Ativo);

                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudCliente").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Alterar(Pessoa cliente)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cli_Acao", 2);
                acessoDadosSql.AdicionarParametros("@cli_Codigo", cliente.Codigo);
                acessoDadosSql.AdicionarParametros("@cli_Nome", cliente.Nome);
                acessoDadosSql.AdicionarParametros("@cli_Cadastro", cliente.Cadastro);
                acessoDadosSql.AdicionarParametros("@cli_Empresa", cliente.Empresa);
                acessoDadosSql.AdicionarParametros("@cli_Cpf", cliente.Cpf);
                acessoDadosSql.AdicionarParametros("@cli_Rg", cliente.Rg);
                acessoDadosSql.AdicionarParametros("@cli_Nascimento", cliente.DataNascimento);
                acessoDadosSql.AdicionarParametros("@cli_Sexo", cliente.Sexo);
                acessoDadosSql.AdicionarParametros("@cli_TipoPessoa", cliente.TipoPessoa);
                acessoDadosSql.AdicionarParametros("@cli_Categoria", cliente.Categoria);
                acessoDadosSql.AdicionarParametros("@cli_Potencial", cliente.Potencial);
                acessoDadosSql.AdicionarParametros("@cli_Logradouro", cliente.Logradouro);
                acessoDadosSql.AdicionarParametros("@cli_Numero", cliente.Numero);
                acessoDadosSql.AdicionarParametros("@cli_Complemento", cliente.Complemento);
                acessoDadosSql.AdicionarParametros("@cli_Apartamento", cliente.Apartamento);
                acessoDadosSql.AdicionarParametros("@cli_Bairro", cliente.Bairro);
                acessoDadosSql.AdicionarParametros("@cli_Cidade", cliente.Cidade);
                acessoDadosSql.AdicionarParametros("@cli_Uf", cliente.Uf);
                acessoDadosSql.AdicionarParametros("@cli_Cep", cliente.Cep);
                acessoDadosSql.AdicionarParametros("@cli_Email", cliente.Email);
                acessoDadosSql.AdicionarParametros("@cli_ContatoFixo", cliente.ContatoFixo);
                acessoDadosSql.AdicionarParametros("@cli_Celular", cliente.Celular);
                acessoDadosSql.AdicionarParametros("@cli_Observacao", cliente.Observacao);
                acessoDadosSql.AdicionarParametros("@cli_Ativo", cliente.Ativo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudCliente").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Excluir(Pessoa cliente)
        {
            try
            {
                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cli_Acao", 3);
                acessoDadosSql.AdicionarParametros("@cli_Codigo", cliente.Codigo);
                return acessoDadosSql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_CrudCliente").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ClienteColecao Consultar(string nome)
        {
            try
            {
                //Criação de uma coleão nova de clientes (aqui está vazio)
                ClienteColecao clienteColecao = new ClienteColecao();

                acessoDadosSql.LimparParametros();
                acessoDadosSql.AdicionarParametros("@cli_Acao", 1);
                acessoDadosSql.AdicionarParametros("@cli_Nome", nome);


                DataTable dataTablecliente = acessoDadosSql.ExecutarConsulta(CommandType.StoredProcedure, "usp_CrudCliente");

                //Faz um conjunto de coleção
                foreach (DataRow linha in dataTablecliente.Rows)
                {
                    //Criar um cliente vazio
                    Pessoa cliente = new Pessoa();

                    //Colocar os dados da linha nele                                              
                    cliente.Codigo = Convert.ToInt32(linha["cli_cod"]);                           
                    cliente.Nome = Convert.ToString(linha["cli_nome"]);                           
                    cliente.Cadastro = Convert.ToDateTime(linha["cli_cadastro"]);
                    cliente.Empresa = Convert.ToString(linha["cli_empresa"]);
                    cliente.Cpf = Convert.ToString(linha["cli_cpf"]);
                    cliente.Rg = Convert.ToString(linha["cli_rg"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["cli_nascimento"]);
                    cliente.Sexo = Convert.ToString(linha["cli_sexo"]);
                    cliente.TipoPessoa = Convert.ToString(linha["cli_pessoa"]);
                    cliente.Categoria = Convert.ToString(linha["cli_categoria"]);
                    cliente.Potencial = Convert.ToString(linha["cli_potencial"]);
                    cliente.Logradouro = Convert.ToString(linha["cli_logradouro"]);
                    cliente.Numero = Convert.ToString(linha["cli_Numero"]);
                    cliente.Complemento = Convert.ToString(linha["cli_complemento"]);
                    cliente.Apartamento = Convert.ToString(linha["cli_apartamento"]);
                    cliente.Bairro = Convert.ToString(linha["cli_Bairro"]);                       
                    cliente.Cidade = Convert.ToString(linha["cli_cidade"]);                       
                    cliente.Uf = Convert.ToString(linha["cli_uf"]);                  
                    cliente.Cep = Convert.ToString(linha["cli_cep"]);                 
                    cliente.Email = Convert.ToString(linha["cli_email"]);            
                    cliente.ContatoFixo = Convert.ToString(linha["cli_telcon"]);     
                    cliente.Celular = Convert.ToString(linha["cli_telcel"]);
                    cliente.Observacao = Convert.ToString(linha["cli_observacao"]);
                    cliente.Ativo = Convert.ToBoolean(linha["cli_ativo"]);                                                                       

                    //Adicionar ele na coleção                                                    
                    clienteColecao.Add(cliente);                                                  
                }                                                                                 
                                                                                                   
                return clienteColecao;                                                             
            }                                                                                      
            catch (Exception ex)                                                                   
            {                                                                                      
                throw new Exception("Não foi possível consultar Cliente.\nDetalhes: " + ex.Message );
            }                                                                                      
        }                                                                                          
    }                                                                                                   
}