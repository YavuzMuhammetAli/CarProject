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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalCarsContext>, ICustomerDal
    {
        public List<CustomersDetailDto> GetCustomerDetail()
        {
            using (RentalCarsContext context = new RentalCarsContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomersDetailDto { Id = c.CustomerId, CustomerName = c.CompanyName, UserName = u.FirstName };
                return result.ToList();

            }
        }
    }
}
