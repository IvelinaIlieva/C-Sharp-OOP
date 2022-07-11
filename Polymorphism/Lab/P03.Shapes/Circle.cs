namespace Shapes
{
    using System;
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculatePerimeter() => 2 * Radius * Math.PI;
        public override double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
        public override string Draw() => base.Draw() + this.GetType().Name;
    }
}
