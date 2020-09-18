using Pacman;
using System;
using System.Collections.Generic;

namespace NewNamespace
{
    class Program
    {
        static void Main()
        {
            var key = new ConsoleKeyInfo();
            var playerKilling = false;
            var map = new Map();
            map.Read();
            var player = new Player { X = 1, Y = 1 };
            map.MapObject[player.X, player.Y] = player;
            map.CreateEnemies(3, player);
            map.DrawAll();
            key = Console.ReadKey();
            do
            {
                player.Move(key, map);
                foreach (var enemy in map.Enemies)
                {
                    enemy.Move(map, player);
                    if (enemy.PlayerDetection(player)) playerKilling = true;
                }
                Console.SetCursorPosition(0, map.MapObject.GetLength(1));
                Score.Draw();
                key = Console.ReadKey();
            }
            while (key.Key != ConsoleKey.Enter && playerKilling == false);
            Console.Clear();
            Console.WriteLine("Game over. Your score - {0}", Score.Money);
            Console.ReadKey();
        }
    }

    interface IMovingObject
    {
        void Move();
    }
}