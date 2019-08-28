using System;
using System.Collections.Generic;
using System.Globalization;

namespace Consultorio
{
    class TelaPacienteListaPeriodo : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaPacienteListaPeriodo(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Pacientes por Período (Data de Cadastro) ";
        }

        public Tela Mostra()
        {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();

            DateTime? dataInicial = null;

            while (dataInicial == null)
            {
                System.Console.Write(" Digite a data incial (ex: 28/08/2019) : ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataInicial = System.Convert.ToDateTime(System.Console.ReadLine(), cf);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine(" Data incorreta ");
                }
            }

            DateTime? dataFinal = null;

            while (dataFinal == null)
            {
                System.Console.Write(" Digite a data final (ex: 30/08/2019) : ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataFinal = System.Convert.ToDateTime(System.Console.ReadLine(), cf);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine(" Data incorreta ");
                }
            }

            PacienteController pacienteRepositorio = new PacienteController();

            List<Paciente> pacientes = pacienteRepositorio.ListaPorPeriodo(dataInicial, dataFinal);

            int opcao = -1;

            while (opcao < 0 || opcao > pacientes.Count)
            {
                for (int i = 0; i < pacientes.Count; i++)
                {
                    System.Console.WriteLine((i + 1) + ". " + pacientes[i]);
                }

                System.Console.WriteLine();
                System.Console.WriteLine(" Digite o número do paciente que deseja remover .");
                System.Console.WriteLine(" Digite 0 para voltar .");
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
                    System.Console.WriteLine(" Opção incorreto ");
                    continue;
                }

                if (opcao != 0)
                {
                    pacienteRepositorio.Remove(pacientes[opcao - 1]);
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
