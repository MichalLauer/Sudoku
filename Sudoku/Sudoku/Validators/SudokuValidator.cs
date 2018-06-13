﻿using System.Drawing;

namespace SudokuApp
{
	class SudokuValidator : DataValidator
	{
        /// <summary>
        /// Checks if sudoku is valid
        /// </summary>
        /// <param name="sudoku">Sudoku to check</param>
        /// <returns>Whether the sudoku is valid</returns>
		public override bool IsValid(Sudoku sudoku)
		{
			bool isCorrect = true;
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
                    if ((!DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.Data, i)) ||
                        !DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.Data, j)) ||
                        !DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.Data, i, j)) ||
                        UIManager.RichTextBoxes[i, j].Text == "") && !UIManager.RichTextBoxes[i,j].ReadOnly) //if has number and is not ReadOnly
					{
						UIManager.RichTextBoxes[i, j].BackColor = Color.Red;
						isCorrect = false;
					}
					else
						UIManager.RichTextBoxes[i, j].BackColor = Color.White;
				}
			}
			return isCorrect;
		}
	}
}
