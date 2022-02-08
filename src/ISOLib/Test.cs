
using ISO3166Lib.ISO;

namespace ISO3166Lib
{
    public class Test
    {
        public Test()
        {
            var iso = new ISO3166();

            var countries = iso.GetArray();
        }
    }
}
