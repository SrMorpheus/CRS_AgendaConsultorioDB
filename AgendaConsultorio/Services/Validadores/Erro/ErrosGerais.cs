using AgendaConsultorio.Models;
using AgendaConsultorio.Services.Validadores;
using AgendaConsultorio.Services.Validadores.Erro.Enum;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaConsultorio.Services
{
    public class ErrosGerais
    {

        private List<ErroModel> ListaError = new List<ErroModel>();


        public void ErrosNome(StatusErros opçao)
        {

            ErroModel nomeErro = new ErroModel();

            switch (opçao)

            {

                case StatusErros.Paciente_nome_caracteres:

                    nomeErro.DescricaoError = "Existe menos de 5 caracteres no nome do paciente.";

                    nomeErro.TipoErrosCliente = ErrosCliente.Nome;

                    ListaError.Add(nomeErro);


                    break;

                case StatusErros.Paciente_nome_vazio:

                    nomeErro.DescricaoError = "Nome do paciente  está vazio.";

                    nomeErro.TipoErrosCliente = ErrosCliente.Nome;

                    ListaError.Add(nomeErro);

                    break;

                default:

                    Console.WriteLine("Erro: opção inválida");
                    break;


            }


        }


        public void ErrosCpf(StatusErros opcao)
        {
            ErroModel ErrorCpf = new ErroModel();

            switch (opcao)
            {

                case StatusErros.CPF_menor_11:

                    ErrorCpf.DescricaoError = "Existe menos de 11 Dígitos no CPF do paciente.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                case StatusErros.CPF_maior_11:

                    ErrorCpf.DescricaoError = "Existe mais de 11 Dígitos no  CPF do paciente. ";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                case StatusErros.CPF_diferente_numero:

                    ErrorCpf.DescricaoError = "O CPF do paciente precisa ser apenas números.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                case StatusErros.CPF_numero_repetido:

                    ErrorCpf.DescricaoError = "O CPF está com tods números repetidos.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                case StatusErros.CPF_nao_valido:

                    ErrorCpf.DescricaoError = "O CPF não é válido.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;


                case StatusErros.CPF_cadastrado:

                    ErrorCpf.DescricaoError = "CPF já cadastrado.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                case StatusErros.Paciente_nao_cadastrado:


                    ErrorCpf.DescricaoError = "paciente não cadastrado";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                default:

                    Console.WriteLine("Erro: opção inválida");
                    break;


            }


        }

        public void ErrosCpf(StatusErros opcao, AgendaVO agenda)
        {
            ErroModel ErrorCpf = new ErroModel();

            switch (opcao)
            {

                case StatusErros.Paciente_com_agenda:

                    ErrorCpf.DescricaoError = "paciente está agendado para " + agenda.DataConsulta.ToString("dd/MM/yyyy") + " às " + agenda.HoraInicial.ToString("HH:mm") + "h.";

                    ErrorCpf.TipoErrosCliente = ErrosCliente.CPF;

                    ListaError.Add(ErrorCpf);

                    break;

                default:

                    Console.WriteLine("Erro: opção inválida");
                    break;

            }


        }


        public void ErrosData(StatusErros opacao, int idade)
        {
            ErroModel ErrorData = new ErroModel();


            switch (opacao)
            {


                case StatusErros.Data_formato:

                    ErrorData.DescricaoError = "Formato da data  não é válido(formato certo DD/MM/AAAA)";

                    ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                    ListaError.Add(ErrorData);

                    break;

                case StatusErros.Paciente_idade:

                    ErrorData.DescricaoError = "paciente só tem " + idade + " anos.";

                    ErrorData.TipoErrosCliente = ErrosCliente.DataNascimento;

                    ListaError.Add(ErrorData);

                    break;

                default:

                    Console.WriteLine("Erro: opção inválida");
                    break;


            }




        }

        public void ErrosAgenda(StatusErros opcao)
        {

            ErroModel ErrorData = new ErroModel();


            switch (opcao)
            {

                case StatusErros.Data_formato:

                    ErrorData.DescricaoError = "Formato da data  não é válido(formato certo DD/MM/AAAA)";

                    ErrorData.TipoErrosCliente = ErrosCliente.DataConsulta;

                    ListaError.Add(ErrorData);

                    break;

                case StatusErros.Agenda_nao_existe:

                    ErrorData.DescricaoError = "agendamento não encontrado";

                    ErrorData.TipoErrosCliente = ErrosCliente.Agenda;

                    ListaError.Add(ErrorData);


                    break;

                default:

                    Console.WriteLine("Erro: opção inválida");
                    break;

            }


        }




    public void ErrosHora(StatusErros opacao)
    {
        ErroModel ErrosHora = new ErroModel();


        switch (opacao)
        {


            case StatusErros.Agenda_futuro:

                ErrosHora.DescricaoError = "O agendamento deve ser para um periodo futuro.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Agenda;

                ListaError.Add(ErrosHora);


                break;

            case StatusErros.Hora_final_maior:

                ErrosHora.DescricaoError = "Hora final não pode ser maior que hora inicial do agendamento.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

                break;

            case StatusErros.Agenda_existe:

                ErrosHora.DescricaoError = "já existe uma consulta agendada nesta data/hora.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Agenda;

                    ListaError.Add(ErrosHora);

                break;

            case StatusErros.Hora_funcionamento:

                ErrosHora.DescricaoError = "O horário de funcionamento do consultório e apenas entre 8:00h às 19:00h,";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

                break;

            case StatusErros.Duracao_consulta:

                ErrosHora.DescricaoError = "A duração mínima para agendamento e de 15 minutos";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

                break;

            case StatusErros.Hora_nao_valida:

                ErrosHora.DescricaoError = "Não são válidas as horas(exemplo de horaas válidas 1400, 1730, 1615, 1000 e 0715).";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);


                break;


            case StatusErros.Hora_formato:

                ErrosHora.DescricaoError = "Formato da hora está incorreta.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);

                break;

            case StatusErros.Hora_com_conflito:

                ErrosHora.DescricaoError = "Existe um conflito de Horário com outra consulta agendada.";

                ErrosHora.TipoErrosCliente = ErrosCliente.Hora;

                ListaError.Add(ErrosHora);


                break;

             default:
                Console.WriteLine("Erro: opção inválida");
                    break;


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