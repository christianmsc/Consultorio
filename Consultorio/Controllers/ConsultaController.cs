using System;
using System.Collections.Generic;
using System.Linq;
namespace Consultorio
{
    public class ConsultaController
    {

        public void Adiciona(Consulta consulta)
        {
            Repositorio.Consultas.Add(consulta);
        }

        public List<Consulta> Lista()
        {
            return Repositorio.Consultas.ToList();
        }

        public bool IsConsultaJaAgendada(DateTime dataConsulta)
        {
            return Repositorio.Consultas.Any(consulta => consulta.DataConsulta == dataConsulta);
        }

        public List<Consulta> ListarConsultasPorPaciente(string nomePaciente)
        {
            return Repositorio.Consultas.Where(consulta => consulta.Paciente.Nome.Contains(nomePaciente)).ToList();
        }

        public Consulta ObterConsultaPorPacienteData(string nomePaciente, DateTime dataConsulta)
        {
            return Repositorio.Consultas.FirstOrDefault(consulta => consulta.Paciente.Nome.Contains(nomePaciente) && consulta.DataConsulta == dataConsulta);
        }

        public List<Dieta> SimularDietas(int limiteCalorias)
        {
            List<Alimento> alimentosConstrutores = Repositorio.Alimentos.Where(alimento => alimento.Grupo == Enums.GrupoAlimentoEnum.Construtores).ToList();
            List<Alimento> alimentosEnergeticos = Repositorio.Alimentos.Where(alimento => alimento.Grupo == Enums.GrupoAlimentoEnum.Energéticos).ToList();
            List<Alimento> alimentosReguladores = Repositorio.Alimentos.Where(alimento => alimento.Grupo == Enums.GrupoAlimentoEnum.Reguladores).ToList();
            List<Dieta> dietasSugeridas = new List<Dieta>();

            foreach (Alimento alimentoConstrutor in alimentosConstrutores)
            {
                if (alimentoConstrutor.Calorias < limiteCalorias)
                {
                    foreach (Alimento alimentoEnergetico in alimentosEnergeticos)
                    {
                        if (alimentoConstrutor.Calorias + alimentoEnergetico.Calorias < limiteCalorias)
                        {
                            foreach (Alimento alimentoRegulador in alimentosReguladores)
                            {
                                if (alimentoConstrutor.Calorias + alimentoEnergetico.Calorias + alimentoRegulador.Calorias <= limiteCalorias)
                                {
                                    Dieta dietaSugerida = new Dieta
                                    {
                                        Alimentos = new List<Alimento>
                                        {
                                            alimentoConstrutor,
                                            alimentoEnergetico,
                                            alimentoRegulador
                                        }
                                    };
                                    dietasSugeridas.Add(dietaSugerida);
                                }
                            }
                        }
                    }
                }
            }

            return dietasSugeridas;
        }

        public void Remove(Consulta consulta)
        {
            Repositorio.Consultas.Remove(consulta);
        }

        public List<Consulta> ListaPorPeriodo(DateTime? dataInicial, DateTime? dataFinal)
        {
            return Repositorio.Consultas.Where(x => x.DataConsulta >= dataInicial && x.DataConsulta <= dataFinal).ToList();
        }

    }
}