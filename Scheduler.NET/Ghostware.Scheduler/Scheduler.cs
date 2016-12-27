using Ghostware.Scheduler.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ghostware.Scheduler
{
    public class Scheduler : Control
    {
        #region Private Properties

        private const string SchedulerGrid = "PART_SchedulerGrid";
        private const string SchedulerItemGrid = "PART_SchedulerItemGrid";
        private const string SchedulerScrollViewer = "PART_ScrollViewer";

        private Grid _schedulerGrid;
        private Grid _schedulerItemGrid;
        private ScrollViewer _scrollViewer;

        #endregion

        #region Constructors

        static Scheduler()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Scheduler), new FrameworkPropertyMetadata(typeof(Scheduler)));
        }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _schedulerGrid = GetTemplateChild(SchedulerGrid) as Grid;
            _schedulerItemGrid = GetTemplateChild(SchedulerItemGrid) as Grid;
            _scrollViewer = GetTemplateChild(SchedulerScrollViewer) as ScrollViewer;
            CreateDays();
        }

        private void CreateDays()
        {
            if (_schedulerGrid == null) return;
            var dayCount = 7;
            var offset = _schedulerGrid.ColumnDefinitions.Count - 1;
            Grid.SetColumnSpan(_scrollViewer, dayCount + 1);

            for (var i = 1; i <= dayCount; i++)
            {
                var item = new ScheduleHeader
                {
                    DayHeader = i.ToString()
                };
                item.SetBinding(StyleProperty, GetOwnerBinding("ScheduleHeaderItemStyle"));
                _schedulerGrid.ColumnDefinitions.Add(new ColumnDefinition());

                _schedulerGrid.Children.Add(item);
                Grid.SetRow(item, 0);
                Grid.SetColumn(item, offset + i);

                var dayItem = new ScheduleDay();
                item.SetBinding(StyleProperty, GetOwnerBinding("ScheduleDayItemStyle"));
                _schedulerItemGrid.ColumnDefinitions.Add(new ColumnDefinition());

                _schedulerItemGrid.Children.Add(dayItem);
                Grid.SetRow(dayItem, 0);
                Grid.SetColumn(dayItem, offset + i);
            }
        }

        private BindingBase GetOwnerBinding(string propertyName)
        {
            return new Binding(propertyName) { Source = this };
        }
    }
}
