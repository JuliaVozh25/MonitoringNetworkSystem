using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class IPTextBox : TextBox
    {
        string RightText;
        protected bool IsValidating(string str)
        {
            Regex rgxIp = new Regex(@"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?(\.|$)){4}");
            return rgxIp.IsMatch(str);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Text != "")
            {
                if (!IsValidating(Text))
                {
                    BackColor = Color.Salmon;
                }
                else
                {
                    BackColor = Color.White;
                    RightText = Text;
                }
            }
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            if (BackColor == Color.Salmon)
                Text = RightText;
        }
    }
}
