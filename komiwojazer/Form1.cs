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


namespace komiwojazer
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        Step step = new Step();
        NonRepeatVector citiesManager = new NonRepeatVector();
        List<List<Point>> population;
        int numOfPopulation = 4;

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

        private void button2_Click(object sender, EventArgs e)
        {
            points.Add(points[0]);
            //listBox1.Items.Add("City (" + points[points.Count - 1].x.ToString() + "; " + points[points.Count - 1].y.ToString() + ")");
            for (int i = 0; i < points.Count - 1; ++i)
            {
                chart1.Series["test1"].Points.AddXY
                                (points[i].x, points[i].y);
                chart1.Series["test2"].Points.AddXY
                                (points[i].x, points[i].y);
            }
            
            chart1.Series["test1"].ChartType =
                                SeriesChartType.FastLine;
            chart1.Series["test1"].Color = Color.Blue;

            chart1.Series["test2"].ChartType =
                                SeriesChartType.FastPoint;
            chart1.Series["test2"].Color = Color.Red;
            points.RemoveAt(points.Count-1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (points.Count >= 1)
            {
                points.RemoveAt(points.Count - 1);
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                chart1.Series["test1"].Points.RemoveAt(points.Count - 1);
                chart1.Series["test2"].Points.RemoveAt(points.Count - 1);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//Mieszaj
        {
            chart1.Series["test1"].Points.Clear();
            chart1.Series["test2"].Points.Clear();

            listBox1.Items.Clear();
            

            for (int i = 0; i <= numOfPopulation; ++i)//per ilosc populacji
            {
                chart1.Series["test1"].Points.Clear();
                chart1.Series["test2"].Points.Clear();
                population = citiesManager.GetUniqueList(points);
                for (int j = 0; j <= population[i].Count - 1; ++j)//za kazde miasto
                {
                    listBox1.Items.Add("City (" + population[i][j].x.ToString() + "; " + population[i][j].y.ToString() + ")");
                    chart1.Series["test1"].Points.AddXY
                    (population[i][j].x, population[i][j].y);
                    chart1.Series["test2"].Points.AddXY
                    (population[i][j].x, population[i][j].y);
                }

            }

            for(int i = 0; i <= numOfPopulation; ++i)
            {
                double totalDist = 0;
                for (int j = 0; j < population[i].Count - 1; ++j)
                {
                    totalDist += step.GetLength(population[i][j], population[i][j + 1]);
                }
                totalDist += step.GetLength(population[i][population[i].Count-1], population[i][0]);       
                listBox2.Items.Add(totalDist.ToString()+' '+i);
            }
            


        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
