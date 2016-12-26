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
        private Grid _schedulerGrid;

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
            CreateDays();
        }

        private void CreateDays()
        {
            if (_schedulerGrid == null) return;

            var offset = _schedulerGrid.ColumnDefinitions.Count - 1;
            for (var i = 1; i <= 7; i++)
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
            }
        }

        private BindingBase GetOwnerBinding(string propertyName)
        {
            return new Binding(propertyName) { Source = this };
        }
    }
}
