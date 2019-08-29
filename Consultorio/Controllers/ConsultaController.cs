using System;
using System.Collections.Generic;
using System.Linq;
namespace Consultorio
{
    class ConsultaController
    {

        public void Adiciona(Consulta consulta)
        {
            Repositorio.Consultas.Add(consulta);
        }

        public List<Consulta> Lista()
        {
            return Repositorio.Consultas.ToList();
        }

        public void Remove(Consulta consulta)
        {
            Repositorio.Consultas.Remove(consulta);
        }

        public List<Consulta> ListaPorPeriodo(DateTime? dataInicial, DateTime? dataFinal)
        {
            return Repositorio.Consultas.Where(x => x.DataRegistro >= dataInicial && x.DataRegistro <= dataFinal).ToList();
        }

    }
}