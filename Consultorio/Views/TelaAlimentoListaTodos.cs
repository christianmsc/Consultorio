using System;
using System.Collections.Generic;
using System.Globalization;

namespace Consultorio
{
    class TelaAlimentoListaTodos : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaAlimentoListaTodos(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Listar Todos os Alimentos ";
        }

        public Tela Mostra()
        {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();



            AlimentoController alimentoController = new AlimentoController();

            List<Alimento> alimentos = alimentoController.Lista();

            if (alimentos.Count == 0)
            {
                Console.WriteLine(" Nenhum alimento cadastrado!\n");
                Console.WriteLine(" Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return this.anterior;
            }
            else
            {



                int opcao = -1;

                while (opcao < 0 || opcao > alimentos.Count)
                {
                    for (int i = 0; i < alimentos.Count; i++)
                    {
                        System.Console.WriteLine((i + 1) + ". " + alimentos[i]);
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine("- Digite o número do alimento que deseja remover ou");
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
                        alimentoController.Remove(alimentos[opcao - 1]);
                        alimentos.RemoveAt(opcao - 1);

                        opcao = -1;


                        System.Console.WriteLine();
                        System.Console.WriteLine(" Paciente Removido ");
                        System.Console.WriteLine();
                    }
                }
                System.Console.WriteLine();

                return this.anterior;
            }
        }
    }
}
