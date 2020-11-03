using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Data;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.ViewModels;
using DifferenzXamarinDemo.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DifferenzXamarinDemo
{
    public partial class App 
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        public static INavigationService AppNavigationService { get; set; } 

        protected override void OnInitialized()
        {
            InitializeComponent();

            //LayoutService.Init();
            //LanguageService.Init();
            AppNavigationService = NavigationService;
            if (Settings.IsLoggedIn)
            {
                AutoLogin();
            }
            else
            {
                NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}").Wait();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Registering all the services
            IoCService.RegisterTypes(containerRegistry);
        }

        static UserDatabase database;
        public static NavigationPage _NavPage;

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase();
                }
                return database;
            }
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
                await AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
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
            await AppNavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MyListPage)}");
        }
    }
}
