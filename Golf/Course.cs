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
        private int distanceToCup;
        private int startingDistance = 0;
        private int courseLength;
        private bool playing = true;
        readonly int tolerance = 3;
        private Player player;
        List<Swing> swings = new List<Swing>();


        // GETTERS AND SETTERS
        public int DistanceToCup { get => distanceToCup;}

        public int StartingDistance { get => startingDistance;}

        public bool Playing { get => playing; set => playing = value; }

        public int TOLERANCE { get => tolerance; }

        public int CourseLength { get => courseLength; }

        // END OF GETTERS AND SETTERS

        // CONSTRUCTOR
        public Course(Player p)
        {
            swings = new List<Swing>();
            player = p;
            this.distanceToCup = rnd.Next(300) + 501;
            this.courseLength = rnd.Next(200) + 800;
            Console.WriteLine("Distance to cup: " + distanceToCup + ". Course length: " + courseLength);
        }

        public void NewSwing()
        {
            Console.WriteLine("\nEnter angle:");
            int angle = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter velocity of swing:");
            int velocity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Swing s = new Swing(angle, velocity);
            
            this.startingDistance += s.CalculateDistance();
            distanceToCup -= s.CalculateDistance();
            Console.Write("your ball traveled " + s.CalculateDistance() + " units.");
            swings.Add(s);
        }

        public bool AmountOfSwings()
        {
            if (swings.Count >= 5)
            {
                Console.WriteLine("\nMax amount of swings reached! You didn't reach the cup!");
                this.printLog();
                this.playing = false;
                return true;
            }
            else return false;
        }

        public void UnitsToCup()
        {
            if (!OvershotCup()) Console.WriteLine(" Distance to cup: " + distanceToCup);
        }

        public bool OvershotCup()
        {
            if (distanceToCup < (this.TOLERANCE * -1))
            {
                distanceToCup = (distanceToCup * -1);
                Console.WriteLine("\nYOU OVERSHOT THE CUP!\nDistance left: " + distanceToCup);
                return true;
            }
            return false;
        }

        public bool OutOfBounds()
        {
            int i = 0;
            foreach (Swing s in swings)
            {
                if (s.CalculateDistance() >= courseLength)
                {
                    Console.WriteLine(" You shot the ball way off course.\n -- G A M E   O V E R --");
                    this.Playing = false;
                    return true;
                }
                i++;
            }
            return false;
        }

        public void printLog()
        {
            Console.WriteLine(player.Name + " took " + swings.Count + " swings on this course.");
            int i = 0;
            foreach (Swing swing in swings) 
            {
                Console.WriteLine( "Swing " + (i + 1) + ": " + swing.CalculateDistance() + " units.");
                i++;
            }
            Console.WriteLine();
        }
    }
}
