using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.View;
using AgendaConsultorio.Services;
using System;

namespace AgendaConsultorio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

          ViewMain main = new ViewMain();

            Listagem listagem = new Listagem();

            listagem.ListagemAgendaGeral();

           // main.ViewMenuPrincipal();





        }
    }
}
