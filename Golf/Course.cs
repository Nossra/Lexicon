using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Course
    {
        Random rnd = new Random();
        int distanceToCup;
        List<Swing> swingAmount = new List<Swing>();

        public Course()
        {
            this.distanceToCup = rnd.Next(300) + 501;
            swingAmount = new Swing[5];
        }

        public Swing newSwing()
        {
            while (!amountOfSwings())
            {
                Console.WriteLine("Enter angle:");
                int angle = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter velocity of swing:");
                int velocity = Convert.ToInt32(Console.ReadLine());
                Swing s = new Swing(angle, velocity);
                s.printDistance();
                swingAmount.Add(s);
                
            }
        }

        public bool amountOfSwings()
        {
            if (swingAmount.Count >= 5)
            {
                Console.WriteLine("Max amount of swings reached! You didn't reach the cup!");
                return true;
            }
            else return false;
        }

        public bool reachedCup()
        {

        }

        
    }
}
