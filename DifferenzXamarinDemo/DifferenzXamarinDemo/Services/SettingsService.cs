using Xamarin.Essentials;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
    public static class SettingsService
    {
        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get
            {
                return Preferences.Get(SettingsKey, SettingsDefault);
            }
            set
            {
                Preferences.Set(SettingsKey, value);
            }
        }

        private const string IsLoggedInKey = "isLoggedIn_key";
        private static readonly bool IsLoggedInDefault = false;

        public static bool IsLoggedIn
        {
            get
            {
                return Preferences.Get(IsLoggedInKey, IsLoggedInDefault);
            }
            set
            {
                Preferences.Set(IsLoggedInKey, value);
            }
        }

        private const string LoggedInUserEmailKey = "LoggedInUserEmail_key";
        private static readonly string LoggedInUserEmailDefault = string.Empty;
        public static string LoggedInUserEmail
        {
            get
            {
                return Preferences.Get(LoggedInUserEmailKey, LoggedInUserEmailDefault);
            }
            set
            {
                Preferences.Set(LoggedInUserEmailKey, value);
            }
        }

    }
}
