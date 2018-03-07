﻿using System;

using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Collections.Generic;
using DifferenzXamarinDemo.Helpers;

namespace DifferenzXamarinDemo
{
	public class App : Application
	{
		static UserDatabase database;

		public static NavigationPage _NavPage;

        //Entry point to Xamarin.Forms app
		public App ()
		{
			var profilePage = new LoginPage ();

            _NavPage = new NavigationPage(profilePage);

			_NavPage.BarBackgroundColor = Color.Teal;
            _NavPage.BarTextColor = Color.White;

            MainPage = _NavPage;

            if (Settings.IsLoggedIn)
            {
                AutoLogin();
            }
		}

		public static UserDatabase Database {
			get { 
				if (database == null) {
					database = new UserDatabase ();
				}
				return database; 
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		static string _Token;
		static Xamarin.Auth.Account _fbaccount;
		public static string Token {
			get { return _Token; }
		}

		public static Xamarin.Auth.Account FBAccount{
			get{ return _fbaccount;}
		}

		public static void SaveFBAccount(Xamarin.Auth.Account account)
		{
			_fbaccount = account;
			_Token = account.Properties["access_token"];
			GetFacebookLoginDetail ();
		}

		public async static void Logout()
		{
			_fbaccount = null;
			_Token = null;

            using (UserDialogs.Instance.Loading(Constants.TITLE_LOGOUT))
            {
                Settings.IsLoggedIn = false;
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
		}

        /// <summary>
        /// Gets the facebook login detail.
        /// </summary>
		public static async void GetFacebookLoginDetail (){
			await Task.Delay(2000);
			using (UserDialogs.Instance.Loading (Constants.TITLE_AUTHENTICATING)) {
				try{
					if (!string.IsNullOrEmpty (_Token)) {
                        AutoLogin();
				} else {
                        await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SESSION_EXPIRED, Constants.TEXT_CANCEL);
				}
				}
				catch(Exception exc) {
                    await App.Current.MainPage.DisplayAlert (Constants.TITLE_ERROR, Constants.MESSAGE_ERROR_SOMETHING_WENT_WRONG, Constants.TEXT_CANCEL);
				}
			};
		}

        public static async void AutoLogin()
        {
            var myDetailPage = new MyListPage();
            var myDetailViewModel = new MyListViewModel();

            List<UserData> userdata = App.Database.GetAll();
            if (userdata != null)
            {
                myDetailViewModel.UserList = userdata;
            }

            Settings.IsLoggedIn = true;

            myDetailPage.BindingContext = myDetailViewModel;
            await App._NavPage.Navigation.PushAsync(myDetailPage);
        }
	}
}

