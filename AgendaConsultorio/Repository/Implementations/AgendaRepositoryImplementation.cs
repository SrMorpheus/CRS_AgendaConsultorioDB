using AgendaConsultorio.Dados;
using AgendaConsultorio.Data.Converter.Implementation;
using AgendaConsultorio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Repository.Implementations
{
    public class AgendaRepositoryImplementation : IAgendaRepository
    {
        private ConsultorioContexto _context;

        private AgendaConverter _converter;


        public AgendaRepositoryImplementation()
        {

            _context = new ConsultorioContexto();

            _converter = new AgendaConverter();



        }


        public void Agendar(AgendaVO agenda)
        {

            try
            {

                var agendaDB = _converter.Parse(agenda);


                _context.Add(agendaDB);

                _context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Agendamento realizado com sucesso!");
                Console.WriteLine();



            }

            catch(Exception ex)
            {

                Console.WriteLine("Erro: base de dados não salvou o agendamento ");

            }





               

            



        }


        public void CancelarAgenda(AgendaVO agenda)
        {

            try
            {

                var agendaDB = _converter.Parse(agenda);

                var result = _context.Agendas.SingleOrDefault(x => x.Id == agendaDB.Id);

                _context.Agendas.Remove(result);

                _context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Agendamento cancelado com sucesso!");
                Console.WriteLine();


            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: base de dados não cancelou o agendamento ");


            }


        }



        public List<AgendaVO> ListaAgendas()
        {

            var agendasDB = _context.Agendas.Include(x => x.Paciente).ToList(); ;

            var agendas = _converter.Parse(agendasDB);    

            return agendas;

        }

    }






 }


