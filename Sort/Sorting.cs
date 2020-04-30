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
using System.ComponentModel.Design.Serialization;

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
                        swap(j, j - 1);
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
                    drawing.draw();
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

        public void Heap_Sort()
        { 
            //variables
            int heapsize = 0;   //last index of the heap
            //create the heap
            while (heapsize < Array.Length-1)
            {
                heapsize++;
                //rise last elementen until heap is restored
                int index = heapsize;
                int parentIndex;
                while (true)
                {
                    //find parent index
                    if (index%2 == 1) { parentIndex = (index - 1) / 2; }
                    else              { parentIndex = (index - 2) / 2; }
                    if (Array[index] > Array[parentIndex])
                    {
                        swap(index, parentIndex);
                        drawing.draw();
                        index = parentIndex;
                        //root cannot break heap property
                        if (index == 0) { break; }
                    }
                    //if no swap occured, the rest of the tree stays in heap condition
                    else { break; }
                }
            }
            //heap created
            //now build heap back
            while (heapsize > 0)
            {  
                //root is largest number of the heap
                swap(0, heapsize);
                drawing.draw();
                heapsize--;
                //sink new root until heap property is restored
                int index = 0;
                while (true)
                {
                    //if index has no children, the heap order is restored
                    if ((index * 2 + 1) > heapsize) { break; }
                    //check left child first
                    if (Array[index] < Array[index * 2 + 1])
                    {
                        //swap with left, if there is no right child or left child > right child
                        if ((index * 2 + 2 > heapsize) || (Array[index * 2 + 1] > Array[index * 2 + 2]))
                        { 
                            swap(index, index * 2 + 1);
                            index = index * 2 + 1;
                            drawing.draw();
                        }
                        else
                        {
                            swap(index, index * 2 + 2);
                            index = index * 2 + 2;
                            drawing.draw();
                        }
                    }//check right child next 
                    else if (Array[index] < Array[index * 2 + 2] && (index * 2 + 2 <= heapsize))
                    {
                        swap(index, index * 2 + 2);
                        index = index * 2 + 2;
                        drawing.draw();
                    }//if neither right nor left child has to be swapped, heap condition is restored
                    else { break; }
                }//end of sinking
            }//end of buildback loop
        }

        public void Insert_Sort()
        {
            for (int current = 1; current < Array.Length; current++)
            {
                //insert current element to sorted
                for (int sorted = 0; sorted < current; sorted++)
                {
                    if (Array[current] < Array[sorted])
                    {
                        int Value = Array[current];
                        //pushback list elements until insertion spot is reached
                        for (int pushing = current; pushing > sorted; pushing--)
                        {
                            Array[pushing] = Array[pushing - 1];
                            drawing.draw();
                        }
                        Array[sorted] = Value;
                        drawing.draw();
                    }
                }
            }//outer loop end
        }

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
