namespace DTO
{
    public class AccountDTORegister
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
    public class AccountDTOLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class AccountDTOChangePassword
    {
        public string PasswordNew { get; set; }
        public string PasswordNewRepeat { get; set; }
    }
    
}
