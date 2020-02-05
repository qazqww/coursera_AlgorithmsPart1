using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfAlgorithms
{
    class ThreeSum
    {
        int[] array;
        int count;
        Random r = new Random();
        List<Tuple<int, int, int>> values = new List<Tuple<int, int, int>>();

        public ThreeSum(int n)
        {
            array = new int[n];
            count = 0;
            values.Clear();

            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(-n*2, n*2);

            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    values.Add(new Tuple<int, int, int>(array[i] + array[j], i, j));

            for (int i = 0; i < values.Count; i++)
                for (int j = 0; j < array.Length; j++)
                {
                    if (values[i].Item1 + array[j] == 0
                        && j != values[i].Item2 && j != values[i].Item3)
                    {
                        Console.WriteLine(values[i].Item2 + ": " + array[values[i].Item2] + ", " + values[i].Item3 + ": " + array[values[i].Item3] + ", " + j + ": " + array[j]);
                        count++;
                    }
                }

            Console.WriteLine("Count: " + count);
        }
    }
}
