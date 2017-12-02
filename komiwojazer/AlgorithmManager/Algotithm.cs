using System;

namespace komiwojazer
{
    class Algotithm
    {
        static void ManageTSP(string[] args)
        {
            Random random = new Random();//do generacji randomowych koordów miast
            int numOfCities = 10;//liczba miast

            int[,] koordynaty = new int[numOfCities, 2];//inicjalizacja tablicy z pozycjami x i y miast
            //x1 y1
            //x2 y2
            //x3 y3
            //itd, nr wiersza to miasto, kol1 to koory x a kol2 to koordy y tego miasta


            //zapełnianie tablicy koordów miast
            for (int i = 0; i < numOfCities; i++)
            {
                koordynaty[i, 0] = random.Next(0, 100);//Convert.ToInt32(Console.ReadLine());
                koordynaty[i, 1] = random.Next(0, 100);//Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("miasto {0} - {1} {2}", i + 1, koordynaty[i, 0], koordynaty[i, 1]);
            }

            //po to żeby ładnie się formatowało
            Console.WriteLine(" ");

            //inicjalizacja trójkątnej tablicy odległości miast od siebie
            double[][] citiesDistance = new double[numOfCities - 1][];//robienie kolumn
            for (int i = 0; i < numOfCities - 1; i++)//robienie zmiennej liczby wierszy
            {
                citiesDistance[i] = new double[i + 1];
            }

            citiesDistance = WyliczTabeleOdleglosci(koordynaty, ref citiesDistance);//populcaja tablicy odległości


            //przykładowo wypisanie odległości między miastem 4 a 5
            //to nie jest 4 i 5 pozycja w tablicy
            //odległość pierwszego miasta od drugiego by była zapisana jako
            //OdlegloscMiedzyMiastami(1,2, ref....) (lub 2,1)
            Console.WriteLine(DistanceBetweenCities(5, 4, ref citiesDistance));
            Console.ReadKey();
        }

        public static double[][] WyliczTabeleOdleglosci(int[,] koordynaty, ref double[][] odleglosciMiast)
        {
            for (int j = 0; j < odleglosciMiast.Length; j++)
            {
                for (int i = 0; i < odleglosciMiast[j].Length; i++)
                {
                    //Console.WriteLine("x1={0} y1={1} x2={2} y2={3}", koordynaty[j + 1,0], koordynaty[j + 1, 1], koordynaty[i, 0], koordynaty[i, 1]);
                    //Console.WriteLine("|x1-x2|={0} |y1-y2|={1}", Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]), Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]));
                    //Console.WriteLine("|x1-x2|^2={0} |y1-y2|^2={1}", Pow(Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]),2), Pow(Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]),2));
                    odleglosciMiast[j][i] = Math.Sqrt(Math.Pow(Math.Abs(koordynaty[j + 1, 0] - koordynaty[i, 0]), 2) + Math.Pow(Math.Abs(koordynaty[j + 1, 1] - koordynaty[i, 1]), 2));
                    //Console.WriteLine("miasto {0} do miasta {1} ma {2}", j + 2, i + 1, odleglosciMiast[j][i]);
                }
                //Console.WriteLine(" ");
            }
            return odleglosciMiast;
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
    }
}
