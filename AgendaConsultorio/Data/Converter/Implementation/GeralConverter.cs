using AgendaConsultorio.Data.Converter.Contract;
using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Data.Converter.Implementation
{
    public class GeralConverter : IGeneric<PacienteVO, Paciente>, IGeneric<Paciente, PacienteVO>
    {

        private readonly PacienteConverter _pacienteConverter;

        private readonly AgendaConverter _agendaConverter;

        public GeralConverter()
        {
            _pacienteConverter = new PacienteConverter();


            _agendaConverter = new AgendaConverter();


        }

   

        public List<Paciente> Parse(List<PacienteVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        public List<PacienteVO> Parse(List<Paciente> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        public Paciente Parse(PacienteVO origin)
        {
            if (origin == null) return null;

            return new Paciente
            {
                Id = origin.Id,

                CPF = origin.CPF,

                Nome = origin.Nome,

                DataNascimento = origin.DataNascimento,

                Agendas = _agendaConverter.Parse(origin.Agendas)

            };
        }

        public PacienteVO Parse(Paciente origin)
        {

            if (origin == null) return null;

            return new PacienteVO
            {
                Id = origin.Id,

                CPF = origin.CPF,

                Nome = origin.Nome,

                DataNascimento = origin.DataNascimento,

                Agendas = _agendaConverter.Parse(origin.Agendas)

            };



        }
    }
}
