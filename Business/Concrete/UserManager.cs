using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        //TODO : Daha sonra Result yapisi ile refactor edilecek! (Hashing yapisi da kontrol edilecek!!!)
        #region Result Yapisi

        //public IDataResult<List<OperationClaim>> GetClaims(User user)
        //{
        //    return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        //}

        //public IResult Add(User user)
        //{
        //    IResult result = BusinessRules.Run(CheckIfUserEmailExist(user.Email));

        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserAdded);
        //}

        //private IResult CheckIfUserEmailExist(string email)
        //{
        //    var result = _userDal.GetAll(u => u.Email == email).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.EmailAlreadyExist);
        //    }

        //    return new ErrorResult();
        //}

        //public IDataResult<User> GetByMail(string email)
        //{
        //    return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        //}

        #endregion
    }
}
