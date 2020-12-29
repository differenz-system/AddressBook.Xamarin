using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using Newtonsoft.Json;

namespace DifferenzXamarinDemo.Services
{
    public class LoginService
    {
        public LoginService()
        {
        }

        /// <summary>
        /// Login - User Login (This is a dummy post call which returns a json we pass as a request json, to simulate login in demo project)
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="LoginData1">Login data1.</param>
        public static async Task<LoginModel> Login(LoginModel LoginData1)
        {
            LoginModel UDI = new LoginModel();
            try
            {
                var client = new System.Net.Http.HttpClient();

                LoginObject Loginobj = new LoginObject();
                Loginobj.LoginData = LoginData1;

                client.BaseAddress = new Uri(APIService.ServiceUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var jData = JsonConvert.SerializeObject(Loginobj);
                var content1 = new StringContent(jData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/post", content1);

                var result = response.Content.ReadAsStringAsync().Result;

                var resultobject = JsonConvert.DeserializeObject<LoginResponse>(result);

                UDI = resultobject?.Data?.LoginData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                UDI.Errors.Add(AppResources.MESSAGE_ERROR_SOMETHING_WENT_WRONG_WITH_USER_LOGIN);
            }
            return UDI;
        }
    }
}
