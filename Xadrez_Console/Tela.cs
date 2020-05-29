﻿using System;
using tabuleiro;
using tabuleiro.Enum;
using xadrez;

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
                    ImprimirPeca(tab.Peca(i, j));

                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H"); //VAI IMPRIMIR NA TELA AS CASAS DO TABULEIRO(CARACTERES/HORIZONTAL)
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor; // COR ORIGINAL DE FUNDO
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; //VAI ALTERAR A COR DE FUNDO NAS CASAS EM QEU É POSSIVEL COLOCAR A PECA EM QUESTAO

            //METODO PARA IMPRIMIR O TABULEIRO NA CONSOLE
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " "); //VAI IMPRIMIR NA TELA AS CASAS DO TABULEIRO(NUMERICO/VERTICAL)

                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H"); //VAI IMPRIMIR NA TELA AS CASAS DO TABULEIRO(CARACTERES/HORIZONTAL)
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca) /*ESTRUTURA DE DECISAO DAS CORES DAS PEÇAS(PEÇAS VERMELHAS REPRESENTAM AS PRETAS. 
                                                        UMA VEZ QUE NÃO É POSSIVEL PRETAS)*/
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
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

                Console.Write(" ");
            }                      
                    
            
        }


        #endregion

    }
}
