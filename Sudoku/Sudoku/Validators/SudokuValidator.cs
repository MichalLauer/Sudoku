using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Validators
{
	class SudokuValidator
	{
		public static bool IsValid(Sudoku sudoku)
		{
			bool isCorrect = true;
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (!DataValidator.Row.IsValid(Sudoku.GetRow(sudoku.usersData, i)) ||
						!DataValidator.Column.IsValid(Sudoku.GetColumn(sudoku.usersData, j)) ||
						!DataValidator.Square.IsValid(Sudoku.GetSquare(sudoku.usersData, i, j)) ||
						UIManager.RichTextBoxes[i, j].Text == "")
					{
						UIManager.RichTextBoxes[i, j].BackColor = Color.Red;
						isCorrect = false;
					}
				}
			}
			return isCorrect;
		}
	}
}
