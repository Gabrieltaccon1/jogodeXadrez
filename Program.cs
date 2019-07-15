using System;
using Tabuleiro;
using xadrez;

namespace JogodeXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine("");
                    Console.Write("DIGITE A POSICAO DE ORIGEM: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("DIGITE O DESTINO: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
                //Tela.imprimirTabuleiro(partida.tab);
            }
            catch (tabuleiroException e)
            { 
                Console.WriteLine(e.Message);

                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);

                Console.WriteLine(pos.toPosicao());

                Console.ReadLine();
            }





        }
    }

}