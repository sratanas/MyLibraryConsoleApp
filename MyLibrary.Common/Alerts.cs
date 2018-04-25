using MyLibrary.Business;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Common
{
    public static class Alerts
    {

        public static void AddedSomethingAlert(Media media)
        {

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"You added {media.Title}!");
            Console.ResetColor();
        }


        
        
        



    }
}
