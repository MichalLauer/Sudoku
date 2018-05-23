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

        public static bool IsValidInput(string input)
        {
            //get if users input is valid
            //return boolean
            return true;
        }
    }
}
