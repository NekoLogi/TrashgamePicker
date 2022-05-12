using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashgamePicker
{
    internal class FileManager
    {
        public static bool DeleteGame()
        {
            if (File.Exists(Settings.PATH))
            {
                try
                {
                    Manager.GAMES.RemoveAt(Trashgame.ID);
                    File.Delete(Settings.PATH!);
                    File.WriteAllLines(Settings.PATH!, Manager.GAMES);
                    return true;
                }
                catch (Exception)
                {
                    ErrorHandler.Message(ErrorHandler.Code.FILE_ACCESS_DENIED);
                    return false;
                }

            }
            ErrorHandler.Message(ErrorHandler.Code.FILE_NOT_FOUND);
            return false;
        }

        public static List<string>? LoadGames()
        {
            if (File.Exists(Settings.PATH))
            {
                try
                {
                    Manager.GAMES.Clear();
                    return File.ReadLines(Settings.PATH!).ToList();
                }
                catch (Exception)
                {
                    ErrorHandler.Message(ErrorHandler.Code.FILE_READ_ERROR);
                    return null;
                }
            }
            ErrorHandler.Message(ErrorHandler.Code.FILE_NOT_FOUND);
            return null;
        }
    }
}
