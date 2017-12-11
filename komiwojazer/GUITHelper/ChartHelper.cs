using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace komiwojazer.GUITHelper
{
    public static class ChartHelper
    {
        public static void InitChart(Chart _chart)
        {
            _chart.Series["test1"].ChartType =
                                SeriesChartType.FastLine;
            _chart.Series["test1"].Color = Color.Blue;

            _chart.Series["test2"].ChartType =
                                SeriesChartType.FastPoint;
            _chart.Series["test2"].Color = Color.Red;
        }
    }
}
