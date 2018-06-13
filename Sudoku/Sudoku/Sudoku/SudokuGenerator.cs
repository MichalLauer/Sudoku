using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuApp
{
    class SudokuGenerator
    {
        private static DataValidator validator = new DataValidator();

        /// <summary>
        /// Generates new sudoku
        /// </summary>
        /// <param name="sudoku"></param>
        public static Sudoku Generate(Sudoku sudoku)
        {
            //Whether randomize sudoku (recursion)
            Randomize(sudoku);
            DateTime dt = DateTime.Now;
            bool timeRanOut = false;
            for (int row = 0; row < 9;)
            {
                for (int col = 0; ;)
                {
                    //If is generating longer than # seconds
                    if (DateTime.Now.CompareTo(dt.AddSeconds(5)) > 0)
                    {
                        timeRanOut = true;
                        break;
                    }

                    //if is editable, else ++
                    if (!sudoku.Metadata[row][col])
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
                        sudoku.Solution[row][col]++;

                    //if is valid, else go back if 9 or uneditable
                    if (DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.Solution, row)) &&
                        DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.Solution, col)) &&
                        DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.Solution, row, col)))
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
                        while (sudoku.Solution[row][col] == 9 || !sudoku.Metadata[row][col])
                        {
                            if (sudoku.Metadata[row][col])
                                sudoku.Solution[row][col] = 0;

                            if (col == 0)
                            {
                                col = 8;
                                if (row != 0)
                                    row--;
                            }
                            else
                                col--;
                        }
                    }
                }
                //If time ran out
                if (timeRanOut)
                    break;
            }

            //If time ran out, then Sudoku has no solution
            if (timeRanOut)
            {
                sudoku = Generate(new Sudoku());
            }

            //return valid sudoku
            return sudoku;

        }

		/// <summary>
		/// Randomizes random # elements in Sudoku
		/// </summary>
		/// <param name="sudoku">Sudoku to randomize</param>
        private static void Randomize(Sudoku sudoku)
        {
            Random rn = new Random();
			for (int i = 0; i < sudoku.RandomizedCount;)
			{
				int row = rn.Next(0, 9);
				int col = rn.Next(0, 9);
				if (sudoku.Solution[row][col] != 0)
					continue;
				else
					sudoku.Solution[row][col] = rn.Next(1, 10);
				if (DataValidator.RowVal.IsValid(Sudoku.GetRow(sudoku.Solution, row)) &&
					DataValidator.ColumnVal.IsValid(Sudoku.GetColumn(sudoku.Solution, col)) &&
					DataValidator.SquareVal.IsValid(Sudoku.GetSquare(sudoku.Solution, row, col)))
				{
                    sudoku.Metadata[row][col] = false;
					i++;
				}
				else
					sudoku.Solution[row][col] = 0;
			}
		}
    }
}
