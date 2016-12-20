using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler
{
    public class Scheduler : Control
    {
        #region Constructors

        static Scheduler()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Scheduler), new FrameworkPropertyMetadata(typeof(Scheduler)));
        }

        #endregion
    }
}
