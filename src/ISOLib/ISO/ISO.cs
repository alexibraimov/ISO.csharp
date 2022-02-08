using ISO3166Lib.Model;
using System.Collections.Generic;
using System.Linq;

namespace ISO3166Lib.ISO
{
    //TODO: Add methods description
    public abstract class ISO <T> where T: ISOModel
    {
        protected IList<T> _models;
        public ISO()
        {
        }
        public abstract int Number { get; }
        public abstract string Name {get;}
        public T this[string key]
        {
            get => Get(key);
        }
        public T Get(string key)
        {
            if (_models == null)
            {
                return default;
            }
            return _models.FirstOrDefault(m => m.Alpha2 == key || m.Alpha3 == key || m.Name == key);
        }
        public bool TryGet(string key, out T model)
        {
            model = Get(key);
            return model != null;
        }
        public T[] GetArray()
        {
            return _models?.ToArray();
        }
    }
}
