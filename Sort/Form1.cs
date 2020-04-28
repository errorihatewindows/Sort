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
            {
                e.DrawLine(Pens.Black, i, (Height - 37), i, (Height - 37) - array[i]);
                e.DrawLine(Pens.LightSkyBlue, i, (Height - 37), i, (Height - 37) - array[i]);
            }

        }

        public void Array_Finish(int[] array)
        {
            Graphics finish = CreateGraphics();

            for (int i = 0; i < array.Length; i++)
            {
                finish.DrawLine(Pens.Black, i, (Height - 37), i, (Height - 37) - array[i]);
                finish.DrawLine(Pens.Green, i, (Height - 37), i, (Height - 37) - array[i]);
            }

            finish.Dispose();
        }

        public void draw()
        {
            counter++;
            if (counter >= 5)
            {
                counter = 0;
                Invalidate();
                Application.DoEvents();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArray(sorting.get_Array(), e.Graphics);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            sorting.generateArray(800);
            Invalidate();
            Application.DoEvents();
            sorting.Bogo_Sort();
            Invalidate();
            Application.DoEvents();
            Array_Finish(sorting.get_Array());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
