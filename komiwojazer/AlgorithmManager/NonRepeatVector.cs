using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komiwojazer.AlgorithmManager
{
    public class NonRepeatVector
    {
        List<List<Point>> population = new List<List<Point>>();

        public List<List<Point>> GetUniqueList(List<Point> _cities)//number to ilosc wierszy w populacji
        {
            _cities.Shuffle();
            population.Add(_cities);
            return population;
        }
    }
}
