namespace Doman.Entities
{
    public abstract class Shape
    {
        public string Name { get; private set; }
        
        public Shape(string name)
        {
            Name = name;
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
