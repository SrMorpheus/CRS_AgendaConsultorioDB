using System;
using System.Collections.Generic;
using System.Text;
using AgendaConsultorio.Data.Converter.Contract;
using AgendaConsultorio.Models;
using AgendaConsultorio.Data;
using System.Linq;

namespace AgendaConsultorio.Data.Converter.Implementation
{
    public class PacienteConverter : IPaciente<PacienteVO, Paciente>, IPaciente<Paciente, PacienteVO>
    {

       




        //destino = origem
        public Paciente Parse(PacienteVO origin)
        {

           

            if (origin == null) return null;

            return new Paciente
            {

                Id = origin.Id,

                CPF = origin.CPF,

                Nome = origin.Nome,

                DataNascimento = origin.DataNascimento,

               


                //agenda agenda aqui
            };


        }

        public List<Paciente> Parse(List<PacienteVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();


        }

        //destino = origem

        public PacienteVO Parse(Paciente origin)
        {


            if (origin == null) return null;

            return new PacienteVO
            {
                Id = origin.Id,

                CPF = origin.CPF,

                Nome = origin.Nome,

                DataNascimento = origin.DataNascimento,

             };


        }

        public List<PacienteVO> Parse(List<Paciente> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
