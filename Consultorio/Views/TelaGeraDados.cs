﻿using Consultorio.Enums;
using System;
using System.Globalization;

namespace Consultorio
{
    class TelaGeraDados : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaGeraDados(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Gerar Dados ";
        }

        public Tela Mostra()
        {
            Console.WriteLine(" >>> " + this.Nome + " <<<");
            Console.WriteLine();

            int? qtdDados = null;
            while (qtdDados == null)
            {
                try
                {
                    Console.Write(" Digite a quantidade de dados desejada para cada entidade : ");
                    qtdDados = Int32.Parse(Console.ReadLine());
                    if (qtdDados == null)
                    {
                        Console.WriteLine(" Digite um valor ");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(" Valor inválido ");
                }
            }

            Console.WriteLine(" Gerando dados ... ");

            Random rnd = new Random();
            CultureInfo cf = new CultureInfo("pt-BR");
            string[] bairros = new[] { "Centro", "Castelo", "Floresta", "Lagoinha", "Bandeirantes" };
            string[] alimentos = new[] { "Achocolatado", "Açúcar", "Adoçante", "Arroz", "Atum", "Azeite", "Azeitona", "Batata Palha" };

            PacienteController pacienteController = new PacienteController();
            AlimentoController alimentoController = new AlimentoController();
            ConsultaController consultaController = new ConsultaController();

            /* Pacientes */
            for (int i = 0; i < qtdDados; i++)
            {
                Paciente paciente = new Paciente();
                paciente.DataRegistro = new DateTime(2019, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60));
                paciente.Nome = "Paciente " + (i + 1);
                paciente.Email = "paciente" + (i + 1) + "@email.com";
                paciente.TelefoneResidencial = "31" + rnd.Next(30000000, 39999999);
                paciente.TelefoneCelular = "31" + rnd.Next(900000000, 999999999);
                paciente.DataNascimento = new DateTime(rnd.Next(1955, 2002), rnd.Next(1, 13), rnd.Next(1, 29));
                paciente.Enderecos = new[] {
                    new Endereco()
                    {
                        Rua = "Rua " + (i+1),
                        Numero = rnd.Next(1000).ToString(),
                        Complemento = rnd.Next(100, 999).ToString(),
                        Bairro = bairros[rnd.Next(5)],
                        Cidade = "Belo Horizonte",
                        Estado = "MG",
                        Cep = rnd.Next(35000000, 35999999).ToString(),
                    }
                };

                pacienteController.Adiciona(paciente);
            }

            /* Alimentos */
            for (int i = 0; i < qtdDados; i++)
            {
                Alimento alimento = new Alimento();
                alimento.DataRegistro = new DateTime(2019, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60));
                alimento.Nome = alimentos[rnd.Next(8)];
                alimento.Grupo = (GrupoAlimentoEnum)rnd.Next(3);
                alimento.Calorias = rnd.Next(50, 500);

                alimentoController.Adiciona(alimento);
            }

            /* Consultas */
            for (int i = 0; i < qtdDados; i++)
            {
                Consulta consulta = new Consulta();
                consulta.DataRegistro = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60));
                consulta.Paciente = pacienteController.Lista()[i];
                consulta.DataConsulta = Convert.ToDateTime($"{rnd.Next(1, 29)}/{rnd.Next(1, 13)}/{2019} {rnd.Next(0, 24)}:{rnd.Next(0, 60)}", cf);
                consulta.Dieta = new Dieta() { Alimentos = alimentoController.Lista().GetRange(0,3)};

                consultaController.Adiciona(consulta);
            }


            Console.WriteLine(" Dados gerados com sucesso! ");
            Console.WriteLine(" Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            return this.anterior;
        }
    }
}