using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;
using AgendaConsultorio.Services.Validadores.Erro.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgendaConsultorio.Services
{
    public class ValidadorAgenda
    {

        private ErrosGerais _errorAgenda;

        private readonly IPacienteRepository _PacienteRepository;

        private readonly IAgendaRepository _AgendaRepository;


        public ValidadorAgenda()
        {

            _PacienteRepository = new PacienteRepositoryImplementation();

            _AgendaRepository = new AgendaRepositoryImplementation();

            _errorAgenda = new ErrosGerais();



        }



        public bool ValidarCpfAgenda(string cpf )
        {
            if (cpf.Length < 11)
            {
                _errorAgenda.ErrosCpf(StatusErros.CPF_menor_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);

                }

                return false;

            }
            else if (cpf.Length > 11)
            {

                _errorAgenda.ErrosCpf(StatusErros.CPF_maior_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);


                }
                return false;
            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);

                    return false;

                }
                else
                {
                    //var cpfExist = DadosPaciente.listaPacientes();

                    var cpfExist = _PacienteRepository.ListaPacientes();

                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorAgenda.ErrosCpf(StatusErros.Paciente_nao_cadastrado);

                        return false;


                    }else if(searchCpf.Agendas.Count >= 1)
                    {

                        AgendaVO agenda = searchCpf.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                       if(agenda!= null)
                        {

                            _errorAgenda.ErrosCpf(StatusErros.Paciente_com_agenda,agenda);
                            return false;
                         
                        }

                    }


                }

                return true;
            }


         }

        public bool ValidarCpfCancelarAgenda(string cpf)
        {
            if (cpf.Length < 11)
            {
                _errorAgenda.ErrosCpf(StatusErros.CPF_menor_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);

                }

                return false;

            }
            else if (cpf.Length > 11)
            {

                _errorAgenda.ErrosCpf(StatusErros.CPF_maior_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);


                }
                return false;


            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(StatusErros.CPF_diferente_numero);

                    return false;


                }
                else
                {
                   // var cpfExist = DadosPaciente.listaPacientes();

                    var cpfExist = _PacienteRepository.ListaPacientes();

                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorAgenda.ErrosCpf(StatusErros.Paciente_nao_cadastrado);

                        return false;


                    }
                   

                 }


             }

                return true;
         }




        public bool ValidarCancelarAgenda(string cpf, string dataConsulta, string horaInicial)
        {


            DateTime dataHora;

            var horaFormat = horaInicial.Substring(0, 2);

            var minuntosFormat = horaInicial.Substring(2, 2);

           var  hora = horaFormat + ":" + minuntosFormat;

            var dataHoraFormat = dataConsulta + " " + hora;

            bool datavalida = DateTime.TryParseExact(dataHoraFormat, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora);

            if(datavalida)
            {

               // AgendaVO agenda = DadosAgenda.listaAgendas().Find( x => x.DataHoraConsulta == dataHora &&  x.CPF == long.Parse(cpf));

                AgendaVO agenda = _AgendaRepository.ListaAgendas().Find(x => x.DataHoraConsulta == dataHora && x.CPF == long.Parse(cpf));


                if (agenda == null)
                {

                    _errorAgenda.ErrosAgenda(StatusErros.Agenda_nao_existe);

                    return false;


                }


            }


            return true;
        }


        public bool ValidarDataAgenda(string data)
        {

            DateTime dataAtual;

            bool datavalida = DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAtual);

            if (!datavalida)
            {
                _errorAgenda.ErrosAgenda(StatusErros.Data_formato);

                return false;

            }

            return true;

        }

        public bool ValidarHoraAgenda(string data)
        {

            DateTime hora;

            if(data.Length < 4 )
            {

                _errorAgenda.ErrosHora(StatusErros.Hora_formato);

                return false;


            }

            var horaFormat = data.Substring(0, 2);

            var minuntosFormat = data.Substring(2, 2);

            data = horaFormat + ":" + minuntosFormat;

            bool horaValida = DateTime.TryParseExact(data, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora);

            if (!horaValida || data.Length  > 5)
            {
                _errorAgenda.ErrosHora(StatusErros.Hora_formato);

                return false;

            }

            return true;

        }


        public bool ValidarAgendamento(string data, string hora, string cpf )
        {

            DateTime dataHora;


            DateTime dataAtual;

            var horaFormat = hora.Substring(0, 2);

            var minuntosFormat = hora.Substring(2, 2);
            
            hora = horaFormat + ":" + minuntosFormat;

            var dataHoraFormat = data + " " + hora;

            bool datavalida = DateTime.TryParseExact(dataHoraFormat, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora);


            //var baseAgendamento = DadosAgenda.listaAgendas();

            var baseAgendamento = _AgendaRepository.ListaAgendas();

            AgendaVO agenda = baseAgendamento.FirstOrDefault(x => x.DataHoraConsulta == dataHora);

           

            if (datavalida)
            {

                

                if(dataHora < DateTime.Now)
                {
                    _errorAgenda.ErrosHora(StatusErros.Agenda_futuro);


                    return false;

                } 
                
               

                else if(agenda!= null)
                {
                  
                    
                        _errorAgenda.ErrosHora(StatusErros.Agenda_existe);

                        return false;

                }


            }

            return true;
        }

        public bool ValidarHorarioFuncionamento(string horaInicial, string horaFinal, string data )
        {
            var horaInicialTime = ConverterHoraMinutos(horaInicial);

            var horaFinalTime = ConverterHoraMinutos(horaFinal);

            TimeSpan InicioExpediente = new TimeSpan(8, 00,0);

            TimeSpan duracao = horaFinalTime - horaInicialTime;

            TimeSpan FinalExpediente = new TimeSpan(19, 00, 0);
           
            DateTime dataAtual;


            bool datavalida = DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAtual);

           // var baseAgendamento = DadosAgenda.listaAgendas().FindAll(x => x.DataConsulta == dataAtual);

            var baseAgendamento = _AgendaRepository.ListaAgendas().FindAll(x => x.DataConsulta == dataAtual);


            if (horaInicialTime.TimeOfDay < InicioExpediente || horaFinalTime.TimeOfDay > FinalExpediente)
            {

                _errorAgenda.ErrosHora(StatusErros.Hora_funcionamento);

                return false;

            }
            else if(horaFinalTime <= horaInicialTime)
            {

                _errorAgenda.ErrosHora(StatusErros.Hora_final_maior);


                return false;


            }
            else if (duracao.Minutes < 15 && duracao.Hours < 1 )
            {

                _errorAgenda.ErrosHora(StatusErros.Duracao_consulta);

                return false;


            }else if(horaInicialTime.Minute % 15 != 0 || horaFinalTime.Minute % 15 != 0 )
            {
                _errorAgenda.ErrosHora(StatusErros.Hora_nao_valida);


                return false;

            } 
            else if(baseAgendamento.Count > 0)
            {
                var temIntersecao = TemIntersecao(horaInicialTime, horaFinalTime, baseAgendamento);
               
                if (temIntersecao)
                {

                    _errorAgenda.ErrosHora(StatusErros.Hora_com_conflito);

                    return false;

                }


            }



            return true;

        }


        private bool TemIntersecao(DateTime horaInincial , DateTime horaFinal, List<AgendaVO> agendas )
        {

             foreach( var lista in agendas)
            {

                if ( (horaInincial > lista.HoraInicial && horaInincial <  lista.HoraFinal) ||
                    (horaFinal > lista.HoraInicial && horaFinal < lista.HoraFinal))
                 {

                    return true;

                }
                  

                }

                return false;
        }

        private DateTime ConverterHoraMinutos(string horaConvert)
        {
            DateTime hora = new DateTime(); ;

            if (!string.IsNullOrEmpty(horaConvert))
            {

                var horaFormat = horaConvert.Substring(0, 2);

                var minuntosFormat = horaConvert.Substring(2, 2);

                horaConvert = horaFormat + ":" + minuntosFormat;


                bool horaValida = DateTime.TryParseExact(horaConvert, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora);

            }

         

            return hora;

        }

        public void ListaDeErrosDadosGeral()
        {

            _errorAgenda.ListaDeErros();


        }

        public void ListaDeErrosDadosEspecifica(ErrosCliente errosCliente)
        {

            _errorAgenda.ListaDeErros(errosCliente);

        }


    }
}
