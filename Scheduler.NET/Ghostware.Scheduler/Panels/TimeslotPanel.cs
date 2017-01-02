using System;
using System.Windows;
using System.Windows.Controls;

namespace Ghostware.Scheduler.Panels
{
    public class TimeslotPanel : Panel
    {
        #region StartTime

        /// <summary>
        /// StartTime Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.RegisterAttached("StartTime", typeof(DateTime), typeof(TimeslotPanel),
                new FrameworkPropertyMetadata((DateTime)DateTime.Now));

        /// <summary>
        /// Gets the StartTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static DateTime GetStartTime(DependencyObject d)
        {
            return (DateTime)d.GetValue(StartTimeProperty);
        }

        /// <summary>
        /// Sets the StartTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetStartTime(DependencyObject d, DateTime value)
        {
            d.SetValue(StartTimeProperty, value);
        }

        #endregion

        #region EndTime

        /// <summary>
        /// EndTime Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.RegisterAttached("EndTime", typeof(DateTime), typeof(TimeslotPanel),
                new FrameworkPropertyMetadata((DateTime)DateTime.Now));

        /// <summary>
        /// Gets the EndTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static DateTime GetEndTime(DependencyObject d)
        {
            return (DateTime)d.GetValue(EndTimeProperty);
        }

        /// <summary>
        /// Sets the EndTime property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetEndTime(DependencyObject d, DateTime value)
        {
            d.SetValue(EndTimeProperty, value);
        }

        #endregion

        protected override Size MeasureOverride(Size availableSize)
        {
            var size = new Size(double.PositiveInfinity, double.PositiveInfinity);
            foreach (UIElement element in this.Children)
            {
                element.Measure(size);
            }
            return new Size();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            const double left = 0;

            foreach (UIElement element in this.Children)
            {
                var startTime = element.GetValue(TimeslotPanel.StartTimeProperty) as DateTime?;
                var endTime = element.GetValue(TimeslotPanel.EndTimeProperty) as DateTime?;

                if (!startTime.HasValue || !endTime.HasValue) return finalSize;

                double startMinutes = (startTime.Value.Hour * 60) + startTime.Value.Minute;
                double endMinutes = (endTime.Value.Hour * 60) + endTime.Value.Minute;
                var startOffset = (finalSize.Height / (24 * 60)) * startMinutes;
                var endOffset = (finalSize.Height / (24 * 60)) * endMinutes;

                var top = startOffset;

                var width = finalSize.Width;
                var height = (endOffset - startOffset);

                element.Arrange(new Rect(left, top, width, height));
            }

            return finalSize;
        }
    }
}
