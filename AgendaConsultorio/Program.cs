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

            viewPaciente.CadastroView();



        }
    }
}
