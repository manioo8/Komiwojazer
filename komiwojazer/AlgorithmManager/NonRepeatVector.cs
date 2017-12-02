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

        public List<List<Point>> GetUniqueList(int _number, List<Point> _cities)
        {
            List<Point> test = _cities;
            for (int i = 0; i <= _number; ++i)
            {
                test.Shuffle();
                population.Add(test);
            }
            return population;
        }
    }
}
