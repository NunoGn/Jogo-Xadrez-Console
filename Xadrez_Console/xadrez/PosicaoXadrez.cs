using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez  /*ESTA CLASS SERVE PARA AJUDAR A PENSAR NO CONTEXTO DO XADREZ. 
                            NESTE CASO NAS POSICOES COM LETRAS*/
    {
        #region ATRIBUTOS

        public char Coluna { get; set; }
        public int Linha { get; set; }

        #endregion

        #region CONSTRUTORES

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        #endregion

        #region METODOS
        
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'A');
        }

        #endregion



        public override string ToString() //OVERRIDE DO METODO ToString()
        {
            return "" + Coluna +"-"+ Linha;
        }
    }
}
