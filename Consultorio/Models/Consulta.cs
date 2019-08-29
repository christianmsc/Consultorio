using System;
using System.Collections.Generic;

namespace Consultorio
{
    class Consulta : EntidadeBase
    {
        public Paciente Paciente { get; set; }

        public DateTime? DataConsulta { get; set; }

        public double Peso { get; set; }

        public double PorcentagemGordura { get; set; }

        public string SensacaoFisica { get; set; }

        public Dieta Dieta { get; set; }

        public override string ToString()
        {
            string s = null;

            return s;
        }
    }
}