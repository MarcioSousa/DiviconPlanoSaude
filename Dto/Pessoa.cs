using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Pessoa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime Cadastro { get; set; }
        public string Empresa { get; set; }
        public string Cpf { get; set; }
        public string Inscricao { get; set; }
        public string Funcacao { get; set; }
        public string Capital { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string TipoPessoa { get; set; }
        public string Categoria { get; set; }
        public string Potencial { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Apartamento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string ContatoFixo { get; set; }
        public string Celular { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }

        //public string Nome
        //{
        //    get
        //    {
        //        return _nome.ToUpper();
        //    }
        //    set
        //    {
        //        _nome = value;
        //    }
        //}

    }
}