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

        public void DrawArray(Graphics e)
        {
            for (int i = 0; i < sorting.get_Array().Length; i++) 
                e.DrawLine(Pens.White, i, (Height - 37), i, (Height - 37) - sorting.get_Array()[i]);
        }

        public void Draw_Line(int x, int y, Graphics e)
        {
            //BlackBackground
            e.DrawLine(Pens.Black, x, 0, x, (Height + 37));
            //Line
            e.DrawLine(Pens.White, x, (Height - 37), x, (Height - 37) - y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArray(e.Graphics);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Invalidate();
            sorting.BubbleSort();
        }
    }
}
