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
        int numOfPopulation = 200;
        int optimalIndex;
        Algorithm algorithm;

       
        

        //funkcja do odpalania ManageLengthsArray jako osobny wątek
        public Thread StartTheThread1(Algorithm _algorithm, List<List<Point>> _population, List<double> lengths, ListBox _listBox, int _numOfPopulation, List<double> _populationLengths, int startIndex,int stopIndex)
        {
            var t = new Thread(() => PopulationScanner.ManageLengthsArray1(
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
        public Thread StartTheThread2(Algorithm _algorithm, List<List<Point>> _population, List<double> lengths, ListBox _listBox, int _numOfPopulation, List<double> _populationLengths, int startIndex, int stopIndex)
        {
            var t = new Thread(() => PopulationScanner.ManageLengthsArray2(
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
        public Thread StartTheThread3(Algorithm _algorithm, List<List<Point>> _population, List<double> lengths, ListBox _listBox, int _numOfPopulation, List<double> _populationLengths, int startIndex, int stopIndex)
        {
            var t = new Thread(() => PopulationScanner.ManageLengthsArray3(
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
            List<double> populationLengths1 = new List<double>();
            List<double> populationLengths2 = new List<double>();
            List<double> populationLengths3 = new List<double>();
            List<double> lengths1 = new List<double>();
            List<double> lengths2 = new List<double>();
            List<double> lengths3 = new List<double>();
            //zaczynamy osobny wątek z funkcją ManageLengthsArray
            PopulationScanner.ManageLengthsArray(
                algorithm,
                population,
                lengths,
                listBox2,
                numOfPopulation,
                populationLengths,
                0,
                numOfPopulation/4-1);
            Thread thread1 = StartTheThread1(
                algorithm,
                population,
                lengths1,
                listBox2,
                numOfPopulation,
                populationLengths1,
                numOfPopulation / 4,
                numOfPopulation*2 / 4-1);
            Thread thread2 = StartTheThread2(
                algorithm,
                population,
                lengths2,
                listBox2,
                numOfPopulation,
                populationLengths2,
                numOfPopulation * 2 / 4 ,
                numOfPopulation*3/4-1);
            Thread thread3 = StartTheThread3(
                algorithm,
                population,
                lengths3,
                listBox2,
                numOfPopulation,
                populationLengths3,
                numOfPopulation*3/4,
                numOfPopulation - 1);
            //czekamy aż się zakończy, żeby dodać wszystkie odległości po kolei do listbox2
            thread1.Join();
            thread2.Join();
            thread3.Join();
            populationLengths.AddRange(populationLengths1);
            populationLengths.AddRange(populationLengths2);
            populationLengths.AddRange(populationLengths3);
            for (int i = 0; i < populationLengths.Count; i++)
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
            button4.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
        }
    }
}
