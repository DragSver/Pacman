using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pacman
{
    public class Player : MapObject
    {
        public char Symbol = '@';
        public ConsoleColor Color = ConsoleColor.Green;

        public void Move(ConsoleKeyInfo key, Map map)
        {
            if (key.Key == ConsoleKey.LeftArrow && !(map.MapObject[X - 1, Y] is Wall))
            {
                if (map.MapObject[X - 1, Y] is Money) Score.Account();
                map.MapObject[X, Y] = null;
                map.DrawInCoordinate(X, Y, null);
                map.MapObject[--X, Y] = this;
            }
            else if (key.Key == ConsoleKey.RightArrow && !(map.MapObject[X + 1, Y] is Wall))
            {
                if (map.MapObject[X + 1, Y] is Money) Score.Account();
                map.MapObject[X, Y] = null;
                map.DrawInCoordinate(X, Y, null);
                map.MapObject[++X, Y] = this;
            }
            else if (key.Key == ConsoleKey.UpArrow && !(map.MapObject[X, Y - 1] is Wall))
            {
                if (map.MapObject[X, Y - 1] is Money) Score.Account();
                map.MapObject[X, Y] = null;
                map.DrawInCoordinate(X, Y, null);
                map.MapObject[X, --Y] = this;
            }
            else if (key.Key == ConsoleKey.DownArrow && !(map.MapObject[X, Y + 1] is Wall))
            {
                if (map.MapObject[X, Y + 1] is Money) Score.Account();
                map.MapObject[X, Y] = null;
                map.DrawInCoordinate(X, Y, null);
                map.MapObject[X, ++Y] = this;
            }
            map.DrawInCoordinate(X, Y, this);
        }
    }
}
