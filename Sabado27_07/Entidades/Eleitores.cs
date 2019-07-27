using System;
using System.Collections.Generic;
namespace Sabado27_07.Entidades
{
    class Eleitores
    {
        public string Nome;
        public int NCadastro;
        public List<Historico> Historicos = new List<Historico>();

        //Cadastro de eleitor
        public void Cadastrar(List<Eleitores>s)
        {
            Console.WriteLine("Informe o Nome");
            Nome = Console.ReadLine();
            //Numero do cadastro controle
            while (NCadastro == 0)
            {
                Console.WriteLine("Informe um numero de cadastro");
                Int32.TryParse(Console.ReadLine(), out NCadastro);
                int re = NCadastro;
                //checando para ver se existe
                var pessoa = s.Find(x => x.NCadastro == re);
                //caso exista reinicia
                if (pessoa != null)
                {
                    Console.WriteLine("Numero de cadastro ja utilizado");
                    NCadastro = 0;
                }
                
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cadastro concluido");
            Console.ResetColor();
        }

        public void Votos(Votacao v,Pautas p)
        {
            Console.WriteLine("Digite 1 para a Favor e 2 para contra");
            string g = Console.ReadLine();
            switch (g)
            {
                case "1":g = "A Favor"; v.AFavor++;break;
                case "2":g = "Contra"; v.Contra++; break;
                default: Console.WriteLine("Invalido"); break;
            }
            //Historico de votos
            Historico H = new Historico();
            H.Regi(g, this, p);
            Historicos.Add(H);
        }
        public void ListaV()
        {
            foreach(var v in Historicos)
            {
                Console.WriteLine($"ID Pauta: {v.ID_Pauta} Voto: {v.Resultado}");
            }
        }
    }
}
