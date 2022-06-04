using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Controller
{
    public class ControllerAgenda
    {

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


             var dados = DadosAgenda.listaAgendas();

            foreach (var item in dados)
            {

                Console.WriteLine(item);

            }


        }



    }
}
