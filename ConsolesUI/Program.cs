using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsolesUI
{
    //SOLID
    //Open Closed Principle => Yazılıma yeni bir özellik ekliyor isek mevcuttaki hiçbir koda dokunulmaz!!
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = 2020, Description = "TOGG "});
            
            carManager.Update(new Car {Id=3, BrandId = 1, ColorId = 2, DailyPrice = 22000, ModelYear = 2020, Description = "sıfır araç" });
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}


        }
    }
}
