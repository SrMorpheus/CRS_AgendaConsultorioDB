using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Services.Validadores.Erro.Enum
{
    public enum StatusErros
    {

        Paciente_nome_caracteres,

        Paciente_nome_vazio,

        Paciente_nao_cadastrado,

        Paciente_com_agenda,

        Paciente_idade,

        CPF_menor_11,

        CPF_maior_11,

        CPF_diferente_numero,

        CPF_numero_repetido ,

        CPF_nao_valido,

        CPF_cadastrado,

        Data_formato,

        Hora_formato,

        Hora_com_conflito,

        Agenda_nao_existe,

        Agenda_existe,

     

        Agenda_futuro,

        Hora_final_maior,

        Hora_funcionamento,

        Duracao_consulta,

        Hora_nao_valida,




    }
}
