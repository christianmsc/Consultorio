using System;

namespace Consultorio
{
    class ConsultorioMain
    {
        static void Main(string[] args)
        {
            /* Menu Principal */
            TelaMenu principal = new TelaMenu(" Menu Principal ");
            TelaMenu pacientes = new TelaMenu(" Pacientes ");
            TelaGeraDados geraDados = new TelaGeraDados(principal);
            TelaLimpaDados limpaDados = new TelaLimpaDados(principal);
            TelaSair sair = new TelaSair();

            principal.AdicionaFilha(pacientes);
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


            Tela atual = principal;
            while (atual != null)
            {
                atual = atual.Mostra();
                System.Console.Clear();
            }
        }
    }
}
