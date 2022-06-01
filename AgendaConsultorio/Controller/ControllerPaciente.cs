using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

using AgendaConsultorio.Dados;

namespace AgendaConsultorio.Controller
{
    public class ControllerPaciente
    {




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


        




    }
}
