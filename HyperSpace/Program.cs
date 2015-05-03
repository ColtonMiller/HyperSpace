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
        }
    }
    public class Unit
    {
        //properties
        int X { get; set; }
        int Y { get; set; }
        ConsoleColor Color { get; set; }
        string Symbol { get; set; }
        bool IsSpaceRift { get; set; }
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
                MoveObstacal();
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
                ConsoleKeyInfo keyPressed = new ConsoleKeyInfo();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (keyPressed )
                {
                    
                }
            }
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
           this.SpaceShip = new Unit(29, 29, ConsoleColor.Red, "@", false);
            
        }
    }
}
