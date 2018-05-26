using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
	class UIManager
	{
		public static RichTextBox[,] RichTextBoxes { get; set; }

		public static int[,] VisibleRtbs { get; set; }
	}
}
