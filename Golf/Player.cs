using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Player
    {
        public int input;
        string name;

        public Player(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        
        public int Input
        {
            get => input;
            set => input = value; }


        /*    try
             {
                 input = Convert.ToInt32(Console.ReadLine());
             }
             catch (Exception e)
             {
                 Console.WriteLine("That wasn't a number. Try again:");
             }
         }
     }*/
    }
}
