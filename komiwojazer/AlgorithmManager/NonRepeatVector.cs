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
        

        public List<List<Point>> GetUniqueList(int _number, List<Point> _cities)//number to ilosc wierszy w populacji
        {
            List<List<Point>> population= new List<List<Point>>(_number);
            
            for (int i = 0; i <= _number; ++i)
            {
                List<Point> test = new List<Point>(ShufflList.Shuffle(_cities));
                test.Add(test[0]);
                population.Add(test);
            }
            return population;
        }
        public static void RemoveDuplicates<T>(IList<T> list)
        {
            if (list == null)
            {
                return;
            }
            int i = 1;
            while (i < list.Count)
            {
                int j = 0;
                bool remove = false;
                while (j < i && !remove)
                {
                    if (list[i].Equals(list[j]))
                    {
                        remove = true;
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
