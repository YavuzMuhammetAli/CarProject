using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using KimlikDogrulama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KimlikDogrulama.KPSPublicSoapClient;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        bool Authentication;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "access token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("parola hatası");
            }
            return new SuccessDataResult<User>(userToCheck, "başarılı giriş");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                TC = userForRegisterDto.TC,
                BirthDay = userForRegisterDto.BirthDay,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            if (!UserAuthentication(user))
            {
                return new ErrorDataResult<User>(user,"Kimlik doğrulaması başarısız");
            }            
            return new SuccessDataResult<User>(user, "kayıt oldu");
        }

        public IResult UserExists(string email)
        {
            if(_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult("kullanıcı mevcut");
            }
            return new SuccessResult("kayıt olundu");
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
                Authentication = result.Result.Body.TCKimlikNoDogrulaResult;
                Console.WriteLine(Authentication);
                return Authentication;
            }
            return Authentication;
        }
    }
}
