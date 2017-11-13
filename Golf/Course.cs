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
        private int _distanceToCup;
        private int _startingDistance = 0;
        private int _courseLength;
        private bool _playing = true;
        private readonly int _TOLERANCE = 2;
        private Player _player;
        private List<Swing> swings = new List<Swing>();


        // GETTERS AND SETTERS
        public int DistanceToCup { get => _distanceToCup;}

        public int StartingDistance { get => _startingDistance;}

        public bool Playing { get => _playing; set => _playing = value; }

        public int TOLERANCE { get => _TOLERANCE; }

        public int CourseLength { get => _courseLength; }
        internal Player Player { get => _player; set => _player = value; }

        // END OF GETTERS AND SETTERS

        // CONSTRUCTOR
        public Course(Player p)
        {
            swings = new List<Swing>();
            _player = p;
            this._distanceToCup = rnd.Next(300) + 501;
            this._courseLength = rnd.Next(200) + 800;
            Console.WriteLine("Distance to cup: " + _distanceToCup + ". Course length: " + _courseLength);
        }

        public void NewSwing()
        {
            Console.WriteLine("\nEnter angle:");
            int angle = Player.Input;
            
            Console.WriteLine("\nEnter velocity of swing:");
            int velocity = Player.Input;
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
                Console.WriteLine("\nMax amount of swings reached! You didn't reach the cup!");
                this.printLog();
                this._playing = false;
                return true;
            }
            else return false;
        }

        public void UnitsToCup()
        {
            if (!OvershotCup()) Console.WriteLine(" Distance to cup: " + _distanceToCup);
        }

        public bool OvershotCup()
        {
            if (_distanceToCup < (this.TOLERANCE * -1))
            {
                _distanceToCup = (_distanceToCup * -1);
                Console.WriteLine("\nYOU OVERSHOT THE CUP!\nDistance left: " + _distanceToCup);
                return true;
            }
            return false;
        }

        public bool OutOfBounds()
        {
            int i = 0;
            foreach (Swing s in swings)
            {
                if (s.CalculateDistance() >= _courseLength)
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
            Console.WriteLine(_player.Name + " took " + swings.Count + " swings on this course.");
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
