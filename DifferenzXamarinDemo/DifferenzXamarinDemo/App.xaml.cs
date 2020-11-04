using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
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

            AppNavigationService = NavigationService;
            //LayoutService.Init();
            //LanguageService.Init();
            if (Settings.IsLoggedIn)
            {
                SessionService.AutoLogin();
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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
