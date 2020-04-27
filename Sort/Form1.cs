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
        int counter = 0;
        int[] lastArray;
        private Sorting sorting;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            sorting = new Sorting(this);
        }

        private void DrawArray(int[] array, Graphics e)
        {
            for (int i = 0; i < array.Length; i++)
                e.DrawLine(Pens.Black, i, (Height - 40), i, (Height - 40) - array[i]);
            for (int i = 0; i < array.Length; i++) 
                e.DrawLine(Pens.LightSkyBlue, i, (Height - 37), i, (Height - 37) - array[i]);
        }

        public void draw()
        {
            counter++;
            if (counter >= 100)
            {
                counter = 0;
                Invalidate();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArray(sorting.get_Array(), e.Graphics);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            sorting.generateArray(800);
            lastArray = null;
            Invalidate();
            sorting.BubbleSort();
            Invalidate();
        }
    }
}
