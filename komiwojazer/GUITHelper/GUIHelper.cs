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
            Form1.ActiveControl = _textBox1;
            _points.Add(new Point(x, y));
            _listBox.Items.Add("City (" + x.ToString() + "; " + y.ToString() + ")");
        }
        public static void CreatekroA100(ListBox _listBox, List<Point> _points)
        {
            {
                int[,] xy = new int[,]{{ 1380 , 939 },
            { 2848 , 96 },
            { 3510 , 1671 },
            { 457 , 334 },
            { 3888 , 666 },
            { 984 , 965 },
            { 2721 , 1482 },
            { 1286 , 525 },
            { 2716 , 1432 },
            { 738 , 1325 },
            { 1251 , 1832 },
            { 2728 , 1698 },
            { 3815 , 169 },
            { 3683 , 1533 },
            { 1247 , 1945 },
            { 123 , 862 },
            { 1234 , 1946 },
            { 252 , 1240 },
            { 611 , 673 },
            { 2576 , 1676 },
            { 928 , 1700 },
            { 53 , 857 },
            { 1807 , 1711 },
            { 274 , 1420 },
            { 2574 , 946 },
            { 178 , 24 },
            { 2678 , 1825 },
            { 1795 , 962 },
            { 3384 , 1498 },
            { 3520 , 1079 },
            { 1256 , 61 },
            { 1424 , 1728 },
            { 3913 , 192 },
            { 3085 , 1528 },
            { 2573 , 1969 },
            { 463 , 1670 },
            { 3875 , 598 },
            { 298 , 1513 },
            { 3479 , 821 },
            { 2542 , 236 },
            { 3955 , 1743 },
            { 1323 , 280 },
            { 3447 , 1830 },
            { 2936 , 337 },
            { 1621 , 1830 },
            { 3373 , 1646 },
            { 1393 , 1368 },
            { 3874 , 1318 },
            { 938 , 955 },
            { 3022 , 474 },
            { 2482 , 1183 },
            { 3854 , 923 },
            { 376 , 825 },
            { 2519 , 135 },
            { 2945 , 1622 },
            { 953 , 268 },
            { 2628 , 1479 },
            { 2097 , 981 },
            { 890 , 1846 },
            { 2139 , 1806 },
            { 2421 , 1007 },
            { 2290 , 1810 },
            { 1115 , 1052 },
            { 2588 , 302 },
            { 327 , 265 },
            { 241 , 341 },
            { 1917 , 687 },
            { 2991 , 792 },
            { 2573 , 599 },
            { 19 , 674 },
            { 3911 , 1673 },
            { 872 , 1559 },
            { 2863 , 558 },
            { 929 , 1766 },
            { 839 , 620 },
            { 3893 , 102 },
            { 2178 , 1619 },
            { 3822 , 899 },
            { 378 , 1048 },
            { 1178 , 100 },
            { 2599 , 901 },
            { 3416 , 143 },
            { 2961 , 1605 },
            { 611 , 1384 },
            { 3113 , 885 },
            { 2597 , 1830 },
            { 2586 , 1286 },
            { 161 , 906 },
            { 1429 , 134 },
            { 742 , 1025 },
            { 1625 , 1651 },
            { 1187 , 706 },
            { 1787 , 1009 },
            { 22 , 987 },
            { 3640 , 43 },
            { 3756 , 882 },
            { 776 , 392 },
            { 1724 , 1642 },
            { 198 , 1810 },
            { 3950 , 1558 }
            };
                for (int i = 0; i < 100; i++)
                {
                    _points.Add(new Point(xy[i, 0], xy[i, 1]));
                    _listBox.Items.Add("City (" + xy[i, 0].ToString() + "; " + xy[i, 1].ToString() + ")");
                }
            }

        }
    }
}
