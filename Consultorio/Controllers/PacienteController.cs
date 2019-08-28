using System;
using System.Collections.Generic;
using System.Linq;
namespace Consultorio
{
    class PacienteController
    {

        public void Adiciona(Paciente paciente)
        {
            Repositorio.Pacientes.Add(paciente);
        }

        public List<Paciente> Lista()
        {
            return Repositorio.Pacientes.ToList();
        }

        public void Remove(Paciente paciente)
        {
            Repositorio.Pacientes.Remove(paciente);
        }

        public List<Paciente> ListaPorPeriodo(DateTime? dataInicial, DateTime? dataFinal)
        {
            return Repositorio.Pacientes.Where(x => x.DataRegistro >= dataInicial && x.DataRegistro <= dataFinal).ToList();
        }

    }
}