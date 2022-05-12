using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TrashgamePicker
{
    internal class Settings
    {
        public static string? PATH { get; set; }


        public static bool Load()
        {
            if (File.Exists("Settings.xml"))
            {
                try
                {
                    using (var xml = new XmlTextReader("Settings.xml"))
                    {
                        while (xml.Read())
                        {
                            if (xml.NodeType == XmlNodeType.Element && xml.Name == "Path")
                            {
                                PATH = xml.ReadString();
                            }
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    ErrorHandler.Message(ErrorHandler.Code.FILE_READ_ERROR);
                    return false;
                }
            }
            ErrorHandler.Message(ErrorHandler.Code.FILE_NOT_FOUND);
            return false;
        }
    }
}
