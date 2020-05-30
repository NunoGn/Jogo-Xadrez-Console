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


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            PartidaTerminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada !=null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();

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
            if(JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça seleccionada não lhe pertence.\nEscolha uma peça sua!");
            }
            if (!Tab.Peca(pos).ExistemMovimentosPossiveis())
            {
                throw new TabuleiroException("Essa peça não tem movimentos disponiveis!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem,Posicao destino) //VAI VERIFICAR SE É POSSIVEL O MOVIMENTO DO UTILIZADOR 
        {
            if (!Tab.Peca(origem).PodeMover(destino))
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
            foreach(Peca x in capturadas)
            {
                if(x.Cor == cor)
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

        public void ColocarNovaPeca(char coluna,int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('C', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('C', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('D', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('E', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('E', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('D', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('C', 7, new Torre(Tab, Cor.Vermelha));           
            ColocarNovaPeca('C', 8, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('D', 7, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('E', 7, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('E', 8, new Torre(Tab, Cor.Vermelha));
            ColocarNovaPeca('D', 8, new Rei(Tab, Cor.Vermelha));               
        }
        
    }
}
