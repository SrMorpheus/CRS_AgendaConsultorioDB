using AgendaConsultorio.Models;
using AgendaConsultorio.Services.Validadores;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaConsultorio.Services
{
    public class ErrosGerais 
    {

       private List<ErroModel> ListaError = new List<ErroModel>();


        public void ErrosNome(int opçao)
        {

            ErroModel nomeErro = new ErroModel();

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
            ErroModel ErrorCpf = new ErroModel();

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
            else if (opcao == 7)
            {

                ErrorCpf.DescricaoError = "paciente não cadastrado";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);

            }


        }

        public void ErrosCpf(int opcao, AgendaVO agenda)
        {
            ErroModel ErrorCpf = new ErroModel();

            if (opcao == 8)
            {
                ErrorCpf.DescricaoError = "paciente está agendado para " + agenda.DataConsulta.ToString("dd/MM/yyyy") + " às " + agenda.HoraInicial.ToString("HH:mm") +"h.";

                ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                ListaError.Add(ErrorCpf);

            }



        }


        public void ErrosData(int opacao, int idade)
        {
            ErroModel ErrorData = new ErroModel();

            if (opacao == 1)
            {
                ErrorData.DescricaoError = "Formato da data  não é válido(formato certo DD/MM/AAAA)";

                ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                ListaError.Add(ErrorData);

            }
            else if (opacao == 2)
            {
                ErrorData.DescricaoError = "paciente só tem " + idade +  " anos.";

                ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                ListaError.Add(ErrorData);

            }

        }

        public void ErrosAgenda(int opcao)
        {

            ErroModel ErrorData = new ErroModel();

            if (opcao == 1)
            {
                ErrorData.DescricaoError = "Formato da data  não é válido(formato certo DD/MM/AAAA)";

                ErrorData.TipoErrosCliente = ErrosCliente.DataConsulta;

                ListaError.Add(ErrorData);


            }
            else if (opcao == 2)
            { 
                ErrorData.DescricaoError = "agendamento não encontrado";

                ErrorData.TipoErrosCliente = ErrosCliente.Agenda;

                ListaError.Add(ErrorData);
                
            }

        }

        public void ErrosHora(int opacao)
        {
            ErroModel ErrosHora = new ErroModel();

            if (opacao == 1)
            {
                ErrosHora.DescricaoError = "O agendamento deve ser para um periodo futuro.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Agenda;

                ListaError.Add(ErrosHora);

            }
            else if (opacao == 2)
            {
                ErrosHora.DescricaoError = "Hora final não pode ser maior que hora inicial do agendamento.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

            }

            else if (opacao == 3)
            {
                ErrosHora.DescricaoError = "já existe uma consulta agendada nesta data/hora.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Agenda;

                ListaError.Add(ErrosHora);

            }

            else if (opacao == 4)
            {
                ErrosHora.DescricaoError = "O horário de funcionamento do consultório e apenas entre 8:00h às 19:00h,";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

            }
            else if (opacao == 5)
            {
                ErrosHora.DescricaoError = "A duração mínima para agendamento e de 15 minutos";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

            }
            else if (opacao == 6)
            {
                ErrosHora.DescricaoError = "Não são válidas as horas(exemplo de horaas válidas 1400, 1730, 1615, 1000 e 0715).";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);


            }
            else if (opacao == 7)
            {

                ErrosHora.DescricaoError = "Formato da hora está incorreta.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);


            }
            else if (opacao == 8)
            {

                ErrosHora.DescricaoError = "Existe um conflito de Horário com outra consulta agendada.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);


            }


        }



        public void ListaDeErros()
        {

            var listaFinal = ListaError.DistinctBy(x => x.DescricaoError);

            foreach (var lista in ListaError)
            {

                Console.WriteLine(lista);

            }

        }

        public void ListaDeErros(ErrosCliente errosCliente)
        {
  
            var listaNova = ListaError.Where(x => x.TipoErrosCliente == errosCliente).Distinct();

            var listaFinal = listaNova.Last();


           Console.WriteLine(listaFinal);



        }

    
    }
}
