using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            Course c = new Course();

            while (playing)
            {
                while (!c.amountOfSwings())
                {
                    c.newSwing();
                    c.unitsToCup();
                    if (c.DistanceToCup <= 10 && c.DistanceToCup >= 1)
                    {
                        Console.WriteLine("YOU HIT THE CUP!");
                        playing = false;
                        break;
                    } 
                }
            }    
        }
    }
}
