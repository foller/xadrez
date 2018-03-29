using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadres
{
    class PartidaDeXadres
    {
        public Tabuleiro tab;
        private int turno;
        private Cor jogadorAtual;
        public bool partidaTerminada {get; private set;}

        public PartidaDeXadres()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            partidaTerminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        { 
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('c',1).toPosicao());
          

        }
    }
}
