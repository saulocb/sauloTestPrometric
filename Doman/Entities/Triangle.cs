using Common.Enums;
using System;

namespace Doman.Entities
{
    public class Triangle : Shape
    {
        public double SideLeft{ get; set; }
        public double SideRight { get; set; }
        public double SideBase { get; set; }

        public Triangle(double sideLeft, double sideRight, double sideBase) : base("Triangle")
        {
            SideLeft = sideLeft;
            SideRight = sideRight;
            SideBase = sideBase;
        }

        public override double GetArea() => (Height * SideBase) / 2;

        public double Height 
        {   
            get 
            {
                var baseTri = SideBase / 2;
                var sqrRight =  Math.Pow(SideRight,2);
                var sqrBase =   Math.Pow(baseTri,2);

                var sumSqr = sqrBase + sqrRight;
                var height = Math.Sqrt(sumSqr);

                return height;
            }            
        }

        public string GetTriangleName() 
        {
            if(SideBase == SideLeft && SideLeft == SideRight)
                return ETriangleType.Equilateral.ToString();
            else if(SideBase != SideLeft && SideLeft == SideRight)
                return ETriangleType.Isosceles.ToString();
            else
                return ETriangleType.Scalene.ToString();
        }

        public override double GetPerimeter() => SideRight + SideLeft + SideBase;
    }
}
