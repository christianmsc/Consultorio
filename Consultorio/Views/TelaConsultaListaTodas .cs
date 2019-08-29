using System;
using System.Collections.Generic;
using System.Globalization;

namespace Consultorio
{
    class TelaConsultaListaTodas : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaConsultaListaTodas(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Listar Todas as Consultas ";
        }

        public Tela Mostra()
        {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();



            ConsultaController consultaController = new ConsultaController();

            List<Consulta> consultas = consultaController.Lista();

            if (consultas.Count == 0)
            {
                Console.WriteLine(" Nenhuma consulta cadastrado!\n");
                Console.WriteLine(" Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return this.anterior;
            }
            else
            {



                int opcao = -1;

                while (opcao < 0 || opcao > consultas.Count)
                {
                    for (int i = 0; i < consultas.Count; i++)
                    {
                        System.Console.WriteLine((i + 1) + ". " + consultas[i]);
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine("- Digite o número da consulta que deseja remover ou");
                    System.Console.WriteLine("- Digite 0 para voltar .");
                    try
                    {
                        opcao = System.Convert.ToInt32(System.Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        System.Console.WriteLine(" Opção incorreta ");
                        continue;
                    }

                    if (opcao < 0 || opcao > 1000)
                    {
                        System.Console.WriteLine(" Opção incorreta ");
                        continue;
                    }

                    if (opcao != 0)
                    {
                        consultaController.Remove(consultas[opcao - 1]);
                        consultas.RemoveAt(opcao - 1);

                        opcao = -1;


                        System.Console.WriteLine();
                        System.Console.WriteLine(" Consulta Removida ");
                        System.Console.WriteLine();
                    }
                }
                System.Console.WriteLine();

                return this.anterior;
            }
        }
    }
}
