using ISO3166Lib.Model;
using System.Collections.Generic;

namespace ISO3166Lib.ISO
{
    public interface IISO<T> where T: IISOModel
    {
        int Number { get; }
        string Name { get; }
    }
}
