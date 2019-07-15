

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public tabuleiro tab { get; protected set; }

        public Peca(tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }
        public void incrementarQtdMovimentos()
        {
            qteMovimentos++;
        }

        // quando a classe tem um metodo abstrato
        //a class tambem se torna abstrata
        public abstract bool[,] movimentosPossiveis();
       
    }
}
