using System.Collections.Generic;

namespace DifferenzXamarinDemo.Models
{
    /// <summary>
    /// LoginModel - Contains attributes for persisting user login data
    /// </summary>
    public class LoginModel
    {
        public LoginModel()
        {
            Errors = new List<string>();
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string DeviceOSType { get; set; }
        public string DeviceUDID { get; set; }
        public string DeviceToken { get; set; }
        public List<string> Errors { get; set; }
    }

    /// <summary>
    /// LoginObject - Wraps LoginModel
    /// </summary>
    public class LoginObject
    {
        public LoginModel LoginData { get; set; }
    }

    public partial class LoginResponse
    {
        public LoginObject Data { get; set; }
    }
}
