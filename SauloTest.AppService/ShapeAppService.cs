using Doman.Entities;
using SauloTest.AppService.Interfaces;
using SauloTest.ViewModel;
using System.Linq;
using System.Text.Json;

namespace SauloTest.AppService
{
    public class ShapeAppService
    {
        private readonly IShapeService _shapeService;

        public ShapeAppService(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        public void Add(Shape obj)
        {
            _shapeService.Add(obj);
        }

        public void Delete(Shape obj)
        {
            _shapeService.Delete(obj);
        }

        public Report_vw PrintReport()
        {
            var all = _shapeService.GetAll().GroupBy(x=>x.Name).Select(x=> new DataReport_vw()
            {
                Name = x.Key,
                Quantity = x.Count()
            }).ToList();


            return new Report_vw(all);            
        }

        public string Serialize(Shape obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
