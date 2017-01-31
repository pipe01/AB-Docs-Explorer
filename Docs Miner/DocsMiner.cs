using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ABPDocsMiner
{
    public class DocMiner
    {
        public string LuaDocsPath;
        
        public List<DocParent> MineDocumentation()
        {
            var files = Directory.EnumerateFiles(LuaDocsPath, "*.html");
            List<DocParent> ret = new List<DocParent>();

            string[] validstarts =
            {
                "class_",
                "group_",
                "namespace_"
            };

            foreach (var item in files)
            {
                if (Path.GetFileName(item).StartsWithAny(validstarts))
                {
                    DocParent p = null;
                    /*try
                    {*/
                        p = MineFile(item);
                    /*}
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }*/

                    if (p != null)
                    {
                        ret.Add(p);
                    }
                }
            }

            ret.Sort((a, b) => a.Name.CompareTo(b.Name));

            foreach (var item in ret)
            {
                item.Children.Sort((a, b) => a.Name.CompareTo(b.Name));
            }

            return ret;
        }

        public DocParent MineFile(string path)
        {
            DocParent ret = new DocParent();

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.DetectEncodingAndLoad(path);

            if ((htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0) || htmlDoc.DocumentNode == null)
            {
                throw new Exception();
            }

            HtmlNode headernode = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[3]/div[2]/div[1]");

            if (headernode == null)
            {
                return null;
            }

            string[] docheader = headernode.InnerHtml.Split(' ');
            ret.Name = docheader[0].Trim();

            string xpath = "/html[1]/body[1]/div[3]/div[4]";

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(xpath);

            var ns = nodes[0].ChildNodes.Where(o => o.Attributes["class"].Value == "memberdecls");

            foreach (var item in nodes[0].ChildNodes) 
            {
                if (item.HasAttributes && item.Name == "table")
                {
                    foreach (var tr in item.ChildNodes)
                    {
                        if (tr.Name == "tr" && tr.Attributes["class"].Value.StartsWith("memitem"))
                        {
                            DocMember mem = new DocMember(ret.ID);

                            var left = tr.ChildNodes[0];
                            var right = tr.ChildNodes[1];

                            string def = "";

                            foreach (var sideitem in left.ChildNodes)
                            {
                                string txt = HttpUtility.HtmlDecode(sideitem.InnerText).Trim();
                                if (txt == "const")
                                {
                                    mem.ReturnConst = true;
                                }
                                else if (txt == "&")
                                {
                                    mem.ReturnPointer = true;
                                }
                                else
                                {
                                    string[] spl = txt.Split(' ');
                                    foreach (var splitem in spl)
                                    {
                                        if (splitem == "const")
                                            mem.ReturnConst = true;
                                        else if (splitem == "&")
                                            mem.ReturnPointer = true;
                                        else
                                            mem.ReturnType = splitem.Trim();
                                    }
                                }
                            }
                            foreach (var sideitem in right.ChildNodes)
                            {
                                var txt = HttpUtility.HtmlDecode(sideitem.InnerText).Trim();
                                if (!txt.EndsWith(" "))
                                {
                                    txt += " ";
                                }
                                def += txt;
                            }

                            def = def.Trim();

                            if (!def.Contains("("))
                            {
                                mem.Name = def.Trim();
                                mem.Kind = DocItem.MemberKind.Attribute;
                            }
                            else
                            {
                                int spaceindex = def.IndexOf('(');
                                string name = def.Substring(0, spaceindex);
                                mem.Name = name.Trim();
                                
                                string paramstr = def.Substring(spaceindex);
                                if (paramstr.Length > 2)
                                {
                                    paramstr = paramstr.Substring(1, paramstr.Length - 2);

                                    string[] spl = paramstr.Split(',');
                                    List<MethodParameter> pars = new List<MethodParameter>();

                                    foreach (var par in spl)
                                    {
                                        pars.Add(MethodParameter.GetFromString(par, mem));
                                    }

                                    mem.Parameters = pars.ToArray();
                                }

                                mem.Kind = DocItem.MemberKind.Method;
                            }

                            if (mem.ReturnType == "class")
                            {
                                mem.Kind = DocItem.MemberKind.Class;
                            }
                            
                            //mem.GenerateID();

                            ret.Children.Add(mem);
                        }
                    }
                }
            }

            ret.GenerateID();
            ret.SetParents();
            return ret;
        }
    }

    public abstract class DocItem
    {
        public enum MemberKind
        {
            Method,
            Attribute,
            Parameter,
            Class
        }

        public abstract MemberKind GetKind();
        public abstract string GetName();

        public abstract string ID
        {
            get; set;
        }

    }

    public class DocMember : DocItem
    {
        public string ReturnType;
        public string Name;
        public MethodParameter[] Parameters = new MethodParameter[0];
        public bool ReturnConst, ReturnPointer;
        public MemberKind Kind;

        public override string GetName()
        {
            return this.Name;
        }

        public override MemberKind GetKind()
        {
            return this.Kind;
        }

        public override string ID
        {
            get; set;
        }

        public string ParentID;

        [NonSerialized]
        public DocParent Parent;

        public DocMember(string parentid, MemberKind kind = MemberKind.Method)
        {
            this.ParentID = parentid;
            this.Kind = kind;
        }
        
        public void GenerateID()
        {
            this.ID = Utils.SHA256(this.FullReturn + this.Name +
                (this.Parameters != null ? this.Parameters.Length.ToString() : "") + this.Kind + this.ParentID);
        }

        public string FullReturn
        {
            get
            {
                return (ReturnConst ? "const " : "") + ReturnType + (ReturnPointer ? " &" : "");
            }
        }
    }

    public class MethodParameter : DocItem
    {
        public string Type;
        public string Name;

        public override string GetName()
        {
            return this.Name;
        }

        public override MemberKind GetKind()
        {
            return MemberKind.Parameter;
        }

        public override string ID
        {
            get; set;
        }

        public string ParentID;

        [NonSerialized]
        public DocMember Method;

        public MethodParameter(string n, string t, string parentid)
        {
            this.Type = t;
            this.Name = n;
            this.ParentID = parentid;
        }

        public void GenerateID()
        {
            this.ID = Utils.SHA256(this.Type + this.Name + this.ParentID);
        }

        public static MethodParameter GetFromString(string str, DocMember method)
        {
            MethodParameter ret;
            string inp = str.Trim();

            int namepos = inp.LastIndexOf(' ');

            if (namepos < 0)
            {
                ret = new MethodParameter("", inp, method.ID);
            }
            else
            {
                string parname = inp.Substring(namepos + 1).Trim();
                string type = inp.Substring(0, namepos).Trim();

                ret = new MethodParameter(parname, type, method.ID);
            }

            //ret.GenerateID();
            return ret;
        }
    }

    public class DocParent : DocItem
    {
        public string Name;
        public List<DocMember> Children = new List<DocMember>();

        public override string GetName()
        {
            return this.Name;
        }

        public override MemberKind GetKind()
        {
            return MemberKind.Class;
        }

        public override string ID
        {
            get; set;
        }

        public DocParent()
        {
            //this.UUID = Guid.NewGuid();
        }

        public void GenerateID()
        {
            this.ID = Utils.SHA256(this.Name + Children.Count);
        }
        
        public void SetParents()
        {
            foreach (var mem in Children)
            {
                mem.Parent = this;
                mem.ParentID = this.ID;
                mem.GenerateID();
                foreach (var param in mem.Parameters)
                {
                    param.Method = mem;
                    param.ParentID = mem.ID;
                    param.GenerateID();
                }
            }
        }

        //public override DocItem GetParent() { return null; }
    }
}
