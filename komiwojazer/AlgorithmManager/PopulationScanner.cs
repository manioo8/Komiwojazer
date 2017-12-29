using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komiwojazer.AlgorithmManager
{
    public class PopulationScanner
    {
        public List<List<Point>> population;
        public List<double> populationLengths;
        public List<double> GetLengthsArray(Algorithm _algorithm, List<List<Point>> _population)
        {
            population = _population;
            populationLengths = new List<double>(population.Count - 1);
            for (int i =0; i<population.Count-1;i++)
            {
                _algorithm.ManageTSP(population[i]);
                for (int j= 0; j < population[i].Count - 1; j++)
                {
                    populationLengths[i]+=_algorithm.DistanceBetweenCities(j, j+1);
                }
            }
         
            return populationLengths;
        }
    }
}
