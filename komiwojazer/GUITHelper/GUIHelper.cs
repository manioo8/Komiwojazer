using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace komiwojazer.GUITHelper
{
    public static class GUIHelper
    {
        public static void AddElementtoBase(
            double x,
            double y,
            TextBox _textBox1,
            TextBox _textBox2,
            ListBox _listBox,
            ContainerControl Form1,
            List<Point> _points)
        {            
            _textBox1.Text = String.Empty;
            _textBox2.Text = String.Empty;
            Form1.ActiveControl = _listBox;
            _points.Add(new Point(x, y));
            _listBox.Items.Add("City (" + x.ToString() + "; " + y.ToString() + ")");
        }
    }
}
