﻿using System;

namespace Consultorio
{
    class TelaGeraDados : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaGeraDados(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Gera Dados ";
        }

        public Tela Mostra()
        {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();

            System.Console.WriteLine(" Gerando dados ... ");

            Random rnd = new Random();
            string[] bairros = new[] { "Centro", "Castelo", "Floresta", "Lagoinha", "Bandeirantes" };

            PacienteController pacienteRepositorio = new PacienteController();

            /* Pacientes */
            for (int i = 0; i < 36; i++)
            {
                Paciente paciente = new Paciente();
                paciente.DataRegistro = new DateTime(2019, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(0, 24), rnd.Next(0, 60), rnd.Next(0, 60));
                paciente.Nome = "Paciente " + (i+1);
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

                pacienteRepositorio.Adiciona(paciente);
            }


            System.Console.WriteLine(" Dados gerados com sucesso! ");
            System.Console.WriteLine();

            return this.anterior;
        }
    }
}