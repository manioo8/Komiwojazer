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
        List<double> populationLengths = new List<double>();
        NonRepeatVector citiesManager = new NonRepeatVector();
        PopulationScanner populationScanner = new PopulationScanner();
        List<List<Point>> population;
        int numOfPopulation = 5;
        Algorithm algorithm;
        

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
            algorithm = new Algorithm();
           // algorithm.ManageTSP(points);
           // algorithm.WyliczTabeleOdleglosci();

            listBox1.Items.Add("City (" + 
                points[points.Count - 1].x.ToString() + "; " + 
                points[points.Count - 1].y.ToString() + ")");

            for (int j = 0; j < numOfPopulation; j++)
            {
                algorithm.ManageTSP(population[j]);
                algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < population[j].Count-1; i++)
                {
                    lengths.Add(algorithm.DistanceBetweenCities(i, i + 1));
                }
                populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }
            for (int i = 0; i < numOfPopulation; i++)
            {
                listBox2.Items.Add(populationLengths[i].ToString());
            }
            
            


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
            chart1.Series["Drogi"].Points.Clear();
            chart1.Series["Miasta"].Points.Clear();

            listBox1.Items.Clear();
            population = citiesManager.GetUniqueList(numOfPopulation, points);
            

            DisplayManager.AddPointsToChart(chart1, listBox1, population, numOfPopulation);
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
