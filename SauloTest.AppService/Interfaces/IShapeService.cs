using Doman.Entities;
using System.Collections.Generic;

namespace SauloTest.AppService.Interfaces
{
    public interface IShapeService
    {
        void Add(Shape obj);
        IReadOnlyCollection<Shape> GetShapeSortedByArea();
        IReadOnlyCollection<Shape> GetShapeSortedByPerimeter();
        IReadOnlyCollection<Shape> GetAll();
        void Delete(Shape obj);
    }
}
