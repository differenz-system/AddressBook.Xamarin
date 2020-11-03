using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class MyDetailPage : ContentPage
    {
        public MyDetailPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MainStackLayout.ScaleTo(1, 250, Easing.SinIn);
        }
    }
}
