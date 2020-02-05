using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursera_Dynamic_Connectivity
{
    class UnionSuccessor
    {
        int[] id;

        public UnionSuccessor(int num)
        {
            id = new int[num];

            for (int i = 0; i < num; i++)
                id[i] = i+1;
        }

        public void Delete(int num)
        {

        }
    }
}
