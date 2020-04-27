﻿using System;
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

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Random zufall = new Random();

            for (int i = 0; i < testarray.Length; i++)
                testarray[i] = zufall.Next(1, 801);

        }

        public void DrawArray(int[] array, Graphics e)
        {
            for(int i = 0; i < array.Length; i++)
                e.DrawLine(Pens.Black, i, Height, i, Height - array[i]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArray(testarray, e.Graphics);
        }
    }
}
