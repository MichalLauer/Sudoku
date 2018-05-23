using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SquareValidator : DataValidator
    {
        public override bool IsValid(int[] square)
        {
            //Removes all duplicates
            int[] fixedRow = square.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedRow.Length == square.Length;
        }
    }
}
