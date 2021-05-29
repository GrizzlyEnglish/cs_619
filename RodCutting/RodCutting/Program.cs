using System;

namespace RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            int[] results = RodCut(prices);

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i].ToString());
            }
        }

        /// <summary>
        /// Gets the best cut for the rods given
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int[] RodCut(int[] prices)
        {
            // Setup the results to be th same size
            int[] results = new int[prices.Length];
            // Set the default
            results[0] = prices[0];
            // Start at 1 we already set the first
            for (int i = 1; i < prices.Length; i++)
            {
                int best_cut = int.MinValue;

                for (int k = 0; k <= i; k++)
                {
                    int max = 0;
                    if (i > k)
                    {
                        max = results[i - k];
                    }

                    best_cut = Math.Max(best_cut, prices[k] + max);
                }

                results[i] = best_cut;
            }

            return results;
        }

    }
}
