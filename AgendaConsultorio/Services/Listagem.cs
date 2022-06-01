using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgendaConsultorio.Dados;

namespace AgendaConsultorio.Services
{
    public class Listagem
    {




        
     public void ListagemPacientesCPF()
     {

       var listaPacientes = DadosPaciente.listaPacientes();

        

        foreach (var lista in listaPacientes.OrderBy(x => x.CPF))
         {


            Console.WriteLine(lista) ;


         }



      }





    }
}
