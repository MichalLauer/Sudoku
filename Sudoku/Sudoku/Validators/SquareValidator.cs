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
            //Lambda
            square = square.Where(x => x != 0).ToArray();
            int[] fixedSquare = square.Distinct().ToArray();
            return fixedSquare.Length == square.Length;
        }
    }
}
