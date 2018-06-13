using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
	class Sudoku
	{
		/// <summary>
		/// Metadata of sudoku. If number is editable, metadata = true
		/// </summary>
		public bool[][] Metadata { get; private set; } =
        {
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
            new bool[]{true,true,true,true,true,true,true,true,true },
        };

		/// <summary>
		/// Generated solution
		/// </summary>
		public int[][] Solution { get; set; } =
		{
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
			new int[]{0,0,0,0,0,0,0,0,0 },
		};

        /// <summary>
        /// Users data
        /// </summary>
        public int[][] Data { get; set; } =
        {
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
            new int[]{0,0,0,0,0,0,0,0,0 },
        };

        /// <summary>
        /// # of randomly shown nums
        /// </summary>
        public int VisibleElements { get; set; } = 20;

		/// <summary>
		/// # of how many numbers should be generated
		/// </summary>
		public int RandomizedCount { get; private set; } = 20;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="generate">If Sudoku should be generated</param>
        /// <param name="fill">If UI should be filled</param>
		public Sudoku(bool generate = false, bool fill = false)
		{
			if (generate)
				GenerateSolution();

			if (fill)
			{
				UI.ResetSudoku();
				UI.SetVisibleRichTextBoxes(this);
				UI.FillSudoku(this);
			}
		}

        /// <summary>
        /// Returns an int array of numbers in specified row
        /// </summary>
        /// <param name="sentData">Sudoku array</param>
        /// <param name="rowIndex">Index of desired row</param>
        /// <returns>Array of int</returns>
        public static int[] GetRow(int[][] sentData, int rowIndex)
        {
            return sentData[rowIndex];
        }

        /// <summary>
        /// Returns an int array of numbers in specified column
        /// </summary>
        /// <param name="sentData">Sudoku array</param>
        /// <param name="columnIndex">Index of desired column</param>
        /// <returns>Array of int</returns>
		public static int[] GetColumn(int[][] sentData, int columnIndex)
        {
            int[] retColumn = new int[9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (j == columnIndex)
                        retColumn[i] = sentData[i][j];
            return retColumn;
        }

        /// <summary>
        /// Returns an int array of numbers in specified square
        /// </summary>
        /// <param name="sentData">Sudoku array</param>
        /// <param name="rowIndex">Index of desired row </param>
        /// <param name="columnIndex">Index of desired column</param>
        /// <returns>Array of int</returns>
		public static int[] GetSquare(int[][] sentData, int rowIndex, int columnIndex)
        {
            int startRow = (rowIndex / 3) * 3;
            int startCol = (columnIndex / 3) * 3;
            int[] retSquare = new int[9];
            for(int i = 0, index = 0; i < 3; i++)
            {
                for(int j=0;j<3;j++, index++)
                {
                    retSquare[index] = sentData[startRow+i][startCol+j];
                }
            }
            return retSquare;
        }

		/// <summary>
		/// Generates new Sudoku array
		/// </summary>
        public void GenerateSolution()
        {
            this.Solution = SudokuGenerator.Generate(this).Solution;
        }

        /// <summary>
        /// Returns all values in the Sudoku
        /// </summary>
        /// <returns>String with all sudoku values</returns>
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    output += $" {Solution[i][j]} ";
                output += "\n";
            }
            return output;

        }
    }
}
