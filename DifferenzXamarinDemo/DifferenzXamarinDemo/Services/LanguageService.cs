using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using DifferenzXamarinDemo.LanguageResources;
using DifferenzXamarinDemo.Models;

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
            AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lan.LanguageCode);
            AppResources.Culture = Thread.CurrentThread.CurrentUICulture;

        }

        private static LanguageModel GetDefaultDeviceCulture()
        {
            var culture = Thread.CurrentThread.CurrentUICulture;
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
