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



            PrintTela();
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

                PrintTela();
                opcao = Console.ReadLine();






            }

        }
            private void PrintTela()
            {

                Console.WriteLine("Menu do Cadastro de Pacientes");
                Console.WriteLine("1-Cadastrar novo paciente");
                Console.WriteLine("2-Excluir paciente");
                Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
                Console.WriteLine("4-Listar pacientes (ordenado por nome)");
                Console.WriteLine("5-Voltar p/ menu principal");



            }












        


    }
}
