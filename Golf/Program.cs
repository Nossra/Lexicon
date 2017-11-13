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
            Course c = new Course();

            while (c.Playing)
            {
                while (!c.AmountOfSwings())
                {
                    c.NewSwing();
                    c.UnitsToCup();
                    
                    if (c.DistanceToCup <= c.TOLERANCE && c.DistanceToCup >= (c.TOLERANCE * -1))
                    {
                        Console.WriteLine("YOU HIT THE CUP!");
                        c.Playing = false;
                        break;                        
                    } 
                }
            }    
        }
    }
}
