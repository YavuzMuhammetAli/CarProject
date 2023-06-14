using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarsContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalCarsContext context = new RentalCarsContext())
            {
                var result = from c in context.Car
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join r in context.Color
                             on c.ColorId equals r.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 imagePath = i.ImagePath,
                                 Description=c.Description,
                                 BrandName=b.BrandName,
                                 ColorName=r.ColorName
                             };
                return result.ToList();
            }
        }

        public List<CarFullDetailDto> GetCarFullDetails()
        {
            using(RentalCarsContext context = new RentalCarsContext())
            {
                var result = from c in context.Car
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join r in context.Color
                             on c.ColorId equals r.Id
                             select new CarFullDetailDto
                             {
                                 Id = c.Id,
                                 ImagePath = i.ImagePath,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 ModelYear=c.ModelYear,
                                 DailyPrice=c.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}
