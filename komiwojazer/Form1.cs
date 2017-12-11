using komiwojazer.AlgorithmManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using komiwojazer.GUITHelper;

namespace komiwojazer
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        List<double> lengths = new List<double>();
        Step step = new Step();
        NonRepeatVector citiesManager = new NonRepeatVector();
        List<List<Point>> population;
        int numOfPopulation = 5;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            this.ActiveControl = textBox1;
            points.Add(new Point(x, y));
            listBox1.Items.Add("City (" + x.ToString() + "; " + y.ToString() + ")");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//Licz odległość
        {
            points.Add(points[0]);
            listBox1.Items.Add("City (" + points[points.Count - 1].x.ToString() + "; " + points[points.Count - 1].y.ToString() + ")");
            for (int i = 0; i < points.Count - 1; ++i)
            {
                lengths.Add(step.GetLength(points[i], points[i + 1]));
                listBox2.Items.Add(lengths[i].ToString());
                chart1.Series["test1"].Points.AddXY
                                (points[i].x, points[i].y);
                chart1.Series["test2"].Points.AddXY
                                (points[i].x, points[i].y);
            }

            ChartHelper.InitChart(chart1);
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayManager.DeleteLastPoint(chart1, listBox1, points);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//Mieszaj
        {
            chart1.Series["test1"].Points.Clear();
            chart1.Series["test2"].Points.Clear();

            listBox1.Items.Clear();
            population = citiesManager.GetUniqueList(numOfPopulation, points);

            DisplayManager.AddPointsToChart(chart1, listBox1, population, numOfPopulation);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
