using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.View;
using AgendaConsultorio.Services;
using System;
using AgendaConsultorio.Data.Converter.Implementation;

namespace AgendaConsultorio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

          //ViewMain main = new ViewMain();

        

           //main.ViewMenuPrincipal();


            var contexo = new ConsultorioContexto();

            var pacienteConveter = new PacienteConverter();

            var AgendasConveter = new AgendaConverter();

            foreach (var item in contexo.Agendas)
            {


                //Console.WriteLine(pacienteConveter.Parse(item));

                Console.WriteLine(AgendasConveter.Parse(item));


            }




        }
    }
}
