using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleHeader : Control
    {
        public ScheduleHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleHeader), new FrameworkPropertyMetadata(typeof(ScheduleHeader)));
        }
    }
}
