﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SquareValidator : DataValidator
    {
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
