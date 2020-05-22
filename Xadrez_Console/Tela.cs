using System;
using tabuleiro;

namespace Xadrez_Console
{
    class Tela
    {

        #region METODOS

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            //METODO PARA IMPRIMIR TELA NA CONSOLE
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }
        }


        #endregion

    }
}
