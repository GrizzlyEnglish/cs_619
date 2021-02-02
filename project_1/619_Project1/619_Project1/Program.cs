using System;

namespace _619_Project1
{
    /// <summary>
    /// 
    /// Project 1
    /// Ryan English
    /// 
    /// Create two insertion sorts
    ///     - Sequential
    ///     - Binary search
    /// 
    /// Compare running time complexities
    /// 
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            Random rand = new Random();

            double seq_time_ms = 0;
            double bs_time_ms = 0;

            int runs = 15;
            int length = 0;

            Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|", "Length of Dataset", "Sequential", "Binary"));

            for (int i = 0; i < runs; i++)
            {
                length = i * 1000;

                // Generate the arrays
                int[] seq_array = new int[length];
                int[] bs_array = new int[length];

                // Fill with random integers
                for (int j = 0; j < length; j++)
                {
                    int num = rand.Next(0, 100);
                    seq_array[j] = num;
                    bs_array[j] = num;
                }

                // Sort by seq search
                DateTime start = DateTime.Now;
                InsertionSortSequential(seq_array);
                seq_time_ms += (DateTime.Now - start).TotalMilliseconds;

                // Sort by binary search
                start = DateTime.Now;
                InsertionSortBinary(bs_array);
                bs_time_ms += (DateTime.Now - start).TotalMilliseconds;

                // Verify each match
                for (int j = 0; j < length; j++)
                {
                    if (seq_array[j] != bs_array[j])
                    {
                        Console.WriteLine("Arrays do not match, something is wrong");
                        throw new Exception("Arrays do not match");
                    }
                }

                Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|", length, seq_time_ms.ToString() + "ms", bs_time_ms.ToString() + "ms"));
            }
        }

        /// <summary>
        /// Sorts an array using insertion sort with a sequential
        /// search on the array.
        /// </summary>
        /// <param name="array">The array that is being sorted</param>
        public static void InsertionSortSequential(int[] array) 
        {
            int position = 1;
            while (position < array.Length) {
                int sub_position = position;
                // Walk backwards looking for the position
                while (sub_position > 0 && array[sub_position - 1] > array[sub_position]) {
                    // Swap the slots
                    int num = array[sub_position - 1];
                    array[sub_position - 1] = array[sub_position];
                    array[sub_position] = num;
                    sub_position -= 1;
                }
                position += 1;
            }
        }

        /// <summary>
        /// Sorts an array using insertion sort with a binary
        /// search on the sorted portion of the array
        /// </summary>
        /// <param name="array">The array that is being sorted</param>
        public static void InsertionSortBinary(int[] array)
        {
            int position = 1;
            while (position < array.Length) {
                int sub_position = position;

                int low_position = 0;
                int mid_position = 0;
                int high_position = sub_position;

                int found_position = -1;

                while (low_position <= high_position) {
                    // Set the mid point
                    mid_position = (high_position + low_position) / 2;
                    if (array[sub_position] > array[mid_position]) {
                        low_position = mid_position + 1;
                    } else if (array[sub_position] < array[mid_position]) {
                        high_position = mid_position - 1;
                    } else {
                        found_position = mid_position;
                        break;
                    }
                }

                if (found_position == -1) {
                    // Position was not found it is low
                    found_position = low_position;
                }

                // Everything needs to move
                int num = array[sub_position];
                for(int i = sub_position; i > found_position; i--) {
                    array[i] = array[i - 1];
                }
                array[found_position] = num;

                position += 1;
            }
        }

    }
}
