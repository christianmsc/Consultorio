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
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();

            System.Console.WriteLine(" Limpando dados ... ");
            
            Repositorio.Pacientes.RemoveAll(paicente => true);

            System.Console.WriteLine(" Dados limpos! ");
            System.Console.WriteLine();

            return this.anterior;
        }
    }
}