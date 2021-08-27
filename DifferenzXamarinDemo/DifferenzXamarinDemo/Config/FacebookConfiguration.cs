﻿namespace DifferenzXamarinDemo.Config
{
    public class FacebookConfiguration
    {
        public static readonly string ClientId = "<your client id>";
        public static readonly string Scope = "email, public_profile";
        public static readonly string AuthorizeUrl = "https://www.facebook.com/dialog/oauth/";
        public static readonly string RedirectUrl = "<your redirect url>";
        public static bool IsUsingNativeUI = false;
    }
}
