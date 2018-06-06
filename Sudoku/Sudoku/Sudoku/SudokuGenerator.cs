﻿using System;
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
            for (int row = 1 ; row < 9;)
            {
				for (int col = 0; ;)
				{
                    sudoku.data[row][col]++;
					//Checks if the value is acceptable
                    if (DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.data, row)) &&
                        DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.data, col)) &&
                        DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.data, row, col)))
                    {
						//if is on the end of a row
                        if (col == 8)
						{
							row++;
							break;
						}
						col++;
						continue;
					}
					//Goes back untill you can raise the value by 1
                    while (sudoku.data[row][col] >= 9)
					{
						sudoku.data[row][col] = 0;
						if (col == 0)
						{
							row--;
							col = 8;
						}
						else
							col--;
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
            for (int i = 0; i < 9;)
            {
                int temp = rn.Next(1, 10);
                if (sudoku.data[0].Contains(temp))
                    continue;
                sudoku.data[0][i] = temp;
                i++;
            }
        }
    }
}
