using Doman.Entities;
using SauloTest.AppService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SauloTest.ServiceDomain
{
    public class ShapeService : IShapeService
    {
        static List<Shape> DB = new List<Shape>();

        public void Add(Shape obj)
        {
            DB.Add(obj);
        }

        public void Delete(Shape obj)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Shape> GetAll()
        {
            return DB;
        }

        public IReadOnlyCollection<Shape> GetShapeSortedByArea()
        {
            return DB.OrderBy(x => x.GetArea()).ToList();
        }

        public IReadOnlyCollection<Shape> GetShapeSortedByPerimeter()
        {
            return DB.OrderBy(x => x.GetPerimeter()).ToList();
        }
    }
}
