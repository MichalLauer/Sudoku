using System.Linq;

namespace SudokuApp
{
    class SquareValidator : DataValidator
    {
		/// <summary>
		/// Checks whether the square is acceptable
		/// </summary>
		/// <param name="square">square of ints</param>
		/// <returns>Boolean of the square state</returns>
		public override bool IsValid(int[] square)
        {
            //remove all 0s from row
            square = square.Where(x => x != 0).ToArray();
            //Removes all duplicates
            int[] fixedSquare = square.Distinct().ToArray();
            //If there were no duplicates, the length is equal
            return fixedSquare.Length == square.Length;
        }
    }
}
