using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera_Dynamic_Connectivity
{
    class UnionSNS
    {
        int[] id;
        int[] size;
        int timeStampCount = 0;

        public UnionSNS(int num)
        {
            id = new int[num];
            size = new int[num];

            for(int i=0; i<num; i++)
            {
                id[i] = i;
                size[i] = 1;
            }
        }

        private int FindRoot(int num)
        {
            if (num < 0 || num >= id.Length)
                return -1;

            while(num != id[num])
            {
                id[num] = id[id[num]];
                num = id[num];
            }

            return num;
        }

        public bool IsConnected(int p, int q)
        {
            if (FindRoot(p) != -1 && FindRoot(p) == FindRoot(q))
                return true;
            return false;
        }

        public void Union(int p, int q)
        {
            int pRoot = FindRoot(p);
            int qRoot = FindRoot(q);

            if (pRoot == qRoot || pRoot == -1 || qRoot == -1)
                return;

            timeStampCount++;

            if(size[pRoot] >= size[qRoot])
            {
                id[qRoot] = pRoot;
                size[pRoot] += size[qRoot];

                if (timeStampCount >= id.Length - 1)
                    IsAllConnected(size[pRoot]);
            }
            else
            {
                id[pRoot] = qRoot;
                size[qRoot] += size[pRoot];

                if (timeStampCount >= id.Length - 1)
                    IsAllConnected(size[qRoot]);
            }
        }

        public bool IsAllConnected(int sizeNum)
        {
            if (sizeNum == id.Length)
            {
                Console.WriteLine("All Connected.");
                return true;
            }

            return false;
        }
    }
}
