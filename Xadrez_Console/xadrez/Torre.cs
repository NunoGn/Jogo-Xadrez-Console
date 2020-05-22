using tabuleiro;
using tabuleiro.Enum;

namespace xadrez
{
    class Torre : Peca //TORRE HERDA DE PECA (CLASS GENERICA)
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString() //SOBRECARGA DO METODO ToString()
        {
            return "T";
        }
    }
}
