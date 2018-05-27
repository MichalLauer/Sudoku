using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Validators
{
    class ColumnValidator : DataValidator
    {
		/// <summary>
		/// Checks whether the column is acceptable
		/// </summary>
		/// <param name="column">Column of ints</param>
		/// <returns>Boolean of the Column state</returns>
        public override bool IsValid(int[] column)
        {
            //remove all 0s from row
            column = column.Where(x => x != 0).ToArray();
            //Removes all duplicates
            int[] fixedColumn = column.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedColumn.Length == column.Length;
        }
    }
}
