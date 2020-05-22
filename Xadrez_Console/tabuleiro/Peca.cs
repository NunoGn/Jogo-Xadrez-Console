using tabuleiro.Enum;

namespace tabuleiro
{
    class Peca
    {
        #region ATRIBUTOS

        public Posicao posicao { get; set; }
        public int qteMovimentos { get; protected set; }
        public Cor  cor { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        #endregion

        #region CONSTRUTORES

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.qteMovimentos = 0;
            this.cor = cor;
            this.tab = tab;
        }

        #endregion
    }
}
