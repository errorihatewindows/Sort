using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Sorting
    {
        private int[] Array;

        public Sorting()
        {
            generateArray(50);
            foreach (int number in Array)
            {
                Console.WriteLine(number);
            }
        }

        //getter
        public int[] get_Array() { return Array; }

        public void generateArray(int size)
        {
            Random rand = new Random();
            List<int> shuffling = new List<int>();
            //insert every integer into a random spot in the list
            for (int i = 0; i < size; i++)
            {
                int position = rand.Next(shuffling.Count + 1);
                shuffling.Insert(position, i);
            }
            //copy list to array
            Array = shuffling.ToArray();
        }

    }
}
