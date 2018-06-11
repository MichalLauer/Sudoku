using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuApp
{
    public partial class Form1 : Form
    {
        private Sudoku sudoku;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			UI.CreateFormUI(this);
			UI.CreateInterface(this);
			UI.CreateSudokuUI(this);
			sudoku = new Sudoku(true, true);
		}

		public void btnReset_Down(object sender, MouseEventArgs e)
		{
			UI.FillSudoku(sudoku);
		}

		public  void btnCheck_Down(object sender, MouseEventArgs e)
		{
			if (!DataValidator.SudokuVal.IsValid(sudoku))
				return;

			DialogResult dr = MessageBox.Show("Vyhrali ste. JUPIIIIIIII! <3 <3 <3 <3 <3 <3\nPřejete si hrát znovu?", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (dr == DialogResult.Yes)
				btnGenerate_Down(null, null);
			else if (dr == DialogResult.No)
				Application.Exit();
		}

		public void btnGenerate_Down(object sender, MouseEventArgs e)
		{
			sudoku = new Sudoku(true, true);
		}

		public void btnEnd_Down(object sender, MouseEventArgs e)
		{
			DialogResult dr = MessageBox.Show("Opravdu si přejete ukončit Sudoku?", "Konec", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (dr == DialogResult.Yes)
				Application.Exit();
		}

		public void rtb_TextChanged(object sender, EventArgs e)
		{
			if (sudoku == null)
				return;
			RichTextBox rtb = (sender as RichTextBox);
			string input = rtb.Text;
			if (!DataValidator.IsValidInput(input))
			{
				rtb.Text = "";
				return;
			}
			int x = int.Parse(rtb.Name[3].ToString());
			int y = int.Parse(rtb.Name[5].ToString());
			sudoku.data[x][y] = int.Parse(input);
		}

		public void btnShowSolution_Down(object sender, MouseEventArgs e)
		{
			UI.ShowSudoku(sudoku);
		}
	}
}
