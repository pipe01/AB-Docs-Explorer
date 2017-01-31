using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheme = System.Collections.Generic.Dictionary<string, System.Drawing.Color>;

namespace AB__Docs_Explorer
{
    class Config
    {
        public string InstallPath;
        public string ColorScheme = "Default";


        public readonly static Dictionary<string, Scheme> Schemes = new Dictionary<string, Scheme>
        {
            { "Default", new Scheme {
                { "NativeType", Color.Blue },
                { "Type", Color.Teal },
                { "MemberName", Color.Salmon },
                { "InvalidMemberName", Color.Red },
                { "WindowBackColor", Color.Transparent },
                { "TextColor", Color.Transparent },
                { "BaseColor", Color.Transparent },
                { "PathBack", Color.Transparent },
            } },
            { "Dark", new Scheme {
                { "WindowBackColor", Color.FromArgb(64, 64, 90) },
                { "TextColor", Color.Silver },
                { "BaseColor", Color.FromArgb(75, 70, 64) },
            } }
        };

        public static Config Inst;

        public static void Load()
        {
            if (!File.Exists("config.json"))
            {
                Inst = new Config();
                Save();
            }

            Inst = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
        }

        public static void Save()
        {
            File.WriteAllText("config.json", JsonConvert.SerializeObject(Inst));
        }
    }
}
