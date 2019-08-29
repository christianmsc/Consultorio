using System;
using System.Collections.Generic;
using System.Globalization;

namespace Consultorio
{
    class TelaConsultaListaPeriodo : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaConsultaListaPeriodo(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Consultas por Período (Data da Consulta) ";
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

            ConsultaController consultaController = new ConsultaController();

            List<Consulta> consultas = consultaController.ListaPorPeriodo(dataInicial, dataFinal);

            int opcao = -1;

            while (opcao < 0 || opcao > consultas.Count)
            {
                for (int i = 0; i < consultas.Count; i++)
                {
                    System.Console.WriteLine((i + 1) + ". " + consultas[i]);
                }

                System.Console.WriteLine();
                System.Console.WriteLine(" Digite o número da consulta que deseja remover .");
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
