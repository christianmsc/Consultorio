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

            // Inserir e-mail
            string email = null;
            while (email == null || email.Length == 0)
            {
                System.Console.Write(" Digite o e-mail : ");

                try
                {
                    email = System.Console.ReadLine();

                    if (email.Length == 0)
                    {
                        mostrarErro("Insira um e-mail");
                    }
                }
                catch (Exception)
                {
                    mostrarErro("E-mail inválido");
                }
            }

            // Inserir data de nascimento
            DateTime? dataNascimento = null;
            while (dataNascimento == null)
            {
                System.Console.Write(" Digite a data de nascimento (ex: 16/01/1992) : ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataNascimento = System.Convert.ToDateTime(System.Console.ReadLine(), cf);
                }
                catch (FormatException)
                {
                    mostrarErro("Data incorreta ou não inserida");
                }
            }

            // Inserir telefone residencial (opcional)
            string telefoneResidencial = null;
            System.Console.Write(" Digite o telefone residencial (ENTER p/ ignorar) : ");
            telefoneResidencial = System.Console.ReadLine();

            // Inserir telefone celular (opcional)
            string telefoneCelular = null;
            System.Console.Write(" Digite o telefone celular (ENTER p/ ignorar) : ");
            telefoneCelular = System.Console.ReadLine();

            // Inserir endereço(s)
            System.Console.WriteLine();
            System.Console.WriteLine(" ENDEREÇO ");
            List<Endereco> enderecos = new List<Endereco>();
            bool inserirEndereco = true;
            while (inserirEndereco)
            {
                System.Console.WriteLine();

                // Inserir rua
                string rua = null;
                while (rua == null || rua.Length == 0)
                {
                    System.Console.Write(" Digite o nome da rua/avenida : ");

                    try
                    {
                        rua = System.Console.ReadLine();

                        if (rua.Length == 0)
                        {
                            mostrarErro("Insira uma rua/avenida");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Rua/avenida inválida");
                    }
                }

                // Inserir número
                string numero = null;
                while (numero == null || numero.Length == 0)
                {
                    System.Console.Write(" Digite o número da casa/prédio : ");

                    try
                    {
                        numero = System.Console.ReadLine();

                        if (numero.Length == 0)
                        {
                            mostrarErro("Insira uma número");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Número inválido");
                    }
                }

                // Inserir complemento (opcional)
                string complemento = null;
                System.Console.Write(" Digite o complemento (ENTER p/ ignorar) : ");
                complemento = System.Console.ReadLine();

                // Inserir bairro
                string bairro = null;
                while (bairro == null || bairro.Length == 0)
                {
                    System.Console.Write(" Digite o nome do bairro : ");

                    try
                    {
                        bairro = System.Console.ReadLine();

                        if (bairro.Length == 0)
                        {
                            mostrarErro("Insira um bairro");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Bairro inválido");
                    }
                }

                // Inserir cidade
                string cidade = null;
                while (cidade == null || cidade.Length == 0)
                {
                    System.Console.Write(" Digite o nome da cidade : ");

                    try
                    {
                        cidade = System.Console.ReadLine();

                        if (cidade.Length == 0)
                        {
                            mostrarErro("Insira uma cidade");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Cidade inválida");
                    }
                }

                // Inserir estado
                string estado = null;
                while (estado == null || estado.Length == 0)
                {
                    System.Console.Write(" Digite o nome do estado : ");

                    try
                    {
                        estado = System.Console.ReadLine();

                        if (estado.Length == 0)
                        {
                            mostrarErro("Insira um estado");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("Estado inválido");
                    }
                }

                // Inserir cep
                string cep = null;
                while (cep == null || cep.Length == 0)
                {
                    System.Console.Write(" Digite o CEP : ");

                    try
                    {
                        cep = System.Console.ReadLine();

                        if (cep.Length == 0)
                        {
                            mostrarErro("Insira um CEP");
                        }
                    }
                    catch (Exception)
                    {
                        mostrarErro("CEP inválido");
                    }
                }

                // Adiciona novo endereço do paciente
                enderecos.Add(new Endereco()
                {
                    Rua = rua,
                    Numero = numero,
                    Complemento = complemento,
                    Bairro = bairro,
                    Cidade = cidade,
                    Estado = estado,
                    Cep = cep
                });

                Console.WriteLine();
                Console.WriteLine(" - Digite 0 (zero) se deseja adicionar mais um endereço, ou");
                Console.WriteLine(" - Digite qualquer outra tecla para confirmar cadastro");

                inserirEndereco = Console.ReadLine() == "0" ? true : false;

            }


            Paciente paciente = new Paciente
            {
                Nome = nome,
                Email = email,
                TelefoneResidencial = telefoneResidencial,
                TelefoneCelular = telefoneCelular,
                DataNascimento = dataNascimento.GetValueOrDefault(),
                Enderecos = enderecos
            };

            PacienteController pacienteController = new PacienteController();
            pacienteController.Adiciona(paciente);


            Console.WriteLine(" Paciente adicionado! ");
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