using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace komiwojazer.AlgorithmManager
{
    public class PopulationScanner
    {

        
        public static void ManageLengthsArray(
            Algorithm _algorithm,
            List<List<Point>> _population,
            List<double> lengths,
            ListBox _listBox, 
            int _numOfPopulation,
            List<double> _populationLengths)
        {
            double[][] citiesDistances=null;
            for (int j = 0; j < _numOfPopulation; j++)
            {
                citiesDistances = _algorithm.ManageTSP(_population[j], citiesDistances);
                //_algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < _population[j].Count - 1; i++)
                {
                    lengths.Add(_algorithm.DistanceBetweenCities(i, i + 1, citiesDistances ));
                }
                _populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }

            for (int i = 0; i < _numOfPopulation; i++)
            {
                _listBox.Items.Add(_populationLengths[i].ToString());
            }

        }

        public static void ManageLengthsArray(
            Algorithm _algorithm,
            List<List<Point>> _population,
            List<double> lengths,
            ListBox _listBox,
            int _numOfPopulation,
            List<double> _populationLengths,
            int startIndex,//od którego indeksu populacji ma liczyć
            int stopIndex)//do którego włącznie ma liczyć
                          //podstawowo liczy się od zerowego do population.Count
        {
            double[][] citiesDistances = null;
            for (int j = startIndex; j < stopIndex + 1; j++)
            {
                citiesDistances = _algorithm.ManageTSP(_population[j], citiesDistances);
                //_algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < _population[j].Count - 1; i++)
                {
                    lengths.Add(_algorithm.DistanceBetweenCities(i, i + 1, citiesDistances));
                }
                _populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }



        }

        public static void ManageLengthsArray1(
            Algorithm _algorithm,
            List<List<Point>> _population,
            List<double> lengths,
            ListBox _listBox,
            int _numOfPopulation,
            List<double> _populationLengths,
            int startIndex,//od którego indeksu populacji ma liczyć
            int stopIndex)//do którego włącznie ma liczyć
            //podstawowo liczy się od zerowego do population.Count
        {
            double[][] citiesDistances = null;
            for (int j = startIndex; j < stopIndex + 1; j++)
            {
                citiesDistances = _algorithm.ManageTSP(_population[j], citiesDistances);
                //_algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < _population[j].Count - 1; i++)
                {
                    lengths.Add(_algorithm.DistanceBetweenCities(i, i + 1, citiesDistances));
                }
                _populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }

            

        }

        public static void ManageLengthsArray2(
            Algorithm _algorithm,
            List<List<Point>> _population,
            List<double> lengths,
            ListBox _listBox,
            int _numOfPopulation,
            List<double> _populationLengths,
            int startIndex,//od którego indeksu populacji ma liczyć.
            int stopIndex)//do którego włącznie ma liczyć
                          //podstawowo liczy się od zerowego do population.Count
        {
            double[][] citiesDistances = null;
            for (int j = startIndex; j < stopIndex+1; j++)
            {
                citiesDistances = _algorithm.ManageTSP(_population[j], citiesDistances);
                //_algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < _population[j].Count - 1; i++)
                {
                    lengths.Add(_algorithm.DistanceBetweenCities(i, i + 1, citiesDistances));
                }
                _populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }



        }

        public static void ManageLengthsArray3(
            Algorithm _algorithm,
            List<List<Point>> _population,
            List<double> lengths,
            ListBox _listBox,
            int _numOfPopulation,
            List<double> _populationLengths,
            int startIndex,//od którego indeksu populacji ma liczyć
            int stopIndex)//do którego włącznie ma liczyć
                          //podstawowo liczy się od zerowego do population.Count
        {
            double[][] citiesDistances = null;
            for (int j = startIndex; j < stopIndex + 1; j++)
            {
                citiesDistances = _algorithm.ManageTSP(_population[j], citiesDistances);
                //_algorithm.WyliczTabeleOdleglosci();
                for (int i = 0; i < _population[j].Count - 1; i++)
                {
                    lengths.Add(_algorithm.DistanceBetweenCities(i, i + 1, citiesDistances));
                }
                _populationLengths.Add(lengths.Sum());
                lengths.Clear();
            }



        }

        public static int GetInedXOfOptimalElement(List<double> _populationLengths)
        {
            List<double> sortedList = new List<double>(_populationLengths);
            sortedList.Sort();
            int index=0;
            for(int i = 0; i < _populationLengths.Count-1; i++)
            {
                if (_populationLengths[i] == sortedList[0])
                {
                    index = i;
                }                
            }
            return index;
        }
    } 
}
