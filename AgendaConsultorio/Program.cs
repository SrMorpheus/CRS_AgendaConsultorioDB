using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.View;
using System;

namespace AgendaConsultorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ViewPaciente viewPaciente = new ViewPaciente();
        

                


                for (int i = 0; i <3; i++)
            {

                viewPaciente.CadastroView();


            }



            viewPaciente.ListagemView(2);


        }
    }
}
