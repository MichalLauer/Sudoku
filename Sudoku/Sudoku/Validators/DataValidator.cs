using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class  DataValidator
    {
		/// <summary>
		/// Instance of Row Validator
		/// </summary>
        public static RowValidator Row { get; private set; } = new RowValidator();

		/// <summary>
		/// Instance of ColumnValidator
		/// </summary>
        public static ColumnValidator Column { get; private set; } = new ColumnValidator();

		/// <summary>
		/// Instance of SquareValidator
		/// </summary>
        public static SquareValidator Square { get; private set; } = new SquareValidator();

		/// <summary>
		/// IsValid method that is iherited by other classes
		/// </summary>
		/// <param name="data">Int of 9 integers</param>
		/// <returns></returns>
        public virtual bool IsValid(int[] data)
        {
            return true;
        }

		/// <summary>
		/// Checks whether the input is valid
		/// </summary>
		/// <param name="input">Users input</param>
		/// <returns>Boolean of input's state</returns>
        public static bool IsValidInput(string input)
        {
            //get if users input is valid
            //return boolean
            return true;
        }
    }
}
