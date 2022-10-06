namespace PCIapi.Model
{
    public class UserReset
    {
        public string EmailID { get; set; }


    }
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class ResetPassword
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        

    }
    public class UpdateResetPassword
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }

    }
}
