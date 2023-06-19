using Business.Abstract;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> Get(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalFullDetailDto>> GetFullDetail(int id)
        {
            return new SuccessDataResult<List<RentalFullDetailDto>>(_rentalDal.GetRentalFullDetails());
        }
    }
}
