using System;
using DifferenzXamarinDemo.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

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
        #endregion

        #region Public Properties

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

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        #endregion







    }
}
