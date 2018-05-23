using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class ColumnValidator : DataValidator
    {
        public override bool IsValid(int[] column)
        {
            //Removes all duplicates
            int[] fixedRow = column.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedRow.Length == column.Length;
        }
    }
}
