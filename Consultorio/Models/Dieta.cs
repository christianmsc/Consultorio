using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio
{
    public class Dieta : EntidadeBase
    {
        public Consulta Consulta { get; set; }

        public List<Alimento> Alimentos { get; set; }

        public int GetTotalCalorias()
        {
            return Alimentos.Sum(alimento => alimento.Calorias);
        }

        public override string ToString()
        {
            string s = null;

            for (int i=0; i< Alimentos.Count; i++)
            {
                s += (i == Alimentos.Count - 1) ? Alimentos[i] + "." : Alimentos[i] + "; ";
            }

            return s;
        }
    }
}