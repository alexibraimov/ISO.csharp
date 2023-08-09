namespace ISOLib.Models
{
    using System;
    public abstract class ISOModel
    {
        internal ISOModel(string alpha3, string name)
        {
            if (string.IsNullOrEmpty(alpha3))
            {
                throw new ArgumentNullException("Alpha 3 cannot be empty or null");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }
            Alpha3 = alpha3;
            Name = name;
        }

        public string Alpha3 { get; }
        public string Name { get; }

        public override string ToString() => Name;
        public override bool Equals(object? obj)
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
