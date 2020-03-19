using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, n;
            Console.WriteLine("Enter field size\n X = ");
            while (!int.TryParse(Console.ReadLine(), out x) && x <= 0) { }
            Console.WriteLine("Y = ");
            while (!int.TryParse(Console.ReadLine(), out y) && y <= 0) { }
            Console.WriteLine("Enter number of obstacles N =");
            while (!int.TryParse(Console.ReadLine(), out n) && n <= 0) { }

            //Generate
            bool[,] field = new bool[x, y];
            var rand = new Random((int)DateTime.UnixEpoch.Ticks);
            for (int i = 0; i < n; i++)
                field[rand.Next(x), rand.Next(y)] = true;

            Console.WriteLine("Move robot by WASD keys, rotate by QE.");
            int posX = x / 2, posY = y / 2, rotation = 0;
            while (true)
            {
                //Draw
                Console.Clear();
                for (int i = 0; i < y; i++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        if (k == posX && i == posY)
                            switch (rotation)
                            {
                                case 0: Console.Write("^"); break;
                                case 90: Console.Write(">"); break;
                                case 180: Console.Write("v"); break;
                                case 270: Console.Write("<"); break;
                            }
                        else if (field[k, i]) Console.Write("X");
                        else Console.Write(" ");
                    }
                    Console.Write("\n");
                }

                //Move
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        if (posY - 1 >= 0 && !field[posX, posY - 1]) posY--;
                        break;
                    case ConsoleKey.A:
                        if (posX - 1 >= 0 && !field[posX - 1, posY]) posX--;
                        break;
                    case ConsoleKey.S:
                        if (posY + 1 < y && !field[posX, posY + 1]) posY++;
                        break;
                    case ConsoleKey.D:
                        if (posX + 1 < x && !field[posX + 1, posY]) posX++;
                        break;
                    case ConsoleKey.Q:
                        rotation = rotation == 0 ? 270 : rotation - 90;
                        break;
                    case ConsoleKey.E:
                        rotation = rotation == 270 ? 0 : rotation + 90;
                        break;
                }
            }
        }
    }
}
