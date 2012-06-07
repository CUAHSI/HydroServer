using System;
using System.Collections.Generic;
using System.Web;

namespace SoapService
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string AuthToken { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}