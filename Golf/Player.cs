
using System;

namespace Golf
{
    class Player
    {
        string _name;

        public Player(string name)
        {
            this._name = name;
        }

        public string Name { get { return _name; } set { _name = value; } }

        public int getInt()
        {
            int input = 0;

            while (true)
            {                
                try
                {
                    input = int.Parse(Console.ReadLine());
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your input was too large! Try again:");
                }
                catch (Exception)
                {
                    Console.WriteLine("That wasnt even a number.. Try again:");
                }
            }
            return input;
        }
    }
}
