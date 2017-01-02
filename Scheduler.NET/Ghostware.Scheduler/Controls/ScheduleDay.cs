using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ghostware.Scheduler.Controls
{
    public class ScheduleDay : ItemsControl
    {
        private const string ElementTimeslotItems = "PART_TimeslotItems";

        StackPanel _dayItems;

        static ScheduleDay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleDay), new FrameworkPropertyMetadata(typeof(ScheduleDay)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _dayItems = GetTemplateChild(ElementTimeslotItems) as StackPanel;

            PopulateDay();
        }

        public void PopulateDay()
        {
             if (_dayItems != null)
            {
                _dayItems.Children.Clear();

                var startTime = new DateTime(2016, 12, 30, 0, 0, 0);
                for (int i = 0; i < 48; i++)
                {
                    var timeslot = new SchedulerTimeslotItem
                    {
                        StartTime = startTime,
                        EndTime = startTime + TimeSpan.FromMinutes(30)
                    };

                    if (startTime.Hour >= 8 && startTime.Hour <= 17)
                        timeslot.SetBinding(BackgroundProperty, GetOwnerBinding("PeakTimeslotBackground"));
                    else
                        timeslot.SetBinding(BackgroundProperty, GetOwnerBinding("OffPeakTimeslotBackground"));

                    timeslot.SetBinding(StyleProperty, GetOwnerBinding("CalendarTimeslotItemStyle"));
                    _dayItems.Children.Add(timeslot);

                    startTime = startTime + TimeSpan.FromMinutes(30);
                }
            }
            //if (Owner != null)
            //{
            //    Owner.ScrollToHome();
            //}
        }

        //#region ItemsControl Container Override

        //protected override DependencyObject GetContainerForItemOverride()
        //{
        //    return new CalendarAppointmentItem();
        //}

        //protected override bool IsItemItsOwnContainerOverride(object item)
        //{
        //    return (item is CalendarAppointmentItem);
        //}

        //#endregion

        public Calendar Owner { get; set; }

        private BindingBase GetOwnerBinding(string propertyName)
        {
            var result = new Binding(propertyName) {Source = Owner};
            return result;
        }
    }
}
