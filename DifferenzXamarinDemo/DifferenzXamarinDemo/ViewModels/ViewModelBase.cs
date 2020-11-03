using System;
using DifferenzXamarinDemo.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace DifferenzXamarinDemo.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; private set; }
        protected FacadeService _facadeService { get; private set; }

        public ViewModelBase(INavigationService navigationService, FacadeService facadeService)
        {
            _navigationService = navigationService;
            _facadeService = facadeService;
        }

        public void Destroy()
        {
           
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
