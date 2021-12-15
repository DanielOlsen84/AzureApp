using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureApp.Models
{

    // Based on the Kruskals algorithm, written in C# by Daniel Olsen, September 2021
    //
    // Prints a random maze with █ as walls and spacecharacters inbetween.
    // Call RandomMaze.DrawMaze(int mazeWidth, int mazeHeight); to print out a maze.
    // The actual size will be ((mazeWidth * 2) + 1) characters.
    //
    // There is no size limit, but too big will generate an error of too small bufferSize.
    //
    // Calling RandomMaze.GenerateBoard(int mazeWidth, int mazeHeight); will return the maze as an int[,] with 1 for wall and 0 for space. 
    //
    //

    class RandomMazeModel
    {
        public class Cell
        {
            //public bool Visited { get; set; }
            public List<int> CellListX { get; set; }
            public List<int> CellListY { get; set; }
            public bool NWall { get; set; }
            public bool EWall { get; set; }
            public bool SWall { get; set; }
            public bool WWall { get; set; }
            public int treeNr { get; set; }
            public Cell()
            {
                //Visited = false;
                CellListX = new List<int>();
                CellListY = new List<int>();
                NWall = true;
                EWall = true;
                SWall = true;
                WWall = true;
                treeNr = 0;
            }
        }

        static public string GetMazeAsString(int mazeWidth, int mazeHeight)
        {

            //int mazeWidth = 40;
            //int mazeHeight = 20;

            //Console.WindowHeight = mazeHeight * 2 + 1 + 5;
            //Console.WindowWidth = mazeWidth * 2 + 1 + 2;

            string s = "";
            char[,] cArr = new char[mazeWidth * 2 + 1, mazeHeight * 2 + 1];
            Cell[,] maze = new Cell[mazeWidth, mazeHeight];

            //Cell[,] maze2 = new Cell[10,10];

            //Console.Clear();

            for (int y = 0; y < mazeHeight * 2 + 1; y++)
            {
                for (int x = 0; x < mazeWidth * 2 + 1; x++)
                {
              //      Console.Write("█");
                    cArr[x, y] = '█';
                }
                //Console.WriteLine();
            }

            int treeCounter = 0;

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    maze[x, y] = new Cell();
                    maze[x, y].treeNr = treeCounter;
                    treeCounter++;
                    //Console.Write("1");
                }
                //Console.WriteLine();
            }

            maze = KruskalsAlgorithm(maze, mazeWidth, mazeHeight);

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    cArr[x * 2 + 1, y * 2 + 1] = ' ';
                    //Console.SetCursorPosition(x * 2 + 1, y * 2 + 1);
                    //Console.Write(" ");


                    //Console.SetCursorPosition(x * 2 + 1, (y * 2) - 1 + 1);
                    if (maze[x, y].NWall == true)
                    {
                        cArr[x * 2 + 1, (y * 2) - 1 + 1] = '█';
                        //Console.Write("");
                    }
                    else
                    {
                        cArr[x * 2 + 1, (y * 2) - 1 + 1] = ' ';
                        //Console.Write(" ");
                    }

                    //Console.SetCursorPosition((x * 2) + 1 + 1, y * 2 + 1);
                    if (maze[x, y].EWall == true)
                    {
                        cArr[(x * 2) + 1 + 1, y * 2 + 1] = '█';
                    }
                    else
                    {
                        cArr[(x * 2) + 1 + 1, y * 2 + 1] = ' ';
                    }

                    //Console.SetCursorPosition(x * 2 + 1, (y * 2) + 1 + 1);
                    if (maze[x, y].SWall == true)
                    {
                        cArr[x * 2 + 1, (y * 2) + 1 + 1] = '█';
                    }
                    else
                    {
                        cArr[x * 2 + 1, (y * 2) + 1 + 1] = ' ';
                    }

                    //Console.SetCursorPosition((x * 2) - 1 + 1, y * 2 + 1);
                    if (maze[x, y].WWall == true)
                    {
                        cArr[(x * 2) - 1 + 1, y * 2 + 1] = '█';
                    }
                    else
                    {
                        cArr[(x * 2) - 1 + 1, y * 2 + 1] = ' ';
                    }
                }
            }

            cArr[1, 1] = 'S';
            cArr[mazeWidth * 2 - 1, mazeHeight * 2 - 1] = 'F';


            for (int i = 0; i < mazeHeight * 2 + 1; i++)
            {
                for (int j = 0; j < mazeWidth * 2 + 1; j++)
                {
                    s = s + cArr[j, i];
                }
                s = s + "\n";
            }
            return s;
        }

        static public void DrawMaze(int mazeWidth, int mazeHeight)
        {

            //int mazeWidth = 40;
            //int mazeHeight = 20;

            //Console.WindowHeight = mazeHeight * 2 + 1 + 5;
            //Console.WindowWidth = mazeWidth * 2 + 1 + 2;


            Cell[,] maze = new Cell[mazeWidth, mazeHeight];
            
            //Cell[,] maze2 = new Cell[10,10];

            Console.Clear();

            for (int y = 0; y < mazeHeight * 2 + 1; y++)
            {
                for (int x = 0; x < mazeWidth * 2 + 1; x++)
                {
                    Console.Write("█");
                }
                Console.WriteLine();
            }

            int treeCounter = 0;

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    maze[x, y] = new Cell();
                    maze[x, y].treeNr = treeCounter;
                    treeCounter++;
                    //Console.Write("1");
                }
                //Console.WriteLine();
            }

            maze = KruskalsAlgorithm(maze, mazeWidth, mazeHeight);

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    Console.SetCursorPosition(x * 2 + 1, y * 2 + 1);
                    Console.Write(" ");

                    Console.SetCursorPosition(x * 2 + 1, (y * 2) - 1 + 1);
                    if (maze[x, y].NWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition((x * 2) + 1 + 1, y * 2 + 1);
                    if (maze[x, y].EWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition(x * 2 + 1, (y * 2) + 1 + 1);
                    if (maze[x, y].SWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition((x * 2) - 1 + 1, y * 2 + 1);
                    if (maze[x, y].WWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
             
        }

        static public int[,] GenerateBoard(int mazeWidth, int mazeHeight)
        {
            int[,] outMaze = new int[mazeWidth * 2 + 1, mazeHeight * 2 + 1];

            for (int y = 0; y < mazeHeight * 2 + 1; y++)
            {
                for (int x = 0; x < mazeWidth * 2 + 1; x++)
                {
                    outMaze[x, y] = 1;
                }
            }

            Cell[,] maze = new Cell[mazeWidth, mazeHeight];
            int treeCounter = 0;
            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    maze[x, y] = new Cell();
                    maze[x, y].treeNr = treeCounter;
                    treeCounter++;

                }

            }

            maze = KruskalsAlgorithm(maze, mazeWidth, mazeHeight);

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    outMaze[x * 2 + 1, y * 2 + 1] = 0;

                    if (maze[x, y].NWall == true)
                    {
                        outMaze[x * 2 + 1, (y * 2) - 1 + 1] = 1;

                    }
                    else
                    {
                        outMaze[x * 2 + 1, (y * 2) - 1 + 1] = 0;

                    }

                    if (maze[x, y].EWall == true)
                    {
                        outMaze[(x * 2) + 1 + 1, y * 2 + 1] = 1;
                    }
                    else
                    {
                        outMaze[(x * 2) + 1 + 1, y * 2 + 1] = 0;
                    }

                    if (maze[x, y].SWall == true)
                    {
                        outMaze[x * 2 + 1, (y * 2) + 1 + 1] = 1;
                    }
                    else
                    {
                        outMaze[x * 2 + 1, (y * 2) + 1 + 1] = 0;
                    }

                    if (maze[x, y].WWall == true)
                    {
                        outMaze[(x * 2) - 1 + 1, y * 2 + 1] = 1;
                    }
                    else
                    {
                        outMaze[(x * 2) - 1 + 1, y * 2 + 1] = 0;
                    }
                }
            }

            return outMaze;
        }

        static private Cell[,] KruskalsAlgorithm(Cell[,] maze, int mazeWidth, int mazeHeight)
        {
            Random rnd = new Random();

            int treeCounter = mazeWidth * mazeHeight;
            bool finished = false;

            while (!finished)
            {
                int rndCellX = 0;
                int rndCellY = 0;
                int rndDir = 0;
                bool validCellDir = false;
                while (!validCellDir)
                {
                    validCellDir = true;
                    rndCellX = rnd.Next(0, mazeWidth);
                    rndCellY = rnd.Next(0, mazeHeight);
                    rndDir = rnd.Next(0, 4);

                    if ((rndCellY == 0) && (rndDir == 0))
                        validCellDir = false;
                    if ((rndCellX == mazeWidth - 1) && (rndDir == 1))
                        validCellDir = false;
                    if ((rndCellY == mazeHeight - 1) && (rndDir == 2))
                        validCellDir = false;
                    if ((rndCellX == 0) && (rndDir == 3))
                        validCellDir = false;
                }

                bool isThereAWall = true;
                int nextCellX = 0;
                int nextCellY = 0;
                switch (rndDir)
                {
                    case (0):
                        {
                            nextCellX = rndCellX;
                            nextCellY = rndCellY - 1;

                            if (maze[rndCellX, rndCellY].NWall == false)
                                isThereAWall = false;

                            break;
                        }
                    case (1):
                        {
                            nextCellX = rndCellX + 1;
                            nextCellY = rndCellY;
                            if (maze[rndCellX, rndCellY].EWall == false)
                                isThereAWall = false;
                            break;
                        }
                    case (2):
                        {
                            nextCellX = rndCellX;
                            nextCellY = rndCellY + 1;
                            if (maze[rndCellX, rndCellY].SWall == false)
                                isThereAWall = false;
                            break;
                        }
                    case (3):
                        {
                            nextCellX = rndCellX - 1;
                            nextCellY = rndCellY;
                            if (maze[rndCellX, rndCellY].WWall == false)
                                isThereAWall = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                }

                if ((isThereAWall == true) && (maze[rndCellX, rndCellY].treeNr != maze[nextCellX, nextCellY].treeNr))
                {
                    int treeNrToChange = maze[nextCellX, nextCellY].treeNr;
                    for (int iX = 0; iX < mazeWidth; iX++)
                    {
                        for (int iY = 0; iY < mazeHeight; iY++)
                        {
                            if (maze[iX, iY].treeNr == treeNrToChange)
                                maze[iX, iY].treeNr = maze[rndCellX, rndCellY].treeNr;
                        }
                    }
                    //maze[nextCellX, nextCellY].treeNr = maze[rndCellX, rndCellY].treeNr;

                    switch (rndDir)
                    {
                        case (0):
                            {
                                maze[rndCellX, rndCellY].NWall = false;
                                maze[nextCellX, nextCellY].SWall = false;
                                break;
                            }
                        case (1):
                            {
                                maze[rndCellX, rndCellY].EWall = false;
                                maze[nextCellX, nextCellY].WWall = false;
                                break;
                            }
                        case (2):
                            {
                                maze[rndCellX, rndCellY].SWall = false;
                                maze[nextCellX, nextCellY].NWall = false;
                                break;
                            }
                        case (3):
                            {
                                maze[rndCellX, rndCellY].WWall = false;
                                maze[nextCellX, nextCellY].EWall = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("ERROR 2");
                                break;
                            }
                    }

                }

                int testTreeNr = maze[0, 0].treeNr;
                finished = true;
                for (int iX = 0; iX < mazeWidth; iX++)
                {
                    for (int iY = 0; iY < mazeHeight; iY++)
                    {
                        if (maze[iX, iY].treeNr != testTreeNr)
                            finished = false;
                    }
                }
                //JustDrawMaze(maze, mazeWidth, mazeHeight);
            }

            return maze;
        }

        static public void JustDrawMaze(Cell[,] maze, int mazeWidth, int mazeHeight)
        {

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    Console.SetCursorPosition(x * 2 + 1, y * 2 + 1);
                    //Console.Write(maze[x, y].treeNr);
                    Console.Write(" ");

                    Console.SetCursorPosition(x * 2 + 1, (y * 2) - 1 + 1);
                    if (maze[x, y].NWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        //Console.Write(maze[x, y].treeNr);
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition((x * 2) + 1 + 1, y * 2 + 1);
                    if (maze[x, y].EWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        //Console.Write(maze[x, y].treeNr);
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition(x * 2 + 1, (y * 2) + 1 + 1);
                    if (maze[x, y].SWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        //Console.Write(maze[x, y].treeNr);
                        Console.Write(" ");
                    }

                    Console.SetCursorPosition((x * 2) - 1 + 1, y * 2 + 1);
                    if (maze[x, y].WWall == true)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        //Console.Write(maze[x, y].treeNr);
                        Console.Write(" ");
                    }
                }
            }
        }
    }
}
