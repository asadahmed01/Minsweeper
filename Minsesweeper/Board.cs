
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

            public void MarkVisited(int x, int y)
            {
                if(IsSafe(x, y))
                    Grid[x, y].Visited = true;
            }

            public void SetupLiveNeihbors()
            {
                
                var random = new Random();
                
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

                if (IsSafe(cell.Rows-1, cell.Columns - 1))
                {
                    if (Grid[cell.Rows-1, cell.Columns - 1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }

                if (IsSafe(cell.Rows-1, cell.Columns + 1))
                {
                    if (Grid[cell.Rows - 1, cell.Columns + 1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }

                if (IsSafe(cell.Rows+1, cell.Columns + 1))
                {
                    if (Grid[cell.Rows +1 , cell.Columns + 1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }

                if (IsSafe(cell.Rows +1, cell.Columns - 1))
                {
                    if (Grid[cell.Rows + 1, cell.Columns - 1].IsLive)
                        cell.NumberOfNeighborsLve++;
                }

            }

            public void Floodfill(int row, int col)
            {
                if(IsSafe(row, col))
                {
                    if((!Grid[row, col].IsLive) && (!Grid[row, col].Visited) )
                    {
                        Grid[row, col].Visited = true;
                        if (Grid[row, col].NumberOfNeighborsLve > 0)
                        {
                            Grid[row, col].Visited = true;
                            return;
                        }
                        else
                        {


                            //flood fill the east
                            Floodfill(row + 1, col);
                            //flood fill to the west
                            Floodfill(row - 1, col);
                            //flood to the north
                            Floodfill(row, col + 1);
                            //to the south
                            Floodfill(row, col - 1);
                        }

                    }
                    
                }
            }

            public bool IsSafe(int x, int y)
            {
                if ((x >= 0 && x < Size) && (y >= 0 && y < Size))
                    return true;
                else
                    return false;
            }
        }
    }
}
