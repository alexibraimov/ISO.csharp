using System;

namespace ISO3166Lib.Model
{
    public abstract class ISOModel
    {
        public ISOModel(string alpha2, string alpha3, string name)
        {
            if (string.IsNullOrEmpty(alpha2))
            {
                throw new ArgumentNullException("Alpha 2 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(alpha3))
            {
                throw new ArgumentNullException("Alpha 3 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }
            Alpha2 = alpha2;
            Alpha3 = Alpha3;
            Name = name;
        }
        public string Alpha2 { get; }
        public string Alpha3 { get; }
        public string Name { get; }
        public override string ToString() => Name;
        public override bool Equals(object obj)
        {
            if (obj is ISOModel model)
            {
                return model.Alpha3.Equals(Alpha3);
            }
            return false;
        }
        public override int GetHashCode() => Alpha3.GetHashCode();
    }
}
