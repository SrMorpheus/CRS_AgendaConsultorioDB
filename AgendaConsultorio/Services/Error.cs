using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaConsultorio.Services
{
    public class Error
    {
        public ErrosCliente TipoErrosCliente { get; set; }

        public string DescricaoError { get; private set; }

        List<Error> ListaError = new List<Error>();



        public void ErrosNome(int opçao)
        {

            Error nomeErro = new Error();

            if (opçao == 1)
            {
                nomeErro.DescricaoError = "Existe menos de 5 caracteres no nome do paciente.";

                nomeErro.TipoErrosCliente = ErrosCliente.Nome;

                ListaError.Add(nomeErro);


            }
            else if (opçao == 2)
            {
                nomeErro.DescricaoError = "Nome do paciente  está vazio.";

                nomeErro.TipoErrosCliente = ErrosCliente.Nome;

                ListaError.Add(nomeErro);


            }



        }


        public void ErrosCpf(int opcao)
        {
            Error ErrorCpf = new Error();


            if (opcao == 1)
            {
                ErrorCpf.DescricaoError = "Existe menos de 11 Dígitos no CPF do paciente.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);


            }
            else if (opcao == 2)
            {
                ErrorCpf.DescricaoError = "Existe mais de 11 Dígitos no  CPF do paciente. ";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);


            }
            else if (opcao == 3)
            {
                ErrorCpf.DescricaoError = "O CPF do paciente precisa ser apenas números.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);


            }
            else if (opcao == 4)
            {
                ErrorCpf.DescricaoError = "O CPF está com tods números repetidos.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);



            }
            else if (opcao == 5)
            {
                ErrorCpf.DescricaoError = "O CPF não é válido.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);

            }
            else if (opcao == 6)
            {

                ErrorCpf.DescricaoError = "CPF já cadastrado.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);




            }


            }


        public void ErrosData(int opçao, int idade)
        {
            Error ErrorData = new Error();

            if (opçao == 1)
            {
                ErrorData.DescricaoError = "Formato da data  não é válido(formato certo DD/MM/AAAA)";

                ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                ListaError.Add(ErrorData);


            }
            else if (opçao == 2)
            {
                ErrorData.DescricaoError = "paciente só tem " + idade +  " anos.";

                ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                ListaError.Add(ErrorData);


            }



        }


        

     


        public void ListaDeErros()
        {



            foreach (var lista in ListaError)
            {

                Console.WriteLine(lista);

            }

        }

        public void ListaDeErros(ErrosCliente errosCliente)
        {

            var listaNova = ListaError.Where(x => x.TipoErrosCliente == errosCliente);

            foreach (var lista in listaNova)
            {

                Console.WriteLine(lista);

            }


        }



        public override string ToString()
        {
            return "Erro: " + DescricaoError;

        }



    }
}
