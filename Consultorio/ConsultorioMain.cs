﻿using System;

namespace Consultorio
{
    class ConsultorioMain
    {
        static void Main(string[] args)
        {
            /* Menu Principal */
            TelaMenu principal = new TelaMenu(" Menu Principal ");
            TelaMenu pacientes = new TelaMenu(" Pacientes ");
            TelaMenu alimentos = new TelaMenu(" Alimentos ");
            TelaMenu consultas = new TelaMenu(" Consultas ");
            TelaGeraDados geraDados = new TelaGeraDados(principal);
            TelaLimpaDados limpaDados = new TelaLimpaDados(principal);
            TelaSair sair = new TelaSair();

            principal.AdicionaFilha(pacientes);
            principal.AdicionaFilha(alimentos);
            principal.AdicionaFilha(consultas);
            principal.AdicionaFilha(geraDados);
            principal.AdicionaFilha(limpaDados);
            principal.AdicionaFilha(sair);

            /* Pacientes */
            TelaPacienteAdicionar pacienteAdicionar = new TelaPacienteAdicionar(pacientes);
            TelaMenu pacienteListar = new TelaMenu(" Pacientes Cadastrados ");

            pacientes.AdicionaFilha(pacienteAdicionar);
            pacientes.AdicionaFilha(pacienteListar);
            pacientes.AdicionaFilha(principal);

            /* Pacientes - Consultar */
            TelaPacienteListaTodos pacienteListaTodos = new TelaPacienteListaTodos(pacienteListar);
            TelaPacienteListaPeriodo pacienteListaPeriodo = new TelaPacienteListaPeriodo(pacienteListar);

            pacienteListar.AdicionaFilha(pacienteListaTodos);
            pacienteListar.AdicionaFilha(pacienteListaPeriodo);
            pacienteListar.AdicionaFilha(pacientes);

            /* Alimentos */
            TelaAlimentoAdicionar alimentoAdicionar = new TelaAlimentoAdicionar(alimentos);
            TelaMenu alimentoListar = new TelaMenu(" Alimentos Cadastrados ");

            alimentos.AdicionaFilha(alimentoAdicionar);
            alimentos.AdicionaFilha(alimentoListar);
            alimentos.AdicionaFilha(principal);

            /* Alimentos - Consultar */
            TelaAlimentoListaTodos alimentoListaTodos = new TelaAlimentoListaTodos(alimentoListar);

            alimentoListar.AdicionaFilha(alimentoListaTodos);
            alimentoListar.AdicionaFilha(alimentos);

            /* Consultas */
            TelaConsultaAdicionar consultaAdicionar = new TelaConsultaAdicionar(consultas);
            TelaConsultaFinalizar consultaFinalizar = new TelaConsultaFinalizar(consultas);
            TelaMenu consultaListar = new TelaMenu(" Consultas Cadastradas ");

            consultas.AdicionaFilha(consultaAdicionar);
            consultas.AdicionaFilha(consultaFinalizar);
            consultas.AdicionaFilha(consultaListar);
            consultas.AdicionaFilha(principal);

            /* Consultas - Listar */
            TelaConsultaListaTodas consultaListaTodas = new TelaConsultaListaTodas(consultaListar);
            TelaConsultaListaPeriodo consultaListaPeriodo = new TelaConsultaListaPeriodo(consultaListar);

            consultaListar.AdicionaFilha(consultaListaTodas);
            consultaListar.AdicionaFilha(consultaListaPeriodo);
            consultaListar.AdicionaFilha(consultas);


            Tela atual = principal;
            while (atual != null)
            {
                atual = atual.Mostra();
                System.Console.Clear();
            }
        }
    }
}
