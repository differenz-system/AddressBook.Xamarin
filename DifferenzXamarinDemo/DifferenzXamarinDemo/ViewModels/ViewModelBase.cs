using System;
using System.Linq;
using System.Threading.Tasks;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using DifferenzXamarinDemo.Views.Popups;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Pages;

namespace DifferenzXamarinDemo.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region Constructor
        public ViewModelBase(INavigationService navigationService, FacadeService facadeService)
        {
            _navigationService = navigationService;
            _facadeService = facadeService;
        }
        #endregion

        #region Private Properties
        protected INavigationService _navigationService { get; private set; }
        protected FacadeService _facadeService { get; private set; }

        // <summary>
        /// Defines the _currentHeader.
        /// </summary>
        private HeaderModel _currentHeader = new HeaderModel();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the CurrentHeader.
        /// </summary>
        public HeaderModel CurrentHeader
        {
            get { return _currentHeader; }
            set { SetProperty(ref _currentHeader, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand LogoutCommand { get { return new DelegateCommand(() => SessionService.Logout()); } }
        #endregion

        #region Private Methods

        #endregion

        #region Public methods

        public void Destroy()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        /// <summary>
        /// ShowLoader.
        /// </summary>
        /// <param name="popup">The popup<see cref="PopupPage"/>.</param>
        /// <param name="animate">Pass true/false for animate the popup view.</param>
        /// <returns>.</returns>
        public static async Task ShowPopup(PopupPage popup, bool animate = false)
        {
            try
            {
                await PopupNavigationService.Instance.PushAsync(popup, animate);
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        /// <summary>
        /// ShowLoader.
        /// </summary>
        /// <param name="animate">Pass true/false for animate the popup view.</param>
        /// <returns>.</returns>
        public static async Task ShowLoader(bool animate = false)
        {
            try
            {
                var doesPopupExists = PopupNavigationService.Instance.PopupStack.Any(p => p is LoadingPopup);
                if (doesPopupExists) return;

                await ShowPopup(new LoadingPopup(), animate);
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        /// <summary>
        /// ClosePopup.
        /// </summary>
        /// <param name="animate">Pass true/false for animate the popup view.</param>
        /// <returns>.</returns>
        public static async Task ClosePopup(bool animate = false)
        {
            try
            {
                if (PopupNavigationService.Instance.PopupStack != null && PopupNavigationService.Instance.PopupStack.Count > 0)
                {
                    await PopupNavigationService.Instance.PopAsync(animate);
                }
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
            }
        }

        /// <summary>
        /// DisplayAlert.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <param name="buttonText">The buttonText<see cref="string"/>.</param>
        /// <returns>.</returns>
        public static async Task DisplayAlertAsync(string title, string message, string buttonText)
        {
            if (!string.IsNullOrEmpty(message))
            {
                await App.Current.MainPage.DisplayAlert(title, message, buttonText);
            }
        }

        /// <summary>
        /// CheckConnectivity.
        /// </summary>
        /// <returns>.</returns>
        public bool CheckConnectivity()
        {
            try
            {
                return CrossConnectivity.Current.IsConnected;
            }
            catch (Exception ex)
            {
                TelemetryService.Instance.Record(ex);
                return false;
            }
        }

        #endregion







    }
}
