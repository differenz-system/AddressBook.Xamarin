using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.ViewModels
{
    public class MyListPageViewModel : ViewModelBase
    {
        public MyListPageViewModel(INavigationService navigationService, FacadeService facadeService) : base(navigationService, facadeService)
        {
        }

        private List<UserData> _userList;
        public List<UserData> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public Command<UserData> SelectItem
        {
            get
            {
                return new Command<UserData>(s =>
                {
                    ViewAddress(s);
                });
            }
        }

        /// <summary>
        /// Views user data from address book.
        /// </summary>
        /// <param name="s">S.</param>
        async void ViewAddress(UserData s)
        {
            var myDetailPage = new MyDetailPage();
            var myDetailViewModel = new MyDetailPageViewModel(_navigationService, _facadeService);
            using (UserDialogs.Instance.Loading(Constants.TITLE_LOADING))
            {
                myDetailViewModel.Name = s.Name;
                myDetailViewModel.ID = s.ID;
                myDetailViewModel.Active = s.Active;
                myDetailViewModel.ContactNumber = s.ContactNumber;
                myDetailViewModel.EmailAddress = s.EmailAddress;
            };

            myDetailPage.BindingContext = myDetailViewModel;
            await App.Current.MainPage.Navigation.PushAsync(myDetailPage);
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Logout();
                });
            }
        }


        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    Add();
                });
            }
        }

        /// <summary>
        /// Navigates to MyDetailsPage to add new user data in address book.
        /// </summary>
        async void Add()
        {
            var myDetailPage = new MyDetailPage();
            var myDetailViewModel = new MyDetailPageViewModel(_navigationService, _facadeService);
            myDetailViewModel.ID = 0;
            myDetailViewModel.Active = false;
            myDetailPage.BindingContext = myDetailViewModel;
            await App.Current.MainPage.Navigation.PushAsync(myDetailPage);
        }
    }
}
