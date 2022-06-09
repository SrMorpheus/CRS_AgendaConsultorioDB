using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Controller
{
    public class ControllerAgenda
    {


        private Listagem _listagem = new Listagem();

        public void CriarAgenda(string cpf, string dataConsulta, string horaInicial, string horaFinal)
        {

            var basePaciente = DadosPaciente.listaPacientes();

            var CpfLong = long.Parse(cpf);

            var paciente = basePaciente.FirstOrDefault(x => x.CPF == CpfLong);

            var horaInicialTime = Agenda.ConverterHora(horaInicial);

            var horaFinalTime = Agenda.ConverterHora(horaFinal);

            var DataConsultaTime = DateTime.Parse(dataConsulta);

            Agenda agenda = new Agenda(CpfLong, DataConsultaTime, horaInicialTime, horaFinalTime, paciente);

            DadosAgenda.Agendar(agenda);


            Console.WriteLine();
            Console.WriteLine("Agendamento realizado com sucesso!");
            Console.WriteLine();

        }

        public void CancelarAgenda(string cpf, string dataConsulta, string horaInicial)
        {

            var baseAgenda = DadosAgenda.listaAgendas();

            var CpfLong = long.Parse(cpf);

            var dataHoraConsulta = Agenda.AgendaDataHora(dataConsulta, horaInicial);

            Agenda agenda = baseAgenda.Find(x => x.CPF == CpfLong && x.DataHoraConsulta == dataHoraConsulta);

            DadosPaciente.listaPacientes().Find(x => x.CPF == CpfLong).ExcluirAgendaPaciente(agenda);

            DadosAgenda.CancelarAgenda(agenda);

            Console.WriteLine();
            Console.WriteLine("Agendamento cancelado com sucesso!");
            Console.WriteLine();

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