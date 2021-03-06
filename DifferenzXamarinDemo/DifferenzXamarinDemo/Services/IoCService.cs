﻿using DifferenzXamarinDemo.ViewModels;
using DifferenzXamarinDemo.Views;
using Prism.Ioc;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Services
{
    public class IoCService
    {
        /// <summary>
        /// RegisterTypes
        /// </summary>
        /// <param name="containerRegistry">containerRegistry</param>
        internal static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Infrastructure Depedencies
            RegisterInfrastructure(containerRegistry);
            // ViewModels for Navigation
            RegisterViewModelsForNavigation(containerRegistry);
            //Services
            RegisterServices(containerRegistry);
        }

        /// <summary>
        /// RegisterInfrastructure
        /// </summary>
        /// <param name="containerRegistry"></param>
        private static void RegisterInfrastructure(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        /// <summary>
        /// Register ViewModels For Navigation
        /// </summary>
        /// <param name="containerRegistry">containerRegistry</param>
        private static void RegisterViewModelsForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MyDetailPage, MyDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MyListPage, MyListPageViewModel>();
        }

        /// <summary>
        /// RegisterServices
        /// </summary>
        /// <param name="containerRegistry"></param>
        private static void RegisterServices(IContainerRegistry containerRegistry)
        {
            // using live services
            RegisterLiveServices(containerRegistry);
        }

        /// <summary>
        /// RegisterLiveServices
        /// </summary>
        /// <param name="containerRegistry"></param>
        private static void RegisterLiveServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<FacadeService>();
            //containerRegistry.Register<IUserSettingsService, UserSettingsService>();
        }
    }
}
