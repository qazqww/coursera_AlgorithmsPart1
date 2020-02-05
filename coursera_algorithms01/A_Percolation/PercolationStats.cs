using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Percolation
{
    class PercolationStats
    {
        int[] openCounts;
        Random r = new Random();

        // n-by-b grid에서 trials번의 독립 시행
        public PercolationStats(int n, int trials)
        {
            openCounts = new int[trials];
            for(int i=0; i<trials; i++)
            {
                Percolation test = new Percolation(n);
                do
                {
                    test.Open(r.Next(0, test.gridLength), r.Next(0, test.gridLength));
                    //test.Print();
                }
                while (test.Percolates() == false);
                openCounts[i] = test.NumberOfOpenSites();
            }
        }

        // 평균 열리는 site 개수
        public double Mean()
        {
            int temp = 0;
            for (int i = 0; i < openCounts.Length; i++)
                temp += openCounts[i];

            return temp / openCounts.Length;
        }
        
        // 편차
        public double Stddev()
        {
            double mean = Mean();
            double temp = 0;

            for (int i = 0; i < openCounts.Length; i++)
                temp += (openCounts[i] - mean) * (openCounts[i] - mean);

            return Math.Sqrt(temp / openCounts.Length - 1);
        }

        // 95% 신뢰구간 최소값
        public double ConfidenceLo()
        {
            double mean = Mean();
            double dev = Stddev();

            return mean - 1.96 * dev / Math.Sqrt(openCounts.Length);
        }

        // 95% 신뢰구간 최대값
        public double ConfidenceHi()
        {
            double mean = Mean();
            double dev = Stddev();

            return mean + 1.96 * dev / Math.Sqrt(openCounts.Length);
        }

        static void Main(string[] args)
        {
            PercolationStats case1 = new PercolationStats(10, 1);
        }
    }
}
