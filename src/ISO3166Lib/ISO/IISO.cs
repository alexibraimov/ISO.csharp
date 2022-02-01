using ISO3166Lib.Model;

namespace ISO3166Lib.ISO
{
    public interface IISO
    {
        ISOName Type { get; }
        string Name { get; }
    }
}
