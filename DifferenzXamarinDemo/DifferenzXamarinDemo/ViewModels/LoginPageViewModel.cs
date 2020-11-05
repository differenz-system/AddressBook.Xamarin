using System;
using System.Text.RegularExpressions;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using Prism.Commands;
using Prism.Navigation;

namespace DifferenzXamarinDemo.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Constructor
        public LoginPageViewModel(INavigationService navigationService, FacadeService facadeService) : base(navigationService, facadeService)
        {
            var header = new HeaderModel();
            header.HeaderText = AppResources.TEXT_LOGIN;
            CurrentHeader = header;
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
                await DisplayAlertAsync(AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, AppResources.TITLE_ERROR, AppResources.TEXT_OK);
                return;
            }

            if (!(Regex.IsMatch(Email, SessionService.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_INVALID_EMAIL, AppResources.TEXT_OK);
                return;
            }

            await ShowLoader(true);
            LoginModel LoginData = new LoginModel();
            LoginData.Email = Email;
            LoginData.Password = Password;
            LoginData.DeviceOSType = "No Device";
            LoginData.DeviceToken = "";
            LoginData.DeviceUDID = "";
            var result = await LoginService.Login(LoginData);

            if (result != null)
            {
                if (result.Errors.Count > 0)
                {
                    await ClosePopup();
                    await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, AppResources.TEXT_OK);
                }
                else
                {
                    await ClosePopup();
                    SessionService.AutoLogin();
                }
            }
            else
            {
                await ClosePopup();
                await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, AppResources.TEXT_OK);
            }
        }
        #endregion

        #region Public methods

        #endregion

    }
}
