using System;
using Tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }
        public void executaMovimento( Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
           Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada ( Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new tabuleiroException("NAO EXISTE PEÇA NA POSICAO ESCOLHIDA");
            }
            if (jogadorAtual != tab.peca(pos).cor){

                throw new tabuleiroException("A PEÇA DE ORIGEM ESCOLHIDA NÃO É SUA ");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new tabuleiroException("NAO HA MOVIMENTOS POSSIVEIS PARA A PEÇA DE ORIGEM ESCOLHIDA");
            }
            {

            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new tabuleiroException("POSIÇÃO DE DESTINO INVALIDA");
            }
            
        }



        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
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

            tab.colocarPeca(new torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());

            //tab.colocarPeca(new torre(tab, Cor.Preta), new Posicao(1, 3));
            //tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
            //tab.colocarPeca(new torre(tab, Cor.Branca), new Posicao(3, 5));
        }
    }
}
