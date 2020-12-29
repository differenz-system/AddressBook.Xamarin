using System;
using System.Diagnostics;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
    /// Defines the <see cref="ITelemetryService" />.
    /// </summary>
    public interface ITelemetryService
    {
        /// <summary>
        /// Record.
        /// </summary>
        /// <param name="ex">Exception.</param>
        void Record(Exception ex);
    }

    /// <summary>
    /// TelemetryService
    /// Record and Handles Exception.
    /// </summary>
    public class TelemetryService : ITelemetryService
    {
        /// <summary>
        /// Defines the _instance.
        /// </summary>
        static ITelemetryService _instance;

        /// <summary>
        /// Gets or sets the Instance.
        /// </summary>
        public static ITelemetryService Instance
        {
            get
            {
                return _instance ?? (_instance = new TelemetryService());
            }
            set
            {
                _instance = value;
            }
        }

        /// <summary>
        /// Record.
        /// </summary>
        /// <param name="ex">Exception.</param>
        public void Record(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
