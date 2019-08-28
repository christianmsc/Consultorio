using System.Collections.Generic;

namespace Consultorio {
    class TelaMenu : Tela {
        public string Nome { get; set; }

        private List<Tela> filhas = new List<Tela>();

        public TelaMenu(string nome) {
            this.Nome = nome;
        }

        public Tela Mostra() {
            System.Console.WriteLine(" >>> " + this.Nome + " <<<");
            System.Console.WriteLine();

            for (int i = 0; i < this.filhas.Count; i++) {
                System.Console.WriteLine((i + 1) + ". " + this.filhas[i].Nome);
            }

            System.Console.WriteLine();
            System.Console.Write(" Escolha a opção : ");
            int indiceDaOpcao =
                System.Convert.ToInt32(System.Console.ReadLine()) - 1;

            System.Console.WriteLine();

            return this.filhas[indiceDaOpcao];
        }

        public void AdicionaFilha(Tela tela) {
            this.filhas.Add(tela);
        }
    }
}