using Consultorio.Enums;
using System;

namespace Consultorio
{
    public class Alimento : EntidadeBase
    {
        public string Nome { get; set; }

        public GrupoAlimentoEnum Grupo { get; set; }

        public int Calorias { get; set; }

        public override string ToString()
        {
            string s = this.Nome + ", ";
            s += this.Grupo + ", ";
            s += this.Calorias + " calorias";

            return s;
        }
    }
}