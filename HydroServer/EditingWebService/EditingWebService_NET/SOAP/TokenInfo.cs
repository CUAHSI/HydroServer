using System;
using System.Collections.Generic;
using System.Web;

namespace SoapService
{
    public class TokenInfo
    {
        public string Status { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public string UserRole { get; set; }

        public string UserName { get; set; }
    }
}