using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserAllListed);
        }

        public IDataResult<List<User>> GetById(int id)
        {
            foreach (var item in _userDal.GetAll())
            {
                if(item.Id==id)
                {
                    return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == id), Messages.UserByIdListed);
                }
            }
            return new ErrorDataResult<List<User>>(Messages.UserNotFind);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
