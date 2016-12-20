using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleLedgerItem : Control
    {
        #region Timeslots

        public static readonly DependencyProperty TimeslotAProperty =
            DependencyProperty.Register("TimeslotA", typeof(string), typeof(ScheduleLedgerItem),
                new FrameworkPropertyMetadata(string.Empty));

        public string TimeslotA
        {
            get { return (string)GetValue(TimeslotAProperty); }
            set { SetValue(TimeslotAProperty, value); }
        }

        public static readonly DependencyProperty TimeslotBProperty =
            DependencyProperty.Register("TimeslotB", typeof(string), typeof(ScheduleLedgerItem),
                new FrameworkPropertyMetadata(string.Empty));

        public string TimeslotB
        {
            get { return (string)GetValue(TimeslotBProperty); }
            set { SetValue(TimeslotBProperty, value); }
        }

        #endregion

        #region Constructors

        static ScheduleLedgerItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleLedgerItem), new FrameworkPropertyMetadata(typeof(ScheduleLedgerItem)));
        }

        #endregion
    }
}
