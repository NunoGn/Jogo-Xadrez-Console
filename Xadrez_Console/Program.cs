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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    Console.Write("Origem: "); //PEDE A PEÇA QUE QUER MOVIMENTAR
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");//ESCOLHE O DESTINO QUE QUER COLOCAR A PEÇA
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

                
                
                
                //Console.WriteLine();          
                               
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            Console.ReadLine();
        }
    }
}
