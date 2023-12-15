using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public interface IAuthorizationDAL
    {
        public ResponseHandler Login(User userEntered, ResponseHandler response);
    }
}
