using AgendaConsultorio.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.View
{
    public class ViewMain
    {

        private  ViewPaciente _viewPaciente = new ViewPaciente();
        private  ViewAgenda   _viewAgenda = new ViewAgenda();




        public void ViewMainCadastroPaciente()
        {

            PrintTelaPaciente();
            var opcao = Console.ReadLine();


            while (opcao != "5")
            {


                switch (opcao)
                {

                    case "1":

                        Console.WriteLine();

                        _viewPaciente.CadastroView();

                        Console.WriteLine();


                        break;

                    case "2":

                        Console.WriteLine();

                        _viewPaciente.ExclusaoView();

                        Console.WriteLine();


                        break;

                    case "3":

                        Console.WriteLine();

                        _viewPaciente.ListagemView(1);

                        Console.WriteLine();


                        break;

                    case "4":

                        Console.WriteLine();

                        _viewPaciente.ListagemView(2);

                        Console.WriteLine();


                        break;

                    case "5":

                        Console.WriteLine();

                        opcao = "5";
                        Console.WriteLine();



                        break;

                    default:

                        Console.WriteLine();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine();

                        break;

                }

                PrintTelaPaciente();
                opcao = Console.ReadLine();

            }

        }
        private void PrintTelaPaciente()
        {    

                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1-Cadastrar novo paciente");
                Console.WriteLine("2-Excluir paciente");
                Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
                Console.WriteLine("4-Listar pacientes (ordenado por nome)");
                Console.WriteLine("5-Voltar p/ menu principal");

        }

        private void PrintTelaAgenda()
        {

            Console.WriteLine("Agenda");
            Console.WriteLine("1-Agendar consulta");
            Console.WriteLine("2-Cancelar agendamento");
            Console.WriteLine("3-Listar agenda");
            Console.WriteLine("4-Voltar p/ menu principal");

        }


        public void ViewMainAgenda()
        {


            PrintTelaAgenda();

            var opcao = Console.ReadLine();


            while (opcao != "4")
            {


                switch (opcao)
                {

                    case "1":

                        Console.WriteLine();

                        _viewAgenda.ViewAgendamento();

                        Console.WriteLine();

                        break;

                    case "2":

                        Console.WriteLine();

                        _viewAgenda.ViewCancelarAgenda();

                        Console.WriteLine();

                        break;

                    case "3":

                        Console.WriteLine();



                        Listagem listagem = new Listagem();

                        _viewAgenda.ViewListaAgenda();

                        Console.WriteLine();

                        break;

                    case "4":

                        Console.WriteLine();

                        opcao = "4";

                        Console.WriteLine();
                        break;

                    default:

                        Console.WriteLine();

                        Console.WriteLine("Opção inválida");

                        Console.WriteLine();
                        break;



                }

                PrintTelaAgenda();

                opcao = Console.ReadLine();

            }


        }


        public void ViewMenuPrincipal()
        {

            PrintTelaMenu();

            var opcao = Console.ReadLine();

            while(opcao != "3")
            {

                switch(opcao)
                {
                    case "1":

                        Console.WriteLine();

                        ViewMainCadastroPaciente();

                        Console.WriteLine();

                        break;

                    case "2":

                        Console.WriteLine();

                        ViewMainAgenda();

                        Console.WriteLine();

                        break;

                    case "3":

                        Console.WriteLine();

                        opcao = "3";

                        Console.WriteLine();

                        break;


                    default:

                        Console.WriteLine();

                        Console.WriteLine("Opção inválida");

                        Console.WriteLine();

                        break;

                }

                PrintTelaMenu();
                opcao = Console.ReadLine();

            }


        }

        private void PrintTelaMenu()
        {

            Console.WriteLine("Menu Principal");
            Console.WriteLine("1-Cadastro de pacientes");
            Console.WriteLine("2-Agenda");
            Console.WriteLine("3-Fim");

        }



    }
}
