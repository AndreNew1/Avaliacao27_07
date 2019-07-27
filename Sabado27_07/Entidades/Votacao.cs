using System;
using System.Collections.Generic;
using Sabado27_07.Service;

namespace Sabado27_07.Entidades
{
    class Votacao
    {
        public bool Finalizada=false;
        public int Ref;
        public double AFavor;
        public double Contra;
        public string Resultado;
        public List<Eleitores> votos=new List<Eleitores>();

        public void VotacaoP(List<Pautas>s,Show show)
        {
            if (s.Count == 0)
                Console.WriteLine("Registre uma Pauta");
            else
            {
                Pautas Pauta;
                foreach (var v in s)
                    Console.WriteLine($"\nPauta:{v.NomeP},Numero:{v.Index}");
                do
                {
                    Console.WriteLine("Escolha a pauta que voce quer iniciar\nCaso não tenha nenhuma pauta digite um numero negativo para sair");
                    Int32.TryParse(Console.ReadLine(), out Ref);
                    //caso todas as pautas ja tenha sido finalizadas
                    if (Ref < 0)
                        show.ShowTela();
                    Pauta = s.Find(x => x.Index == Ref);
                    //checa se a pauta ja esta finalizada
                    if (Pauta.Resultado == true)
                    {
                        Console.WriteLine("Pauta ja finalizada!!");
                        Ref = 0;
                    }
                } while (Ref <= 0);
                while (votos.Count != Pauta.Eleitores.Count)
                {
                    Console.WriteLine("Eleitores disponiveis");
                    foreach (var v in Pauta.Eleitores)
                    {//Controle de eleitores
                        if (!votos.Contains(v))
                            Console.WriteLine($"Nome:{v.Nome},Numero:{v.NCadastro}");
                    }
                    Console.WriteLine("Digite o numero de cadastro do eleitor");
                    Int32.TryParse(Console.ReadLine(), out int Resu);
                    var Pessoa = Pauta.Eleitores.Find(x => x.NCadastro == Resu);
                    if (Pessoa != null)
                        if (!votos.Contains(Pessoa))
                        {
                            Pessoa.Votos(this,Pauta);
                            votos.Add(Pessoa);
                        }
                }
                Pauta.PautaTrue();
                Finalizada = true;
                Console.Clear();
                ResultadoV();
            }
        }
        public void ResultadoV()
        {
            double soma = AFavor + Contra;
            if (AFavor == Contra)
                Resultado = "EMPATE";
            else if (AFavor > Contra)
                Resultado = "A FAVOR";
            else Resultado = "CONTRA";
            double PorcAfavor = (AFavor / soma) * 100;
            double PorcContra = (Contra / soma) * 100;
            Console.WriteLine("Votacão finalizada");
            Console.WriteLine($"Decissão Geral:{Resultado}");
            Console.WriteLine($"A Favor:{PorcAfavor}%");
            Console.WriteLine($"Contra:{PorcContra}%");
        }
    }
}
