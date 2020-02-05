using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera_Dynamic_Connectivity
{
    class Union
    {
        int[] nums;

        public Union(int num)
        {
            nums = new int[num];
            for(int i=0; i<num; i++)
                nums[i] = i;
        }

        public void IsConnected(int p, int q)
        {
            if (p < 0 || p >= nums.Length || q < 0 || q >= nums.Length)
            {
                Console.WriteLine("Error: 숫자가 배열의 범위를 벗어났습니다.");
                return;
            }            

            if (nums[p] == nums[q])
                Console.WriteLine("Connected.");
            else
                Console.WriteLine("Not Connected.");
        }

        public void Connect(int p, int q)
        {
            if (p < 0 || p >= nums.Length || q < 0 || q >= nums.Length)
                return;

            for(int i=0; i<nums.Length; i++)
            {
                if (nums[i] == nums[p])
                    nums[i] = nums[q];
            }
        }
    }

    class UnionTree
    {
        int[] nums;
        int[] sizes;

        public UnionTree(int num)
        {
            nums = new int[num];
            sizes = new int[num];
            for (int i = 0; i < num; i++) {
                nums[i] = i;
                sizes[i] = 1;
            }
        }

        // 경로를 완전히 압축하려면 재귀함수를 이용하면 되는듯
        // 이 경로 압축 코드는 val의 부모를 조부모(?)로 붙여가는 코드 (val이 2계단 위로 가서 붙음)
        private int FindRoot(int val)
        {
            if (val < 0 || val >= nums.Length)
                return -1;

            while(val != nums[val]) // nums[val] => val의 부모
            {
                nums[val] = nums[nums[val]];
                val = nums[val];
            }
            return val;
        }

        public void IsConnected(int p, int q)
        {
            if (p < 0 || p >= nums.Length || q < 0 || q >= nums.Length)
            {
                Console.WriteLine("Error: 숫자가 배열의 범위를 벗어났습니다.");
                return;
            }

            if (FindRoot(p) == FindRoot(q))
                Console.WriteLine("Connected.");
            else
                Console.WriteLine("Not Connected.");
        }

        public void Connect(int p, int q)
        {
            if (p < 0 || p >= nums.Length || q < 0 || q >= nums.Length)
                return;

            int i = FindRoot(p);
            int j = FindRoot(q);

            if (i == j)
                return;

            if(sizes[i] >= sizes[j]) {
                nums[j] = i;
                sizes[i] += sizes[j];
            }
            else {
                nums[i] = j;
                sizes[j] += sizes[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Union union = new Union(10);

            //union.IsConnected(0, 1);
            //union.Connect(0, 1);
            //union.IsConnected(0, 1);
            //union.Connect(1, 9);
            //union.IsConnected(0, 9);
            //union.IsConnected(9, 11);

            //UnionTree unionTree = new UnionTree(10);

            //unionTree.IsConnected(0, 1);
            //unionTree.Connect(0, 1);
            //unionTree.IsConnected(0, 1);
            //unionTree.Connect(1, 9);
            //unionTree.IsConnected(0, 9);
            //unionTree.IsConnected(9, 11);

            //UnionSNS union1 = new UnionSNS(100);

            //Console.WriteLine(union1.IsConnected(0, 1));
            //Console.WriteLine(union1.IsConnected(500, 1));
            //Console.WriteLine(union1.IsConnected(700, 800));
            //union1.Union(10, 20);
            //union1.Union(30, 20);
            //union1.Union(20, 40);
            //Console.WriteLine(union1.IsConnected(1, 40));
            //Console.WriteLine(union1.IsConnected(10, 40));

            //UnionSNS union2 = new UnionSNS(5);

            //union2.Union(0, 1);
            //union2.Union(2, 1);
            //union2.Union(3, 1);
            //union2.Union(4, 5);
            //Console.WriteLine(union2.IsConnected(1, 4));
            //union2.Union(4, 1);
            //Console.WriteLine(union2.IsConnected(1, 4));

            UnionLargest union3 = new UnionLargest(5);

            union3.Union(0, 1);
            union3.Union(2, 1);
            union3.Union(3, 1);
            Console.WriteLine(union3.Find(0));
            union3.Union(4, 1);
            Console.WriteLine(union3.Find(2));
            Console.WriteLine(union3.Find(3));
            Console.WriteLine(union3.Find(4));
            Console.WriteLine(union3.Find(1));
            Console.WriteLine(union3.Find(0));
        }
    }
}
