using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Sudoku
{
	class UI
	{
		public static void CreateFormUI(Form form)
		{
			form.FormBorderStyle = FormBorderStyle.None;
			form.Size = new Size(615, 207);
			form.WindowState = FormWindowState.Normal;
			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - form.Size.Width / 2,
									  Screen.PrimaryScreen.Bounds.Height / 2 - form.Size.Height / 2);
		}

		public static void CreateSudokuUI(Form1 form)
		{
			UIManager.RichTextBoxes = new RichTextBox[9, 9];
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					int x = (j >= 3 && j < 6) ? 14 + 20 * j : (j >= 6 && j < 9) ? 18 + 20 * j : 10 + 20 * j;
					int y = (i >= 3 && i < 6) ? 14 + 20 * i : (i >= 6 && i < 9) ? 18 + 20 * i : 10 + 20 * i;
					RichTextBox rtb = new RichTextBox()
					{
						Size = new Size(20, 20),
						Margin = new Padding(0, 0, 0, 0),
						Parent = form,
						Location = new Point(201+x, y),
						SelectionAlignment = HorizontalAlignment.Center,
						MaxLength = 1,
						BackColor = Color.White,
						Tag = $"{i}-{j}"
					};
					rtb.TextChanged += new EventHandler(form.rtb_TextChanged);
					UIManager.RichTextBoxes[i,j] = rtb;
				}
			}
		}

		public static void ResetSudokuUI(Sudoku sudoku)
		{
			foreach (RichTextBox item in UIManager.RichTextBoxes)
			{
				item.BackColor = Color.White;
				item.Text = "";
				item.ReadOnly = false;
			}
		}

		public static void CreateInterface(Form1 form)
		{
			Button btnReset = new Button()
			{
				Text = "Resetovat Sudoku",
				Size = new Size(200, 45),
				Location = new Point(400, 10),
				Parent = form
			};

			Button btnCheck = new Button()
			{
				Text = "Zkontrolovat Sudoku",
				Size = new Size(200, 45),
				Location = new Point(400, 57),
				Parent = form
			};

			Button btnGenerate = new Button()
			{
				Text = "Znovu vygenerovat Sudoku",
				Size = new Size(200, 45),
				Location = new Point(400, 105),
				Parent = form
			};

			Button btnEnd = new Button()
			{
				Text = "Ukoncit Sudoku",
				Size = new Size(200, 45),
				Location = new Point(400, 152),
				Parent = form
			};

			Button btnShowSolution = new Button()
			{
				Text = "Ukazat vygen. reseni",
				Size = new Size(200, 45),
				Location = new Point(10, 10),
				Parent = form
			};

			Button btnCustom = new Button()
			{
				Text = "Vlastni sudoku",
				Size = new Size(200, 45),
				Location = new Point(10, 57),
				Parent = form
			};

			Button btnSolve = new Button()
			{
				Text = "Vyresit Sudoku",
				Size = new Size(200, 45),
				Location = new Point(10, 57),
				Parent = form
			};

			btnReset.MouseDown += new MouseEventHandler(form.btnReset_Down);
			btnCheck.MouseDown += new MouseEventHandler(form.btnCheck_Down);
			btnGenerate.MouseDown += new MouseEventHandler(form.btnGenerate_Down);
			btnEnd.MouseDown += new MouseEventHandler(form.btnEnd_Down);
			btnShowSolution.MouseDown += new MouseEventHandler(form.btnShowSolution_Down);
			btnCustom.MouseDown += new MouseEventHandler(form.btnCustom_Down);
			btnSolve.MouseDown += new MouseEventHandler(form.btnSolve_Down);
		}

		public static void ShowSudoku(Sudoku sudoku)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					UIManager.RichTextBoxes[i, j].Text = sudoku.data[i][j].ToString();
				}
			}
		}

		public static void Fill(Sudoku sudoku, bool reset = false, bool generateNew = true)
		{
			if (reset)
				ResetSudokuUI(sudoku);
			//show random 20 elements
			if (generateNew)
			{
				GenerateVisibleElements(sudoku);
			}
			for (int i = 0; i < sudoku.VisibleElements; i++)
			{
				int x = UIManager.VisibleRtbs[i, 0];
				int y = UIManager.VisibleRtbs[i, 1];
				UIManager.RichTextBoxes[x, y].Text = sudoku.data[x][y].ToString();
				UIManager.RichTextBoxes[x, y].ReadOnly = true;
				UIManager.RichTextBoxes[x, y].BackColor = Color.FromArgb(230, 230, 230);
			}
		}

		public static void GenerateVisibleElements(Sudoku sudoku)
		{
			UIManager.VisibleRtbs = new int[sudoku.VisibleElements, 2];
			Random rn = new Random();
			bool exists;
			for (int i = 0; i < sudoku.VisibleElements;)
			{
				int x = rn.Next(0, 9);
				int y = rn.Next(0, 9);
				exists = false;
				for (int j = 0; j < sudoku.VisibleElements; j++)
				{
					if (UIManager.VisibleRtbs[j, 0] == x && UIManager.VisibleRtbs[j, 1] == y)
					{
						exists = true;
						break;
					}
				}
				if (exists)
					continue;
				UIManager.VisibleRtbs[i, 0] = x;
				UIManager.VisibleRtbs[i, 1] = y;
				i++;
			}
		}
	}
}
