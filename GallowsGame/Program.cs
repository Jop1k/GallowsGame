using System;
using System.Text;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GallowsGame();

            while (true)
            {
                Console.WriteLine("Выбирайте: 1) Играть | 2) Выйти");
                string userAnswer = Console.ReadLine().ToLower();

                switch (userAnswer)
                {
                    case "1":
                    case "играть":
                        game.PlayGame();
                        Console.Clear();
                        break;
                    case "2":
                    case "выйти":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Такого выбора нет");
                        break;
                }
            }

        }
    }
}