using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashgamePicker
{
    internal class ErrorHandler
    {
        private static readonly Dictionary<int, string> ERRORS = new()
        {
            { 0, "Datei wurde nicht gefunden." },
            { 1, "Datei konnte nicht gelesen werden." },
            { 2, "Auf Datei konnte nicht zugegriffen werden." },
        };

        public enum Code
        {
            FILE_NOT_FOUND,
            FILE_READ_ERROR,
            FILE_ACCESS_DENIED,
        }

        public static void Message(Code code)
        {
            MainWindow.Message($"Errorcode {(int)code}: {ERRORS[(int)code]}");
            Environment.Exit(0);
        }
    }
}
