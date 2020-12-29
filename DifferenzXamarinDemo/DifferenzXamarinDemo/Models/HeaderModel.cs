using Prism.Commands;
using Prism.Mvvm;

namespace DifferenzXamarinDemo.Models
{
    /// <summary>
    /// Defines the <see cref="HeaderModel" />.
    /// </summary>
    public class HeaderModel : BindableBase
    {

        #region Private Properties

        /// <summary>
        /// Defines the _headerText.
        /// </summary>
        private string _headerText = "";

        /// <summary>
        /// Defines the _leftText.
        /// </summary>
        private string _leftText = "";

        /// <summary>
        /// Defines the _rightText.
        /// </summary>
        private string _rightText = "";

        /// <summary>
        /// Defines the _leftCommand.
        /// </summary>
        private DelegateCommand _leftCommand = null;

        /// <summary>
        /// Defines the _rightCommand.
        /// </summary>
        private DelegateCommand _rightCommand = null;

        /// <summary>
        /// Defines the _searchContactCommand.
        /// </summary>
        private DelegateCommand<string> _searchContactCommand = null;

        /// <summary>
        /// Defines the _isVisibleSearchEntry.
        /// </summary>
        private bool _isVisibleSearchEntry = false;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the HeaderText.
        /// </summary>
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        /// <summary>
        /// Gets or sets the LeftText.
        /// </summary>
        public string LeftText
        {
            get { return _leftText; }
            set { SetProperty(ref _leftText, value); }
        }

        /// <summary>
        /// Gets or sets the RightText.
        /// </summary>
        public string RightText
        {
            get { return _rightText; }
            set { SetProperty(ref _rightText, value); }
        }

        /// <summary>
        /// Gets or sets the LeftCommand.
        /// </summary>
        public DelegateCommand LeftCommand
        {
            get { return _leftCommand; }
            set { SetProperty(ref _leftCommand, value); }
        }

        /// <summary>
        /// Gets or sets the RightCommand.
        /// </summary>
        public DelegateCommand RightCommand
        {
            get { return _rightCommand; }
            set { SetProperty(ref _rightCommand, value); }
        }

        /// <summary>
        /// Gets or sets the IsVisiblesearchEntry.
        /// </summary>
        public bool IsVisiblesearchEntry
        {
            get { return _isVisibleSearchEntry; }
            set { SetProperty(ref _isVisibleSearchEntry, value); }
        }

        /// <summary>
        /// Gets or sets the SearchContactCommand.
        /// </summary>
        public DelegateCommand<string> SearchContactCommand
        {
            get { return _searchContactCommand; }
            set { SetProperty(ref _searchContactCommand, value); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        #endregion
    }
}
