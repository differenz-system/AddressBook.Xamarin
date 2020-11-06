using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using DifferenzXamarinDemo.Models;
using Newtonsoft.Json;

namespace DifferenzXamarinDemo.Services
{
    public static class ProviderService
    {
        public static async Task<string> GetFacebookEmailAsync()
        {
            string email = string.Empty;
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.GetAsync("https://graph.facebook.com/me?fields=email&access_token=" + SessionService.Token);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Could not get FACEBOOK email. Status: {httpResponse.StatusCode}");
                }

                string data = await httpResponse.Content.ReadAsStringAsync();
                FacebookData facebookData = JsonConvert.DeserializeObject<FacebookData>(data);

                email = facebookData.Email;
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
            return await Task.FromResult(email);
        }

    }
}
