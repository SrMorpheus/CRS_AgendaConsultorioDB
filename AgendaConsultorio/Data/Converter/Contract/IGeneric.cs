using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaConsultorio.Data.Converter.Contract
{
    public interface IGeneric<O, D>
    {

        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
