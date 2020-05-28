namespace tabuleiro
{
    class Posicao
    {
        #region ATRIBUTOS

        public int Linha { get; set; }
        public int Coluna { get; set; }

        #endregion

        #region CONSTRUTORES

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        #endregion

        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString() //SOBRECARGA DO METODO ToString()
        {
            return "Posição: " + Linha + ", " + Coluna.ToString(); 
        }
    }
}
