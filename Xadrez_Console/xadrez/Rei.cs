using tabuleiro;
using tabuleiro.Enum;

namespace xadrez
{
    class Rei : Peca //REI HERDA DE PECA (CLASS GENERICA)
    {
        #region CONSTRUTORES

        public Rei(Tabuleiro tab, Cor cor):base(tab,cor)
        {

        }
               
       
        #endregion

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override string ToString() //SOBRECARGA DO METODO ToString()
        {
            return "R";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas,Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //POSICAO A NORTE DO REI
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna); 

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A NE DO REI
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A LESTE DO REI
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A SE DO REI
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A SUL DO REI
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A SO DO REI
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A OESTE DO REI
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //POSICAO A NO DO REI
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;


        }

    }
}
