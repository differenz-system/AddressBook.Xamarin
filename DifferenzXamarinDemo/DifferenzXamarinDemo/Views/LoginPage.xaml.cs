using DifferenzXamarinDemo.Services;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            mainStackView.ScaleTo(0);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            SettingsService.IsLoggedIn = false;
            await mainStackView.ScaleTo(1, 250, Easing.Linear);
        }
    }
}
