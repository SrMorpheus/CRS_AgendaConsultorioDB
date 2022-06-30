using System.Collections.Generic;

namespace AgendaConsultorio.Data.Converter.Contract
{
    public interface IAgenda<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
