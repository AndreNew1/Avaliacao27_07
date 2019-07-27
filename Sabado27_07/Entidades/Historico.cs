namespace Sabado27_07.Entidades
{
    class Historico
    {
        public int ID_Eleitor;
        public int ID_Pauta;
        public string Resultado;

        public void Regi(string g,Eleitores IDE,Pautas IdP)
        {
            ID_Eleitor = IDE.NCadastro;
            ID_Pauta = IdP.Index;
            Resultado = g;
        }
    }
}
