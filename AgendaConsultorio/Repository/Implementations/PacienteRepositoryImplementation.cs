using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using AgendaConsultorio.Dados;
using AgendaConsultorio.Data.Converter.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MoreLinq.Extensions;

namespace AgendaConsultorio.Repository.Implementations
{


    public class PacienteRepositoryImplementation : IPacienteRepository
    {

        private ConsultorioContexto _context;

        private PacienteConverter _converter;

        private GeralConverter _converterGeral;


        public PacienteRepositoryImplementation()
        {

            _context = new ConsultorioContexto();

            _converter = new PacienteConverter();

            _converterGeral = new GeralConverter();
        }

        public void CadastrarPaciente(PacienteVO paciente)
        {

            try
            {

                var pacienteDB = _converter.Parse(paciente);

                _context.Add(pacienteDB);

                _context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Cadastro realizado com sucesso!");
                Console.WriteLine();


            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: base de dados não salvou o paciente");

            }

        }

        public void ExcluirPaciente(PacienteVO paciente)
        {

            try
            {

                var pacienteDB = _context.Pacientes.Include(x => x.Agendas).SingleOrDefault(x => x.Id == paciente.Id);


                _context.Pacientes.Remove(pacienteDB);

                _context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Paciente excluído com sucesso!");
                Console.WriteLine();


            }
            catch(Exception ex)
            {

                Console.WriteLine("Erro: base de dados não excluiu o paciente");

            }

        }

        public List<PacienteVO> ListaPacientes()
        {
          
            var pacientesDB = _context.Pacientes.Include(X => X.Agendas).ToList();

            var pacientes = _converterGeral.Parse(pacientesDB);

            return pacientes;

        }
    }
}
