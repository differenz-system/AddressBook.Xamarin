using System;
using DifferenzXamarinDemo.Config;
using DifferenzXamarinDemo.Models;
using Xamarin.Auth;

namespace DifferenzXamarinDemo.Services
{
    public static class OAuthAuthenticatorService
    {
        private static OAuth2Authenticator oAuth2Authenticator;

        public static OAuth2Authenticator CreateOAuth2(OAuth2ProviderType socialLoginProvider)
        {
            switch (socialLoginProvider)
            {
                case OAuth2ProviderType.FACEBOOK:
                    oAuth2Authenticator = new OAuth2Authenticator(
                        clientId: FacebookConfiguration.ClientId,
                        scope: FacebookConfiguration.Scope,
                        authorizeUrl: new Uri(FacebookConfiguration.AuthorizeUrl),
                        redirectUrl: new Uri(FacebookConfiguration.RedirectUrl),
                        getUsernameAsync: null,
                        isUsingNativeUI: FacebookConfiguration.IsUsingNativeUI)
                    {
                        AllowCancel = true,
                        ShowErrors = false,
                        ClearCookiesBeforeLogin = true
                    };
                    break;
            }

            AuthenticationState = oAuth2Authenticator;
            return oAuth2Authenticator;
        }

        public static OAuth2Authenticator AuthenticationState { get; private set; }
    }
}
