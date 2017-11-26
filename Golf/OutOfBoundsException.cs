using System;

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
