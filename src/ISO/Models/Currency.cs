namespace ISOLib.Models
{
    public class Currency : ISOModel
    {
        internal Currency(string name, string alpha3, string number, int minorUnit) : base(alpha3: alpha3, name: name)
        {
            Number = number;
            MinorUnit = minorUnit;
        }

        public string Number { get; }
        public int MinorUnit { get; }
    }
}
