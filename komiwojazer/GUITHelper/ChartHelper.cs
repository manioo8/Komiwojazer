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
            _chart.Series["Drogi"].ChartType =
                                SeriesChartType.FastLine;
            _chart.Series["Drogi"].Color = Color.Blue;

            _chart.Series["Miasta"].ChartType =
                                SeriesChartType.FastPoint;
            _chart.Series["Miasta"].Color = Color.Red;
        }
    }
}
