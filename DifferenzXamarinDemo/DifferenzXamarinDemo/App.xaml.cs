using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;

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
            Device.SetFlags(new[] { "SwipeView_Experimental", "AppTheme_Experimental" });
            App.Current.UserAppTheme = (OSAppTheme)AppInfo.RequestedTheme;

            AppNavigationService = NavigationService;
            LanguageService.Init();
            Sharpnado.Shades.Initializer.Initialize(true, true, filter: "ShadowsRenderer");
            if (SettingsService.IsLoggedIn)
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
            App.Current.UserAppTheme = (OSAppTheme)AppInfo.RequestedTheme;
        }
    }
}
