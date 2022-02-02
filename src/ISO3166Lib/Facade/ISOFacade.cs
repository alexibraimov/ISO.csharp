using ISO3166Lib.ISO;
using ISO3166Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISO3166Lib.Facade
{
    public sealed class ISOFacade<T> where T : class, IISOModel
    {
        private IISO<T> _iso;
        private IList<T> _models
        {
            get
            {
                if (_iso.Number == 639)
                {
                    return (IList<T>)ISO639.Languages;
                }
                if (_iso.Number == 3166)
                {
                    return (IList<T>)ISO3166.Countries;
                }
                return null;
            }
        }
        public ISOFacade(IISO<T> iso)
        {
            if (iso == null)
            {
                throw new ArgumentNullException("ISO is not null and not empty");
            }
            if (iso.Number != 639 && iso.Number != 3166)
            {
                throw new ArgumentException("ISO is not found");
            }
            _iso = iso;
        }

        public int Number => _iso == null ? -1 : Number;
        public string Name => _iso == null ? null : _iso.Name;
        public T this[string key]
        {
            get => Get(key);
        }
        public T Get(string key)
        {
            if (_models == null)
            {
                return null;
            }
            return _models.FirstOrDefault(m => m.Alpha2 == key || m.Alpha3 == key || m.Name == key);
        }
        public bool TryGet(string key, out IISOModel model)
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
