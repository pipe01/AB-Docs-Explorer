using ABPDocsMiner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB__Docs_Explorer
{
    class Documentation : List<DocParent>
    {
        public void SaveToFile()
        {
            File.WriteAllText("doccache.json", JsonConvert.SerializeObject(this));
        }

        public static Documentation LoadFromFile()
        {
            if (!File.Exists("doccache.json"))
            {
                new Documentation().SaveToFile();
            }

            var ret = JsonConvert.DeserializeObject<Documentation>(File.ReadAllText("doccache.json"));
            return ret;
        }

        public DocItem Search(string name, int depth = 1, bool ignorecase = true, bool strict = false)
        {
            DocItem ret = null;

            foreach (var item in this)
            {
                if (item.Name.CompareComplex(name))
                {
                    ret = item;
                    break;
                }
                else if (depth >= 1)
                {
                    foreach (var sub in item.Children)
                    {
                        if (sub.Name.CompareComplex(name))
                        {
                            ret = sub;
                            break;
                        }
                        /*else if (depth >= 2 && sub.Parameters.Length > 0)
                        {
                            foreach (var param in sub.Parameters)
                            {
                                if (param.Name.CompareComplex(name))
                                {
                                    ret = param;
                                    break;
                                }
                            }
                        }*/
                    }
                }
            }

            return ret;
        }

        public DocItem SearchComplex(string name)
        {
            /*DocItem ret = null;
            int depth = 0;
            
            while (depth++ < 3 && ret == null)
            {
                ret = Search(name, depth, true);
            }

            return ret;*/
            return Search(name, 2);
        }
    }

    class Comments : Dictionary<string, string>
    {
        public void SaveToFile()
        {
            try
            {
                File.WriteAllText("comments.json", JsonConvert.SerializeObject(this));

            }
            catch (IOException)
            {
                
            }
        }

        public static Comments LoadFromFile()
        {
            if (!File.Exists("comments.json"))
            {
                File.WriteAllText("comments.json", JsonConvert.SerializeObject(new Comments()));
            }

            var ret = JsonConvert.DeserializeObject<Comments>(File.ReadAllText("comments.json"));
            return ret;
        }

        public new string this[string key]
        {
            get
            {
                return base[key];
            }
            set
            {
                if (!base.ContainsKey(key))
                {
                    base.Add(key, value);
                }
                else
                {
                    if (value == "")
                    {
                        base.Remove(key);
                    }
                    else
                    {
                        base[key] = value;
                    }
                }
            }
        }
    }
}
