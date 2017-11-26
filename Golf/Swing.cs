using System;

namespace Golf
{
    class Swing
    {
        private int _velocity;
        private int _angle;
        private readonly double _GRAVITY = 9.8;

        public Swing(int angle, int velocity)
        {
            this._velocity = velocity;
            this._angle = angle;
        }
        
        public double AngleInRadians()
        {
            double angleInRadians = (Math.PI / 180) * _angle;
            return angleInRadians;
        }

        public int CalculateDistance()
        {
            int distance = Convert.ToInt32(Math.Pow(_velocity, 2) / _GRAVITY * Math.Sin(2 * AngleInRadians()));
            return distance;
        }      
    }
}
