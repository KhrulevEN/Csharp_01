using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Output
{
    static public class Output
    {

        static public void PrintXYColor(string msg, bool bWriteLine = true, int x = -1, int y = -1, ConsoleColor foregroundcolor = ConsoleColor.White)
        {
            if (x != -1 || y != -1)
            {
                Console.SetCursorPosition(x, y);
            }
            Console.ForegroundColor = foregroundcolor;
            if (bWriteLine)
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.Write(msg);
            }
        }
        static public void Pause()
        {
            Console.ReadKey();
        }
    }

}
