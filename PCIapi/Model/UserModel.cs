using System;
using System.Collections.Generic;

namespace PCIapi.Model
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool IsReset { get; set; }
        public bool IsBlocked { get; set; }
        

    }
    public class IsAdminORNot
    {
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public string ErrorMassege { get; set; }

    }


}
