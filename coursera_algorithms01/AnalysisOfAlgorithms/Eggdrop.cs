using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Version 0: 1 egg, ≤T tosses.
 * Version 1: ∼1lg⁡n eggs and ∼1lg⁡n tosses.
 * Version 2: ∼lg⁡T eggs and ∼2lg⁡T tosses.
 * Version 3: 2 eggs and ∼2n tosses.
 * Version 4: 2 eggs and ≤c sqrt T​ tosses for some fixed constant ccc.
*/

namespace AnalysisOfAlgorithms
{
    class Eggdrop
    {
        Random r = new Random();
        const int maxFloor = 64; // n
        int targetFloor; // T
        int answer = -1;
        int tempStep = 2;

        public Eggdrop(int version)
        {
            targetFloor = r.Next(1, maxFloor+1);

            switch (version)
            {
                case 1:
                    Version1();
                    break;
               case 2:
                   Version2();
                   break;
                //case 3:
                //    Version3();
                //    break;
                //case 4:
                //    Version4();
                //    break;
                //case 5:
                //    Version5();
                //    break;
            }
        }

        public void Answer()
        {
            Console.WriteLine("Target: {0} // answer : {1}", targetFloor, answer);
        }

        private bool Toss(int floor)
        {
            if (floor >= targetFloor)
                return true; // egg breaks
            else
                return false; // egg doesnt break
        }

        private int Version1()
        {
            for (int i = 0; i < targetFloor; i++)
            {
                if (Toss(i) == true)
                {
                    answer = i;
                    break;
                }
            }
            return answer;
        }

        private int Version2(int num = maxFloor/2)
        {
            int testFloor = num;
            tempStep *= 2;

            if(Toss(testFloor) == true)
            {
                if (Toss(testFloor - 1) == false)
                    return testFloor;
                answer = Version2(testFloor - maxFloor / tempStep);
            }
            else
            {
                if (Toss(testFloor + 1) == true)
                    return testFloor + 1;
                answer = Version2(testFloor + maxFloor / tempStep);
            }

            return answer;
        }

        private int Version3()
        {
            return answer;
        }

        private int Version4()
        {
            return answer;
        }

        private int Version5()
        {
            return answer;
        }
    }
}
