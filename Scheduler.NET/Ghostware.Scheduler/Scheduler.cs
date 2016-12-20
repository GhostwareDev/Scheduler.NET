using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler
{
    public class Scheduler : Control
    {
        public Scheduler()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Scheduler), new FrameworkPropertyMetadata(typeof(Scheduler)));
        }
    }
}
