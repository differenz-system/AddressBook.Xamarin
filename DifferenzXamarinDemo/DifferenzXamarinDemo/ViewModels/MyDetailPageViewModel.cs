﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Acr.UserDialogs;
using DifferenzXamarinDemo.Helpers;
using DifferenzXamarinDemo.Models;
using DifferenzXamarinDemo.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.ViewModels
{
    public class MyDetailPageViewModel : ViewModelBase
    {
        #region Constructor
        public MyDetailPageViewModel(INavigationService navigationService, FacadeService facadeService) : base(navigationService, facadeService)
        {
        }
        #endregion

        #region Private Properties
        private int _ID { get; set; } = -1;
        #endregion

        #region Public Properties

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;

                if (value <= 0)
                {
                    SaveButtonText = Constants.TEXT_SAVE;
                    DeleteButtonText = Constants.TEXT_CANCEL;
                }
                else
                {
                    SaveButtonText = Constants.TEXT_UPDATE;
                    DeleteButtonText = Constants.TEXT_DELETE;
                }
            }
        }

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public bool Active { get; set; }
        public string SaveButtonText { get; set; } = Constants.TEXT_UPDATE;
        public string DeleteButtonText { get; set; } = Constants.TEXT_DELETE;

        #endregion

        #region Commands

        public DelegateCommand SaveCommand { get { return new DelegateCommand(() => Save()); } }
        public DelegateCommand DeleteCommand {
            get {
                return new DelegateCommand(() => {
                    if (ID > 0) {
                        Delete();
                    } else {
                        Cancel();
                    }
                });
            }
        }
        public DelegateCommand BackCommand { get { return new DelegateCommand(() => Cancel()); } }
        

        #endregion

        #region Private Methods
        /// <summary>
        /// Saves user details to address book.
        /// </summary>
        async void Save()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(ContactNumber))
            {
                if (!(Regex.IsMatch(EmailAddress, Constants.EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                {
                    await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_INVALID_EMAIL, Constants.TEXT_OK);
                    return;
                }

                if (!(Regex.IsMatch(ContactNumber, Constants.PHONE_NO_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                {
                    await App.Current.MainPage.DisplayAlert(Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_INVALID_CONTACT_NO, Constants.TEXT_OK);
                    return;
                }

                using (UserDialogs.Instance.Loading(Constants.TITLE_SAVING))
                {
                    var userData = new UserData();
                    userData.ID = ID;
                    userData.Name = Name;
                    userData.EmailAddress = EmailAddress;
                    userData.ContactNumber = ContactNumber;
                    userData.Active = Active;
                    DatabaseService.SaveItem(userData);
                };
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_SUCCESS, Constants.MESSAGE_SUCCESS_DATA_UPDATED, Constants.TEXT_OK);
                await _navigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(Constants.TITLE_VALIDATION_ERROR, Constants.MESSAGE_ERROR_INSERT_ALL_DATA, Constants.TEXT_OK);
            }
        }

        /// <summary>
        /// Deletes user details from address book.
        /// </summary>
        async void Delete()
        {
            using (UserDialogs.Instance.Loading(Constants.TITLE_DELETING))
            {
                if (ID != 0)
                {
                    DatabaseService.DeleteItem(ID);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            };
        }

        async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region Public methods

        #endregion
        
    }
}
