using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleLedgerItem : Control
    {
        public ScheduleLedgerItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleLedgerItem), new FrameworkPropertyMetadata(typeof(ScheduleLedgerItem)));
        }

        #region TimeslotA

        //public static readonly DependencyProperty TimeslotAProperty =
        //    DependencyProperty.Register("TimeslotA", typeof(string), typeof(ScheduleLedgerItem),
        //        new FrameworkPropertyMetadata(string.Empty));

        //public string TimeslotA
        //{
        //    get { return (string)GetValue(TimeslotAProperty); }
        //    set { SetValue(TimeslotAProperty, value); }
        //}

        #endregion

        #region TimeslotB

        //public static readonly DependencyProperty TimeslotBProperty =
        //    DependencyProperty.Register("TimeslotB", typeof(string), typeof(ScheduleLedgerItem),
        //        new FrameworkPropertyMetadata(string.Empty));

        //public string TimeslotB
        //{
        //    get { return (string)GetValue(TimeslotBProperty); }
        //    set { SetValue(TimeslotBProperty, value); }
        //}

        #endregion
    }
}
