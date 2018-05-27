using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku.Validators;

namespace Sudoku
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
			sudoku = new Sudoku(true);
			UI.CreateFormUI(this);
			UI.CreateInterface(this);
			UI.CreateSudokuUI(this);
			UI.Fill(sudoku, true);
		}

		public void btnReset_Down(object sender, MouseEventArgs e)
		{
			UI.ResetSudokuUI(sudoku);
			UI.Fill(sudoku, false, false);
		}

		public  void btnCheck_Down(object sender, MouseEventArgs e)
		{
			if (!SudokuValidator.IsValid(sudoku))
				return;

			DialogResult dr = MessageBox.Show("Vyhrali ste. JUPIIIIIIII! <3 <3 <3 <3 <3 <3\nPřejete si hrát znovu?", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (dr == DialogResult.Yes)
				btnGenerate_Down(null, null);
			else if (dr == DialogResult.No)
				Application.Exit();
		}

		public void btnGenerate_Down(object sender, MouseEventArgs e)
		{
			UI.ResetSudokuUI(sudoku);
			UI.Fill(sudoku);
		}

		public void btnEnd_Down(object sender, MouseEventArgs e)
		{
			DialogResult dr = MessageBox.Show("Opravdu si přejete ukončit Sudoku?", "Konec", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (dr == DialogResult.Yes)
				Application.Exit();
		}

		public void rtb_TextChanged(object sender, EventArgs e)
		{
			RichTextBox rtb = (sender as RichTextBox);
			string input = rtb.Text;
			if (!DataValidator.IsValidInput(input))
			{
				rtb.Text = "";
				return;
			}
			rtb.BackColor = Color.White;
			string[] indexes = rtb.Tag.ToString().Split('-').ToArray();
			sudoku.usersData[int.Parse(indexes[0])][int.Parse(indexes[1])] = int.Parse(input);
		}
	}
}
