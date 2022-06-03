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

<<<<<<< HEAD
            ValidadorCliente validador = new ValidadorCliente();
=======
       ValidadorCliente validador = new ValidadorCliente();
>>>>>>> temp-branch

       Console.WriteLine("-----------------------------------------------------------------------");
       Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
       Console.WriteLine("-----------------------------------------------------------------------");


       foreach (var lista in listaPacientes.OrderBy(x => x.CPF))
       {


         var idade = validador.CalculoIdade(lista.DataNascimento);


         Console.WriteLine("{0,-11} {1,-40} {2, 11}   {3,4}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
         //Console.WriteLine(lista);


        }



      }

        public void ListagemPacientesNome()
        {

            var listaPacientes = DadosPaciente.listaPacientes();


            ValidadorCliente validador = new ValidadorCliente();


            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,-11} {1,-40} {2,10}   {3,-3}", "CPF", "Nome", "Dt.Nasc.", "Idade");
            Console.WriteLine("-----------------------------------------------------------------------");


            foreach (var lista in listaPacientes.OrderBy(x => x.Nome))
            {


                var idade = validador.CalculoIdade(lista.DataNascimento);



<<<<<<< HEAD
=======
                Console.WriteLine("{0,-11} {1,-40} {2, 11}   {3,4}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
                //Console.WriteLine(lista);


>>>>>>> temp-branch
                Console.WriteLine("{0,-11} {1,-12} {2, 41:N1} {3,3}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
            



            }



        }





    }
}
