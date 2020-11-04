using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Constructor
        public LoginPageViewModel(INavigationService navigationService, FacadeService facadeService) : base(navigationService, facadeService)
        {
        }
        #endregion

        #region Private Properties
        private string _password;
        private string _email;
        #endregion

        #region Public Properties
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand LoginCommand { get { return new DelegateCommand(() => Login()); } }
        #endregion

        #region Private Methods
        /// <summary>
        /// Performs user login.
        /// </summary>
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                await UserDialogs.Instance.AlertAsync(Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TITLE_ERROR, Constants.TEXT_OK);
                return;
            }

            if (!(Regex.IsMatch(Email, Constants.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_INVALID_EMAIL, Constants.TEXT_OK);
                return;
            }

            LoginModel result = new LoginModel();
            using (UserDialogs.Instance.Loading(Constants.TITLE_AUTHENTICATING))
            {
                LoginModel LoginData = new LoginModel();
                LoginData.Email = Email;
                LoginData.Password = Password;
                LoginData.DeviceOSType = "No Device";
                LoginData.DeviceToken = "";
                LoginData.DeviceUDID = "";
                result = await LoginService.Login(LoginData);
            };
            if (result != null)
            {
                if (result.Errors.Count > 0)
                {
                    await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
                }
                else
                {
                    using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
                    {
                        SessionService.AutoLogin();
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, Constants.TEXT_OK);
            }
        }
        #endregion

        #region Public methods

        #endregion

    }
}
