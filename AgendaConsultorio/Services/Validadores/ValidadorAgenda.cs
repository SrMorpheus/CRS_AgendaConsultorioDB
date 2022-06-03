using AgendaConsultorio.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AgendaConsultorio.Services
{
    public class ValidadorAgenda
    {

        private Error _errorAgenda = new Error();



        public bool ValidarCpfAgenda(string cpf )
        {
            if (cpf.Length < 11)
            {
                _errorAgenda.ErrosCpf(1);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                }

                return false;


            }
            else if (cpf.Length > 11)
            {

                _errorAgenda.ErrosCpf(2);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);


                }
                return false;


            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorAgenda.ErrosCpf(3);

                    return false;


                }
                else
                {
                    var cpfExist = DadosPaciente.listaPacientes();

                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorAgenda.ErrosCpf(7);

                        return false;


                    }


                }

                return true;
            }


         }



     }
}
