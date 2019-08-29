using Consultorio.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
namespace Consultorio
{
    class TelaAlimentoAdicionar : Tela
    {
        private Tela anterior;

        public string Nome { get; set; }

        public TelaAlimentoAdicionar(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Adicionar Alimento ";
        }

        public Tela Mostra()
        {
            Console.WriteLine(" >>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine(" INFORMAÇÕES DO ALIMENTO\n");


            // Inserir nome
            string nome = null;
            while (nome == null || nome.Length == 0)
            {
                System.Console.Write(" Digite o nome : ");

                try
                {
                    nome = System.Console.ReadLine();

                    if (nome.Length == 0)
                    {
                        mostrarErro("Insira um nome");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Nome inválido");
                }
            }

            // Inserir grupo ao qual o alimento pertence
            int? grupo = null;
            while (grupo == null || !(grupo >= 0 && grupo <= 2))
            {
                System.Console.WriteLine();
                System.Console.WriteLine(" 0 - Energéticos; 1 - Reguladores; 2 -  Construtores");
                System.Console.Write(" Digite o grupo ao qual o alimento pertence : ");
                

                try
                {
                    grupo = Int32.Parse(Console.ReadLine());

                    if (!(grupo >= 0 && grupo <= 2))
                    {
                        mostrarErro("Opção Inválida");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Opção inválida");
                }
            }

            // Inserir grupo ao qual o alimento pertence
            int? calorias = null;
            while (calorias == null)
            {
                System.Console.WriteLine();
                System.Console.Write(" Digite a quantidade de calorias do alimento : ");
                
                try
                {
                    calorias = Int32.Parse(Console.ReadLine());

                    if (calorias == null)
                    {
                        mostrarErro("Insira um valor");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("Valor inválido");
                }
            }

            Alimento alimento = new Alimento()
            {
                Nome = nome,
                Grupo = (GrupoAlimentoEnum)grupo,
                Calorias = (int)calorias
            };

            AlimentoController alimentoController = new AlimentoController();
            alimentoController.Adiciona(alimento);


            Console.WriteLine(" Alimento adicionado! ");
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