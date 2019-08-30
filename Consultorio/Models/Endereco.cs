using System;

namespace Consultorio
{
    public class Endereco : EntidadeBase
    {
        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public override string ToString()
        {
            string s = this.Rua + ", ";
            s += "N° " + this.Numero + ", ";
            s += this.Complemento.Length > 0 ? "Compl. " + this.Complemento + ", " : "";
            s += this.Bairro + ", ";
            s += this.Cidade + " - ";
            s += this.Estado + ", ";
            s += "Cep " + this.Cep;

            return s;
        }
    }
}