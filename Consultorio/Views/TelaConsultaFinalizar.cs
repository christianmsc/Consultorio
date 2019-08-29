using System;
using System.Collections.Generic;
using System.Globalization;
namespace Consultorio
{
    class TelaConsultaFinalizar : Tela
    {
        private Tela anterior;

        public string Nome { get; set; }

        public TelaConsultaFinalizar(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Finalizar Consulta ";
        }

        public Tela Mostra()
        {
            Console.WriteLine(" >>> " + this.Nome + " <<<");
            Console.WriteLine();

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

                        if (nome == "0")
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

            // Data da consulta
            DateTime? dataConsulta = null;
            while (dataConsulta == null)
            {
                System.Console.Write(" Digite a data e hoário da consulta (ex: 29/08/2019 16:00) : ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataConsulta = System.Convert.ToDateTime(System.Console.ReadLine(), cf);
                }
                catch (FormatException)
                {
                    mostrarErro("Data incorreta ou não inserida");
                }
            }


            Consulta consulta = consultaController.ObterConsultaPorPacienteData(nome, (DateTime)dataConsulta);

            if (consulta == null)
            {
                Console.WriteLine(" Não foi encontrada nenhuma consulta com o paciente e horário informados ");
                Console.WriteLine(" Pressione qualquer tecla para continuar...");
                Console.ReadKey();

                return this.anterior;
            }

            // Adicionar Peso
            double? peso = null;
            while (peso == null)
            {
                System.Console.Write(" Peso : ");

                try
                {
                    peso = Double.Parse(System.Console.ReadLine());

                    if (peso == null)
                    {
                        mostrarErro("Insira um peso");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Peso inválido");
                }
            }

            // Adicionar Porcentagem de Gordura
            double? porcentagemGordura = null;
            while (porcentagemGordura == null)
            {
                System.Console.Write(" Porcentagem de Gordura : ");

                try
                {
                    porcentagemGordura = Double.Parse(System.Console.ReadLine());

                    if (porcentagemGordura == null)
                    {
                        mostrarErro("Insira uma porcentagem de gordura");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Porcentagem inválida");
                }
            }

            // Adicionar Sensação Física
            string sensacaoFisica = null;
            while (sensacaoFisica == null)
            {
                System.Console.Write(" Sensação física do paciente : ");

                try
                {
                    sensacaoFisica = System.Console.ReadLine();

                    if (sensacaoFisica.Length == 0)
                    {
                        mostrarErro("Insira uma sensação física");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Formato inválido");
                }
            }

            // Adicionar Dieta
            int? opcao = null;
            Dieta dieta = null;
            while (opcao == null)
            {
                System.Console.WriteLine("Deseja adicionar uma dieta para o paciente?");
                System.Console.Write(" 1 - Sim, 2 - Não : ");
                opcao = Int32.Parse(Console.ReadLine());

                if (opcao < 1 && opcao > 2)
                {
                    mostrarErro("Digite uma opção válida");
                    opcao = null;
                }
                else if (opcao == 1)
                {
                    int? opcao2 = -1;
                    while (opcao2 != null && opcao2 != 2)
                    {
                        int? limiteCalorias = null;
                        while (limiteCalorias == null)
                        {
                            try
                            {
                                Console.Write("Digite a meta de consumo calórico : ");
                                limiteCalorias = Int32.Parse(Console.ReadLine());

                                if (limiteCalorias == null)
                                {
                                    mostrarErro("Digite um valor");
                                }
                            }
                            catch (Exception)
                            {
                                mostrarErro("Valor inválido");
                            }
                        }
                        List<Dieta> dietas = consultaController.SimularDietas((int)limiteCalorias);
                        if (dietas == null || dietas.Count == 0)
                        {
                            opcao2 = null;
                            while (opcao2 == null)
                            {
                                Console.WriteLine("Nenhuma dieta pode ser gerada com a quantidade de calorias informada");
                                Console.WriteLine("Deseja inserir um novo valor ou cancelar?");
                                System.Console.Write(" 1 - Novo valor, 2 - Cancelar : ");
                                opcao2 = Int32.Parse(Console.ReadLine());

                                if (opcao2 < 1 && opcao2 > 2)
                                {
                                    mostrarErro("Digite uma opção válida");
                                    opcao2 = null;
                                }
                            }
                        }
                        else
                        {
                            
                            for (int i = 0; i < dietas.Count; i++)
                            {
                                System.Console.WriteLine((i + 1) + ". " + dietas[i]);
                            }
                            int? opcao3 = null;
                            while (opcao3 == null)
                            {
                                System.Console.WriteLine();
                                System.Console.Write("- Digite o número da dieta que deseja escolher : ");
                                try
                                {
                                    opcao3 = System.Convert.ToInt32(System.Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    System.Console.WriteLine(" Opção incorreta ");
                                    opcao3 = null;
                                    continue;
                                }

                                if (opcao3 < 0 || opcao3 > dietas.Count)
                                {
                                    System.Console.WriteLine(" Opção incorreta ");
                                    opcao3 = null;
                                    continue;
                                }

                                if (opcao3 != 0)
                                {
                                    dieta = dietas[(int)opcao3 - 1];
                                    System.Console.WriteLine(" Dieta Escolhida ");
                                    System.Console.WriteLine();
                                    opcao2 = null;
                                }
                            }
                        }
                    }
                }
            }

            consulta.Peso = (double)peso;
            consulta.PorcentagemGordura = (double)porcentagemGordura;
            consulta.SensacaoFisica = sensacaoFisica;
            consulta.Dieta = dieta;


            System.Console.WriteLine();
            Console.WriteLine(" Consulta finalizada! ");
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