using AgendaConsultorio.Data.Converter.Contract;
using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Data.Converter.Implementation
{
    public class AgendaConverter : IAgenda<AgendaVO, Agenda>, IPaciente<Agenda, AgendaVO>
    {
        private readonly PacienteConverter _pacienteConverter;


        public AgendaConverter()
        {

            _pacienteConverter = new PacienteConverter();


        }


        //destino = origem
        public Agenda Parse(AgendaVO origin)
        {

            if (origin == null) return null;


            return new Agenda
            {
                Id = origin.Id,

                CPF = origin.CPF,

                DataConsulta = origin.DataConsulta,

                HoraInicial = origin.HoraInicial,

                HoraFinal = origin.HoraFinal,

                DataHoraConsulta = origin.DataHoraConsulta,

                PacienteID = origin.PacienteId,

                Paciente = _pacienteConverter.Parse(origin.Paciente)
           




            };
        }


            

        public List<Agenda> Parse(List<AgendaVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }



    //destino = origem
    public AgendaVO Parse(Agenda origin)
     {

        if (origin == null) return null;



        return new AgendaVO
        {

            Id = origin.Id,

            CPF = origin.CPF,

            DataConsulta = origin.DataConsulta,

            HoraInicial = origin.HoraInicial,

            HoraFinal = origin.HoraFinal,

            DataHoraConsulta = origin.DataHoraConsulta,

            PacienteId = origin.PacienteID,

            Paciente = _pacienteConverter.Parse(origin.Paciente)


            //Paciente = _PacienteRepository.ListaPacientes().Find(X => X.Id == origin.PacienteID)






        };


    }

    public List<AgendaVO> Parse(List<Agenda> origin)
        {


            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();



        }
    }
}
