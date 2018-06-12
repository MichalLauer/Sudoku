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
			for (int row = 0 ; row < 9;)
            {
				for (int col = 0; ;)
				{
                    if (!sudoku.metadata[row][col])
                    {
                        if (col == 8)
                        {
                            col = 0;
                            row++;
                            break;
                        }
                        else
                            col++;
                        continue;
                    }
					else
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
						while (sudoku.data[row][col] >= 9 || !sudoku.metadata[row][col])
						{
                            if (sudoku.metadata[row][col])
                                sudoku.data[row][col] = 0;
							if (col == 0 && row == 0)
							{
                                sudoku.DisableMetadata();
                                row = 0;
                                col = 0;
                                break;
							}
							if (col == 0)
							{
								col = 8;
								row--;
							}
							else
								col--;
						}
					}

				}
            }

			for (int i = 0; i < 9; i++)
				for (int j = 0; j < 9; j++)
					sudoku.solution[i][j] = sudoku.data[i][j];

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
                    sudoku.metadata[row][col] = false;
					i++;
				}
				else
					sudoku.data[row][col] = 0;
			}
		}
    }
}
