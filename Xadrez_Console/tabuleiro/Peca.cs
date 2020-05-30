using tabuleiro.Enum;

namespace tabuleiro
{
    abstract class Peca
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
            QteMovimentos = 0;
        }

        #endregion
        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }
        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        public bool ExistemMovimentosPossiveis() //VAI VERIFICAR SE EXISTEM MOVIMENTOS POSSIVEIS PARA A PECA QUE O UTILIZADOR ESCOLHEU PARA JOGAR
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tab.Linhas; i++)
            {
                for(int j=0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }                    
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
        

        
    }
}
