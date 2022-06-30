using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;
using System;
using System.Linq;

namespace AgendaConsultorio.Services.Validadores
{
    public class ListagemAgenda
    {

        private readonly IAgendaRepository _AgendaRepository;

        public ListagemAgenda()
        {

            _AgendaRepository = new AgendaRepositoryImplementation();

        }


        public void ListagemAgendaGeral()
        {

            //var listaAgenda = DadosAgenda.listaAgendas();

            var listaAgenda = _AgendaRepository.ListaAgendas();


            var count = listaAgenda.Count();

            if (count > 0)
            {

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("{0,7} {1,8} {2,5} {3,5} {4,-40} {5,10}", "Data", "H.Ini", "H.Fim", "Tempo", "Nome", "Dt.Nasc.");
                Console.WriteLine("---------------------------------------------------------------------------------");

                foreach (var lista in listaAgenda.OrderBy(x => x.DataHoraConsulta))
                {


                    var intervalo = lista.HoraFinal - lista.HoraInicial;


                    Console.WriteLine("{0,8} {1,4} {2,5} {3,5} {4,-40} {5,11}", lista.DataConsulta.ToString("dd/MM/yyyy"), lista.HoraInicial.ToString("HH:mm"), lista.HoraFinal.ToString("HH:mm"), intervalo.ToString(@"hh\:mm"), lista.Paciente.Nome, lista.Paciente.DataNascimento.ToString("dd/MM/yyyy"));


                }

                // Console.WriteLine("{0,8} {1,4} {2,5} {3,5} {4,-40} {5,11}", "01/01/2022", "07:30", "08:00", "00:30", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "99/99/9999");

            }

            else
            {

                Console.WriteLine("Sem agendamentos!");

            }


        }

        public void ListagemAgendaEspecifica(string dataInicial, string dataFinal)
        {

            var dataInicialTime = Models.AgendaVO.ConveterData(dataInicial);

            var dataFinalTime = AgendaVO.ConveterData(dataFinal);

            // var listaAgenda = DadosAgenda.listaAgendas();

            var listaAgenda = _AgendaRepository.ListaAgendas();

            var count = listaAgenda.Count(x => x.DataConsulta >= dataInicialTime && x.DataConsulta <= dataFinalTime);

            if (count > 0)
            {

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("{0,7} {1,8} {2,5} {3,5} {4,-40} {5,10}", "Data", "H.Ini", "H.Fim", "Tempo", "Nome", "Dt.Nasc.");
                Console.WriteLine("---------------------------------------------------------------------------------");


                foreach (var lista in listaAgenda.OrderBy(x => x.DataHoraConsulta).Where(x => x.DataConsulta >= dataInicialTime && x.DataConsulta <= dataFinalTime))
                {

                    var intervalo = lista.HoraFinal - lista.HoraInicial;


                    Console.WriteLine("{0,8} {1,4} {2,5} {3,5} {4,-40} {5,11}", lista.DataConsulta.ToString("dd/MM/yyyy"), lista.HoraInicial.ToString("HH:mm"), lista.HoraFinal.ToString("HH:mm"), intervalo.ToString(@"hh\:mm"), lista.Paciente.Nome, lista.Paciente.DataNascimento.ToString("dd/MM/yyyy"));


                }
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("Sem agendamento para esse período");

            }

        }

    }
}
