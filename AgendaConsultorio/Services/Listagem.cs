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

            ValidadorCliente validador = new ValidadorCliente();

            

     
        Console.WriteLine("{0,-11} {1,-12} {2,40} {3,42}", "CPF", "Nome", "Dt.Nasc.", "Idade");



            foreach (var lista in listaPacientes.OrderBy(x => x.CPF))
            {
                var idade = validador.CalculoIdade(lista.DataNascimento);

                string lengt = ( 40 - (lista.Nome.Length)).ToString();


                Console.WriteLine("{0,-11} {1,-12} {2, 41:N1} {3,3}", lista.CPF.ToString("D11"), lista.Nome, lista.DataNascimento.ToString("dd/MM/yyyy"), idade);
            


            }



      }





    }
}
