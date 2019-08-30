using System;
using System.Collections.Generic;
using System.Globalization;
namespace Consultorio
{
    class TelaConsultaAdicionar : Tela
    {
        private Tela anterior;

        public string Nome { get; set; }

        public TelaConsultaAdicionar(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Adicionar Consulta ";
        }

        public Tela Mostra()
        {
            Console.WriteLine(" >>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine(" INFORMAÇÕES DA CONSULTA\n");

            PacienteController pacienteController = new PacienteController();
            ConsultaController consultaController = new ConsultaController();
            
            // Pesquisar por paciente
            Paciente paciente = null;
            string nome = null;

            while (paciente == null)
            {
                while (nome == null || nome.Length == 0)
                {
                    System.Console.Write(" Digite o nome do paciente : ");

                    try
                    {
                        nome = System.Console.ReadLine();

                        if (nome.Length == 0)
                        {
                            mostrarErro("Insira um nome");
                        }

                        if(nome == "0")
                        {
                            return this.anterior;
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Nome inválido");
                    }
                }

                paciente = pacienteController.Obter(nome);
                if (paciente == null)
                {
                    Console.WriteLine(" Paciente não encontrado! ");
                    Console.WriteLine(" Digite outro nome ou 0 para cancelar ");
                    nome = null;
                }
                
            }

            // Inserir data da consulta
            DateTime? dataConsulta = null;
            while (dataConsulta == null)
            {
                System.Console.Write(" Digite a data e hoário da consulta (ex: 29/08/2019 16:00) : ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataConsulta = System.Convert.ToDateTime(System.Console.ReadLine(), cf);
                    if (consultaController.IsConsultaJaAgendada((DateTime)dataConsulta))
                    {
                        mostrarErro(" Existe uma consulta agendada para este dia e horário, escolha outro ");
                        dataConsulta = null;
                    }
                }
                catch (FormatException)
                {
                    mostrarErro("Data incorreta ou não inserida");
                }
            }

            
            consultaController.Adiciona(new Consulta
            {
                Paciente = paciente,
                DataConsulta = (DateTime)dataConsulta
            });


            Console.WriteLine(" Consulta marcada! ");
            Console.WriteLine(" Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            return this.anterior;
        }

        private void mostrarErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {mensagem} ");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }

}