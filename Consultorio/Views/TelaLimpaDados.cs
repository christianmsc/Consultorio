using System;

namespace Consultorio
{
    class TelaLimpaDados : Tela
    {
        private Tela anterior;

        public string Nome { get; set; }

        public TelaLimpaDados(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = " Limpa Dados ";
        }

        public Tela Mostra()
        {
            Console.WriteLine(" >>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine(" Limpando dados ... ");

            Repositorio.Consultas.RemoveAll(consulta => true);
            Repositorio.Pacientes.RemoveAll(paciente => true);
            Repositorio.Alimentos.RemoveAll(alimento => true);
            
            

            Console.WriteLine(" Dados limpos! ");
            Console.WriteLine(" Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            return this.anterior;
        }
    }
}