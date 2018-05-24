using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class RowValidator : DataValidator
    {
        public override bool IsValid(int[] row)
        {
            //remove all 0s from row
            row = row.Where(x => x != 0).ToArray();
            //Removes all duplicates
            int[] fixedRow = row.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedRow.Length == row.Length;
        }
    }
}
