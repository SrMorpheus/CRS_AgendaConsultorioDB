﻿using AgendaConsultorio.Controller;
using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.View
{
    public class ViewAgenda
    {

        private ValidadorAgenda _validador = new ValidadorAgenda();

        private ControllerAgenda _controllerAgenda = new ControllerAgenda();



        public bool CPFView(out string cpfRetorno)
        {
            Console.Write("CPF: ");

            var cpf = Console.ReadLine();

            var resposta = _validador.ValidarCpfAgenda(cpf);

            cpfRetorno = cpf;

            return resposta;


        }


        public bool CPFCancelarView(out string cpfRetorno)
        {
            Console.Write("CPF: ");

            var cpf = Console.ReadLine();

            var resposta = _validador.ValidarCpfCancelarAgenda(cpf);

            cpfRetorno = cpf;

            return resposta;


        }

        public bool DataView(out string dataRetorno)
        {
            Console.Write("Data da consulta: ");

            var data = Console.ReadLine();

            var resposta = _validador.ValidarDataAgenda(data);

            dataRetorno = data;

            return resposta;


        }

        public bool HoraInicialView(out string horaRetorno)
        {
            Console.Write("Hora inicial: ");

            var horaInical = Console.ReadLine();

            var resposta = _validador.ValidarHoraAgenda(horaInical);

            horaRetorno = horaInical;

            return resposta;


        }

        public bool HoraFinalView(out string horaRetorno)
        {
            Console.Write("Hora final: ");

            var horaFinal = Console.ReadLine();

            var resposta = _validador.ValidarHoraAgenda(horaFinal);

            horaRetorno = horaFinal;

            return resposta;


        }


        public void Agendarview(out string cpfRetorno, out string dataRetorno, out string horaInicialRetorno, out string horaFinalRetorno)

        {





            string cpf;
            bool boolCpf = CPFView(out cpf);

            string data = " ";
            bool boolData = false;

            string horaInicial = " ";
            bool boolHoraInicial = false;

            string horaFinal = " ";
            bool boolHoraFinal = false;

            while (!boolCpf)
            {


                Console.WriteLine();

                _validador.ListaDeErrosDadosEspecifica(ErrosCliente.CPF);

                Console.WriteLine();

                boolCpf = CPFView(out cpf);



            }

            if (boolCpf)
            {

                boolData = DataView(out data);

            }


            while (!boolData)
            {


                Console.WriteLine();

                _validador.ListaDeErrosDadosEspecifica(ErrosCliente.DataConsulta);

                Console.WriteLine();

                boolData = DataView(out data);





            }

            if (boolData)
            {
                boolHoraInicial = HoraInicialView(out horaInicial);

            }

            while (!boolHoraInicial)
            {


                Console.WriteLine();

                _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Hora);

                Console.WriteLine();


                boolHoraInicial = HoraInicialView(out horaInicial);




            }

            if (boolHoraInicial)
            {
                boolHoraFinal = HoraFinalView(out horaFinal);

            }

            while (!boolHoraFinal)
            {


                Console.WriteLine();

                _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Hora);

                Console.WriteLine();

                boolHoraFinal = HoraFinalView(out horaFinal);





            }

          


            cpfRetorno = cpf;

            dataRetorno = data;

            horaInicialRetorno = horaInicial ;

            horaFinalRetorno = horaFinal;



        }


        public void ViewAgendamento()
        {

            string cpf, data, horaInicial, horaFinal;

            bool boolAgendamento = false;


            Agendarview(out cpf, out data, out horaInicial, out horaFinal);

            boolAgendamento = _validador.ValidarAgendamento(data, horaInicial, horaFinal);

           

            if (!boolAgendamento)

            {
                while (!boolAgendamento)
                {

                    Console.WriteLine();

                    _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Agenda);

                    Console.WriteLine();

                    Agendarview(out cpf, out data, out horaInicial, out horaFinal);

                    boolAgendamento = _validador.ValidarAgendamento(data, horaInicial, horaFinal);




                }


            }

            bool boolAgendamentoHorario = _validador.ValidarHorarioFuncionamento(horaInicial, horaFinal,data);



            if(!boolAgendamentoHorario)
            {

                while (!boolAgendamentoHorario)
                {

                    Console.WriteLine();

                    _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Hora);

                    Console.WriteLine();

                    var boolHoraInicial = HoraInicialView(out horaInicial);

                    var boolHoraFinal = HoraFinalView(out horaFinal);

                    boolAgendamentoHorario = _validador.ValidarHorarioFuncionamento(horaInicial, horaFinal,data);



                }

            }


            if(boolAgendamento == true && boolAgendamentoHorario == true)
            {

                _controllerAgenda.CriarAgenda(cpf, data, horaInicial, horaFinal);


            }






        }



        public void ViewCancelarAgenda()
        {


            var baseAgendamento = DadosAgenda.listaAgendas();

            string cpf = " ";

            string dataConsulta = " ";

            string horaInicial = " ";

            bool boolDataConsulta = false;

            bool boolHoraInicial = false;

            bool boolAgendaExclusao = false;


            if (baseAgendamento.Count > 0)
            {


                while (boolAgendaExclusao != true)
                {

                    var boolCpf = CPFCancelarView(out cpf);



                    while (!boolCpf)
                    {
                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.CPF);

                        Console.WriteLine();

                        boolCpf = CPFCancelarView(out cpf);

                    }

                    if (boolCpf)
                    {

                        boolDataConsulta = DataView(out dataConsulta);

                    }

                    while (!boolDataConsulta)
                    {

                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.DataConsulta);

                        Console.WriteLine();

                        boolDataConsulta = DataView(out dataConsulta);


                    }
                    if (boolDataConsulta)
                    {

                        boolHoraInicial = HoraInicialView(out horaInicial);


                    }

                    while (!boolHoraInicial)
                    {

                        Console.WriteLine();

                        _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Hora);

                        Console.WriteLine();


                        boolHoraInicial = HoraInicialView(out horaInicial);


                    }


                    if (boolCpf == true && boolDataConsulta == true && boolHoraInicial == true)
                    {

                        boolAgendaExclusao = _validador.ValidarCancelarAgenda(cpf, dataConsulta, horaInicial);

                        if (!boolAgendaExclusao)
                        {

                            Console.WriteLine();

                            _validador.ListaDeErrosDadosEspecifica(ErrosCliente.Agenda);

                            Console.WriteLine();


                        }



                    }

                }

                if (boolAgendaExclusao)
                {

                    _controllerAgenda.CancelarAgenda(cpf, dataConsulta, horaInicial);

                }
            }
            else
            {

                Console.WriteLine("Sem agendamentos na base de dados!");


            }




        }


    }
}
