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
        private ValidadorCliente _validador = new ValidadorCliente();

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


        public bool DataView(out string dataNascimento)
        {
            Console.Write("Data de Nascimento: ");

            var data = Console.ReadLine();

            var resposta = _validador.ValidarData(data);

            dataNascimento = data;

            return resposta;


        }

        public void CadastroView()
        {

            

            string cpf;

            var boolCpf = CPFView(out cpf);



            string nome;

            var boolNome = NomeView(out nome);





            string data;

            var boolData = DataView(out data);


            if(boolNome == true && boolCpf == true && boolData == true)
            {


                _controllerPaciente.CriarPaciente(nome, cpf, data);



            }



            else
            {


                while (!(boolNome == true && boolCpf == true && boolData == true))
                {

                    if (boolCpf == false)
                    {


                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.CPF);

                        Console.WriteLine();

                        boolCpf = CPFView(out cpf);

                        Console.WriteLine();



                    }

                    if (boolNome == false)
                    {

                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Nome);

                        Console.WriteLine();

                        boolNome = NomeView(out nome);

                        Console.WriteLine();

                    }

                 
                    if (boolData == false)
                    {

                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.DataNascimento);

                        Console.WriteLine();

                        boolData = DataView(out data);

                        Console.WriteLine();



                    }



                }


                _controllerPaciente.CriarPaciente(nome, cpf, data);


            }



        }



        public void ListagemView()
        {
            _controllerPaciente.ListaPacientesCPF();

        }


    }
}
