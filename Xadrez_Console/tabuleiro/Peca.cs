using tabuleiro.Enum;

namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public int NumMovimentos { get; protected set; }
        public Cor  Cor { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            NumMovimentos = 0;
        }
    }
}
