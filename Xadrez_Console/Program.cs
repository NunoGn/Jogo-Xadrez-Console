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

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.PartidaTerminada)
                {
                    try
                    {


                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        
                        

                        Console.WriteLine();
                        Console.Write("Origem: "); //PEDE A PEÇA QUE QUER MOVIMENTAR
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");//ESCOLHE O DESTINO QUE QUER COLOCAR A PEÇA
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);

                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }


            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadLine();
        }
    }

}


