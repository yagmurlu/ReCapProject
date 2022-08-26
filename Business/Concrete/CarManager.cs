using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            //if (car.Description.Length>2 && car.DailyPrice>0)
            //{
            //    _carDal.Add(car);
            //}
            //else
            //{
            //    Console.WriteLine("Ürün açıklaması 2'den büyük olmalı ve günlük fiyat 0'dan fazla olmalı.");
            //}
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
            //if (car.Description.Length > 2 && car.DailyPrice > 0)
            //{
            //    _carDal.Update(car);
            //}
            //else
            //{
            //    Console.WriteLine("Ürün açıklaması 2'den büyük olmalı ve günlük fiyat 0'dan fazla olmalı.");
            //}
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);

        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
    }
}
