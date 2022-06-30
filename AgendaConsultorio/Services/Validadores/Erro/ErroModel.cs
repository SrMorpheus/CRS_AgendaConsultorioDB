using AgendaConsultorio.Models;
using System;

namespace AgendaConsultorio.Services.Validadores
{
    public class ErroModel : IEquatable<ErroModel>
    {

        public ErrosCliente TipoErrosCliente { get; set; }

        public string DescricaoError { get;  set; }


        public override string ToString()
        {
            return "Erro: " + DescricaoError;

        }

        public override bool Equals(object obj)
        {

            return this.Equals(obj as ErroModel);

        }

        public bool Equals(ErroModel other)
        {

            if (other == null)
                return false;


            return this.TipoErrosCliente.Equals(other.TipoErrosCliente) &&
         (
             object.ReferenceEquals(this.TipoErrosCliente, other.TipoErrosCliente) &&
             this.TipoErrosCliente.Equals(other.TipoErrosCliente)
         ) &&
         (
             object.ReferenceEquals(this.DescricaoError, other.DescricaoError) ||
             this.DescricaoError != null &&
             this.DescricaoError.Equals(other.DescricaoError));


        }


    }
}
