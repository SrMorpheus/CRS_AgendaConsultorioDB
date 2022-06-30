using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

using AgendaConsultorio.Dados;
using AgendaConsultorio.Services;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;

namespace AgendaConsultorio.Controller
{
    public class ControllerPaciente
    {


        private readonly IPacienteRepository _PacienteRepository;

        private readonly IAgendaRepository _AgendaRepository;


        private ListagemPaciente _listagem = new ListagemPaciente();

        public ControllerPaciente()
        {

            _PacienteRepository = new PacienteRepositoryImplementation();

            _AgendaRepository = new AgendaRepositoryImplementation();

            _listagem = new ListagemPaciente();



        }





        public void CriarPaciente( string nome , string cpf , string dataNascimento)
        {

            var cpfLong = long.Parse(cpf);

            var Data = DateTime.Parse(dataNascimento);

            PacienteVO paciente = new PacienteVO(nome , cpfLong, Data);

            //DadosPaciente.CadastrarPaciente(paciente);

            _PacienteRepository.CadastrarPaciente(paciente);

        }

        public void ExcluirPaciente(string cpf)
        {

            var cpfLong = long.Parse (cpf);

            //var basePaciente = DadosPaciente.listaPacientes();

            var basePaciente = _PacienteRepository.ListaPacientes();




            PacienteVO paciente = basePaciente.Find(x=> x.CPF == cpfLong);

            if(paciente.Agendas.Count > 0)
            {

                foreach (var listaAgendas in paciente.Agendas)
                {

                    _AgendaRepository.CancelarAgenda(listaAgendas);
                  //DadosAgenda.CancelarAgenda(listaAgendas);

                }

            }


            //DadosPaciente.ExcluirPaciente(paciente);
            _PacienteRepository.ExcluirPaciente(paciente);
           

        }



        public void ListaPacientesCPF()
        {

            _listagem.ListagemPacientesCPF();

        }

        public void ListaPacientesNome()
        {

            _listagem.ListagemPacientesNome();


        }






    }
}
