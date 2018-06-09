using System.Windows.Forms;

namespace SudokuApp
{
	class UIManager
	{
        /// <summary>
        /// Array[,] of all RichTextBoxes
        /// </summary>
		public static RichTextBox[,] RichTextBoxes { get; set; }

        /// <summary>
        /// Indexes in Array[,] of all Visible RichTextBoxes
        /// </summary>
		public static int[,] VisibleRtbs { get; set; }
	}
}
