using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
		/// <summary>
		/// The data of sudoku
		/// </summary>
        public int[][] data =
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


		public int[][] usersData =
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
		/// Index of randomly generated row
		/// </summary>
		public int VisibleElements { get; set; } = 20;

		/// <summary>
		/// Public constructor
		/// </summary>
		/// <param name="generate">Generate new Sudoku</param>
		public Sudoku(bool generate = false)
		{
			if (generate)
				Generate();
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
            SudokuGenerator.Generate(this);
        }

		/// <summary>
		/// Loads data from RichTextBoxes
		/// </summary>
		public void LoadData()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (UIManager.RichTextBoxes[i, j].Text == "")
						data[i][j] = 0;
					else
					{
						SolidNumbers
					}
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
                    output += $" {data[i][j]} ";
                output += "\n";
            }
            return output;

        }
    }
}
