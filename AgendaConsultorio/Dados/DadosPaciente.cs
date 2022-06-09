using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Dados
{
    public class DadosPaciente
    {

        private static List<Paciente> _basePacientes = new List<Paciente>();

        public static void CadastrarPaciente(Paciente paciente)
        {

            _basePacientes.Add(paciente);

        }



        public static void ExcluirPaciente(Paciente paciente)
        {

            _basePacientes.Remove(paciente) ;


        }


        public static List<Paciente> listaPacientes ()
        {

            return _basePacientes;

        }


    }
}
