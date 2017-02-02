using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleHeader : Control
    {
        #region Dependency properties

        public static readonly DependencyProperty DayHeaderProperty =
            DependencyProperty.Register("DayHeader", typeof(string), typeof(ScheduleHeader),
                new FrameworkPropertyMetadata(string.Empty));

        public string DayHeader
        {
            get { return (string)GetValue(DayHeaderProperty); }
            set { SetValue(DayHeaderProperty, value); }
        }

        #endregion

        #region Constructors

        static ScheduleHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleHeader), new FrameworkPropertyMetadata(typeof(ScheduleHeader)));
        }

        #endregion
    }
}
