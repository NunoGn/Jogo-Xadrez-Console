namespace tabuleiro
{
    class Tabuleiro
    {
        #region ATRIBUTOS
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        #endregion


        #region CONTRUTORES

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        #endregion


        #region METODOS

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna);
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            //METODO PARA INSERIR UMA PEÇA NO TABULEIRO
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
        public bool PosicaoValida(Posicao pos)
        {

            //VAI AVALIAR SE A POSICAO QUE O UTILIZADOR QUER COLOCAR A PEÇA É VALIDA (DENTRO DO TABULEIRO)
            if (pos.Linha <= 0 || pos.Linha >= Linhas || pos.Coluna <= 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

    }
}
