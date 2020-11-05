using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
    /// Defines the <see cref="PopupNavigationService" />.
    /// </summary>
    public class PopupNavigationService
    {
        /// <summary>
        /// Defines the _instance.
        /// </summary>
        static IPopupNavigation _instance;

        /// <summary>
        /// Gets or sets the Instance.
        /// </summary>
        public static IPopupNavigation Instance
        {
            get
            {
                return _instance ?? (_instance = PopupNavigation.Instance);
            }
            set
            {
                _instance = value;
            }
        }
    }
}

