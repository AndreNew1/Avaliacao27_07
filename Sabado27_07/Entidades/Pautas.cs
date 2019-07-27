using System;
using System.Collections.Generic;
namespace Sabado27_07.Entidades
{
    class Pautas
    {
        public string NomeP;
        public int Index;
        public List<Eleitores> Eleitores=new List<Eleitores>();
        public bool Resultado=false;

        public void RegistrarPauta(List<Eleitores> g,List<Pautas>pautas)
        {
            //Pauta so pode ser registrada quando houver eleitores
            if (g.Count == 0)
                Console.WriteLine("Registre um eleitor");
            else
            {
                string s = "";
                Console.WriteLine("\nInforme o Nome da Pauta");
                NomeP = Console.ReadLine();
                while (s != "sim")
                {
                    //checando caso numero da pauta ja exista
                    Console.WriteLine("Informe o Numero da Pauta");
                    Int32.TryParse(Console.ReadLine(), out Index);
                    var v = pautas.Find(x => x.Index == Index);
                    if (v == null) s = "sim";
                    else Console.WriteLine("Ja Existe uma Pauta com essa Numeração");
                }
                while (s != "n")
                {   s = "";
                    int Resu = 0;
                    //caso erros ou numeração errada
                    while (Resu <= 0)
                    {
                        //lista de eleitores que ainda não votaram
                        foreach (var v in g)
                        {
                            if(!Eleitores.Contains(v))
                            Console.WriteLine($"Nome:{v.Nome} Numero:{v.NCadastro}");
                        }
                        Console.WriteLine("Informe o numero do eleitor");
                        Int32.TryParse(Console.ReadLine(), out Resu);
                    }
                    var Pessoa = g.Find(x => x.NCadastro == Resu);
                    if (Pessoa != null)
                        Eleitores.Add(Pessoa);
                    while (s != "s" && s != "n")
                    {
                        Console.WriteLine("Deseja cadastrar outro eleitor?(s/n)");
                        s = Console.ReadLine().ToLower();
                    }
                    Console.Clear();
                    //caso todos os eleitores possiveis tenha ja sido registrado
                    if (Eleitores.Count == g.Count)
                    {
                        Console.WriteLine("Registre mais eleitores");
                        s = "n";
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cadastro da pauta concluido");
                Console.ResetColor();
            }
        }
        public void PautaTrue()
        {
            Resultado = true;
        }
    }
}
