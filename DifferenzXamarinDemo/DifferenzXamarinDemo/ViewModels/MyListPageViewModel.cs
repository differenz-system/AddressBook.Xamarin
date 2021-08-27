using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.Views;
using DLToolkit.Forms.Controls;
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
            header.HeaderText = AppResources.Text_ADDRESS_BOOK;
            header.LeftText = "sign-out-alt"; //AppResources.TEXT_LOGOUT;
            header.RightText = "plus"; //AppResources.TEXT_ADD;
            header.LeftCommand = LogoutCommand;
            header.RightCommand = AddCommand;
            header.IsVisiblesearchEntry = true;
            header.SearchContactCommand = SearchContactCommand;
            CurrentHeader = header;
        }
        #endregion

        #region Private Properties
        private List<UserData> _userList;
        private FlowObservableCollection<object> _items = new FlowObservableCollection<object>();
        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        private string _searchText;
        private bool isVisibleMessage;
        #endregion

        #region Public Properties
        public List<UserData> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public FlowObservableCollection<object> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public bool IsVisibleMessage
        {
            get { return isVisibleMessage; }
            set { SetProperty(ref isVisibleMessage, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand<UserData> DeleteItemCommand { get { return new DelegateCommand<UserData>((obj) => DeleteAddress(obj)); } }
        public DelegateCommand<UserData> SelectItemCommand { get { return new DelegateCommand<UserData>((obj) => ViewAddress(obj)); } }
        public DelegateCommand AddCommand { get { return new DelegateCommand(Add); } }

        public DelegateCommand<string> SearchContactCommand
        {
            get { return new DelegateCommand<string>(async (obj) => await DelayedQueryForKeyboardTypingSearches(obj).ConfigureAwait(false)); }
        }
        #endregion

        #region Private Methods

        private async Task DelayedQueryForKeyboardTypingSearches(string searchtxt)
        {
            try
            {
                Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel(); await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
.ContinueWith(task => SearchContact(searchtxt, this.throttleCts.Token), CancellationToken.None,
             TaskContinuationOptions.OnlyOnRanToCompletion,
             TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
            }
        }

        private void SearchContact(string searchtxt, CancellationToken token)
        {
            try
            {
                UserList = DatabaseService.GetAll();
                if (searchtxt.Count() > 0)
                {
                    var sorted = UserList.Where(c => c.Name.ToLower().Contains(searchtxt.ToLower()))
                        .OrderBy(item => item.Name)
                        .GroupBy(item => item.Name[0].ToString())
                        .Select(itemGroup => new Grouping<string, UserData>(itemGroup.Key.ToUpper(), itemGroup))
                        .ToList();
                    Items = new FlowObservableCollection<object>(sorted);
                }
                else
                {
                    var sorted = UserList
                       .OrderBy(item => item.Name)
                       .GroupBy(item => item.Name[0].ToString())
                       .Select(itemGroup => new Grouping<string, UserData>(itemGroup.Key.ToUpper(), itemGroup))
                       .ToList();
                    Items = new FlowObservableCollection<object>(sorted);
                }

                IsVisibleMessage = Items.Count > 0 ? false : true;
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        private async void DeleteAddress(UserData obj)
        {
            try
            {
                if (obj != null)
                {
                    await ShowLoader(true);
                    DatabaseService.DeleteItem(obj.ID);
                    await ClosePopup();
                    UserList = DatabaseService.GetAll();
                    var sorted = UserList.OrderBy(item => item.Name).GroupBy(item => item.Name[0].ToString())
                       .Select(itemGroup => new Grouping<string, UserData>(itemGroup.Key.ToUpper(), itemGroup)).ToList();
                    Items = new FlowObservableCollection<object>(sorted);
                    IsVisibleMessage = Items.Count > 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                await ClosePopup();
                TelemetryService.Instance.Record(ex);
            }
        }

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
            try
            {
                await _navigationService.NavigateAsync($"{nameof(MyDetailPage)}");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Public methods

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                UserList = DatabaseService.GetAll();

                var sorted = UserList
                .OrderBy(item => item.Name)
                .GroupBy(item => item.Name[0].ToString())
                .Select(itemGroup => new Grouping<string, UserData>(itemGroup.Key.ToUpper(), itemGroup))
                .ToList();

                Items = new FlowObservableCollection<object>(sorted);
                IsVisibleMessage = Items.Count > 0 ? false : true;
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }
        #endregion

    }
}
