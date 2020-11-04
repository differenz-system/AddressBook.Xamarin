﻿using System;
using Android.App;
using DifferenzXamarinDemo.CustomControls;
using DifferenzXamarinDemo.Droid.Renderers;
using DifferenzXamarinDemo.Services;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRenderer))]
namespace DifferenzXamarinDemo.Droid.Renderers
{
    /// <summary>
    /// FacebookLoginButtonRenderer - Custom renderer of type FacebookLoginButton
    /// </summary>
    public class FacebookLoginButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				var btn = (Android.Widget.Button)Control;

				//Executes facebook authentication process
				btn.Click += (object senderobj, EventArgs evn) => {
					if (string.IsNullOrEmpty(SessionService.Token))
					{
						var activity = Context as Activity;

						var auth = new OAuth2Authenticator(
									  clientId: "129521717733836", // OAuth2 client id
									  scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
									  authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"), // the auth URL for the service
									  redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

						auth.Completed += (sender, eventArgs) => {
							// We presented the UI, so it's up to us to dimiss it on iOS.
							if (eventArgs.IsAuthenticated)
							{

								SessionService.SaveFBAccount(eventArgs.Account);
							}
							else
							{
								// The user cancelled
							}
						};
						activity.StartActivity(auth.GetUI(activity));
					}
					else
					{
						SessionService.GetFacebookLoginDetail();
					}
				};
			}
		}
	}
}

