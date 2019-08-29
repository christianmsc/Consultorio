using System;
using System.Collections.Generic;

namespace Consultorio
{
    class Dieta : EntidadeBase
    {
        public Consulta Consulta { get; set; }

        public List<Alimento> Alimentos { get; set; }

        public override string ToString()
        {
            string s = null;

            foreach (Alimento alimento in Alimentos)
            {
                s = alimento.ToString();
            }

            return s;
        }
    }
}