using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consultorio;
using System.Collections.Generic;
using Consultorio.Enums;
using System;

namespace ConsultorioTests
{
    [TestClass]
    public class DietaTest
    {
        [TestMethod]
        public void TestarSimuladorDeDietas()
        {
            Random rnd = new Random();
            AlimentoController alimentoController = new AlimentoController();
            ConsultaController consultaController = new ConsultaController();

            /* Alimentos */
            for (int i = 0; i < 1000; i++)
            {
                Alimento alimento = new Alimento();
                alimento.Grupo = (GrupoAlimentoEnum)rnd.Next(3);
                alimento.Calorias = rnd.Next(50, 500);
                alimentoController.Adiciona(alimento);
            }

            List<Dieta> dietas = consultaController.SimularDietas(500);

            foreach(Dieta dieta in dietas)
            {
                int totalCalorias = dieta.GetTotalCalorias();
                Assert.IsTrue(totalCalorias <= 500, "Total de caloridas da dieta ultrapassa o limite de calorias");
            }

        }
    }
}
