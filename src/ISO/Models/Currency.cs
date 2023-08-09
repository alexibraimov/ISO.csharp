namespace ISOLib.Models
{
    public class Currency : ISOModel
    {
        internal Currency(string name, string alpha3, string? number, int? decimals) : base(alpha3: alpha3, name: name)
        {
            Number = number;
            Deciamals = decimals;
        }

        public string? Number { get; }
        public int? Deciamals { get; }
    }
}
