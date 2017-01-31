using AB__Docs_Explorer.Controls;
using ABPDocsMiner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AB__Docs_Explorer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //LoadColorScheme();
        }

        private Documentation Docs;
        private Comments Comms;
        private TimeoutTimer timerComment, timerSearch;

        private readonly Dictionary<string, Color> ColorScheme = new Dictionary<string, Color>()
        {
            { "NativeType", Color.Blue },
            { "Type", Color.Teal },
            { "MemberName", Color.Salmon },
            { "InvalidMemberName", Color.Red },
            { "WindowBackColor", Color.FromArgb(64, 64, 90) },
            { "TextColor", Color.Silver },
            { "BaseColor", Color.FromArgb(75, 70, 64) },
            { "PathBack", Color.Transparent },
            //{ "ButtonText", Color.Black },
        };

        private readonly string[] LuaNativeTypes =
        {
            "nil",
            "boolean",
            "number",
            "string",
            "userdata",
            "function",
            "thread",
            "table",
            "integer", "float" //Not native, but used in the AB+ docs
        };
        
        
        #region Forms
        private void Form1_Load(object sender, EventArgs e)
        {
            Config.Load();

            Docs = Documentation.LoadFromFile();
            Comms = Comments.LoadFromFile();
            LoadClasses();

            txtPath.Text = Config.Inst.InstallPath;

            lblRetType.ReferenceClick += LblRetType_ReferenceClick;
            lblVarType.ReferenceClick += LblRetType_ReferenceClick;

            splitContainer1.Panel2Collapsed = true;

            timerComment = new TimeoutTimer(this);
            timerComment.Timeout += TTimer_Timeout;
            timerComment.MaximumMS = 500;

            timerSearch = new TimeoutTimer(this);
            timerSearch.Timeout += TimerSearch_Timeout;
            timerSearch.MaximumMS = 500;
        }

        private void TimerSearch_Timeout(object sender, EventArgs e)
        {
            string query = txtSearch.Text;
            DocItem ret = Docs.SearchComplex(query);
            
            if (ret == null)
            {
                txtSearch.ForeColor = Color.Red;
            }
            else
            {
                txtSearch.ForeColor = Color.Black;

                switch (ret.GetKind())
                {
                    case DocItem.MemberKind.Method:
                    case DocItem.MemberKind.Attribute:
                        DocMember mem = (DocMember)ret;
                        SelectClass(mem.Parent);
                        SelectMember(mem);
                        lvMembers.Focus();
                        break;
                    case DocItem.MemberKind.Parameter:
                        break;
                    case DocItem.MemberKind.Class:
                        SelectClass(ret.GetName());
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LblRetType_ReferenceClick(object sender, EventArgs e)
        {
            var label = (RichTextLabel)sender;

            string target = "";

            //Get the namespace from the current selected item
            string namesp = lbClasses.Items[lbClasses.SelectedIndex]
                .ToString()
                .Split(new[] { "::" }, StringSplitOptions.None)[0];

            //Get the parts of the return type
            string[] fullreturn = label.Text.Split(' ');

            string typename;

            //If it starts with "const"
            if (fullreturn[0] == "const")
            {
                //The name of the type is the second item
                typename = fullreturn[1];
            }
            else
            {
                //If not, it's the first
                typename = fullreturn[0];
            }

            //If the name of the type itself contains a namespace
            if (typename.Contains("::"))
            {
                //Get that namespace and use that
                string[] spl = typename.Split(new[] { "::" }, StringSplitOptions.None);
                typename = spl[1];
                namesp = spl[0];
            }

            //Join the namespace and the type name to get a full type
            target = namesp + "::" + typename;

            //If the full type name isn't found
            if (SelectClass(target) == -1)
            {
                //Try searching for the type name alone
                SelectClass(typename);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text) && Directory.EnumerateFiles(txtPath.Text, "isaac-ng.exe").Any())
            {
                Config.Inst.InstallPath = txtPath.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartMine(false);
        }

        private void workerMine_DoWork(object sender, DoWorkEventArgs e)
        {
            DocMiner g = new DocMiner();
            g.LuaDocsPath = Path.Combine(Config.Inst.InstallPath, "tools/LuaDocs/");

            var ret = g.MineDocumentation().ToList();
            
            Docs = new Documentation();
            foreach (var item in ret)
            {
                Docs.Add(item);
            }

            Docs.SaveToFile();
        }

        private void workerMine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadClasses();
            pbProgress.Style = ProgressBarStyle.Blocks;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvMembers.Items.Clear();

            lblFuncRet_SelectedIndexChanged(sender, e);

            foreach (var item in Docs[lbClasses.SelectedIndex].Children)
            {
                ListViewItem itm = new ListViewItem();
                
                //The enum values match with the image indexes, so we can do this
                itm.ImageIndex = (int)item.Kind;

                Color typecolor = GetTypeColor(item.ReturnType);
                
                itm.AddSubItemWithName("return", item.FullReturn, typecolor);
                itm.AddSubItemWithName("name", item.Name, ColorScheme["MemberName"]);

                if (item.Parameters.Length > 0)
                {
                    string str = "";
                    for (int i = 0; i < item.Parameters.Length; i++)
                    {
                        str += item.Parameters[i].Type + " " + item.Parameters[i].Name;
                        if (i != item.Parameters.Length - 1)
                            str += ", ";
                    }
                    itm.AddSubItemWithName("parameters", str);
                }

                itm.Tag = item;

                lvMembers.Items.Add(itm);
            }
        }

        private void lvMembers_DoubleClick(object sender, EventArgs e)
        {
            if (lvMembers.SelectedItems.Count == 1)
            {
                var itm = lvMembers.SelectedItems[0];
                switch (itm.SubItems["return"].Text)
                {
                    case "class":
                        string cname = itm.SubItems["name"].Text;
                        SelectClass(Docs[lbClasses.SelectedIndex].Name + "::" + cname);
                        break;
                }
            }
        }

        private void lblFuncRet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = GetSelectedMember();

            bool sel = item != null;

            splitContainer1.Panel2Collapsed = !sel;

            if (sel)
            {
                UpdateMemberInfo(item);
            }
        }

        private void lvParameters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int col = lvParameters.GetColumnIndexFromPoint(e.Location);

            if (col == 2) //Comment column
            {
                lvParameters.StartEditing(txtEditParamComm, lvParameters.SelectedItems[0], 2);
            }
        }

        private void TTimer_Timeout(object sender, EventArgs e)
        {
            Console.WriteLine(new Random().Next());

            var item = GetSelectedMember();

            Comms[item.ID] = txtComments.Text;

            Task.Run(() =>
            {
                if (Comms[item.ID] == "")
                {
                    Comms.Remove(item.ID);
                }
                Comms.SaveToFile();
            });
        }

        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            timerComment.Start();
            timerComment.Reset();
        }

        private void lvParameters_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            var itm = GetSelectedMember();

            if (!e.Cancel)
            {
                Comms[itm.Parameters[lvParameters.SelectedIndices[0]].ID] = e.DisplayText;
                Comms.SaveToFile();
            }
        }
        #endregion

        #region Logic
        private void StartMine(bool background)
        {
            if (!background)
            {
                pbProgress.Style = ProgressBarStyle.Marquee;
                lbClasses.Items.Clear();
            }
            workerMine.RunWorkerAsync();
        }

        private void LoadClasses()
        {
            foreach (var item in Docs)
            {
                lbClasses.Items.Add(item.Name);
            }
        }

        private int SelectClass(string name, bool sel = true)
        {
            for (int i = 0; i < lbClasses.Items.Count; i++)
            {
                if (lbClasses.Items[i].ToString() == name)
                {
                    if (sel)
                        lbClasses.SelectedIndex = i;

                    return i;
                }
            }
            return -1;
        }
        private int SelectClass(DocParent cl, bool sel = true)
        {
            return SelectClass(cl.Name, sel);
        }

        private int SelectMember(string name, bool sel = true)
        {
            var children = Docs[lbClasses.SelectedIndex].Children;
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Name == name)
                {
                    if (sel)
                    {
                        lvMembers.SelectedIndices.Clear();
                        lvMembers.SelectedIndices.Add(i);
                    }
                    return i;
                }
            }
            return -1;
        }
        private int SelectMember(DocMember mem, bool sel = true)
        {
            return SelectMember(mem.Name, sel);
        }

        public delegate DocMember GetSelectedMemberDelegate();
        private DocMember GetSelectedMember()
        {
            if (lvMembers.InvokeRequired)
            {
                return (DocMember)lvMembers.Invoke((GetSelectedMemberDelegate)GetSelectedMember);
            }

            bool sel = lvMembers.SelectedItems.Count == 1;
            if (sel)
            {
                var lvitem = lvMembers.SelectedItems[0];
                var item = (DocMember)lvitem.Tag;
                return item;
            }
            return null;
        }

        private void UpdateMemberInfo(DocMember item)
        {
            lblMemName.Text = item.Name;
            lblMemName.ForeColor = ColorScheme["MemberName"];

            switch (item.Kind)
            {
                case DocMember.MemberKind.Method:
                    gbVariable.Visible = false;
                    gbFunction.Visible = true;

                    lblRetType.Text = "";
                    lblRetType.AppendFormatted(BeautifyReturnType(item));

                    
                    lvParameters.Items.Clear();

                    if (item.Parameters.Length > 0)
                    {
                        foreach (var param in item.Parameters)
                        {
                            ListViewItem itm = new ListViewItem(param.Type);
                            itm.SubItems[0].ForeColor = GetTypeColor(param.Type);

                            bool noname = param.Name == "";

                            itm.AddSubItemWithName("name",
                                noname ? "?" : param.Name,
                                ColorScheme[noname ? "InvalidMemberName" : "MemberName"]);

                            bool hascomment = Comms.ContainsKey(param.ID);

                            var commitem = itm.SubItems.Add(hascomment ? Comms[param.ID] : "Double click to edit");
                            if (!hascomment)
                            {
                                commitem.ForeColor = Color.LightGray;
                            }

                            lvParameters.Items.Add(itm);
                        }
                        lvParameters.Show();
                        lblParameters.Show();
                    }
                    else
                    {
                        lvParameters.Hide();
                        lblParameters.Hide();
                    }


                    break;
                case DocMember.MemberKind.Attribute:
                    gbVariable.Visible = true;
                    gbFunction.Visible = false;

                    lblVarType.Text = "";
                    lblVarType.AppendFormatted(BeautifyReturnType(item));

                    break;
                case DocMember.MemberKind.Class:
                default:
                    break;
            }

            txtComments.Clear();

            if (Comms.ContainsKey(item.ID))
            {
                txtComments.Text = Comms[item.ID];
            }
        }

        private Color GetTypeColor(string type)
        {
            return ColorScheme[LuaNativeTypes.Contains(type) ? "NativeType" : "Type"];
        }

        private string BeautifyReturnType(DocMember item)
        {
            string ret = "";
            if (item.ReturnConst)
            {
                ret += "#0033ccconst ";
            }
            ret += GetTypeColor(item.ReturnType).ToHex() + (item.ReturnType == "" ? "none" : item.ReturnType);
            if (item.ReturnPointer)
            {
                ret += "#0033cc &";
            }
            return ret;
        }

        public void LoadColorScheme(Control ctrl = null)
        {
            Control c = ctrl ?? this;
            string ctype = c.GetType().Name;

            if (ColorScheme.ContainsKey(ctype + "Text"))
            {
                Color clr = ColorScheme[ctype + "Text"];
                if (clr != Color.Transparent)
                    c.ForeColor = ColorScheme[ctype + "Text"];
            }
            else
            {
                if (ColorScheme.ContainsKey(c.Tag + "Text"))
                {
                    Color clr = ColorScheme[c.Tag + "Text"];
                    if (clr != Color.Transparent)
                        c.ForeColor = ColorScheme[c.Tag + "Text"];
                }
                else
                {
                    c.ForeColor = ColorScheme["TextColor"];
                }
            }

            if (ColorScheme.ContainsKey(ctype + "Back"))
            {
                Color clr = ColorScheme[ctype + "Back"];
                if (clr != Color.Transparent)
                    c.BackColor = ColorScheme[ctype + "Back"];
            }
            else
            {
                if (ColorScheme.ContainsKey(c.Tag + "Back"))
                {
                    Color clr = ColorScheme[c.Tag + "Back"];
                    if (clr != Color.Transparent)
                        c.BackColor = ColorScheme[c.Tag + "Back"];
                }
                else
                {
                    c.BackColor = ColorScheme["BaseColor"];
                }
            }

            if (c == this)
                c.BackColor = ColorScheme["WindowBackColor"];

            foreach (Control item in c.Controls)
            { 
                LoadColorScheme(item);
            }
        }
        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            timerSearch.Start();
            timerSearch.Reset();
        }
    }
}
