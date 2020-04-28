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
        //private functions for sorting
        private void swap(int i1, int i2)
        {
            int temp = Array[i1];
            Array[i1] = Array[i2];
            Array[i2] = temp;
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

        public void Shaker_Sort()
        {
            //one cycle locks in one left and one right
            for (int outer = 0; outer < Array.Length/2; outer++)
            {
                //sort to left first
                for (int i = Array.Length - 1 - outer; i > outer; i--)
                {
                    if (Array[i] < Array[i - 1]) { swap(i, i - 1); drawing.draw(); }
                }
                for (int i = outer; i < Array.Length - 1; i++)
                {
                    if (Array[i] > Array[i + 1]) { swap(i, i + 1); drawing.draw(); }
                }
            }//end of outer loop
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
            }//end of outer loop
        }//end of Radix  Sort

        //---------------------------------------------------------------------------
        //meme sorts
        //---------------------------------------------------------------------------
        private bool is_sorted(int[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                if (Array[i] < Array[i + 1]) { return false; }
            }
            return true;
        }
        public void Bogo_Sort()
        {
            Random rand = new Random();

            while (!is_sorted(Array))
            {
                int i1 = rand.Next(Array.Length);
                int i2 = rand.Next(Array.Length);

                swap(i1, i2);
                drawing.draw();
            }
        }

    }
}
