using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
//tworzenie losowej listy z poczatkowej listy miast
namespace komiwojazer.AlgorithmManager
{
    static class ShufflList
    {
        public static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        public static List<Point> Shuffle(List<Point> list)
        {
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];

                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));


                int k = (box[0] % n);
                n--;
                Point value = list[k];
                list[k] = list[n];
                list[n] = value;

            }
            return list;
        }
    }
}
