using DataAccessLayer.DAL;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceLayer
{
    public interface IAuthorizationService
    {
        public ResponseHandler Login(User userEntered, ResponseHandler response);
    }
}
