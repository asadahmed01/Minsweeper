using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minsesweeper
{
    partial class Program
    {
        static Board board = new Board(8);
        static void Main(string[] args)
        {
            
            printBoard(board);
            board.SetupLiveNeihbors();
            
            printBoard(board);
            
            Console.ReadLine();
        }

        private static void printBoard(Board board)
        {
            Cell cell;
            
            Console.WriteLine(" =================================");
            //the outer loop is for the row
            for (int i = 0; i < board.Size; i++)
            {
               
                //the inner loop is for columns
                for (int j = 0; j < board.Size; j++)
                {
                    
                    cell = board.Grid[i, j];
                    board.CalculateLiveNeighbors(cell);
                    if (cell.IsLive)
                    {

                        Console.Write(" | ");
                        Console.Write("*");
                        
                    }

                    else if (cell.NumberOfNeighborsLve > 0)
                    {
                        Console.Write(" | ");
                        Console.Write(cell.NumberOfNeighborsLve);
                    }
                    else
                    {
                        Console.Write(" | ");
                        Console.Write("o");
                    }

                    



                }
                
                Console.Write(" | ");
                Console.Write(i);
                Console.WriteLine();
                
            }
            
            Console.WriteLine(" =================================");
        }
    }
}
