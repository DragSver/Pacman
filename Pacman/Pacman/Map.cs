using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Pacman
{
    public class Map
    {
        enum MapObjects { Wall = '#', Enemy = '*', Player = '@', Empty = ' ', Money = '.' }

        public MapObject[,] MapObject;
        public List<Enemy> Enemies;

        public void Read()
        {
            var mapString = File.ReadAllLines("../../Map.txt");
            MapObject = new MapObject[mapString[0].Length, mapString.Length];
            for (int y = 0; y < MapObject.GetLength(1); y++)
            {
                for (int x = 0; x < MapObject.GetLength(0); x++)
                {
                    switch (mapString[y][x])
                    {
                        case (char)MapObjects.Wall:
                            MapObject[x, y] = new Wall();
                            break;
                        case (char)MapObjects.Empty:
                            MapObject[x, y] = null;
                            break;
                        case (char)MapObjects.Money:
                            MapObject[x, y] = new Money();
                            break;
                    }
                }
            }
        }
        public void DrawAll()
        {
            for (int y = 0; y < MapObject.GetLength(1); y++)
            {
                for (int x = 0; x < MapObject.GetLength(0); x++)
                {
                    if (MapObject[x, y] is Wall)
                    {
                        Console.ForegroundColor = ((Wall)MapObject[x, y]).Color;
                        Console.Write(((Wall)MapObject[x, y]).Symbol);
                        Console.ResetColor();
                    }
                    else if (MapObject[x, y] is Enemy)
                    {
                        Console.ForegroundColor = ((Enemy)MapObject[x, y]).Color;
                        Console.Write(((Enemy)MapObject[x, y]).Symbol);
                        Console.ResetColor();
                    }
                    else if (MapObject[x, y] is Player)
                    {
                        Console.ForegroundColor = ((Player)MapObject[x, y]).Color;
                        Console.Write(((Player)MapObject[x, y]).Symbol);
                        Console.ResetColor();
                    }
                    else if (MapObject[x, y] is Money)
                    {
                        Console.ForegroundColor = ((Money)MapObject[x, y]).Color;
                        Console.Write(((Money)MapObject[x, y]).Symbol);
                        Console.ResetColor();
                    }
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
            Score.Draw();
        }
        public void CreateEnemies(int quantity, Player player)
        {
            Enemies = new List<Enemy>();
            for (int i = 0; i < quantity; i++)
            {
                Enemies.Add(new Enemy());
                Enemies[i].Stagin(MapObject, player);
                Enemies[i].HisLastStep = MapObject[Enemies[i].X, Enemies[i].Y];
                MapObject[Enemies[i].X, Enemies[i].Y] = Enemies[i];
            }
        }
        public void DrawInCoordinate(int X, int Y, MapObject obj)
        {
            Console.SetCursorPosition(X, Y);
            if (obj is Wall)
            {
                Console.ForegroundColor = ((Wall)obj).Color;
                Console.Write(((Wall)obj).Symbol);
            }
            else if (obj is Enemy)
            {
                Console.ForegroundColor = ((Enemy)obj).Color;
                Console.Write(((Enemy)obj).Symbol);
            }
            else if (obj is Player)
            {
                Console.ForegroundColor = ((Player)obj).Color;
                Console.Write(((Player)obj).Symbol);
            }
            else if (obj is Money)
            {
                Console.ForegroundColor = ((Money)obj).Color;
                Console.Write(((Money)obj).Symbol);
            }
            else
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');
            }
            Console.ResetColor();
            Console.CursorVisible = false;
        }
    }
}
