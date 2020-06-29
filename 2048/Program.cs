using System;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }
        Model model;
        void Start() 
        {
            model = new Model(4);
            model.Start();
            model.points = 0;

            while (true)
            {
                Show();
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W: model.Up(); break;
                    case ConsoleKey.S: model.Down(); break;
                    case ConsoleKey.A: model.Left(); break;
                    case ConsoleKey.D: model.Right(); break;
                    case ConsoleKey.Escape: return;
                }
            }
        }

        void Show() 
        {
            Console.SetCursorPosition(0, 0);
            for (var x = 0; x < model.size; x++)
            {
                for (var y = 0; y < model.size; y++)
                    Console.Write($"{model.GetMap(x, y)}  ");
                Console.WriteLine();
            }
            if (model.IsGameOver())
            {
                Console.WriteLine("\nОчки: ", model.points);
            }
            else
            {
                Console.WriteLine($"\nИгра окончена\nВы набрали {model.points} очков");
            }
        }
    }
}
