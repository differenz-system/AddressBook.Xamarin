using System;
using System.Collections.Generic;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.ViewModels;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Views
{
    public partial class MyListPage : ContentPage
    {
        public MyListPage()
        {
            InitializeComponent();  
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MyList.ScaleTo(1, 250, Easing.Linear);

            var vm = this.BindingContext as MyListPageViewModel;
            var itemsSource = vm.UserList;
            vm.UserList = DatabaseService.GetAll();
            //MyList.ItemsSource = vm.UserList;
        }
    }
}
