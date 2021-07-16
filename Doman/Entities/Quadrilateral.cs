namespace Doman.Entities
{
    public class Quadrilateral : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Quadrilateral(double heigth, double width) : base(heigth == width ? "Square" : "Recangle")
        {
            Height = heigth;
            Width = width;
        }

        public override double GetArea() => Height * Width;

        public override double GetPerimeter() => (Width + Height) * 2;


        public string GetQuadrilateralName()
        {
            if (Height == Width)
            {
                return "Square";
            } else
            {
                return "Recangle";
            }
        }
    }
}
