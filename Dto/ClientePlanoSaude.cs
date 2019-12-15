using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ClientePlanoSaude
    {
        public int Codigo { get; set; }
        public int CodigoPlanoSaude { get; set; }
        public int CodigoCliente { get; set; }
        public string Nome { get; set; }
        public DateTime Vigencia { get; set; }
        public DateTime Emissao { get; set; }
        public Decimal Valor { get; set; }
    }
}
