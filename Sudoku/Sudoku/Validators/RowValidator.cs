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
            //remove all 0s from row
            row = row.Where(x => x != 0).ToArray();
            //Removes all duplicates
            int[] fixedRow = row.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedRow.Length == row.Length;
        }
    }
}
