using ChessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        //reference to the class Board. Contains the values of the board.
        static Board myBoard = new Board(8);

        // 2D array of buttons whose values are determined by myBoard.
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            comboBox1.Text = "Skoczek";
            comboBox2.Text = "Białe";
            //create buttons and place them into panel1
            int buttonSize = panel1.Width / myBoard.Size;

            //make the panel a perfect square
            panel1.Height = panel1.Width;

            //nested loops. create buttons and print them to the screeen
            
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    // add a click event to each button.
                    btnGrid[i, j].Click += Grid_Button_Click;

                    // add the new button to the panel.
                    panel1.Controls.Add(btnGrid[i, j]);

                    // set the location of the new button.
                    btnGrid[i, j].Location = new Point(i* buttonSize, j* buttonSize);

                    btnGrid[i, j].Tag = new Point(i, j);

                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            var king = new Bitmap(Chess.Properties.Resources.King);
            var quinn = new Bitmap(Chess.Properties.Resources.Quinn);
            var greenDot = new Bitmap(Chess.Properties.Resources.GreenDot);
            var rookBlack = new Bitmap(Chess.Properties.Resources.RookBlack);
            var rookWhite = new Bitmap(Chess.Properties.Resources.RookWhite);
            var knightWhite = new Bitmap(Chess.Properties.Resources.KnigtWhite);
            var knightBlack = new Bitmap(Chess.Properties.Resources.KnightBlack);
            var bishopBlack = new Bitmap(Chess.Properties.Resources.BishopBlack);
            var bishopWhite = new Bitmap(Chess.Properties.Resources.BishopWhite);
            var quinnBlack = new Bitmap(Chess.Properties.Resources.QuinnBlack);

            //get the row and col number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];

            //determine legal next moves
            myBoard.MarkNextLegalMove(currentCell, comboBox1.Text, comboBox2.Text);

            //update the text on each button

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                    if (myBoard.theGrid[i, j].CurrentlyOccupied == false)
                        btnGrid[i, j].Image = null;
                    
                    if (myBoard.theGrid[i, j].LegalNextMove == true && myBoard.theGrid[i, j].CurrentlyOccupied == false)
                    {
                        btnGrid[i, j].Image = greenDot;
                    }
                    else if(myBoard.theGrid[i, j].LegalNextMove == true && myBoard.theGrid[i, j].CurrentlyOccupied == true && myBoard.theGrid[i, j].Color != comboBox2.Text)
                    {
                        btnGrid[i, j].BackColor = Color.Red;
                    }
                    else if (myBoard.theGrid[i, j] == currentCell)
                    {
                        switch (comboBox2.Text)
                        {
                            case "Białe":
                                switch (comboBox1.Text)
                                {
                                    case "Skoczek":
                                        btnGrid[i, j].Image = knightWhite;
                                        break;

                                    //case "King":
                                    //    btnGrid[i, j].Image = king;
                                    //    break;

                                    case "Wieża":
                                        btnGrid[i, j].Image = rookWhite;

                                        break;

                                    case "Goniec":

                                        btnGrid[i, j].Image = bishopWhite;

                                        break;

                                    case "Hetman":
                                        btnGrid[i, j].Image = quinn;

                                        break;

                                    default:

                                        break;

                                }


                                break;

                            case "Czarne":
                                switch (comboBox1.Text)
                                {
                                    case "Skoczek":
                                        btnGrid[i, j].Image = knightBlack;

                                        break;

                                    //case "King":
                                      
                                    //    break;

                                    case "Wieża":
                                        btnGrid[i, j].Image = rookBlack;

                                        break;

                                    case "Goniec":

                                        btnGrid[i, j].Image = bishopBlack;

                                        break;

                                    case "Hetman":
                                        btnGrid[i, j].Image = quinnBlack;

                                        break;

                                    default:

                                        break;

                                }

                                break;

                            default:

                                break;

                        }
                        
                    }
                }
            }


        }
    }
}
