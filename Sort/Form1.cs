using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
        int[] testarray = new int[800];
        private Sorting sorting;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            sorting = new Sorting(this);
            sorting.generateArray(800);
        }

        public void DrawArray(int[] array, Graphics e)
        {
            for (int i = 0; i < array.Length; i++)
                e.DrawLine(Pens.Black, i, Height, i, Height - array[i]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArray(sorting.get_Array(), e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sorting.BubbleSort();
        }
    }
}
