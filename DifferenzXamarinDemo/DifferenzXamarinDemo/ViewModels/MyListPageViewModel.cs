using System.Collections.Generic;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.Views;
using Prism.Commands;
using Prism.Navigation;

namespace DifferenzXamarinDemo.ViewModels
{
    public class MyListPageViewModel : ViewModelBase
    {
        #region Constructor
        public MyListPageViewModel(INavigationService navigationService, FacadeService facadeService) : base(navigationService, facadeService)
        {
        }
        #endregion

        #region Private Properties
        private List<UserData> _userList;
        #endregion

        #region Public Properties
        public List<UserData> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }
        #endregion

        #region Commands

        public DelegateCommand<UserData> SelectItemCommand { get { return new DelegateCommand<UserData>((obj) => ViewAddress(obj)); } }
        public DelegateCommand AddCommand { get { return new DelegateCommand(Add); } }

        #endregion

        #region Private Methods

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
        #endregion

        #region Public methods

        #endregion

    }
}
