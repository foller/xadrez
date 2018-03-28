﻿using System;
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
            Tabuleiro tab = new Tabuleiro(8,8);

            PosicaoXadres pos = new PosicaoXadres('a', 1);


          
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));
                Tela.imprimirTabuleiro(tab);

          
            Console.ReadLine();

            



        }
    }
}
