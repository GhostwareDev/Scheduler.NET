using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleHeader : Control
    {
        #region Constructors

        static ScheduleHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleHeader), new FrameworkPropertyMetadata(typeof(ScheduleHeader)));
        }

        #endregion
    }
}
