using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;
using Plugin.Multilingual;

namespace DifferenzXamarinDemo.Services
{
    public static class LanguageService
    {
        public static List<LanguageModel> LanguageList { get; set; }

        static LanguageService()
        {
            LanguageList = new List<LanguageModel>();
            LanguageList.Add(new LanguageModel() { LanguageName = "English", LanguageCode = "en" });
            LanguageList.Add(new LanguageModel() { LanguageName = "Spanish", LanguageCode = "es" });
        }

        public static void Init()
        {
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
        }

        public static void SetCulture(string language = "English")
        {
            LanguageModel lan;
            if (string.IsNullOrEmpty(language))
            {
                lan = GetDefaultDeviceCulture();
            }
            else
            {
                lan = LanguageList.Where(l => l.LanguageName == language).FirstOrDefault();
            }
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(lan.LanguageCode);
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;

        }

        private static LanguageModel GetDefaultDeviceCulture()
        {
            var culture = CrossMultilingual.Current.DeviceCultureInfo;
            var lan = LanguageList.Where(l => l.LanguageCode == culture.TwoLetterISOLanguageName).FirstOrDefault();
            if (lan != null)
            {
                return lan;
            }
            else
            {
                return LanguageList.FirstOrDefault();
            }
        }
    }
}
