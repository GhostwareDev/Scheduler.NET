using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Ghostware.Scheduler.Controls
{
    public class SchedulerTimeslotItem : ButtonBase
    {
        #region StartTime

        /// <summary>
        /// StartTime Dependency Property
        /// </summary>
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(SchedulerTimeslotItem),
                new FrameworkPropertyMetadata((DateTime)DateTime.Now));

        /// <summary>
        /// Gets or sets the StartTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        #endregion

        #region EndTime

        /// <summary>
        /// StartTime Dependency Property
        /// </summary>
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(SchedulerTimeslotItem),
                new FrameworkPropertyMetadata((DateTime)DateTime.Now));

        /// <summary>
        /// Gets or sets the StartTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

        #endregion
    }
}
