/****************************************************
 **                  CRIADO POR: NUNO CORREIA      **
 **         DATA INICIO PROJETO:   20/05/2020      **
 **            DATA FIM PROJETO:                   **
 ****************************************************/

using System;
using tabuleiro;
using tabuleiro.Enum;
using tabuleiro.Exceptions;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            /*PosicaoXadrez pos = new PosicaoXadrez('A',1);
            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosicao());*/
            


           try
            {
                Tabuleiro tab = new Tabuleiro(8, 8); //NUMERO DE POSICOES QUE O JOGO CONTEM

                tab.ColocarPeca(new Torre(tab, Cor.preto), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.preto), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.preto), new Posicao(2, 4));

                tab.ColocarPeca(new Torre(tab, Cor.branco/*peças brancas*/), new Posicao(3, 5));
                tab.ColocarPeca(new Rei(tab, Cor.branco), new Posicao(4, 6));


                Tela.ImprimirTabuleiro(tab);//IMPRIME TABULEIRO NA CONSOLE
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            Console.ReadLine();
        }
    }
}
