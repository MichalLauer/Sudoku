using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuGenerator
    {
        private static DataValidator validator = new DataValidator();
        public static void Generate(Sudoku sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0, value = 1; j < 9;)
                {
                    sudoku.data[i][j] = value;
                    if (DataValidator.Row.IsValid(Sudoku.GetRow(sudoku, i)) &&
                        DataValidator.Column.IsValid(Sudoku.GetColumn(sudoku, j)) &&
                        DataValidator.Square.IsValid(Sudoku.GetSquare(sudoku, i, j)))
                    {
                        j++;
                        continue;
                    }
                    value++;
                    if (j == 1)
                    {
                        i = -2;
                        break;
                    }
                    if (value == 10)
                        value = sudoku.data[i][j=-1]+1;
                }
            }
            
        }
    }
}
