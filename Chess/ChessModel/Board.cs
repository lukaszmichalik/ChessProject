using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class Board
    {
        public int Size { get; set; }

        public Cell[,] theGrid { get; set; }


        public Board (int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];

            for(int i = 0; i< Size; i++)
            {
                for(int j=0; j< Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMove(Cell currentCell, string chessPiece, string chessColor)
        {
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].Color = chessColor;

            //step 1 - clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    //theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            switch(chessPiece)
            {
                case "Skoczek" :
                    if(isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber +1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;


                    break;

                //case "King":

                //    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                //        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                //        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                //        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                //        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                //        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                //        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                //        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                //    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                //        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                //    break;

                case "Wieża":

                    bool access1 = true;
                    bool access2 = true;
                    bool access3 = true;
                    bool access4 = true;

                    for (int i = 1; i < Size; i++)
                    {

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber) && access1==true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].CurrentlyOccupied == true)
                                access1 = false;
                        }
                          

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber) && access2 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].CurrentlyOccupied == true)
                                access2 = false;
                        }

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i) && access3 == true)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access3 = false;
                        }


                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i) && access4 == true)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access4 = false;
                        }
                    }
                    break;

                case "Goniec":


                    bool access5 = true;
                    bool access6 = true;
                    bool access7 = true;
                    bool access8 = true;

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i) && access5 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access5 = false;
                        }

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i) && access6 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access6 = false;
                        }

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i) && access7 == true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access7 = false;
                        }



                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i) && access8 == true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access8 = false;
                        }
                    }

                    break;

                case "Hetman":
                    bool access9 = true;
                    bool access10 = true;
                    bool access11 = true;
                    bool access12 = true;
                    bool access13 = true;
                    bool access14 = true;
                    bool access15 = true;
                    bool access16 = true;

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber) && access9 == true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].CurrentlyOccupied == true)
                                access9 = false;
                        }


                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber) && access10 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].CurrentlyOccupied == true)
                                access10 = false;
                        }

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i) && access11 == true)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access11 = false;
                        }


                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i) && access12 == true)
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access12 = false;
                        }

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i) && access13 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access13 = false;
                        }

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i) && access14 == true)
                        {
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access14 = false;
                        }

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i) && access15 == true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].CurrentlyOccupied == true)
                                access15 = false;
                        }



                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i) && access16 == true)
                        {
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                            if (theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].CurrentlyOccupied == true)
                                access16 = false;
                        }
                    }

                    break;

                default:

                    break;

            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool isSafe(int v1, int v2)
        {
            if (v1 >= 0 && v1 <= 7 && v2 >= 0 && v2 <= 7)
                return true;
            else
                return false;
        }
    }
}
