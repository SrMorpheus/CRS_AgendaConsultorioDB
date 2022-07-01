using AgendaConsultorio.Models;
using System.Collections.Generic;

namespace AgendaConsultorio.Repository
{
    public interface IPacienteRepository
    {

        void CadastrarPaciente(PacienteVO paciente);

        void ExcluirPaciente(PacienteVO paciente);

        List<PacienteVO> ListaPacientes();



    }
}