﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private Sudoku sudoku;

        public Form1()
        {
            InitializeComponent();
            sudoku = new Sudoku();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SudokuGenerator.Generate(sudoku);
            richTextBox1.Text = sudoku.ToString();
            //int[] s = Sudoku.GetSquare(sudoku, 6, 6);
            //foreach (int item in s)
            //    richTextBox1.Text += item.ToString();
        }
    }
}
