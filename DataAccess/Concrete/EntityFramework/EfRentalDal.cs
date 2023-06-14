using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarsContext>, IRentalDal
    {
        public List<RentalFullDetailDto> GetRentalFullDetails()
        {
            using (RentalCarsContext context = new RentalCarsContext())
            {
                var result = from r in context.Rentals
                             join c in context.Car
                             on r.CarId equals c.Id
                             join m in context.Customers
                             on r.CustomerId equals m.CustomerId
                             select new RentalFullDetailDto
                             {
                                 Id = r.Id,
                                 CarName = c.Description,
                                 CustomerName = m.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
