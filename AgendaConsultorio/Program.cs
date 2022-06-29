using AgendaConsultorio.Dados;
using AgendaConsultorio.Models;
using AgendaConsultorio.View;
using AgendaConsultorio.Services;
using System;
using AgendaConsultorio.Data.Converter.Implementation;
using System.Data.SqlClient;

namespace AgendaConsultorio
{
    public class Program
    {
        static void Main(string[] args)
        {

           try
            {

               ViewMain main = new ViewMain();

                main.ViewMenuPrincipal();

            }
            catch(SqlException EX)
            {

                Console.WriteLine("Erro: falha na requisição de conexão ao Banco de Dados");


            }



           
         }




        }
    }

