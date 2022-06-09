using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgendaConsultorio.Services
{
    public class ValidadorAgenda
    {

        private Error _errorAgenda = new Error();

        public bool ValidarCpfAgenda(string cpf )
        {
            if (cpf.Length < 11)
            {
                _errorAgenda.ErrosCpf(1);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                }

                return false;

            }
            else if (cpf.Length > 11)
            {

                _errorAgenda.ErrosCpf(2);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);


                }
                return false;
            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                    return false;

                }
                else
                {
                    var cpfExist = DadosPaciente.listaPacientes();

                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorAgenda.ErrosCpf(7);

                        return false;


                    }else if(searchCpf.Agendas.Count >= 1)
                    {

                        Agenda agenda = searchCpf.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                       if(agenda!= null)
                        {

                            _errorAgenda.ErrosCpf(8,agenda);
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
                _errorAgenda.ErrosCpf(1);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                }

                return false;

            }
            else if (cpf.Length > 11)
            {

                _errorAgenda.ErrosCpf(2);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);


                }
                return false;


            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                    return false;


                }
                else
                {
                    var cpfExist = DadosPaciente.listaPacientes();

                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorAgenda.ErrosCpf(7);

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

                Agenda agenda = DadosAgenda.listaAgendas().Find( x => x.DataHoraConsulta == dataHora &&  x.CPF == long.Parse(cpf));
                
                if(agenda == null)
                {

                    _errorAgenda.ErrosAgenda(2);

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
                _errorAgenda.ErrosAgenda(1);

                return false;

            }

            return true;

        }

        public bool ValidarHoraAgenda(string data)
        {

            DateTime hora;

            if(data.Length < 4 )
            {

                _errorAgenda.ErrosHora(7);

                return false;


            }

            var horaFormat = data.Substring(0, 2);

            var minuntosFormat = data.Substring(2, 2);

            data = horaFormat + ":" + minuntosFormat;

            bool horaValida = DateTime.TryParseExact(data, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora);

            if (!horaValida || data.Length  > 5)
            {
                _errorAgenda.ErrosHora(7);

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


            var baseAgendamento = DadosAgenda.listaAgendas();

            Agenda agenda = baseAgendamento.FirstOrDefault(x => x.DataHoraConsulta == dataHora);

           

            if (datavalida)
            {

                

                if(dataHora < DateTime.Now)
                {
                    _errorAgenda.ErrosHora(1);


                    return false;

                } 
                
               

                else if(agenda!= null)
                {
                  
                    
                        _errorAgenda.ErrosHora(3);

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

            var baseAgendamento = DadosAgenda.listaAgendas().FindAll(x => x.DataConsulta == dataAtual);



            if (horaInicialTime.TimeOfDay < InicioExpediente || horaFinalTime.TimeOfDay > FinalExpediente)
            {

                _errorAgenda.ErrosHora(4);

                return false;

            }
            else if(horaFinalTime <= horaInicialTime)
            {

                _errorAgenda.ErrosHora(2);


                return false;


            }
            else if (duracao.Minutes < 15 && duracao.Hours < 1 )
            {

                _errorAgenda.ErrosHora(5);

                return false;


            }else if(horaInicialTime.Minute % 15 != 0 || horaFinalTime.Minute % 15 != 0 )
            {
                _errorAgenda.ErrosHora(6);


                return false;

            } 
            else if(baseAgendamento.Count > 0)
            {
                var temIntersecao = TemIntersecao(horaInicialTime, horaFinalTime, baseAgendamento);
               
                if (temIntersecao)
                {

                    _errorAgenda.ErrosHora(8);

                    return false;

                }


            }



            return true;

        }


        private bool TemIntersecao(DateTime horaInincial , DateTime horaFinal, List<Agenda> agendas )
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

            DateTime hora;

            var horaFormat = horaConvert.Substring(0, 2);

            var minuntosFormat = horaConvert.Substring(2, 2);

            horaConvert = horaFormat + ":" + minuntosFormat;


            bool horaValida = DateTime.TryParseExact(horaConvert, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora);

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
