using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuApp
{
    class SudokuGenerator
    {
        private static DataValidator validator = new DataValidator();

		/// <summary>
		/// Algorithm to generate new sudoku 
		/// </summary>
		/// <param name="sudoku"></param>
        public static void Generate(Sudoku sudoku)
        {
            Randomize(sudoku);
			//skips first row, because it's randomly generated
            for (int row = 0 ; row < 9;)
            {
				for (int col = 0; ;)
				{
					if (sudoku.data[row][col] == 0)
						sudoku.data[row][col]++;
					if (DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.data, row)) &&
						DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.data, col)) &&
						DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.data, row, col)))
					{
						if (col == 8)
						{
							col = 0;
							row++;
							break;
						}
						else
							col++;
					}
					else
					{
						while (sudoku.data[row][col] >= 9)
						{
							sudoku.data[row][col] = 0;
							if (col == 0 && row == 0)
							{
								;
							}
							if (col == 0)
							{
								col = 8;
								row--;
							}
							else
								col--;
						}
						sudoku.data[row][col]++;
					}

				}
            }
            
        }

		/// <summary>
		/// Randomizes first row of the sudoku
		/// </summary>
		/// <param name="sudoku"></param>
        private static void Randomize(Sudoku sudoku)
        {
            Random rn = new Random();
			for (int i = 0; i < sudoku.RandomizedCount;)
			{
				int row = rn.Next(0, 9);
				int col = rn.Next(0, 9);
				if (sudoku.data[row][col] != 0)
					continue;
				else
					sudoku.data[row][col] = rn.Next(1, 10);
				if (DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.data, row)) &&
					DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.data, col)) &&
					DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.data, row, col)))
				{
					i++;
					sudoku.metadata[row][col] = false;
				}
				else
					sudoku.data[row][col] = 0;
			}
		}
    }
}
