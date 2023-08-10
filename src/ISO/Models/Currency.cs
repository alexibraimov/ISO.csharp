namespace ISOLib
{
    public class Currency
    {
        internal Currency(string name, string alpha3, string number, int minorUnit)
        {
            Alpha3 = alpha3;
            Name = name;
            Number = number;
            MinorUnit = minorUnit;
        }

        public string Alpha3 { get; }
        public string Name { get; }
        public string Number { get; }
        public int MinorUnit { get; }
        public override string ToString() => Name;
        public override bool Equals(object obj)
        {
            if (obj is Currency model)
            {
                return model.Alpha3.Equals(Alpha3);
            }
            return false;
        }
        public override int GetHashCode() => Alpha3.GetHashCode();
    }
}
