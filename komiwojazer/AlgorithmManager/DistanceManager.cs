using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komiwojazer.AlgorithmManager
{
    class DistanceManager
    {
        Random random = new Random();
        List<Point> points { get; set;}

        public DistanceManager(List<Point> _points)
        {
            points = _points;
        }

        public double[,] CreateCoordinates()
        {
            double[,] coordinates = new double[points.Count-1, 2];
            for (int i = 0; i < points.Count-1; i++)
            {
                coordinates[i, 0] = random.Next(0, 100);//Convert.ToInt32(Console.ReadLine());
                coordinates[i, 1] = random.Next(0, 100);//Convert.ToInt32(Console.ReadLine());
            }

            return coordinates;
        }

        public static double DistanceBetweenCities(int city_1, int city_2, ref double[][] citiesDistance)
        {
            if (city_1 == city_2)
            {
                return 0;
            }
            if (city_1 > city_2)
            {
                return citiesDistance[city_1 - 2][city_2 - 1];

            }
            else
            {
                return citiesDistance[city_2 - 2][city_1 - 1];
            }
        }

        public void CreateDiagonalMatrixOfLengths()
        {

        }

    }
}
