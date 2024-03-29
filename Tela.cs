﻿using Tabuleiro;
using System;
using xadrez;

namespace JogodeXadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8-i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirTabuleiro(tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    } else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                    Console.Write(" ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }
         public static void imprimirPeca( Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-");
            }
            else
            {

                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write("");
            }
        }
          
    }
}
