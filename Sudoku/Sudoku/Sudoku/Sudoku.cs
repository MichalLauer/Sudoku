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
		/// The data of sudoku
		/// </summary>
		public bool[][] Metadata =
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
		/// The data of sudoku
		/// </summary>
		public int[][] Solution =
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
        /// Sudoku data of the game
        /// </summary>
        public int[][] Data =
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

        public void DisableMetadata()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    Metadata[i][j] = true;
        }

        /// <summary>
        /// Index of randomly generated row
        /// </summary>
        public int VisibleElements { get; set; } = 20;

		/// <summary>
		/// How much number should be generated
		/// </summary>
		public int RandomizedCount { get; private set; } = 20;

		/// <summary>
		/// Public constructor
		/// </summary>
		/// <param name="generate">Generate new Sudoku</param>
		public Sudoku(bool generate = false, bool fill = false)
		{
			if (generate)
				Generate();

			if (fill)
			{
				UI.ResetSudokuUI();
				UI.SetVisibleRichTextBoxes(this);
				UI.FillSudoku(this);
			}
		}

		/// <summary>
		/// Returns an int array of numbers in specified row
		/// </summary>
		/// <param name="sudoku">Sudoku to fetch the row from</param>
		/// <param name="rowIndex">index of the desired row</param>
		/// <returns>Int array</returns>
        public static int[] GetRow(int[][] sentData, int rowIndex)
        {
            return sentData[rowIndex];
        }

		/// <summary>
		/// Returns an int array of numbers in specified column
		/// </summary>
		/// <param name="sudoku">Sudoku to fetch the column from</param>
		/// <param name="columnIndex">index of the desired column</param>
		/// <returns>Int array</returns>
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
		/// <param name="sudoku">Sudoku to fetch the column from</param>
		/// <param name="rowIndex">Index of the row</param>
		/// <param name="columnIndex">Index of the column</param>
		/// <returns>Int array</returns>
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
        public void Generate()
        {
            this.Solution = SudokuGenerator.Generate(this).Solution;
        }

		/// <summary>
		/// Loads data from RichTextBoxes
		/// </summary>
		public void LoadDataFromRTBs()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					Solution[i][j] = (UIManager.RichTextBoxes[i, j].Text == "") ? 0 : int.Parse(UIManager.RichTextBoxes[i, j].Text);
				}
			}
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
