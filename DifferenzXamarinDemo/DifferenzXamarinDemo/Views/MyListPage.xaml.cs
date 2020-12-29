using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class MyListPage : ContentPage
    {
        public MyListPage()
        {
            InitializeComponent();
            MyList.ScaleTo(0);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MyList.ScaleTo(1, 250, Easing.Linear);
        }
    }
}
