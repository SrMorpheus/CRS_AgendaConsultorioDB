using AgendaConsultorio.Models;
using AgendaConsultorio.Repository;
using AgendaConsultorio.Repository.Implementations;
using AgendaConsultorio.Services.Validadores.Erro.Enum;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AgendaConsultorio.Services
{
    public class ValidadorPaciente
    {

        private ErrosGerais _errorCliente = new ErrosGerais();



        private readonly IPacienteRepository _PacienteRepository;

   

        public ValidadorPaciente()
        {

            _PacienteRepository = new PacienteRepositoryImplementation();


             ErrosGerais _errorCliente = new ErrosGerais();

    }



        public bool ValidarNome(string nome)
        {
            
            if (string.IsNullOrWhiteSpace(nome))
            {
                _errorCliente.ErrosNome(StatusErros.Paciente_nome_vazio);

                return false;


            }
            else if (nome.Length < 5)
            {
                _errorCliente.ErrosNome(StatusErros.Paciente_nome_caracteres);

                return false;


            }

            return true;

        }


        public bool ValidarCpf(string cpf)
        {
            

            if (cpf.Length < 11)
            {
                _errorCliente.ErrosCpf(StatusErros.CPF_menor_11);



                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);

                }
                return false;


            }
            else if (cpf.Length > 11)
            {

                _errorCliente.ErrosCpf(StatusErros.CPF_maior_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);


                }
                return false;


            }
            else
            { 

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);

                    return false;


                }

                else if (!ValidacaoCpfRepetido(cpf)) 
                { 
                    _errorCliente.ErrosCpf(StatusErros.CPF_numero_repetido);

                    return false;

                }
                else if (!ValidacaoCPF(cpf))
                {
                    _errorCliente.ErrosCpf(StatusErros.CPF_nao_valido);

                    return false;


                }else
                {
                    // var cpfExist = DadosPaciente.listaPacientes();

                    var cpfExist = _PacienteRepository.ListaPacientes();




                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (searchCpf != null && searchCpf.CPF.ToString("D11") == cpf)
                    {

                        _errorCliente.ErrosCpf(StatusErros.CPF_cadastrado);

                        return false;


                    }


                }


            }

            return true;

        }

        public bool ValidarExclusãoPaciente (string cpf)
        {


            if (cpf.Length < 11)
            {
                _errorCliente.ErrosCpf(StatusErros.CPF_menor_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);

                }

                return false;


            }
            else if (cpf.Length > 11)
            {

                _errorCliente.ErrosCpf(StatusErros.CPF_maior_11);


                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);


                }
                return false;


            }
            else
            {

                if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                {

                    _errorCliente.ErrosCpf(StatusErros.CPF_diferente_numero);

                    return false;


                }
                else
                {
                    //var cpfExist = DadosPaciente.listaPacientes();

                    var cpfExist = _PacienteRepository.ListaPacientes();


                    var searchCpf = cpfExist.Where(x => x.CPF == long.Parse(cpf)).FirstOrDefault();


                    if (!(searchCpf != null && searchCpf.CPF.ToString("D11") == cpf))
                    {

                        _errorCliente.ErrosCpf(StatusErros.Paciente_nao_cadastrado);

                        return false;


                    }
                    else if (searchCpf.Agendas.Count >= 1)
                    {


                        AgendaVO agenda = searchCpf.Agendas.FirstOrDefault(x => x.DataHoraConsulta >= DateTime.Now);

                        if (agenda != null)
                        {

                            _errorCliente.ErrosCpf(StatusErros.Paciente_com_agenda,agenda);
                            return false;



                        }



                    }


                }

                return true;
            }

        }


        public bool ValidarData(string data)
        {

            DateTime dataAtual;

            bool datavalida = DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAtual);


            if (!datavalida)
            {
                _errorCliente.ErrosData(StatusErros.Data_formato, 0);

                return false;

            }
            else if (datavalida)
            {

                var dataNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", null);

                var idade = CalculoIdade(dataNascimento);

                if (idade < 13)
                {
                    _errorCliente.ErrosData(StatusErros.Paciente_idade, idade);

                    return false;

                }



            }

            return true;

        }

        public int CalculoIdade(DateTime dataNascimento)
        {

            int idade = DateTime.Now.Year - dataNascimento.Year;

            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {

                idade = idade - 1;

            }

            return idade;

        }

        private bool ValidacaoCpfRepetido(string cpf)
        {
            var isRepeated = true;

            for (int i = 1; i < cpf.Length; i++)
            {

                if (cpf[0] != cpf[i])
                {

                    isRepeated = false;
                    break;

                }
            }

            if (isRepeated)
            {

                return false;

            }

            return true;


        }

        private bool ValidacaoCPF(string cpf)
        {

            var Parte01Cpf = cpf.Substring(0, 9);

            var Parte02Cpf = cpf.Substring(9, 2);

            long digitoK = 0;

            long digitoJ = 0;

            long soma = 0;

            int count = 10;

            foreach (var x in Parte01Cpf)
            {

                soma = (count * (int)char.GetNumericValue(x)) + soma;

                count--;

            }

            var resto = soma % 11;

            if (resto < 2)
            {

                digitoJ = 0;

            }
            else if (resto >= 2 && resto <= 10)
            {

                digitoJ = 11 - resto;

            }

            Parte01Cpf = Parte01Cpf + digitoJ.ToString();

            count = 11;

            soma = 0;

            foreach (var x in Parte01Cpf)
            {

                soma = (count * (int)char.GetNumericValue(x)) + soma;

                count--;

            }

            resto = soma % 11;

            if (resto < 2)
            {

                digitoK = 0;

            }
            else if (resto >= 2 && resto <= 10)
            {

                digitoK = 11 - resto;

            }

            var digitosFinais = digitoJ.ToString() + digitoK.ToString();

            if (digitosFinais == Parte02Cpf)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

        public void ListaDeErrosDadosGeral()
        {

            _errorCliente.ListaDeErros();


        }

        public void ListaDeErrosDadosEspecifica(ErrosCliente errosCliente)
        {

            _errorCliente.ListaDeErros(errosCliente);

        }



    }
}