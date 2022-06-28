using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Dados
{
    public class DadosPaciente
    {

        private static List<PacienteVO> _basePacientes = new List<PacienteVO>();

        public static void CadastrarPaciente(PacienteVO paciente)
        {

            _basePacientes.Add(paciente);

        }



        public static void ExcluirPaciente(PacienteVO paciente)
        {

            _basePacientes.Remove(paciente) ;


        }


        public static List<PacienteVO> listaPacientes ()
        {

            return _basePacientes;

        }


    }
}
