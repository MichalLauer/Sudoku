using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SudokuApp
{
    class  DataValidator
    {
		/// <summary>
		/// Instance of Row, Column, Square and Sudoku Validator
		/// </summary>
        public static RowValidator RowVal { get; private set; } = new RowValidator();
        public static ColumnValidator ColumnVal { get; private set; } = new ColumnValidator();
        public static SquareValidator SquareVal { get; private set; } = new SquareValidator();
        public static SudokuValidator SudokuVal { get; private set; } = new SudokuValidator();

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
        /// IsValid method that checks Sudoku
        /// </summary>
        /// <param name="sudoku">Sudoku to check</param>
        /// <returns></returns>
        public virtual bool IsValid(Sudoku sudoku)
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
			return Regex.IsMatch(input, "^[1-9]$");
        }
    }
}
