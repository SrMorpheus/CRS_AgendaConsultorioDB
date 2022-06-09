using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Text;

using AgendaConsultorio.Controller;

namespace AgendaConsultorio.View
{
    public class ViewPaciente
    {
        private ValidadorPaciente _validador = new ValidadorPaciente();

        private ControllerPaciente _controllerPaciente = new ControllerPaciente();

        public bool NomeView(out string nomeRetorno)
        {


            Console.Write("Nome: ");

            var nome = Console.ReadLine();

            var resposta = _validador.ValidarNome(nome);

            nomeRetorno = nome;

            return resposta;


        }

        public bool CPFView(out string cpfRetorno)
        {
            Console.Write("CPF: ");

            var cpf = Console.ReadLine();

            var resposta = _validador.ValidarCpf(cpf);

            cpfRetorno = cpf;

            return resposta;


        }

        public bool CPFExclusãoView(out string cpfRetorno)
        {
            Console.Write("CPF: ");

            var cpf = Console.ReadLine();

            var resposta = _validador.ValidarExclusãoPaciente(cpf);

            cpfRetorno = cpf;

            return resposta;


        }


        public bool DataView(out string dataNascimento)
        {
            Console.Write("Data de Nascimento: ");

            var data = Console.ReadLine();

            var resposta = _validador.ValidarData(data);

            dataNascimento = data;

            return resposta;


        }


        public void ExclusaoView()
        {


            var dadosPacientes = DadosPaciente.listaPacientes();


            if(dadosPacientes.Count > 0)
            {

                string cpf;

                var boolCpf = CPFExclusãoView(out cpf);


                while (!boolCpf)
                {

                    Console.WriteLine();

                    _validador.ListaDeErrosDadosEspecifica(ErrosCliente.CPF);

                    Console.WriteLine();

                    boolCpf = CPFExclusãoView(out cpf);

                }

                if(boolCpf)
                {

                    _controllerPaciente.ExcluirPaciente(cpf);

                }

            }
            else
            {

                Console.WriteLine("Sem nenhum Paciente cadastrado na base de dados!");


            }


        }


        public void CadastroView()
        {

           
            string cpf;

            string nome = " ";

            string data = " ";

            bool boolNome = false;

            bool boolData = false;


            var boolCpf = CPFView(out cpf);
            
            if(boolCpf == false)
            {

                while (!boolCpf)
                {


                    Console.WriteLine();

                    _validador.ListaDeErrosDadosEspecifica(ErrosCliente.CPF);

                    Console.WriteLine();

                    boolCpf = CPFView(out cpf);
                }

            } 
         
            if(boolCpf)
            {

                boolNome = NomeView(out nome);

            }

            while (!boolNome)
             {

                Console.WriteLine();

                _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Nome);

                Console.WriteLine();

                boolNome = NomeView(out nome);

   
             }


            if (boolNome)
            {

                boolData = DataView(out data);


            }

            while (!boolData)
             {

               Console.WriteLine();

               _validador.ListaDeErrosDadosEspecifica(ErrosCliente.DataNascimento);

               Console.WriteLine();

               boolData = DataView(out data);

             


             }

            Console.WriteLine();

            if (boolNome == true && boolCpf == true && boolData == true)
            {

                _controllerPaciente.CriarPaciente(nome, cpf, data);


            }       

        }


        public void ListagemView(int opcao)
        {

            var dadosPaciente = DadosPaciente.listaPacientes();


            if(dadosPaciente.Count > 0)
            {

                if (opcao == 1)
                {

                    _controllerPaciente.ListaPacientesCPF();


                }
                else if (opcao == 2)
                {

                    _controllerPaciente.ListaPacientesNome();

                }

            }
            else
            {
            
                Console.WriteLine("Sem Pacientes cadastrados!");
          
            }

        }


    }
}
