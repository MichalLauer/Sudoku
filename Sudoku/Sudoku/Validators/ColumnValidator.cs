using System.Linq;

namespace SudokuApp
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
            //Lambda
            column = column.Where(x => x != 0).ToArray();
            int[] fixedColumn = column.Distinct().ToArray();
            return fixedColumn.Length == column.Length;
        }
    }
}
