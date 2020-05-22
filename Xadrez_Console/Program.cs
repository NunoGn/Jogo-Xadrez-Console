using System;
using tabuleiro;
using tabuleiro.Enum;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tab = new Tabuleiro(8, 8); //NUMERO DE POSICOES QUE O JOGO CONTEM

            tab.ColocarPeca(new Torre(tab,Cor.preto), new Posicao(0,0));
            tab.ColocarPeca(new Torre(tab, Cor.preto), new Posicao(1, 3));
            tab.ColocarPeca(new Rei(tab, Cor.preto), new Posicao(2, 4));



            Tela.ImprimirTabuleiro(tab);//IMPRIME TABULEIRO NA CONSOLE

            Console.ReadKey();
        }
    }
}
