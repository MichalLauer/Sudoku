using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class SudokuGenerator
    {
        private static DataValidator validator = new DataValidator();

        public static void Generate(Sudoku sudoku)
        {
            Randomize(sudoku);
            for (int radek = 1 ; radek < 9;)
            {
				for (int sloupec = 0; ;)
				{
                    sudoku.data[radek][sloupec]++;
                    if (DataValidator.Row.IsValid(Sudoku.GetRow(sudoku, radek)) &&
                        DataValidator.Column.IsValid(Sudoku.GetColumn(sudoku, sloupec)) &&
                        DataValidator.Square.IsValid(Sudoku.GetSquare(sudoku, radek, sloupec)))
                    {
                        if (sloupec == 8)
						{
							radek++;
							break;
						}
						sloupec++;
						continue;
					}
                    while (sudoku.data[radek][sloupec] >= 9)
					{
						sudoku.data[radek][sloupec] = 0;
						if (sloupec == 0)
						{
							radek--;
							sloupec = 8;
						}
						else
							sloupec--;
					}
				}
            }
            
        }

        private static void Randomize(Sudoku sudoku)
        {
            Random rn = new Random();
            for (int i = 0; i < 9;)
            {
                int temp = rn.Next(1, 10);
                if (sudoku.data[0].Contains(temp))
                    continue;
                sudoku.data[0][i] = temp;
                i++;
            }
        }
    }
}
