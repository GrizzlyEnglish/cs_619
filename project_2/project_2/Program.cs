using System;

namespace project_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] dimensions = new int[] { 5, 10, 3, 12, 5, 50, 6 };
            int[,] costTable = new int[dimensions.Length - 1, dimensions.Length - 1];
            int[,] reconstructionTable = new int[dimensions.Length - 1, dimensions.Length - 1];

            Console.WriteLine($"Min cost: {Cost(dimensions, 1, dimensions.Length - 1, costTable, reconstructionTable)}");

            Console.WriteLine("Cost Table");
            PrintTable(costTable);
            Console.WriteLine("Reconstruction Table");
            PrintTable(reconstructionTable);

        }

        public static void Print(int[,] reconstructionTable, int i, int j)
        {
            if (i == j)
            {
                Console.Write($"A{i}");
            } 
            else
            {
                Console.Write("(");
                Print(reconstructionTable, i, reconstructionTable[i, j]);
                Print(reconstructionTable, reconstructionTable[i, j] + 1, j);
                Console.Write(")");
            }
        }

        public static int Cost(int[] dimensions, int i, int j, int[,] costTable, int[,] reconstructionTable)
        {
            if (i == j)
            {
                return 0;
            }

            int minCost = int.MaxValue;
            int reconstructionIndex = int.MaxValue;

            for (int k = i; k < j; k++) 
            {
                int cost = Cost(dimensions, i, k, costTable, reconstructionTable) + Cost(dimensions, k + 1, j, costTable, reconstructionTable) + dimensions[i-1] * dimensions[k] * dimensions[j];
     
                if (cost < minCost)
                {
                    minCost = cost;
                    reconstructionIndex = k;
                }
            }

            costTable[i - 1, j - 1] = minCost;
            reconstructionTable[i - 1, j - 1] = reconstructionIndex;

            return minCost;
        }

        public static void PrintTable(int[,] table)
        {
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for (int k = 0; k < table.GetLength(1); k++)
                {
                    Console.Write($"{table[i, k]} ");
                }
                Console.WriteLine("");
            }
        }

    }
}
