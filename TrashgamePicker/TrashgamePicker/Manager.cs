using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashgamePicker
{
    internal class Manager
    {
        public static List<string> GAMES = new List<string>();

        public static void PickGame()
        {
            Random rnd = new Random();
            int newID = Trashgame.ID;
            while (Trashgame.ID == newID)
            {
                newID = rnd.Next(0, GAMES.Count);
            }
            Trashgame.ID = newID;
            Trashgame.NAME = GAMES[Trashgame.ID];
        }
    }
}
