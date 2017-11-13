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
        int startingDistance = 0;
        List<Swing> swingAmount = new List<Swing>();

        public int DistanceToCup { get => distanceToCup;}
        public int StartingDistance { get => startingDistance;}

        public Course()
        {
            this.distanceToCup = rnd.Next(300) + 501;
            Console.WriteLine("Distance to cup: " + distanceToCup);
        }

        public void newSwing()
        {
            Console.WriteLine("Enter angle:");
            int angle = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter velocity of swing:");
            int velocity = Convert.ToInt32(Console.ReadLine());
            Swing s = new Swing(angle, velocity);
            this.startingDistance += s.calculateDistance(angle);
            distanceToCup -= s.calculateDistance(angle);
            Console.Write("your ball traveled " + s.calculateDistance(angle) + " units.");
            swingAmount.Add(s);
        }

        public bool amountOfSwings()
        {
            if (swingAmount.Count >= 5)
            {
                Console.WriteLine("\nMax amount of swings reached! You didn't reach the cup!");
                return true;
            }
            else return false;
        }

        public void unitsToCup()
        {
            if (!overshotCup()) Console.WriteLine(" Distance to cup: " + distanceToCup);
        }

        public bool overshotCup()
        {
            if (distanceToCup < 1)
            {
                distanceToCup = (distanceToCup * -1);
                Console.WriteLine("\nYOU OVERSHOT THE CUP!\nDistance left: " + distanceToCup);
                return true;
            }
            return false;
        }
    }
}
