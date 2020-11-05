using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
    public static class SettingsService
    {
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		#endregion

		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

		private const string IsLoggedInKey = "isLoggedIn_key";
		private static readonly bool IsLoggedInDefault = false;

		public static bool IsLoggedIn
		{
			get
			{
				return AppSettings.GetValueOrDefault(IsLoggedInKey, IsLoggedInDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
			}
		}
	}
}
