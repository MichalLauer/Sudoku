using System;
using System.Windows.Forms;
using System.Drawing;


namespace SudokuApp
{
	class UI
	{
        /// <summary>
        /// Sets Form to it's proper looks
        /// </summary>
        /// <param name="form">Form to change</param>
		public static void CreateForm(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.None;
			form.Size = new Size(415, 207);
			form.WindowState = FormWindowState.Normal;
			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - form.Size.Width / 2,
									  Screen.PrimaryScreen.Bounds.Height / 2 - form.Size.Height / 2);
		}

        /// <summary>
        /// Creates UI for Sudoku
        /// </summary>
        /// <param name="form">Form to create Sudoku on</param>
		public static void CreateSudoku(Form1 form)
		{
			UIManager.RichTextBoxes = new RichTextBox[9, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					//center - right - left
					int x = (j >= 3 && j < 6) ? 14 + 20 * j : (j >= 6 && j < 9) ? 18 + 20 * j : 10 + 20 * j;
					int y = (i >= 3 && i < 6) ? 14 + 20 * i : (i >= 6 && i < 9) ? 18 + 20 * i : 10 + 20 * i;
					RichTextBox rtb = new RichTextBox()
					{
						Size = new Size(20, 20),
						Margin = new Padding(0, 0, 0, 0),
						Parent = form,
						Name = $"rtb{i}-{j}",
						Location = new Point(x, y),
						SelectionAlignment = HorizontalAlignment.Center,
						MaxLength = 1,
						BackColor = Color.White,
						Tag = "Hidden"
					};
					rtb.TextChanged += new EventHandler(form.rtb_TextChanged);
					UIManager.RichTextBoxes[i,j] = rtb;
				}
			}
		}

		/// <summary>
		/// Create interface that user comunicates on
		/// </summary>
		/// <param name="form">Form to create interface on</param>
		public static void CreateInterface(Form1 form)
		{
			Button btnReset = new Button()
			{
				Text = "Resetovat Sudoku",
				Size = new Size(200, 30),
				Location = new Point(200, 10),
				Parent = form
			};

			Button btnCheck = new Button()
			{
				Text = "Zkontrolovat Sudoku",
				Size = new Size(200, 30),
				Location = new Point(200, 50),
				Parent = form
			};

			Button btnGenerate = new Button()
			{
				Text = "Znovu vygenerovat Sudoku",
				Size = new Size(200, 30),
				Location = new Point(200, 90),
				Parent = form
			};

			Button btnShowSolution = new Button()
			{
				Text = "Ukazat vygen. reseni",
				Size = new Size(200, 30),
				Location = new Point(200, 130),
				Parent = form
			};

			Button btnEnd = new Button()
			{
				Text = "Ukoncit Sudoku",
				Size = new Size(200, 30),
				Location = new Point(200, 170),
				Parent = form
			};

			btnReset.MouseDown += new MouseEventHandler(form.btnReset_Down);
			btnCheck.MouseDown += new MouseEventHandler(form.btnCheck_Down);
			btnGenerate.MouseDown += new MouseEventHandler(form.btnGenerate_Down);
			btnEnd.MouseDown += new MouseEventHandler(form.btnEnd_Down);
			btnShowSolution.MouseDown += new MouseEventHandler(form.btnShowSolution_Down);
		}

		/// <summary>
		/// Fully resets sudoku UI with proper Color, Text, ReadOnly and Tag
		/// </summary>
		public static void ResetSudoku()
		{
			foreach (RichTextBox item in UIManager.RichTextBoxes)
			{
				item.BackColor = Color.White;
				item.Text = "";
				item.ReadOnly = false;
				item.Tag = "Hidden";
			}
		}

		/// <summary>
		/// Displays whole sudoku that has been generated
		/// </summary>
		/// <param name="sudoku">sudoku to show</param>
		public static void ShowSudoku(Sudoku sudoku)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					UIManager.RichTextBoxes[i, j].Text = sudoku.Solution[i][j].ToString();
				}
			}
		}

		/// <summary>
		/// Fills Sudoku Interface with its proper values
		/// </summary>
		public static void FillSudoku(Sudoku sudoku)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (UIManager.RichTextBoxes[i,j].Tag.ToString() == "Shown")
					{
						UIManager.RichTextBoxes[i, j].Text = sudoku.Solution[i][j].ToString();
                        UIManager.RichTextBoxes[i, j].ReadOnly = true;
						UIManager.RichTextBoxes[i, j].BackColor = Color.FromArgb(230, 230, 230);
						sudoku.Data[i][j] = sudoku.Solution[i][j];
					}
					else
					{
						UIManager.RichTextBoxes[i, j].Text = "";
						UIManager.RichTextBoxes[i, j].ReadOnly = false;
						UIManager.RichTextBoxes[i, j].BackColor = Color.White;
					}

				}
			}

		}

		/// <summary>
		/// Generate random elements that would be shown
		/// </summary>
		/// <param name="sudoku"></param>
		public static void SetVisibleRichTextBoxes(Sudoku sudoku)
		{
			Random rn = new Random();
			for (int i = 0; i < sudoku.VisibleElements;)
			{
				int x = rn.Next(0, 9);
				int y = rn.Next(0, 9);
				if (UIManager.RichTextBoxes[x, y].Tag.ToString() == "Hidden")
                {
                    UIManager.RichTextBoxes[x, y].Tag = "Shown";
					i++;
				}
			}
		}
	}
}
