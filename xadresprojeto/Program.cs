using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadres;

namespace xadresprojeto
{
    class Program
    {
        static void Main(string[] args)
        {


            PartidaDeXadres partida = new PartidaDeXadres();


            while (!partida.partidaTerminada)
            {
                Console.Clear();

                Tela.imprimirTabuleiro(partida.tab);
                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadres().toPosicao();

                bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);


                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadres().toPosicao();

                partida.executaMovimento(origem, destino);

            }
                
               

          
            Console.ReadLine();

            



        }
    }
}
