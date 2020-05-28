using System;
using tabuleiro;
using tabuleiro.Enum;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool PartidaTerminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branco;
            PartidaTerminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }
        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.branco), new PosicaoXadrez('C', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branco), new PosicaoXadrez('C', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branco), new PosicaoXadrez('D', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branco), new PosicaoXadrez('E', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branco), new PosicaoXadrez('E', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.branco), new PosicaoXadrez('D', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.preto), new PosicaoXadrez('C', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preto), new PosicaoXadrez('C', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preto), new PosicaoXadrez('D', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preto), new PosicaoXadrez('E', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preto), new PosicaoXadrez('E', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.preto), new PosicaoXadrez('D', 8).ToPosicao());


        }
    }
}
