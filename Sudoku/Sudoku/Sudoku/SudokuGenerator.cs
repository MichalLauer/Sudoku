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
            for (int radek = 0 ; radek < 9;)
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
							if (radek == 8)
								;
							break;
						}
						sloupec++;
						continue;
					}
					while (sudoku.data[radek][sloupec] == 9)
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
					////if data==9, then there is no correct number
					////else data++
					//if (sudoku.data[radek][sloupec] == 9)
					//{
					//	//reset this bubble of data
					//	sudoku.data[radek][sloupec] = 0;
					//	//if sloupec==0; then we have to go up by one
					//	if (sloupec == 0)
					//	{
					//		radek--;
					//		sloupec = 8;
					//		break;
					//	}
					//	sloupec--;
					//}
				}
            }
            
        }
    }
}
