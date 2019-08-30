using System;
using System.Collections.Generic;

namespace Consultorio
{
    public class Consulta : EntidadeBase
    {
        public Paciente Paciente { get; set; }

        public DateTime DataConsulta { get; set; }

        public double Peso { get; set; }

        public double PorcentagemGordura { get; set; }

        public string SensacaoFisica { get; set; }

        public Dieta Dieta { get; set; }

        public override string ToString()
        {
            string s = null;
            s += Paciente.Nome + " - ";
            s += DataConsulta.ToString("dd/MM/yyyy hh:mm");
            s += Peso != 0.0d ? ", Peso: " + Peso : "";
            s += PorcentagemGordura != 0.0d ? ", % de Gordura: " + PorcentagemGordura : "";
            s += SensacaoFisica != null ? ", Sensação Física: " + SensacaoFisica : "";
            s += Dieta != null ? "\nDieta: " + Dieta : "";

            return s;
        }
    }
}