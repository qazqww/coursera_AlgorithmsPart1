using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera_Dynamic_Connectivity
{
    class UnionLargest
    {
        int[] id;

        public UnionLargest(int num)
        {
            id = new int[num];

            for(int i=0; i<num; i++)
                id[i] = i;
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

        public int Find(int num)
        {
            return FindRoot(num);
        }

        public bool IsConnected(int p, int q)
        {
            if (FindRoot(p) == FindRoot(q) && FindRoot(p) != -1)
                return true;
            return false;
        }

        public void Union(int p, int q)
        {
            int pRoot = FindRoot(p);
            int qRoot = FindRoot(q);

            if (pRoot == qRoot || pRoot == -1 || qRoot == -1)
                return;

            if (pRoot >= qRoot)
                id[qRoot] = pRoot;
            else
                id[pRoot] = qRoot;
        }
    }
}
