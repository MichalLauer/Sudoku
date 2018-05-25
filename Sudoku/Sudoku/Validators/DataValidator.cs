using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class  DataValidator
    {
        public static RowValidator Row { get; private set; } = new RowValidator();
        public static ColumnValidator Column { get; private set; } = new ColumnValidator();
        public static SquareValidator Square { get; private set; } = new SquareValidator();

        public virtual bool IsValid(int[] data)
        {
            return true;
        }

        public static bool IsValid(Sudoku sudoku, int[] data)
        {
            sudoku.data[data[0]][data[1]] = data[2];
            if (DataValidator.Row.IsValid(Sudoku.GetRow(sudoku, data[0])) &&
                DataValidator.Column.IsValid(Sudoku.GetColumn(sudoku, data[1])) &&
                DataValidator.Square.IsValid(Sudoku.GetSquare(sudoku, data[0], data[1])))
            {
                return true;
            }
            sudoku.data[data[0]][data[1]] = 0;
            return false;
        }

        public static bool IsEditable(Sudoku sudoku, int row, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku.randomNums[i, 0] == row
                   && sudoku.randomNums[i, 1] == col)
                    return false;
            }
            return true;
        }

        public static bool IsValidInput(string input)
        {
            //get if users input is valid
            //return boolean
            return true;
        }
    }
}
