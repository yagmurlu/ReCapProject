using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; // newleme işlemidir.

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=600,Description="Arazi Aracı", ModelYear=2005},
                new Car{Id=2,BrandId=2,ColorId=1,DailyPrice=500,Description="Karavan", ModelYear=2015},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=1000,Description="Limuzin", ModelYear=2020},
                new Car{Id=4,BrandId=3,ColorId=2,DailyPrice=700,Description="Opel Corsa", ModelYear=2018},
                new Car{Id=5,BrandId=1,ColorId=3,DailyPrice=800,Description="Fiat Egea", ModelYear=2021},
            
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(x=>x.Id==id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
