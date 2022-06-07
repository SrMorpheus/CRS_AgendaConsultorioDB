using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;

namespace AgendaConsultorio.Services
{
    public class Listagem
    {
        
     public void ListagemPacientesCPF()
     {

       var listaPacientes = DadosPaciente.listaPacientes();




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



                    Agenda agenda = lista.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                    var dataConsulta = agenda.AgendaPacienteData();
                    var horaConsulta = agenda.AgendaPacienteHora();

                    Console.WriteLine("{0,37}", dataConsulta);
                    Console.WriteLine("{0,26}", horaConsulta);



                }

            }



      }

        public void ListagemPacientesNome()
        {

            var listaPacientes = DadosPaciente.listaPacientes();


            ValidadorPaciente validador = new ValidadorPaciente();



            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (var lista in listaPacientes.OrderBy(x => x.Nome))
            {
    

                var idade = validador.CalculoIdade(lista.DataNascimento);



                Console.WriteLine("{0,-11} {1,-40} {2, 11}   {3,4}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
                //Console.WriteLine(lista);

                if(lista.Agendas.Count != 0)
                {

                    

                    Agenda agenda = lista.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                    var dataConsulta = agenda.AgendaPacienteData();
                    var horaConsulta = agenda.AgendaPacienteHora();

                    Console.WriteLine("{0,37}", dataConsulta);
                    Console.WriteLine("{0,26}", horaConsulta);



                }

               

                //   Console.WriteLine("{0,-11} {1,-12} {2, 41:N1} {3,3}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);




            }



        }

        public void ListagemAgendaGeral()
        {

            var listaAgenda = DadosAgenda.listaAgendas();


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
            Console.WriteLine("-----------------------------------------------------------------------");


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,8} {1,8} {2,6} {3,10} {4,-40} {5,10}", "Data", "H.Ini", "H.Fim", "Tempo","Nome", "Dt.Nasc.");
            Console.WriteLine("-----------------------------------------------------------------------");
          

        }



    }
}
