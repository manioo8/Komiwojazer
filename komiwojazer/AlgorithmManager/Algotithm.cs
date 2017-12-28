using System;
using System.Collections.Generic;
namespace komiwojazer
{
    public class Algorithm
    {
        List<Point> OneRoad { get; set;}
        double[][] citiesDistances;
        double[,] koordynaty { get; set; }
        public Algorithm(List<Point> _oneRoad) => OneRoad = _oneRoad;

        public void ManageTSP()
        {

            koordynaty = new double[OneRoad.Count, 2];//inicjalizacja tablicy z pozycjami x i y miast



            //zapełnianie tablicy koordów miast
            for (int i = 0; i < OneRoad.Count; i++)
            {
                koordynaty[i, 0] = OneRoad[i].x;//Convert.ToInt32(Console.ReadLine());
                koordynaty[i, 1] = OneRoad[i].y;//Convert.ToInt32(Console.ReadLine());
                
            }

            //po to żeby ładnie się formatowało
          

            //inicjalizacja trójkątnej tablicy odległości miast od siebie
            citiesDistances = new double[OneRoad.Count - 1][];//robienie kolumn
            for (int i = 0; i < OneRoad.Count-1; i++)//robienie zmiennej liczby wierszy
            {
                citiesDistances[i] = new double[i + 1];
            }

            citiesDistances = WyliczTabeleOdleglosci();//populcaja tablicy odległości


            //przykładowo wypisanie odległości między miastem 4 a 5
            //to nie jest 4 i 5 pozycja w tablicy
            //odległość pierwszego miasta od drugiego by była zapisana jako
            //OdlegloscMiedzyMiastami(1,2, ref....) (lub 2,1)
            
        }

        public double[][] WyliczTabeleOdleglosci()
        {
            for (int j = 0; j < citiesDistances.Length; j++)
            {
                for (int i = 0; i < citiesDistances[j].Length; i++)
                {
                    //Console.WriteLine("x1={0} y1={1} x2={2} y2={3}", koordynaty[j + 1,0], koordynaty[j + 1, 1], koordynaty[i, 0], koordynaty[i, 1]);
                    //Console.WriteLine("|x1-x2|={0} |y1-y2|={1}", Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]), Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]));
                    //Console.WriteLine("|x1-x2|^2={0} |y1-y2|^2={1}", Pow(Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]),2), Pow(Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]),2));
                    citiesDistances[j][i] = Math.Sqrt(Math.Pow(Math.Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]), 2) + Math.Pow(Math.Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]), 2));
                    //Console.WriteLine("miasto {0} do miasta {1} ma {2}", j + 2, i + 1, odleglosciMiast[j][i]);
                }
                //Console.WriteLine(" ");
            }
            return citiesDistances;
        }
        public double DistanceBetweenCities(int city_1, int city_2)
        {
            if (city_1 == city_2)
            {
                return 0;
            }
            if (city_1 > city_2)
            {
                return citiesDistances[city_1 - 2][city_2 - 1];

            }
            else
            {
                return citiesDistances[city_2][city_1 + 1];
            }
        }
    }
}
