using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadres;

namespace xadresprojeto
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadres partida)
        {
            Tela.imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }


        public static void imprimirPecasCapturadas(PartidaDeXadres partida)
        {
            Console.WriteLine("Pecas Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca)); 
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("".PadLeft(50) + (8 - i) + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    
                    
                        Tela.imprimirPeca(tab.peca(i, j));
                        
                    
                }
                Console.WriteLine("");
            }
            Console.WriteLine(" a b c d e f g h".PadLeft(67));
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] possicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("".PadLeft(50) + (8 - i) + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (possicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }


                    Tela.imprimirPeca(tab.peca(i, j));

                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine("");
            }
            Console.WriteLine(" a b c d e f g h".PadLeft(67));
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadres lerPosicaoXadres()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadres(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else { 
                
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }

            
            Console.Write(" ");
            }
        }


    }
}
