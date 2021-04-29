using System;

namespace Doman.Entities
{
    public abstract class Shape
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        
        public Shape(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
