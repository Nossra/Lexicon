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

            while (!c.AmountOfSwings())
            {
                try
                {
                    c.OutOfBounds();
                    c.NewSwing();
                    c.UnitsToCup();
                    if (c.DistanceToCup <= c.TOLERANCE && c.DistanceToCup >= (c.TOLERANCE * -1))
                    {
                        Console.WriteLine("YOU HIT THE CUP!\n");
                        c.printLog();
                        break;
                    }
                }
                catch (OutOfBoundsException e)
                {
                    c.printLog();
                    break;
                }
            }
        }
    }
}
