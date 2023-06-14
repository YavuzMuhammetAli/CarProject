using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using KimlikDogrulama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KimlikDogrulama.KPSPublicSoapClient;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        bool sonuc;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if(!UserAuthentication(user))
            {
                return new ErrorResult("Kullanıcı kimlik bilgileri doğrulanamadı");
            }
            _userDal.Add(user);
            return new SuccessResult("kullanıcı eklendi");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("kullanıcı silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "kullanıcılar listelendi");
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), "maile göre kullanıcı listelendi");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), "claimsler geldi");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("güncelleme yapıldı");
        }

        public bool UserAuthentication(User user)
        {
            List<User> users = new List<User>();
            users.Add(user);
            EndpointConfiguration conf = new EndpointConfiguration();
            KPSPublicSoapClient kps = new KPSPublicSoapClient(conf);
            foreach (User u in users)
            {
                var result = kps.TCKimlikNoDogrulaAsync(Convert.ToInt64(u.TC), u.FirstName, u.LastName, u.BirthDay.Year);
                sonuc = result.Result.Body.TCKimlikNoDogrulaResult;
                return sonuc;
            }
            return sonuc;
        }
    }
}
