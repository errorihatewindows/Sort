using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    class Sorting
    {
        private Form1 drawing;
        private int[] Array;

        public Sorting(Form1 form)
        {
            drawing = form;
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

        public void BubbleSort()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for(int j = Array.Length - 1; j > i; j--)
                {
                    if (Array[j] < Array[j - 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j - 1];
                        Array[j - 1] = temp;
                        drawing.draw();
                        Application.DoEvents();
                    }
                }
            }
        }

    }
}
