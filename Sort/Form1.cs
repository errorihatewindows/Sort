using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
        int[] lastArray;
        private Sorting sorting;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            sorting = new Sorting(this);
        }

        public void DrawArray(int[] array, Graphics e)
        {
            for (int i = 0; i < array.Length; i++)
                e.DrawLine(Pens.Black, i, (Height - 40), i, (Height - 40) - array[i]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int[] currentArray = sorting.get_Array();
            //first draw of the sorting cycle
            if (lastArray == null)              
                DrawArray(sorting.get_Array(), e.Graphics);
            else
            {
                for (int i = 0; i < lastArray.Length; i++)        
                {
                    if (lastArray[i] != currentArray[i])
                    {
                        Draw_Line(i, currentArray[i], e.Graphics);
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            sorting.generateArray(800);
            lastArray = null;
            Invalidate();
            sorting.BubbleSort();
        }
    }
}
