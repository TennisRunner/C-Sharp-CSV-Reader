using System;
using System.Collections.Generic;
using System.Linq;

namespace botshell
{
    public class Options
    {
        public Options()
        {
            p = new List<KeyValuePair<string, string>>();
        }

        public int Count
        {
            get
            {
                return p.Count;
            }
        }

        public void Add(string key, string value)
        {
            this.p.Add(new KeyValuePair<string, string>(key, value));
        }

        public List<string> GetKeys()
        {
            return p.Select(x => x.Key).ToList();
        }

        public List<string> GetValues()
        {
            return p.Select(x => x.Value).ToList();
        }

        public string this[string index]
        {
            get
            {
                KeyValuePair<string, string> el = p.Where(x => x.Key == index).FirstOrDefault();

                if (el.Key != null)
                {
                    return el.Value;
                }

                return string.Empty;
            }

            set
            {
                KeyValuePair<string, string> el = p.Where(x => x.Key == index).FirstOrDefault();

                if (el.Key == null)
                {
                    p.Add(new KeyValuePair<string, string>(index, value));
                }
                else
                {
                    p.Insert(p.IndexOf(el), new KeyValuePair<string, string>(el.Key, value));
                    p.Remove(el);
                }
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < p.Count)
                    return p[index].Value;
                else
                    return string.Empty;
            }

            set
            {
                if (index < p.Count)
                {
                    var el = p[index];
                    p.Insert(index, new KeyValuePair<string, string>(el.Key, value));
                    p.Remove(el);
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
        }

        List<KeyValuePair<string, string>> p;
    }
}
