using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

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

        //functions of the sorting framework
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
        //--------------------------------------------------------------------------
        //sorting algorithms
        //--------------------------------------------------------------------------
        public void Bubble_Sort()
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
                    }
                }
            }
        }

        public void Radix_Sort()
        {
            //initialize empty list array
            List<int>[] radix = new List<int>[10];
            for (int i = 0; i < 10; i++)
            {
                radix[i] = new List<int>();
            }
            //loop through every digit
            for (int i = 0; i < Math.Log10(Array.Length-1); i++)
            {
                //splits into groups
                foreach (int number in Array)
                {
                    string strnum = number.ToString();
                    //imagine leading 0s
                    if (strnum.Length <= i) { radix[0].Add(number); }
                    else    //sort into right list
                    {
                        //string indexing has 0 as MSB
                        int id = strnum.Length - 1 - i;
                        Console.WriteLine("number: {0}     index: {1}", number, id);
                        radix[strnum[id]-'0'].Add(number);
                    }
                }
                //write lists into array
                int index = 0;
                for (int j = 0; j < 10; j++)
                {
                    foreach (int number in radix[j])
                    {
                        Array[index] = number;
                        index++;
                        drawing.draw();
                    }
                    radix[j].Clear();
                }
            }
        }

    }
}
