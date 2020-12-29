using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;

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
        OAuth2Authenticator oAuth2Authenticator;
        OAuth2ProviderType OAuth2ProviderType { get; set; }
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
        public static EventHandler OnPresenter;
        #endregion

        #region Commands
        public DelegateCommand LoginCommand { get { return new DelegateCommand(() => Login()); } }
        public DelegateCommand LoginWithFacebookCommand { get { return new DelegateCommand(() => LoginWithFacebook()); } }

        #endregion

        #region Private Methods

        /// <summary>
        /// Performs user login.
        /// </summary>
        private async void Login()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                {
                    await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, AppResources.TEXT_OK);
                    return;
                }

                if (!(Regex.IsMatch(Email, SessionService.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                {
                    await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_INVALID_EMAIL, AppResources.TEXT_OK);
                    return;
                }
                var isConnected = CheckConnectivity();
                if (!isConnected)
                {
                    await DisplayAlertAsync(AppResources.TITLE_ALERT, AppResources.MESSAGE_ERROR_NO_INTERNET, AppResources.TEXT_OK);
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
                        SettingsService.LoggedInUserEmail = result.Email;
                        Debug.WriteLine($"Logged In User : {result.Email}");
                        SessionService.AutoLogin();
                    }
                }
                else
                {
                    await ClosePopup();
                    await DisplayAlertAsync(AppResources.TITLE_ERROR, AppResources.MESSAGE_ERROR_EMAIL_PASSWORD_ERROR, AppResources.TEXT_OK);
                }
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        private async void LoginWithFacebook()
        {
            try
            {
                var isConnected = CheckConnectivity();
                if (!isConnected)
                {
                    await DisplayAlertAsync(AppResources.TITLE_ALERT, AppResources.MESSAGE_ERROR_NO_INTERNET, AppResources.TEXT_OK);
                    return;
                }

                Authenticate(OAuth2ProviderType.FACEBOOK);
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        private void Authenticate(OAuth2ProviderType providerType)
        {
            try
            {
                oAuth2Authenticator = OAuthAuthenticatorService.CreateOAuth2(providerType);
                oAuth2Authenticator.Completed += OAuth2Authenticator_Completed;
                oAuth2Authenticator.Error += OAuth2Authenticator_Error;

                OAuth2ProviderType = providerType;
                var presenter = new OAuthLoginPresenter();
                // This is workaround for iOS because when open presenter on iOS, 
                // view is not correctly shown. Then is necessary  modify view on 
                // iOS LoginPageRenderer renderer. On Android, view is correctly shown.
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (providerType == OAuth2ProviderType.FACEBOOK)
                        {
                            OnPresenter?.Invoke(oAuth2Authenticator, EventArgs.Empty);
                        }
                        else
                        {
                            presenter.Login(oAuth2Authenticator);
                        }
                        break;
                    case Device.Android:
                        presenter.Login(oAuth2Authenticator);
                        break;
                }
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        private async void OAuth2Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                string email = string.Empty;
                switch (OAuth2ProviderType)
                {
                    case OAuth2ProviderType.FACEBOOK:
                        SessionService.SaveFBAccount(eventArgs.Account);
                        email = await ProviderService.GetFacebookEmailAsync();
                        Debug.WriteLine($"Logged In User : {email}");
                        SettingsService.LoggedInUserEmail = email;
                        SessionService.AutoLogin();
                        break;
                }
            }
            else
            {
                oAuth2Authenticator.OnCancelled();
                oAuth2Authenticator = default(OAuth2Authenticator);
            }
        }

        private async void OAuth2Authenticator_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            OAuth2Authenticator authenticator = (OAuth2Authenticator)sender;
            if (authenticator != null)
            {
                authenticator.Completed -= OAuth2Authenticator_Completed;
                authenticator.Error -= OAuth2Authenticator_Error;
            }

            string title = "Authentication Error";
            string msg = e.Message;

            Debug.WriteLine($"Error authenticating with {OAuth2ProviderType}! Message: {e.Message}");
            await Application.Current.MainPage.DisplayAlert(title, msg, "OK");
        }

        #endregion

        #region Public methods

        #endregion
    }
}
