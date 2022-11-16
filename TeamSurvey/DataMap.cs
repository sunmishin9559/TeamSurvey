using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSurvey
{
    class DataMap
    {
        private String key;
        private String value;
        private List<String> keys;
        private List<String> values;

        public DataMap()
        {
            key = null;
            value = null;
            keys = new List<String>();
            values = new List<String>();
        }

        public void put(String key, String value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public int size()
        {
            return keys.Count();
        }

        public String getKey(String value)
        {
            int index = values.IndexOf(value);

            return keys.ElementAt(index);
        }

        public String[] getValues()
        {
            return values.ToArray();
        }
    }
}
