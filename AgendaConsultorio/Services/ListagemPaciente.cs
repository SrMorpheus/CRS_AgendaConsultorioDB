using System;
using System.Linq;
using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;

namespace AgendaConsultorio.Services
{
    public class ListagemPaciente
    {

        private readonly IPacienteRepository _PacienteRepository;

        public ListagemPaciente()
        {

            _PacienteRepository = new PacienteRepositoryImplementation();

        }

        public void ListagemPacientesCPF()
        {

           // var listaPacientes = DadosPaciente.listaPacientes();

            var listaPacientes = _PacienteRepository.ListaPacientes();

            ValidadorPaciente validador = new ValidadorPaciente();

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (var lista in listaPacientes.OrderBy(x => x.CPF))
            {

                var idade = validador.CalculoIdade(lista.DataNascimento);



                Console.WriteLine("{0,-11} {1,-40} {2, 11}   {3,4}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
                //Console.WriteLine(lista);

                if (lista.Agendas.Count != 0)
                {

                    AgendaVO agenda = lista.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                    if(agenda!= null)
                    {

                        var dataConsulta = agenda.AgendaPacienteData();
                        var horaConsulta = agenda.AgendaPacienteHora();

                        Console.WriteLine("{0,37}", dataConsulta);
                        Console.WriteLine("{0,26}", horaConsulta);

                    }

                }

            }

        }

        public void ListagemPacientesNome()
        {

            //var listaPacientes = DadosPaciente.listaPacientes();

            var listaPacientes = _PacienteRepository.ListaPacientes();


            ValidadorPaciente validador = new ValidadorPaciente();

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (var lista in listaPacientes.OrderBy(x => x.Nome))
            {


                var idade = validador.CalculoIdade(lista.DataNascimento);



                Console.WriteLine("{0,-11} {1,-40} {2, 11}   {3,4}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
                //Console.WriteLine(lista);

                if (lista.Agendas.Count != 0)
                {

                    AgendaVO agenda = lista.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                    if(agenda != null)
                    {

                        var dataConsulta = agenda.AgendaPacienteData();
                        var horaConsulta = agenda.AgendaPacienteHora();

                        Console.WriteLine("{0,37}", dataConsulta);
                        Console.WriteLine("{0,26}", horaConsulta);

                    }
                  

                }

                //   Console.WriteLine("{0,-11} {1,-12} {2, 41:N1} {3,3}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);

            }


        }

       
    }
}
