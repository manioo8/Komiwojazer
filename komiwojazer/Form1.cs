using komiwojazer.AlgorithmManager;
using System;
using System.Threading;
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
        List<Point> points = new List<Point>();       //lista punktow x i y miast
        List<double> lengths = new List<double>();
        List<double> populationLengths = new List<double>();
        NonRepeatVector citiesManager = new NonRepeatVector();
        PopulationScanner populationScanner = new PopulationScanner();
        List<List<Point>> population;
        int numOfPopulation = 20;
        int optimalIndex;
        Algorithm algorithm;
        

        //funkcja do odpalania ManageLengthsArray jako osobny wątek
        public Thread StartTheThread(Algorithm _algorithm, List<List<Point>> _population, List<double> lengths, ListBox _listBox, int _numOfPopulation, List<double> _populationLengths, int startIndex,int stopIndex)
        {
            var t = new Thread(() => PopulationScanner.ManageLengthsArray(
                algorithm,
                population,
                lengths,
                listBox2,
                numOfPopulation,
                populationLengths,
                startIndex,
                stopIndex));
            t.Start();
            return t;
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//dodaj miasto
        {
            GUIHelper.AddElementtoBase(
                Convert.ToDouble(textBox1.Text),
                Convert.ToDouble(textBox2.Text),
                textBox1,
                textBox2,
                listBox1, 
                this,
                points);
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

            listBox2.Items.Clear();
            //listBox1.Items.Add("City (" + 
            //   points[points.Count - 1].x.ToString() + "; " + 
            //    points[points.Count - 1].y.ToString() + ")");

            NonRepeatVector.RemoveDuplicates(population);
            
            numOfPopulation = population.Count;//populacja się zmniejszyła

            //zaczynamy osobny wątek z funkcją ManageLengthsArray
            Thread thread1 = StartTheThread(
                algorithm,
                population,
                lengths,
                listBox2,
                numOfPopulation,
                populationLengths,
                0,
                numOfPopulation);

            //czekamy aż się zakończy, żeby dodać wszystkie odległości po kolei do listbox2
            thread1.Join();

            for (int i = 0; i < numOfPopulation; i++)
            {
                listBox2.Items.Add(populationLengths[i].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayManager.DeleteLastPoint(listBox1, points);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//Mieszaj
        {
            chart1.Series["Drogi"].Points.Clear();
            chart1.Series["Miasta"].Points.Clear();

            listBox2.Items.Clear();
            population = citiesManager.GetUniqueList(numOfPopulation, points);
            

            DisplayManager.AddPointsToChart(chart1, listBox1, population, numOfPopulation);
            button3.Enabled = false;
            button1.Enabled = false;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            chart1.Series["Drogi"].Points.Clear();
            chart1.Series["Miasta"].Points.Clear();
            optimalIndex = PopulationScanner.GetInedXOfOptimalElement(populationLengths);

            for (int j = 0; j <= population[0].Count - 1; ++j)
            {
                chart1.Series["Drogi"].Points.AddXY
                (population[optimalIndex][j].x, population[optimalIndex][j].y);
                chart1.Series["Miasta"].Points.AddXY
                (population[optimalIndex][j].x, population[optimalIndex][j].y);
                
                listBox1.Items.Add("City (" + population[optimalIndex][j].x.ToString() + "; " + population[optimalIndex][j].y.ToString() + ")");
            }
            listBox2.Items.Add(populationLengths[optimalIndex].ToString());
        }
    }
}
