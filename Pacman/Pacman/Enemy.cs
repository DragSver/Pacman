using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    public class Enemy : MapObject
    {
        enum Direction { Top, Right, Down, Left }

        public char Symbol = '*';
        public ConsoleColor Color = ConsoleColor.Red;
        public MapObject HisLastStep;

        public void Move(Map map, Player player)
        {
            if (HisLastStep is Money)
            {
                map.MapObject[X, Y] = new Money();
                map.DrawInCoordinate(X, Y, new Money());
            }
            else
            {
                map.MapObject[X, Y] = null;
                map.DrawInCoordinate(X, Y, null);
            }
            if (!(map.MapObject[X, Y - 1] is Wall) && Y - player.Y > 0) HisLastStep = map.MapObject[X, --Y];
            else if (!(map.MapObject[X, Y + 1] is Wall) && Y - player.Y < 0) HisLastStep = map.MapObject[X, ++Y];
            else if (!(map.MapObject[X - 1, Y] is Wall) && X - player.X > 0) HisLastStep = map.MapObject[--X, Y];
            else if (!(map.MapObject[X + 1, Y] is Wall) && X - player.X < 0) HisLastStep = map.MapObject[++X, Y];
            map.MapObject[X, Y] = this;
            map.DrawInCoordinate(X, Y, this);
        }
        public void Stagin(MapObject[,] map, Player player)
        {
            var random = new Random();
            do
            {
                X = random.Next(1, map.GetLength(0));
                Y = random.Next(1, map.GetLength(1));
            }
            while (map[X, Y] is Wall || (X == player.X && Y == player.Y));
        }
        public bool PlayerDetection(Player player)
        {
            var x = X;
            var y = Y;
            if (((player.X == X++ || player.X == X--) && (player.Y == Y)) || ((player.Y == Y++ || player.Y == Y--) && (player.X == X)))
            {
                X = x; Y = y;
                return true;
            }
            else
            {
                X = x; Y = y;
                return false;
            }
        }
    }
}
