using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Repository
{
    public  interface IPacienteRepository
    {

        void CadastrarPaciente(PacienteVO paciente);

        void ExcluirPaciente(PacienteVO paciente);

        List<PacienteVO> ListaPacientes();



    }
}
