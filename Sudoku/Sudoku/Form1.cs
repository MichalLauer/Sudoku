using System;
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
            sudoku.Generate();
            richTextBox1.Text = sudoku.ToString();
        }
    }
}
