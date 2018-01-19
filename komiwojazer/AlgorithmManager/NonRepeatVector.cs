using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace komiwojazer.AlgorithmManager
{
    public class NonRepeatVector
    {
        
        /// <summary>
        /// takes number of paths and an original city list. returns population, which is a list of lists of points
        /// </summary>
        /// <param name="_number">how big the returned population is</param>
        /// <param name="_cities">list of cities to be shuffled</param>
        /// <returns></returns>
        public List<List<Point>> GetUniqueList(int _number, List<Point> _cities)//number to ilosc wierszy w populacji
        {
            List<List<Point>> population= new List<List<Point>>(_number);
            
            for (int i = 0; i < _number; ++i)
            {
                List<Point> test = new List<Point>(ShufflList.Shuffle(_cities));
                test.Add(test[0]);
                population.Add(test);
            }
            return population;
        }

        /// <summary>
        /// edytuje populację wyrzucając każdą drogę która się już pojawiła
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">populacja do sprawdzenia</param>
        public static void RemoveDuplicates<T>(IList<List<T>> list)
        {
            if (list == null)//czy pusta lista?
            {
                return;
            }
            int i = 1;
            while (i < list.Count)//dla każdej kolejnej listy punktów
            {
                int j = 0;
                bool remove = false;
                while (j < i && !remove)//sprawdzamy poprzednie listy punktów
                {
                    int equalCount = 0;
                    for (int k = 0; k < list[j].Count; k++)//czy każdy element następnej nie jest jak w poprzedniej liście
                    {
                        if (Equals(list[i][k],list[j][k]))
                        {
                            equalCount++;
                            
                        }
                        if (equalCount==list[j].Count)//jeśli każdy element listy jast taki sam jak poprzedniej, to wywalamy
                        {
                            remove = true;
                        }
                        
                    }
                    
                    j++;
                }
                if (remove)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

    }
 
    
}
