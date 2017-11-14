using System;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);
            
            Course c = new Course(player);
            
            while (c.Playing)
            {
                while (!c.AmountOfSwings())
                {
                    c.NewSwing();
                    if (!c.OutOfBounds())
                    {
                        c.UnitsToCup();
                        if (c.DistanceToCup <= c.TOLERANCE && c.DistanceToCup >= (c.TOLERANCE * -1))
                        {
                            Console.WriteLine("YOU HIT THE CUP!\n");
                            c.printLog();
                            c.Playing = false;
                            break;
                        }
                    }
                    else
                    {
                        c.printLog();
                        c.Playing = false;
                        break;
                    }
                }
            }    
        }
    }
}
