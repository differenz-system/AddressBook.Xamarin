using System;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.ViewModels;
using DifferenzXamarinDemo.Views;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Services
{
    public class SessionService
    {
        #region Constructor
        public SessionService()
        {
        }
        #endregion

        #region Private Properties

        static string _Token;
        static Xamarin.Auth.Account _fbaccount;

        #endregion

        #region Public Properties
        public static readonly string EMAIL_REGEX = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly string PHONE_NO_REGEX = @"\d{10}";

        public static string Token { get { return _Token; } }

        public static Xamarin.Auth.Account FBAccount
        {
            get { return _fbaccount; }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public methods

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

            SettingsService.IsLoggedIn = false;
            SettingsService.LoggedInUserEmail = string.Empty;
            await App.AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
        }

        /// <summary>
        /// Gets the facebook login detail.
        /// </summary>
		public static async void GetFacebookLoginDetail()
        {
            try
            {
                if (!string.IsNullOrEmpty(_Token))
                {
                    AutoLogin();
                }
                else
                {
                    await ViewModelBase.DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_SESSION_EXPIRED, AppResources.TEXT_CANCEL);
                }
            }
            catch (Exception ex)
            {
                await ViewModelBase.DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_SOMETHING_WENT_WRONG, AppResources.TEXT_CANCEL);
            }
        }

        public static async void AutoLogin()
        {
            SettingsService.IsLoggedIn = true;
            await App.AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MyListPage)}");
        }

        #endregion

    }
}
