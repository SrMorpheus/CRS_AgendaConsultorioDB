using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Models
{
    public class Paciente
    {

        private string _nome;

        private long _cpf;

        private DateTime _dataNascimento;

        public string Nome
        {
            get
            {

                return _nome;

            }

             private set
            {

                _nome = value;

            }
        }

        public long CPF 
        {
            
            get 
            {

                return _cpf;
            
            }
            set 
            { 

                _cpf = value;
            
            }
        }


        public DateTime DataNascimento { 
            get 
            {

                return _dataNascimento;
            
            } 
            set
            { 
            
               _dataNascimento = value;

            
            }
        }


        public List<Agenda> Agendas { get; set; }   = new List<Agenda> ();


        public Paciente (string nome, long cpf, DateTime dataNascimento)
        {
           
            this.Nome = nome;

            this.CPF = cpf;

            this.DataNascimento = dataNascimento;
   
        }

        public void adicionarAgendaPaciente( Agenda agenda)
        {

            Agendas.Add(agenda);


        }

        public void ExcluirAgendaPaciente(Agenda agenda)
        {

            Agendas.Remove(agenda);

        }




        public override string ToString()
        {
            ValidadorPaciente validador = new ValidadorPaciente();

            var idade = validador.CalculoIdade(this.DataNascimento);

            return this.CPF.ToString("D11") + " " + this.Nome + " " + DataNascimento.ToString("dd/MM/yyyy") + " " + idade ;
        }


    }
}
