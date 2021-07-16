namespace Doman.Entities
{

    public class Circle : Shape
    {
        public double Radius { get; set; }
        private readonly double Pi = 3.14;

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }


        public override double GetPerimeter() => 2 * Pi * Radius;

        public override double GetArea() => Pi * Radius * Radius;
    }
}
