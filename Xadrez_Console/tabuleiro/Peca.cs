using tabuleiro.Enum;

namespace tabuleiro
{
    class Peca
    {
        #region ATRIBUTOS

        public Posicao Posicao { get; set; }
        public int QteMovimentos { get; protected set; }
        public Cor  Cor { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        #endregion

        #region CONSTRUTORES

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            QteMovimentos = 0;
            Cor = cor;
            Tab = tab;
        }

        #endregion
        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }
    }
}
