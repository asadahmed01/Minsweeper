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

            //printBoard(board);
            //board.SetupLiveNeihbors();
            //printBoard(board);
            //DisplayCurrentBoard(board);
            string x;
            string y;
            Console.WriteLine("Enter X and Y coordinates or 'x' to Quit:");
            board.SetupLiveNeihbors();
            printBoard(board);
            while (true)
            {
                Console.WriteLine("Enter X coordinate:");
                x = Console.ReadLine();

                Console.WriteLine("Enter Y coordinate:");
                y = Console.ReadLine();
                if (x.Trim() == "x" || y.Trim() == "x")
                    break;
                //board.MarkVisited(Convert.ToInt32(x), Convert.ToInt32(y));
                board.Floodfill(Convert.ToInt32(y), Convert.ToInt32(x));
                DisplayCurrentBoard(board, Convert.ToInt32(y), Convert.ToInt32(x));
            }
            Console.WriteLine("Press Enter to Exit...");
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
                Console.Write(i+1);
                Console.WriteLine();
                
            }
            
            Console.WriteLine(" =================================");
        }


        private static void DisplayCurrentBoard(Board board, int x, int y)
        {
            Console.WriteLine(" =================================");
            Cell cell;
            for (int i = 0; i < board.Size; i++)
            {
                for (int k = 0; k < board.Size; k++)
                {
                    cell = board.Grid[i, k];
                    
                   
                        
                    if (cell.Visited)
                    {
                        if (cell.IsLive)
                        {
                            Console.Write(" | ");
                            Console.Write("*");
                            //Environment.Exit(1);
                        }

                        if (cell.NumberOfNeighborsLve > 0)
                        {
                            Console.Write(" | ");
                            Console.Write(cell.NumberOfNeighborsLve);
                        }

                        else
                        {
                            Console.Write(" | ");
                            Console.Write("O");
                        }
                    }

                        

                        
                    //}

                    else
                    {
                        //if(cell.NumberOfNeighborsLve > 0)
                        //{
                        //    Console.Write(" | ");
                        //    Console.Write(cell.NumberOfNeighborsLve);
                        //}
                        //else
                        //{
                        //    Console.Write(" | ");
                        //    Console.Write("?");
                        //}
                        Console.Write(" | ");
                        Console.Write("?");

                    }

                }

                Console.Write(" | ");
                //Console.Write(i+1);
                Console.WriteLine();
            }

            Console.WriteLine(" =================================");
        }
    }
}
