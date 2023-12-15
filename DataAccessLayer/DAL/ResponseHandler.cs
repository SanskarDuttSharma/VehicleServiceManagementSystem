using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class ResponseHandler
    {
        [Key]
        public int ResponseID { get; set; }
        public string Token { get; set; }
        public bool LoggedIn { get; set; }
        public int UserID { get; set; }
    }
}
