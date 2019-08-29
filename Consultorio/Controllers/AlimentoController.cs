using System;
using System.Collections.Generic;
using System.Linq;
namespace Consultorio
{
    class AlimentoController
    {

        public void Adiciona(Alimento alimento)
        {
            Repositorio.Alimentos.Add(alimento);
        }

        public List<Alimento> Lista()
        {
            return Repositorio.Alimentos.ToList();
        }

        public void Remove(Alimento alimento)
        {
            Repositorio.Alimentos.Remove(alimento);
        }


    }
}