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
        Random random = new Random();


        //funkcja do odpalania ManageLengthsArray jako osobny wątek
        public Thread StartTheThread1(Algorithm _algorithm, List<List<Point>> _population, List<double> lengths, ListBox _listBox, int _numOfPopulation, List<double> _populationLengths, int startIndex,int stopIndex)
        {
            var t = new Thread(() => PopulationScanner.ManageLengthsArray1(
                algorithm,
                population,
                lengths,
                listBox2,
                numOfPopulation,
                _populationLengths,
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
                _populationLengths,
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
                _populationLengths,
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
            //GUIHelper.AddElementtoBase( Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), textBox1, textBox2, listBox1, this, points);
            GUIHelper.CreatekroA100(listBox1, points);
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
            chart1.Series["Drogi"].Points.Clear();
            chart1.Series["Miasta"].Points.Clear();

            listBox2.Items.Clear();

            //tu populacja to 1 droga
            population = citiesManager.GetUniqueList(numOfPopulation, points);
            //teraz populacja to numOfPopulation różnych dróg

            //points.Add(points[0]);
            algorithm = new Algorithm();

            listBox2.Items.Clear();
            //listBox1.Items.Add("City (" + 
            //   points[points.Count - 1].x.ToString() + "; " + 
            //    points[points.Count - 1].y.ToString() + ")");

            NonRepeatVector.RemoveDuplicates(population);

            


            //początek pętli
            for (int glrb = 0; glrb < 3; glrb++)
            {
                numOfPopulation = population.Count;//populacja się zmniejszyła



                {//wyliczanie odległości
                    List<double> populationLengths1 = new List<double>();
                    List<double> populationLengths2 = new List<double>();
                    List<double> populationLengths3 = new List<double>();
                    List<double> lengths1 = new List<double>();
                    List<double> lengths2 = new List<double>();
                    List<double> lengths3 = new List<double>();
                    //zaczynamy osobny wątek z funkcją ManageLengthsArray
                    //każda z tych funkcji wylicza drogę dla kolejnych elementów populacji
                    PopulationScanner.ManageLengthsArray(algorithm, population, lengths, listBox2, numOfPopulation, populationLengths, 0, numOfPopulation / 4);
                    Thread thread1 = StartTheThread1(algorithm, population, lengths1, listBox2, numOfPopulation, populationLengths1, numOfPopulation / 4, numOfPopulation * 2 / 4);
                    Thread thread2 = StartTheThread2(algorithm, population, lengths2, listBox2, numOfPopulation, populationLengths2, numOfPopulation * 2 / 4, numOfPopulation * 3 / 4);
                    Thread thread3 = StartTheThread3(algorithm, population, lengths3, listBox2, numOfPopulation, populationLengths3, numOfPopulation * 3 / 4, numOfPopulation);
                    //czekamy aż się zakończy, żeby dodać wszystkie odległości po kolei do listbox2
                    thread1.Join();
                    thread2.Join();
                    thread3.Join();
                    populationLengths.AddRange(populationLengths1);
                    populationLengths.AddRange(populationLengths2);
                    populationLengths.AddRange(populationLengths3);
                }

                //wyrzucamy każdy element populacji którego odległość jest mniejsza niż średnia
                double srednia = populationLengths.Average();
                for (int i = 0; i < populationLengths.Count; i++)
                {
                    if (populationLengths[i] < srednia)
                    {
                        population.RemoveAt(i);
                        populationLengths.RemoveAt(i);
                        i--;
                    }
                }


                //dorabiamy pół populacji przez rekombinowanie kolejnych dwóch elementów
                List<List<Point>> randomlyGeneratedPopulation = new List<List<Point>>();
                for (int f = 0; f < population.Count - 1; f++)
                {

                    var tempvec1 = new List<Point>(population[f]);
                    var tempvec2 = new List<Point>(population[f + 1]);
                    //wybieramy 2 odcinki w wektorach o tych samych długościach
                    int vecstart1 = (int)(random.NextDouble() * (population[0].Count - 1));
                    int vecstop1 = (int)(random.NextDouble() * (population[0].Count - 1));
                    if (vecstart1 > vecstop1)
                    {
                        var temp = vecstop1;
                        vecstop1 = vecstart1;
                        vecstart1 = temp;
                    }
                    int vecstart2 = (int)(random.NextDouble() * ((population[0].Count - 1) - (vecstop1 - vecstart1)));
                    int vecstop2 = vecstart2 + (vecstop1 - vecstart1);
                    int startDifferences = new int();
                    startDifferences = vecstart2 - vecstart1;//o ile wektor 2 jest dalej niz wektor1
                    List<Point> removedFromVec1 = new List<Point>();
                    List<Point> removedFromVec2 = new List<Point>();
                    //zamiana miejsc
                    //int wjakiejpetli = 0;
                    for (int i = vecstart1; i < vecstop1; i++)
                    {
                        //wjakiejpetli++;
                        //removedFromVec1.Add(tempvec1[i]);
                        tempvec1[i] = population[f + 1][i + startDifferences];
                        //removedFromVec2.Add(tempvec2[i + startDifferences]);
                        tempvec2[i + startDifferences] = population[f][i];
                    }

                    //naprawa błędnych wektorów miast 1

                    //sprawdzanie w jakich miejscach sa powtorzenia
                    List<int> miejscaPowtorzen1 = new List<int>();
                    List<int> miejscaPowtorzen2 = new List<int>();
                    //stary kod
                    {/*
                        for (int i = 0; i < tempvec1.Count - 1; i++)//dla kazdego punktu w wektorze (oprócz ostatniego który jest powtórzeniem pierwszego)
                        {
                            for (int j = i - 1; j >= 0; j--)//dla każdego poprzedniego punktu w tym wektorze
                            {
                                if (Equals(tempvec1[i], tempvec1[j]))//jesli poprzedni był już taki jaki jest teraz
                                {
                                    miejscaPowtorzen1.Add(i);
                                }
                            }
                        }
                        for (int i = 0; i < miejscaPowtorzen1.Count; i++)
                        {
                            tempvec1[miejscaPowtorzen1[0]] = removedFromVec1[0];//to ten teraz zamieniamy z czymś co usuneliśmy
                            removedFromVec1.RemoveAt(0);//i zapominamy o tym co usuneliśmy
                            miejscaPowtorzen1.RemoveAt(0);
                        }


                        //to samo dla 2giego wektora
                        for (int i = 0; i < tempvec2.Count - 1; i++)//dla kazdego punktu w wektorze
                        {
                            for (int j = i - 1; j >= 0; j--)//dla każdego poprzedniego punktu w tym wektorze
                            {
                                if (Equals(tempvec2[i], tempvec2[j]))//jesli poprzedni był już taki jaki jest teraz
                                {
                                    miejscaPowtorzen2.Add(i);
                                }
                            }
                        }
                        for (int i = 0; i < miejscaPowtorzen2.Count; i++)
                        {
                            tempvec2[miejscaPowtorzen2[i]] = removedFromVec2[0];//to ten teraz zamieniamy z czymś co usuneliśmy
                            removedFromVec2.RemoveAt(0);//i zapominamy o tym co usuneliśmy
                        }
                    */}

                    //tu wektory mają powtórzenia

                    //sprawdzamy gdzie się powtarzają, i których elementów brakuje
                    for (int i = 0; i < tempvec1.Count - 1; i++)//dla kazdego punktu w wektorze (oprócz ostatniego który jest powtórzeniem pierwszego)
                    {
                        bool brakuje = true;
                        for (int j = i - 1; j >= 0; j--)//dla każdego poprzedniego punktu w tym wektorze
                        {
                            if (Equals(tempvec1[i], tempvec1[j]))//jesli poprzedni był już taki jaki jest teraz
                            {
                                miejscaPowtorzen1.Add(i);
                            }
                        }
                        for (int j = 0; j < tempvec1.Count - 1; j++)//dla każdego punktu w wektorze zmienionym
                        {
                            if (Equals(population[f][i], tempvec1[j]))//jesli w zmienionym jest już taki jak w orginalnym
                            {
                                brakuje=false;
                            }
                        }
                        if (brakuje)
                        {
                            removedFromVec1.Add(population[f][i]);
                        }
                    }

                    //wrzucamy brakujące elementy w miejsca powtórzeń
                    foreach (int pozycja in miejscaPowtorzen1)
                    {
                        tempvec1[pozycja] = removedFromVec1[0];
                        removedFromVec1.RemoveAt(0);
                    }
                    miejscaPowtorzen1.Clear();
                    removedFromVec1.Clear();


                    //sprawdzamy gdzie się powtarzają, i których elementów brakuje
                    for (int i = 0; i < tempvec2.Count - 1; i++)//dla kazdego punktu w wektorze (oprócz ostatniego który jest powtórzeniem pierwszego)
                    {
                        bool brakuje = true;
                        for (int j = i - 1; j >= 0; j--)//dla każdego poprzedniego punktu w tym wektorze
                        {
                            if (Equals(tempvec2[i], tempvec2[j]))//jesli poprzedni był już taki jaki jest teraz
                            {
                                miejscaPowtorzen2.Add(i);
                            }
                        }
                        for (int j = 0; j < tempvec2.Count - 1; j++)//dla każdego punktu w wektorze zmienionym
                        {
                            if (Equals(population[f+1][i], tempvec2[j]))//jesli w zmienionym jest już taki jak w orginalnym
                            {
                                brakuje = false;
                            }
                        }
                        if (brakuje)
                        {
                            removedFromVec2.Add(population[f+1][i]);
                        }
                    }

                    //wrzucamy brakujące elementy w miejsca powtórzeń
                    foreach (int pozycja in miejscaPowtorzen2)
                    {
                        tempvec2[pozycja] = removedFromVec2[0];
                        removedFromVec2.RemoveAt(0);
                    }
                    miejscaPowtorzen2.Clear();
                    removedFromVec2.Clear();
                    { }





                    //tu wektory nie mają powtórzeń

                    randomlyGeneratedPopulation.Add(tempvec1);
                    randomlyGeneratedPopulation.Add(tempvec2);

                    //test powtorzenia
                    //int powtorzenie=0;
                    //for (int i = 0; i < tempvec1.Count; i++)//dla kazdego punktu w wektorze
                    //{
                    //    for (int j = i - 1; j >= 0; j--)//dla każdego poprzedniego punktu w tym wektorze
                    //    {
                    //        if (Equals(tempvec1[i], tempvec1[j]))//jesli poprzedni był już taki jaki jest teraz
                    //        {
                    //            powtorzenie++;
                    //            //tempvec1[i] = removedFromVec1[0];//to ten teraz zamieniamy z czymś co usuneliśmy
                    //            //removedFromVec1.RemoveAt(0);//i zapominamy o tym co usuneliśmy
                    //        }
                    //    }
                    //}
                }
                population.AddRange(randomlyGeneratedPopulation);
                randomlyGeneratedPopulation.Clear();
                populationLengths.Clear();
            }
            //koniec pętli
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
            //chart1.Series["Drogi"].Points.Clear();
            //chart1.Series["Miasta"].Points.Clear();

            //listBox2.Items.Clear();
            //population = citiesManager.GetUniqueList(numOfPopulation, points);
            

            //DisplayManager.AddPointsToChart(chart1, listBox1, population, numOfPopulation);
            //button3.Enabled = false;
            //button1.Enabled = false;
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
