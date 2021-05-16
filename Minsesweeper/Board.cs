
using System;

namespace Minsesweeper
{
    partial class Program
    {
        public class Board
        {
            public int Size { get; set; }
            public Cell[,] Grid { get; set; }

            //add difficulty here
           
            public Board(int size)
            {
                Size = size;
                //set the size of the board 
                Grid = new Cell[Size, Size];
                //initialize each cell on the board
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[i, j] = new Cell(i, j);
                    }
                }
            }

            public void SetupLiveNeihbors()
            {
                Cell cell;
                //var result = decimal.ToDouble(decimal.Divide(difficulty, 100));
                //int percentage = Convert.ToInt32(result * (Size * Size));
                //Console.WriteLine(percentage);
                var random = new Random();
                //int randomNumber = random.Next(1, 20);
                //Console.WriteLine(randomNumber);
                for (int i = 0; i < Size; i++)
                {
                    int x = random.Next(1, Size);
                    int y = random.Next(1, Size);
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[x, y].IsLive = true;
                       
                    }
                }
            }

            public void CalculateLiveNeighbors(Cell cell)
            {
                if (IsSafe(cell.Rows +1, cell.Columns))
                {
                    if(Grid[cell.Rows + 1, cell.Columns].IsLive)
                        cell.NumberOfNeighborsLve++;
                }
                if (IsSafe(cell.Rows - 1, cell.Columns))
                {
                    if (Grid[cell.Rows - 1, cell.Columns].IsLive)
                        cell.NumberOfNeighborsLve++;
                }
                if (IsSafe(cell.Rows, cell.Columns+1))
                {
                    if (Grid[cell.Rows, cell.Columns+1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }
                if (IsSafe(cell.Rows, cell.Columns-1))
                {
                    if (Grid[cell.Rows, cell.Columns-1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }

                //Console.WriteLine(cell.NumberOfNeighborsLve);


            }

            public bool IsSafe(int x, int y)
            {
                if ((x < Size && y < Size) && (x >= 0 && y >= 0))
                    return true;
                else
                    return false;
            }
        }
    }
}
