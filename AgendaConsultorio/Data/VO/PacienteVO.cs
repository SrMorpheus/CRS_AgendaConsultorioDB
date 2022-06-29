using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Models
{
    public class PacienteVO
    {

        private string _nome;

        private long _cpf;

        private DateTime _dataNascimento;

        public int Id { get; set; }


        public string Nome
        {
            get
            {

                return _nome;

            }

            set
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


        public List<AgendaVO> Agendas { get; set; }  



        


        public PacienteVO (string nome, long cpf, DateTime dataNascimento)
        {
           
            this.Nome = nome;

            this.CPF = cpf;

            this.DataNascimento = dataNascimento;

            this.Agendas   = new List<AgendaVO>();

        }

        public PacienteVO()
        { 

        }


        public void adicionarAgendaPaciente( AgendaVO agenda)
        {

            Agendas.Add(agenda);

        }

        public void ExcluirAgendaPaciente(AgendaVO agenda)
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
