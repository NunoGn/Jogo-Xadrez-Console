using tabuleiro;
using tabuleiro.Enum;

namespace xadrez
{
    class Rei : Peca //REI HERDA DE PECA (CLASS GENERICA)
    {
        public Rei(Tabuleiro tab, Cor cor):base(tab,cor)
        {

        }


        public override string ToString() //SOBRECARGA DO METODO ToString()
        {
            return "R";
        }
    }
}
