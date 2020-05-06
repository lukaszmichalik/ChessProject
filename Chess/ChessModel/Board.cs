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

        public void MarkNextLegalMove(Cell currentCell, string chessPiece)
        {
            //step 1 - clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            switch(chessPiece)
            {
                case "Knight" :
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

                case "King":

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;

                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;

                    break;

                case "Rook":

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber+i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber+i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;

                case "Bishop":

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }

                    break;

                case "Quinn":

                    for (int i = 1; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;

                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
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
