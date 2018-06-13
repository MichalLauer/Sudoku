using System.Linq;

namespace SudokuApp
{
    class RowValidator : DataValidator
    {
		/// <summary>
		/// Checks whether the row is acceptable
		/// </summary>
		/// <param name="row">row of ints</param>
		/// <returns>Boolean of the Row state</returns>
		public override bool IsValid(int[] row)
        {
            //Lambda
            row = row.Where(x => x != 0).ToArray();
            int[] fixedRow = row.Distinct().ToArray();
            return fixedRow.Length == row.Length;
        }
    }
}
