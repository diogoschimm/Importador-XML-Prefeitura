using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfrontadorNFSe
{
    public class NFSe
    {
        public int IdNFSe { get; set; }

        public string NumeroNFSe { get; set; }
        public string CodigoVerificacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NumeroRPS { get; set; }
        public string Discriminacao { get; set; }
        public string NumeroPedido { get; set; }
        public string DocumentoTomador { get; set; }
        public string NomeTomador { get; set; }
        public double ValorNFSe { get; set; }
        public double ValorISS { get; set; }
    }
}
