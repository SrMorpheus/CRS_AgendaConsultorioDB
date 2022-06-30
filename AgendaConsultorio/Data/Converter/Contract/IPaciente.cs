using System.Collections.Generic;

namespace AgendaConsultorio.Data.Converter.Contract
{
    public interface IPaciente<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
