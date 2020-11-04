using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Views;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Services
{
    public class SessionService
    {
        public SessionService()
        {
        }

        static string _Token;
        static Xamarin.Auth.Account _fbaccount;
        public static string Token
        {
            get { return _Token; }
        }

        public static Xamarin.Auth.Account FBAccount
        {
            get { return _fbaccount; }
        }

        public static void SaveFBAccount(Xamarin.Auth.Account account)
        {
            _fbaccount = account;
            _Token = account.Properties["access_token"];
            GetFacebookLoginDetail();
        }

        public async static void Logout()
        {
            _fbaccount = null;
            _Token = null;

            using (UserDialogs.Instance.Loading(Constants.TITLE_LOGOUT))
            {
                Settings.IsLoggedIn = false;
                await App.AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
            }
        }

        /// <summary>
        /// Gets the facebook login detail.
        /// </summary>
		public static async void GetFacebookLoginDetail()
        {
            await Task.Delay(2000);
            using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
            {
                try
                {
                    if (!string.IsNullOrEmpty(_Token))
                    {
                        AutoLogin();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SESSION_EXPIRED, Constants.TEXT_CANCEL);
                    }
                }
                catch (Exception exc)
                {
                    await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG, Constants.TEXT_CANCEL);
                }
            };
        }

        public static async void AutoLogin()
        {
            Settings.IsLoggedIn = true;
            await App.AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MyListPage)}");
        }
    }
}
