using System;
using System.Collections.Generic;
using System.Globalization;

namespace Consultorio
{
    class TelaPacienteListaTodos : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaPacienteListaTodos(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Listar Todos os Pacientes ";
        }

        public Tela Mostra()
        {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();



            PacienteController pacienteController = new PacienteController();

            List<Paciente> pacientes = pacienteController.Lista();

            if (pacientes.Count == 0)
            {
                Console.WriteLine(" Nenhum paciente cadastrado!\n");
                Console.WriteLine(" Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return this.anterior;
            }
            else
            {



                int opcao = -1;

                while (opcao < 0 || opcao > pacientes.Count)
                {
                    for (int i = 0; i < pacientes.Count; i++)
                    {
                        System.Console.WriteLine((i + 1) + ". " + pacientes[i]);
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine("- Digite o número do paciente que deseja remover ou");
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
                        pacienteController.Remove(pacientes[opcao - 1]);
                        pacientes.RemoveAt(opcao - 1);

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
