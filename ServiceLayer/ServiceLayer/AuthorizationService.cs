using DataAccessLayer.DAL;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceLayer
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationDAL _authorizationDAL;

        public AuthorizationService(IAuthorizationDAL authorizationDAL)
        {
            _authorizationDAL = authorizationDAL;
        }

        public ResponseHandler Login(User userEntered, ResponseHandler response)
        {
            return _authorizationDAL.Login(userEntered, response);
        }
    }
}
