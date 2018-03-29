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
        public int turno;
        public Cor jogadorAtual;
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

        public void realizarJogada(Posicao origem, Posicao destino){
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();


        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("Peça escolhida não condiz com o jogador do turno.");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimento possivel para a peca escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida");
            }

        }



        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }


        private void colocarPecas()
        {
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadres('c',1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadres('a', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadres('c', 4).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('b', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('b', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadres('d', 1).toPosicao());
        }
    }
}
