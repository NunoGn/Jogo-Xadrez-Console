using System;
using System.Collections.Generic;
using tabuleiro;
using tabuleiro.Enum;
using tabuleiro.Exceptions;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool PartidaTerminada { get; private set; }
        private HashSet<Peca> pecas; //PARA AS PEÇAS EM JOGO
        private HashSet<Peca> capturadas; //PARA AS PEÇAS QUE SAO CAPTURADAS PELOS JOGADORES
        public bool Xeque { get; private set; }


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            PartidaTerminada = false;
            Xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();

        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        //RESPONSAVEL PELO MOVIMENTO DAS PEÇAS E CASO EXISTA UMA PEÇA NA POSIÇÃO DESTINO É CAPTURADA
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            //SE O REI ESTA EM XEQUE VOLTA A COLOCAR A PEÇA NA POSICAO DE ORIGEM
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQteMovimentos();

            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecacapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecacapturada);

                throw new TabuleiroException("Não se pode colocar em Xeque!");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if(TesteXequeMate(Adversaria(JogadorAtual)))
            {
                PartidaTerminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }           
            
        }

        public void ValidarPosicaoOrigem(Posicao pos) /*METODO QUE VAI VERIFICAR SE EXISTE ALGUMA PEÇA NA POSIÇÃO ESCOLHIDA,
                                                                VAI AVALIAR A PEÇA QUE O UTILIZADOR ESCOLHEU SE LHE PERTENCE 
                                                                E VAI VERIFICAR SE HÁ JGADAS POSSIVEIS PARA A PEÇA ESCOLHIDA */
        {
            //EXCECCOES PERSONALIZADAS
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça seleccionada não lhe pertence.\nEscolha uma peça sua!");
            }
            if (!Tab.Peca(pos).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Essa peça não tem movimentos disponiveis!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) //VAI VERIFICAR SE É POSSIVEL O MOVIMENTO DO UTILIZADOR 
        {
            if (!Tab.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino não é válida!");
            }
        }


        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Vermelha;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) // VAI DEVOLVER TODAS AS PEÇAS CAPTURADAS DA COR INFORMADA
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) //VAI DEVOLVER TODAS AS PEÇAS EM JOGO
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Vermelha;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor) //VAI VERIFICAR SE O REI ESTA EM XEQUE
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor" + cor + "no tabuleiro");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)//VAI TESTAR SE EXISTE XEQUEMATE
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('A', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('B', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('C', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('D', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('E', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('F', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('G', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('H', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('A', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('B', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('C', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('D', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('E', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('F', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('G', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('H', 2, new Peao(Tab, Cor.Branca));

            ColocarNovaPeca('A', 8, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('B', 8, new Cavalo(Tab, Cor.Vermelha));
            ColocarNovaPeca('C', 8, new Bispo(Tab, Cor.Vermelha));
            ColocarNovaPeca('D', 8, new Dama(Tab, Cor.Vermelha));
            ColocarNovaPeca('E', 8, new Rei(Tab, Cor.Vermelha));
            ColocarNovaPeca('F', 8, new Bispo(Tab, Cor.Vermelha));
            ColocarNovaPeca('G', 8, new Cavalo(Tab, Cor.Vermelha));
            ColocarNovaPeca('H', 8, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('A', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('B', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('C', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('D', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('E', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('F', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('G', 7, new Peao(Tab, Cor.Vermelha));
            ColocarNovaPeca('H', 7, new Peao(Tab, Cor.Vermelha));
        }

    }
}
