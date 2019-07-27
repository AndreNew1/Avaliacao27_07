using System;
using System.Collections.Generic;
using Sabado27_07.Entidades;
using Newtonsoft.Json;
using System.IO;

namespace Sabado27_07.Service
{
    class Show
    {
        List<Eleitores> Eleitores = new List<Eleitores>();
        List<Pautas> Pautas = new List<Pautas>();
        List<Votacao> Votos = new List<Votacao>();
        public void Ler()
        {
            try
            {
                Pautas = JsonConvert.DeserializeObject<List<Pautas>>(File.ReadAllText(@"C:\Users\Treinamento 2\Desktop\Pautas.json"));
                foreach (var v in Pautas)
                {
                    foreach (var n in v.Eleitores)
                    {
                        if (!Eleitores.Exists(x => x.NCadastro == n.NCadastro))
                            Eleitores.Add(n);
                    }
                }
                Votos = JsonConvert.DeserializeObject<List<Votacao>>(File.ReadAllText(@"C:\Users\Treinamento 2\Desktop\Votos.json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ShowTela()
        {
            while (true)
            {
                Ler();
                Console.WriteLine("\nDigite 1 para Cadastrar Eleitores\nDigite 2 para Cadastrar Pautas\nDigite 3 Para iniciar uma votacao\nDigite 4 para ver Todos os eleitores cadastrados\n" +
                    "Digite 5 para ver todas as pautas cadastradas\nDigite 6 para Resultado de todas as Pauta");
                string g = Console.ReadLine();
                switch (g)
                {
                    case "1":
                        {
                            Eleitores ele = new Eleitores();
                            ele.Cadastrar(Eleitores);
                            Eleitores.Add(ele);
                            break;
                        }
                    case "2":
                        {
                            Pautas Pa = new Pautas();
                            Pa.RegistrarPauta(Eleitores, Pautas);
                            Pautas.Add(Pa);
                            ArquivarP(Pautas);
                            break;
                        }
                    case "3":
                        {
                            Votacao votacao = new Votacao();
                            votacao.VotacaoP(Pautas,this);
                            Votos.Add(votacao);
                            ArquivarP(Pautas);
                            ArquivarV(Votos);
                            break;
                        }
                    case "4": { foreach (var v in Eleitores){ Console.WriteLine($"Nome:{v.Nome},Numero:{v.NCadastro}"); v.ListaV(); } break; }
                    case "5": { foreach (var v in Pautas) { Console.WriteLine($"Nome:{v.NomeP},Numero:{v.Index}"); } break; }
                    case "6":
                        {
                            foreach (var v in Pautas)
                            {
                                if (v.Resultado == true)
                                {
                                    Console.WriteLine($"\nNome:{v.NomeP} Numero{v.Index}");
                                    var Resu = Votos.Find(x => x.Ref == v.Index);
                                    Resu.ResultadoV();
                                    ArquivarP(Pautas);
                                    ArquivarV(Votos);
                                }
                            }
                            break;
                        }
                }
            }
        }
        static void ArquivarP(List<Pautas> sh)
        {
            using (StreamWriter s = File.CreateText(@"C:\Users\Treinamento 2\Desktop\Pautas.json"))
            {
                string g = JsonConvert.SerializeObject(sh, Formatting.Indented);
                s.Write(g);
            }
        }
        static void ArquivarV(List<Votacao> sh)
        {
            using (StreamWriter s = File.CreateText(@"C:\Users\Treinamento 2\Desktop\Votos.json"))
            {
                string g = JsonConvert.SerializeObject(sh, Formatting.Indented);
                s.Write(g);
            }
        }

    }
}
