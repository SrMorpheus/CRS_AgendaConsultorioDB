using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;
using AgendaConsultorio.Services.Validadores;
using System;
using System.Linq;

namespace AgendaConsultorio.Controller
{
    public class ControllerAgenda
    {

        private ListagemAgenda _listagem;

        private readonly IPacienteRepository _PacienteRepository;

        private readonly IAgendaRepository _AgendaRepository;

        public ControllerAgenda()
        {

            _PacienteRepository = new PacienteRepositoryImplementation();

            _AgendaRepository = new AgendaRepositoryImplementation();

            _listagem = new ListagemAgenda();

        }

        public void CriarAgenda(string cpf, string dataConsulta, string horaInicial, string horaFinal)
        {

            //var basePaciente = DadosPaciente.listaPacientes();

            var basePaciente = _PacienteRepository.ListaPacientes();

            var CpfLong = long.Parse(cpf);

            var paciente = basePaciente.FirstOrDefault(x => x.CPF == CpfLong);

            var horaInicialTime = AgendaVO.ConverterHora(horaInicial);

            var horaFinalTime = AgendaVO.ConverterHora(horaFinal);

            var DataConsultaTime = DateTime.Parse(dataConsulta);

            AgendaVO agenda = new AgendaVO(CpfLong, DataConsultaTime, horaInicialTime, horaFinalTime, paciente);

            // DadosAgenda.Agendar(agenda);

            _AgendaRepository.Agendar(agenda);

        }

        public void CancelarAgenda(string cpf, string dataConsulta, string horaInicial)
        {

            //var baseAgenda = DadosAgenda.listaAgendas();

            var baseAgenda = _AgendaRepository.ListaAgendas();

            var CpfLong = long.Parse(cpf);

            var dataHoraConsulta = AgendaVO.AgendaDataHora(dataConsulta, horaInicial);

            AgendaVO agenda = baseAgenda.Find(x => x.CPF == CpfLong && x.DataHoraConsulta == dataHoraConsulta);

            // DadosPaciente.listaPacientes().Find(x => x.CPF == CpfLong).ExcluirAgendaPaciente(agenda);

            _AgendaRepository.CancelarAgenda(agenda);

           // _PacienteRepository.ListaPacientes().Find(x => x.CPF == CpfLong).ExcluirAgendaPaciente(agenda);

        }

        public void ListaAgendaGeral()
        {

            _listagem.ListagemAgendaGeral();

        }

        public void ListaAgendaPeriodo(string dataInicial, string dataFinal)
        {

            _listagem.ListagemAgendaEspecifica(dataInicial, dataFinal);

        }
    }
}