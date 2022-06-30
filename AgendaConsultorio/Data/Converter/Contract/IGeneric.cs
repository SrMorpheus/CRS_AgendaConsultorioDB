using System.Collections.Generic;

namespace AgendaConsultorio.Data.Converter.Contract
{
    public interface IGeneric<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
