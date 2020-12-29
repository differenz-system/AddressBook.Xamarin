using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class MyDetailPage : ContentPage
    {
        public MyDetailPage()
        {
            InitializeComponent();
            MainStackLayout.ScaleTo(0);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MainStackLayout.ScaleTo(1, 250, Easing.Linear);
        }
    }
}
