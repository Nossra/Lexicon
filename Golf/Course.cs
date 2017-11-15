using System;
using System.Collections.Generic;

namespace Golf
{
    class Course
    {
        Random rnd = new Random();
        private int _distanceToCup;
        private int _startingDistance = 0;
        private int _courseLength;
        private const int _TOLERANCE = 2;
        private Player _player;
        private List<Swing> swings;
        
        // GETTERS AND SETTERS
        public int DistanceToCup { get => _distanceToCup; set => _distanceToCup = value; }

        public int StartingDistance { get => _startingDistance;}

        public int TOLERANCE { get => _TOLERANCE; }

        public int CourseLength { get => _courseLength; }

        public Player Player { get => _player; set => _player = value; }

        public List<Swing> Swings { get => swings; }

        // END OF GETTERS AND SETTERS

        // CONSTRUCTOR
        public Course(Player p)
        {
            swings = new List<Swing>();
            _player = p;
            this._distanceToCup = rnd.Next(300) + 501;
            this._courseLength = rnd.Next(200) + 800;
            Console.WriteLine("Distance to cup: " + DistanceToCup + ". Course length: " + CourseLength);
        }

        public void NewSwing()
        {
            Console.WriteLine("\nSwing: " + (swings.Count +1) + ". Enter angle:");
            int angle = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("\nEnter velocity of swing:");
            int velocity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Swing s = new Swing(angle, velocity);
            
            this._startingDistance += s.CalculateDistance();
            _distanceToCup -= s.CalculateDistance();
            Console.Write("your ball traveled " + s.CalculateDistance() + " units.");
            swings.Add(s);
        }

        public bool AmountOfSwings()
        {
            if (swings.Count >= 5)
            {
                Console.WriteLine("\nMax amount of swings reached! You didn't reach the cup!\n\n -- G A M E  O V E R --\n");
                printLog();
                return true;
            }
            else return false;
        }

        public void UnitsToCup()
        {
            if (!OvershotCup()) Console.WriteLine(" Distance to cup: " + DistanceToCup);
        }

        public bool OvershotCup()
        {
            if (DistanceToCup < (this.TOLERANCE * -1))
            {
                DistanceToCup = (DistanceToCup * -1);
                Console.WriteLine("\nYOU OVERSHOT THE CUP!\nDistance left: " + DistanceToCup);
                return true;
            }
            return false;
        }

        public void OutOfBounds()
        {
            int i = 0;
            foreach (Swing s in swings)
            {
                if (s.CalculateDistance() >= CourseLength)
                {
                    throw new OutOfBoundsException();
                }
                i++;
            }
        }

        public void printLog()
        {
            Console.WriteLine(Player.Name + " took " + Swings.Count + " swings on this course.");
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
