using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman
{
    public static class Score
    {
        public static int Money = 0;
        public static void Account()
        {
            Money++;
        }
        public static void Draw()
        {
            Console.WriteLine("Score: {0}", Money);
        }
    }
}
