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

                try
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);


                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadres().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);


                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadres().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);
                    partida.realizarJogada(origem, destino);

                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
            }
            }



            Console.ReadLine();
        }





    }

}
