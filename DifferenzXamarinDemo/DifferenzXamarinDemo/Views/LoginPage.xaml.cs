using System;
using System.Collections.Generic;
using DifferenzXamarinDemo.Helpers;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Settings.IsLoggedIn = false;
            await mainStackView.ScaleTo(1, 250, Easing.SinIn);
        }
    }
}
