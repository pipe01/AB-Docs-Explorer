using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AB__Docs_Explorer.Controls
{
    public partial class RichTextLabel : UserControl
    {
        public RichTextLabel()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public event EventHandler ReferenceClick;

        private const int ColorCodeLength = 6;
        private const char ColorCode = '#';

        private bool IsHoverName;

        public override string Text
        {
            get
            {
                return rtbText.Text;
            }
            set
            {
                rtbText.Text = value;
            }
        }

        public void AppendFormatted(string text)
        {
            char[] arr = text.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                char c = text[i];

                if (c == ColorCode) //&& !(i > 0 && arr[i - 1] == '\\'))
                {
                    IEnumerable<char> skip = arr.Skip(i + 1); //Skip to the position after &
                    IEnumerable<char> take = skip.Take(ColorCodeLength); //Take 6 characters
                    string code = new string(take.ToArray()); //Convert that to string

                    var color = FromHex(code); //Get the color from the hexadecimal

                    //Take the text that's between this color code and the next
                    string rest = new string(text.Skip(i + 1 + ColorCodeLength).TakeWhile(a => a != ColorCode).ToArray());

                    //Append it
                    AppendColor(rest, color);

                    //Skip all these characters
                    i += ColorCodeLength + rest.Length;
                }
                else
                {
                    rtbText.Text += c;
                }
            }
        }

        private void AppendColor(string text, Color color)
        {
            rtbText.SelectionStart = rtbText.TextLength;
            rtbText.SelectionLength = 0;

            rtbText.SelectionColor = color;
            rtbText.AppendText(text);
            rtbText.SelectionColor = rtbText.ForeColor;
        }

        private Color FromHex(string hex)
        {
            return ColorTranslator.FromHtml("#" + hex);
        }

        private void rtbText_MouseMove(object sender, MouseEventArgs e)
        {
            int mindex = rtbText.GetCharIndexFromPosition(rtbText.PointToClient(Cursor.Position));
            
            string[] split = rtbText.Text.Split(' ');
            string word = split[0];
            int wordindex = 0;

            if (split[0] == "const")
            {
                wordindex = "const ".Length;
                word = split[1];
            }
            
            if (mindex >= wordindex && mindex < word.Length + wordindex)
            {
                rtbText.Cursor = Cursors.Hand;
                IsHoverName = true;
            }
            else
            {
                rtbText.Cursor = Cursors.Default;
                IsHoverName = false;
            }
        }

        private void rtbText_MouseUp(object sender, MouseEventArgs e)
        {
            HideCaret(rtbText.Handle);

            if (IsHoverName)
            {
                ReferenceClick?.Invoke(this, e);
            }
        }
    }
}
