using System;
using tabuleiro;
using tabuleiro.Enum;

namespace Xadrez_Console
{
    class Tela
    {

        #region METODOS

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            //METODO PARA IMPRIMIR O TABULEIRO NA CONSOLE
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " "); //VAI IMPRIMIR NA TELA AS CASAS DO TABULEIRO(NUMERICO/VERTICAL)

                for (int j = 0; j < tab.Colunas; j++)
                {                    
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H"); //VAI IMPRIMIR NA TELA AS CASAS DO TABULEIRO(CARACTERES/HORIZONTAL)
        }


        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.branco)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }


        #endregion

    }
}
