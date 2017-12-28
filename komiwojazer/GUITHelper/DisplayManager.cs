using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace komiwojazer.GUITHelper
{
    public static class DisplayManager
    {
        //Adds points from List of points to the series and display the series in the listbox.
        public static void AddPointsToChart(Chart _form, ListBox _listBox, List<List<Point>> _population, int _numOfPopultaion)
        {
            for (int i = 0; i <= _numOfPopultaion; ++i)
            {
                for (int j = 0; j <= _population[i].Count - 1; ++j)
                {
                    _listBox.Items.Add("City (" + _population[i][j].x.ToString() + "; " + _population[i][j].y.ToString() + ")");
                    _form.Series["Drogi"].Points.AddXY
                    (_population[i][j].x, _population[i][j].y);
                    _form.Series["Miasta"].Points.AddXY
                                    (_population[i][j].x, _population[i][j].y);
                }

            }
        }
        public static void DeleteLastPoint(Chart _form, ListBox _listBox, List<Point> _points) //deletes last point from the Chart, Listbox and List of points
        {
            if (_points.Count >= 1)
            {
                _points.RemoveAt(_points.Count - 1);
                _listBox.Items.RemoveAt(_listBox.Items.Count - 1);
                _form.Series["Drogi"].Points.RemoveAt(_points.Count - 1);
                _form.Series["Miasta"].Points.RemoveAt(_points.Count - 1);
            }
        }

    }
}
