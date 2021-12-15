using AzureApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureApp.Controllers
{
    public class RandomMazeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RandomMaze()
        {
            string s = RandomMazeModel.GetMazeAsString(40, 20);
            //int[,] maze = RandomMaze.GenerateBoard(90, 40);

            //for (int y = 0; y < 40; y++)
            //{
            //    for (int x = 0; x < 90; x++)
            //    {
            //        s = s + maze[x, y];
            //    }
            //    s = s + "\n";
            //}

            return View("Maze", s);
            //return Ok(s);
        }
    }
}
