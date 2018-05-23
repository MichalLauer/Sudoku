using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
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

        public static int[] GetRow(Sudoku sudoku, int rowIndex)
        {
            return sudoku.data[rowIndex];
        }

        public static int[] GetColumn(Sudoku sudoku, int columnIndex)
        {
            int[] retColumn = new int[9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (j == columnIndex)
                        retColumn[i] = sudoku.data[i][j];
            return retColumn;
        }

        public static int[] GetSquare(Sudoku sudoku, int rowIndex, int columnIndex)
        {
            int sqrRowIndex = rowIndex / 3;
            int sqrColIndex = columnIndex / 3;
            int[] retSquare = new int[9];
            for(int i = 0; i < 3; i++)
            {
                for(int j=0;j<3;j++)
                {
                    retSquare[(i*3)+j] = sudoku.data[i+(3*sqrColIndex)][j + (3 * sqrColIndex)];
                }
                sqrColIndex++;
            }
            return retSquare;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    output += $" {data[i][j]} ";
                output += "\n";
            }
            return output;

        }
    }
}
