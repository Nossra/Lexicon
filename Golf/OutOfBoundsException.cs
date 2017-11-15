using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class OutOfBoundsException : Exception
    {
        public OutOfBoundsException()
        {
            Console.WriteLine(" You shot the ball way off course.\n\n -- G A M E   O V E R --\n");
        }
    }
}
