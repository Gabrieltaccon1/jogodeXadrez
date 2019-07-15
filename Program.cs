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
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno" + partida.turno);
                        Console.WriteLine("AGUARDANDO JOGADA : " + partida.jogadorAtual);

                        Console.WriteLine("");
                        Console.Write("DIGITE A POSICAO DE ORIGEM: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("DIGITE O DESTINO: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(tabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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