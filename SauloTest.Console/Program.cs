using Doman.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SauloTest.AppService;
using SauloTest.AppService.Interfaces;
using SauloTest.ServiceDomain;
using System;
using System.Collections.Generic;

namespace prometricAssessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            var provider = RegisterServices();
            ShapeAppService _appService = new ShapeAppService(provider.GetRequiredService<IShapeService>());

            // add sharp to the db list
            foreach (var item in GetMockData())
            {
                _appService.Add(item);
            }

            // get list of sharp from the db 
            var list = _appService.GetAll();

            // show sharp details
            Console.WriteLine("Hello, here is my shape list: ");
            foreach (var item in list)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Area: {item.GetArea()}");
                Console.WriteLine($"Perimeter: {item.GetPerimeter()}");
            }

            // report
            while (true)
            {
                Console.WriteLine($"Type 0 - To print the report");
                var typing = Console.ReadLine();
                if (typing == "0")
                {
                    foreach (var item in _appService.PrintReport().Data)
                    {
                        Console.WriteLine(item.Details);
                    }
                }

                // remove sharp
                if (list.Count > 0)
                {
                    Console.WriteLine($"the sharp with the name {list[0].Name} and ID  {list[0].Id} was removeed from the list ");
                    _appService.Delete(list[0]);
                }
                Console.WriteLine($"Press enter to continue");
                Console.ReadLine();
               
            }


        }

        private static List<Shape> GetMockData()
        {
            var list = new List<Shape>()
            {
                new Square(2),
                new Square(6),
                new Square(4),
                new Square(7),

                new Rectangle(3,2),
                new Rectangle(5,2),
                new Rectangle(7,2),
                new Rectangle(32,21),

                new Triangle(2,4,4),
                new Triangle(2,4,2),

                new Triangle(2,3,4),
                new Triangle(2,5,4),

                new Triangle(2,2,2),
                new Triangle(3,3,3),

                new Circle(4),
                new Circle(2),
            };
            return list;
        }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IShapeService, ShapeService>();
            return services.BuildServiceProvider();
        }
    }
}
