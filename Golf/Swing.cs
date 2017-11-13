using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Swing
    {
        private int _velocity;
        private int _angle;
        private readonly double GRAVITY = 9.8;

        public Swing(int angle, int velocity)
        {
            this._velocity = velocity;
            this._angle = angle;
        }

        //GETTERS AND SETTERS
        public int Velocity { get => _velocity; set => _velocity = value; }
        public int Angle { get => _angle; set => _angle = value; }

        public double AngleInRadians()
        {
            double angleInRadians = (Math.PI / 180) * _angle;
            return angleInRadians;
        }

        public int CalculateDistance()
        {
            int distance = Convert.ToInt32(Math.Pow(_velocity, 2) / GRAVITY * Math.Sin(2 * AngleInRadians()));
            return distance;
        }      
    }
}
