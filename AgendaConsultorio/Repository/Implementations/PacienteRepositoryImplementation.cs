
using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AgendaConsultorio.Dados;
using AgendaConsultorio.Data.Converter.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgendaConsultorio.Repository.Implementations
{

 
    public class PacienteRepositoryImplementation : IPacienteRepository
    {

        private ConsultorioContexto _context;

        private PacienteConverter _converter; 


        public PacienteRepositoryImplementation()
        {

            _context = new ConsultorioContexto();

            _converter = new PacienteConverter();

        }

        public void CadastrarPaciente(PacienteVO paciente)
        {

            try
            {

                var pacienteDB = _converter.Parse(paciente);

                _context.Add(pacienteDB);

                _context.SaveChanges();


            }catch(Exception ex)
            {

                Console.WriteLine("Erro: base de dados não salvou o paciente");

            }



        }

        public void ExcluirPaciente(PacienteVO paciente)
        {

            try
            {

                Console.WriteLine(paciente.Id);
                var pacienteDB = _converter.Parse(paciente);

                _context.Pacientes.Remove(pacienteDB);

                

                _context.SaveChanges();



            }catch(Exception ex)
            {

                Console.WriteLine("Erro: base de dados não excluiu o paciente");


            }


        }

        public List<PacienteVO> ListaPacientes()
        {

            var pacientesDB = _context.Pacientes.Include(X => X.Agendas).ToList();

            var pacientes = _converter.Parse(pacientesDB);

            return pacientes;

        }
    }
}
