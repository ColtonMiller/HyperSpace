using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            HyperSpace game = new HyperSpace();
            game.PlayGame();
        }
    }
    public class Unit
    {
        //properties
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }
        public bool IsSpaceRift { get; set; }
        //variables
        public static List<string> obsticalList = new List<string> {"*",".",":",";","\'","\""};
        static Random randomNumberGenerator = new Random();
        //methods
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
        }
        //constructor creates new obstical at random coordinate using Cyan as the color
        public Unit( int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Color = ConsoleColor.Cyan;
            this.Symbol = obsticalList[randomNumberGenerator.Next(0, obsticalList.Count - 1)];
        }
        //constructor creates new unit either ship or SpaceRift 
        public Unit(int x, int y, ConsoleColor color, string symbol, bool isSpaceRift)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            this.Symbol = symbol;
            this.IsSpaceRift = isSpaceRift;
        }
    }
    public class HyperSpace
    {
        //properties
        public int Score { get; set; }
        public int Speed { get; set; }
        public List<Unit> ObstacalList { get; set; }
        public Unit SpaceShip { get; set; }
        public bool Smashed { get; set; }
        //Variables 
        private Random randomNumberGenerator = new Random();
        //Methods
        public void PlayGame()
        {
            while (!Smashed)
            {
                if (randomNumberGenerator.Next(1,11) == 1)
                {
                    Unit spaceRift = new Unit(randomNumberGenerator.Next(0, 59), 5, ConsoleColor.Green, "%", true);
                    ObstacalList.Add(spaceRift);
                }
                else
                {
                    Unit obstacal = new Unit(randomNumberGenerator.Next(0, 59), 5);
                    ObstacalList.Add(obstacal);
                }
                MoveShip();
                MoveObstacles();
                DrawGame();
                if (this.Speed < 170)
                {
                    this.Speed += 1;
                    System.Threading.Thread.Sleep(170 - Speed);
                }
            }
        }
        public void MoveShip()
        {
            if (Console.KeyAvailable)
            {
                
                //variable to hold key pressed
                ConsoleKey keyPressed = Console.ReadKey().Key;
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (keyPressed == ConsoleKey.LeftArrow && SpaceShip.X > 0)
                {
                    SpaceShip.X--;
                }
                else if (keyPressed == ConsoleKey.RightArrow && SpaceShip.X < Console.WindowWidth - 2)
                {
                    SpaceShip.X++;
                }
            }
        }
        public void MoveObstacles()
        {
            List<Unit> newObstacleList = new List<Unit> { };
            foreach (Unit obstacle in ObstacalList)
            {
                obstacle.Y++;
                if (obstacle.IsSpaceRift == true && obstacle.X == SpaceShip.X && obstacle.Y == SpaceShip.Y)
                {
                    Speed -= 50;
                }
                if (obstacle.IsSpaceRift == false && obstacle.X == SpaceShip.X && obstacle.Y == SpaceShip.Y)
                {
                    Smashed = true;
                }
                if (obstacle.Y > 30)
                {
                    newObstacleList.Add(obstacle);
                }
                else
                {
                    Score++;
                }
            }
            ObstacalList = newObstacleList;
        }
        public void DrawGame()
        {
            Console.Clear();
            SpaceShip.Draw();
            foreach (Unit obstacle in ObstacalList)
            {
                obstacle.Draw();
            }
            PrintAtPosition(20, 2, "Score: " + Score, ConsoleColor.Green);
            PrintAtPosition(20, 3, "Speed: " + this.Speed, ConsoleColor.Green);
            
        }
        public void PrintAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
        //Constructor
        public HyperSpace()
        {
            this.Score = 0;
            this.Speed = 0;
            this.ObstacalList = new List<Unit> {};
            Console.BufferHeight = 30;
            Console.WindowHeight = 30;
            Console.BufferWidth = 60;
            Console.WindowWidth = 60;
            //initialize SpaceShip 
           this.SpaceShip = new Unit(19, 29, ConsoleColor.Red, "@", false);
            
        }
    }
}
