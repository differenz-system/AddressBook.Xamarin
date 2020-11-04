using System;
using System.Collections.Generic;
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
            var header = new HeaderModel();
            header.HeaderText = Constants.Text_ADDRESS_BOOK;
            header.LeftText = Constants.TEXT_LOGOUT;
            header.RightText = Constants.TEXT_ADD;
            header.LeftCommand = LogoutCommand;
            header.RightCommand = AddCommand;
            CurrentHeader = header;
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
        /// <param name="userData">UserData.</param>
        async void ViewAddress(UserData userData)
        {
            var param = new NavigationParameters();
            param.Add("userdata", userData);
            await _navigationService.NavigateAsync($"{nameof(MyDetailPage)}", param);
        }

        /// <summary>
        /// Navigates to MyDetailsPage to add new user data in address book.
        /// </summary>
        async void Add()
        {
            await _navigationService.NavigateAsync($"{nameof(MyDetailPage)}");
        }
        #endregion

        #region Public methods

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                UserList = DatabaseService.GetAll();
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }
        #endregion

    }
}
