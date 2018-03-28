using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadres
{
    class PosicaoXadres
    {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadres(char coluna, int linha)
        {
            this.linha = linha;
            this.coluna = coluna;

        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
