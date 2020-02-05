using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Percolation
{
    class Percolation
    {
        int[,] grid;
        int[,] size;
        int startPoint;
        int endPoint;

        public int gridLength;
        int openCount = 0;

        public Percolation(int n)
        {
            grid = new int[n, n];
            grid.Initialize();

            size = new int[n, n];
            for(int i=0; i<n; i++)
                for(int j=0; j<n; j++)
                    size[i, j] = 1;

            gridLength = n;
            startPoint = n * n + 1;
            endPoint = n * n + 2;
        }

        public void Open(int row, int col)
        {
            if (IsOpen(row, col) == true)
                return;

            grid[row, col] = row + col * gridLength + 1; // 1 ~ num^2

            Union(row, col, row - 1, col);
            Union(row, col, row + 1, col);
            Union(row, col, row, col - 1);
            Union(row, col, row, col + 1);

            openCount++;
        }

        public bool IsOpen(int row, int col)
        {
            if (grid[row, col] == 0)
                return false;
            return true;
        }

        // 시작지점과 연결되어있는가
        public bool IsFull(int row, int col)
        {
            if (grid[row, col] == startPoint)
                return true;
            return false;
        }

        public int NumberOfOpenSites()
        {
            return openCount;
        }

        // percolate 상태인가
        public bool Percolates()
        {
            if (startPoint == gridLength * gridLength + 1 || endPoint == gridLength * gridLength + 2)
                return false;
            if (FindRoot(startPoint) == FindRoot(endPoint) && FindRoot(startPoint) != -1)
                return true;
            return false;
        }

        private int FindRoot(int row, int col)
        {
            // grid를 벗어난 경우
            if (row < 0 || row >= gridLength || col < 0 || col >= gridLength)
                return -1;

            int index = row + col * gridLength + 1;
            int value = grid[row, col];

            // 아직 open되지 않은 경우
            if (value == 0)
                return -1;

            while (index != value)
            {
                index = value;

                // start나 end point가 value일 때
                if (value == gridLength * gridLength + 1)
                    value = startPoint;
                else if (value == gridLength * gridLength + 2)
                    value = endPoint;
                else
                {
                    int colTemp = (value - 1) / gridLength;
                    int rowTemp = (value - 1) - colTemp * gridLength;
                    value = grid[rowTemp, colTemp];
                }
            }
            return index;
        }

        private int FindRoot(int index)
        {
            int colTemp = (index - 1) / gridLength;
            int rowTemp = (index - 1) - colTemp * gridLength;
            return FindRoot(rowTemp, colTemp);
        }

        public bool IsConnected(int row1, int col1, int row2, int col2)
        {
            if (FindRoot(row1, col1) == FindRoot(row2, col2) && FindRoot(row1, col1) != 0)
                return true;
            return false;
        }

        public void Union(int row1, int col1, int row2, int col2)
        {
            int root1 = FindRoot(row1, col1);
            int root2 = FindRoot(row2, col2);

            if (root1 == root2 || root1 == -1)
                return;

            int root1_Col = (root1 - 1) / gridLength;
            int root1_Row = (root1 - 1) - root1_Col * gridLength;
            int root2_Col = (root2 - 1) / gridLength;
            int root2_Row = (root2 - 1) - root2_Col * gridLength;

            if (row2 == -1 && startPoint == gridLength * gridLength + 1) // 첫 줄이 startPoint와 union하는 경우
            {
                startPoint = root1;
                size[root1_Row, root1_Col] += 1;
                return;
            }
            else if (row2 == gridLength && endPoint == gridLength * gridLength + 2) // 끝 줄이 endPoint와 union하는 경우
            {
                endPoint = root1;
                size[root1_Row, root1_Col] += 1;
                return;
            }

            if (root2 == -1)
                return;

            if (size[root1_Row, root1_Col] >= size[root2_Row, root2_Col])
            {
                grid[root2_Row, root2_Col] = root1;
                size[root1_Row, root1_Col] += size[root2_Row, root2_Col];
            }
            else
            {
                grid[root1_Row, root1_Col] = root2;
                size[root2_Row, root2_Col] += size[root1_Row, root1_Col];
            }
        }

        public void Print()
        {
            Console.WriteLine(startPoint + " " + endPoint);
            for (int i = 0; i < gridLength; i++)
            {
                for (int j = 0; j < gridLength; j++)
                {
                    Console.Write(grid[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
