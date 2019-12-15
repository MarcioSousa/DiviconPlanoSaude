using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Venda
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public int CodigoPlanoSaude { get; set; }
        public DateTime DataPagamento { get; set; }
        public Decimal Valor { get; set; }
    }
}
