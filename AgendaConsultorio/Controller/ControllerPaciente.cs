using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

using AgendaConsultorio.Dados;
using AgendaConsultorio.Services;

namespace AgendaConsultorio.Controller
{
    public class ControllerPaciente
    {

        private Listagem _listagem = new Listagem();


        public void CriarPaciente( string nome , string cpf , string dataNascimento)
        {


            var cpfLong = long.Parse(cpf);

            var Data = DateTime.Parse(dataNascimento);

            Paciente paciente = new Paciente(nome , cpfLong, Data);


            DadosPaciente.CadastrarPaciente(paciente);

            Console.WriteLine();
            Console.WriteLine("Cadastro realizado com sucesso!");
            Console.WriteLine();


        }

        public void ListaPacientesCPF()
        {

            _listagem.ListagemPacientesCPF();

        }

        public void ListaPacientesNome()
        {

            _listagem.ListagemPacientesNome();


        }






    }
}
