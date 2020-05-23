using System;
using tabuleiro.Exceptions;

namespace tabuleiro
{
    class Tabuleiro
    {
        #region ATRIBUTOS

        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        #endregion


        #region CONTRUTORES

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        #endregion


        #region METODOS

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos) //METODO PARA INSERIR UMA PEÇA NO TABULEIRO
        {
            if (ExistePeca(pos)) //PRIMEIRO AVALIA SE A POSICAO JA CONTEM PEÇA
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }

            // SE POSICAO FOR NULA ENTAO SIM COLO0CA PEÇA NA POSICAO MENCIONADA
            
                Pecas[pos.Linha, pos.Coluna] = p;
                p.Posicao = pos;
                       
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos); //VERIFICA SE EXISTE ALGUMA PECA DE JOGO EM DETERMINADA POSICAO
            return Peca(pos) != null;
        }

        public bool PosicaoValida(Posicao pos)
        {

            //VAI AVALIAR SE A POSICAO QUE O UTILIZADOR QUER COLOCAR A PEÇA É VALIDA (DENTRO DO TABULEIRO)
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!"); /*EXCECAO PERSONALIZADA CASO SEJA 
                                                                        INSERIDA ALGUMA POSICAO INCORRECTA*/
            }
        }

        #endregion

    }
}
