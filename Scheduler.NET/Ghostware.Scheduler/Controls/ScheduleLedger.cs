using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ghostware.Scheduler.Controls
{
    [TemplatePart(Name = ElementLedgerControl, Type = typeof(StackPanel))]
    public class ScheduleLedger : Control
    {
        #region Private Properties

        private const string ElementLedgerControl = "PART_LedgerItems";
        private StackPanel _ledgerItems;

        #endregion

        #region Constructors

        static ScheduleLedger()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScheduleLedger), new FrameworkPropertyMetadata(typeof(ScheduleLedger)));
        }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ledgerItems = GetTemplateChild(ElementLedgerControl) as StackPanel;

            CreateLedgerItems();
        }

        private void CreateLedgerItems()
        {
            if (_ledgerItems == null) return;
            for (var i = 0; i < 24; i++)
            {
                var item = new ScheduleLedgerItem
                {
                    TimeslotA = i.ToString(),
                    TimeslotB = "00"
                };
                item.SetBinding(StyleProperty, GetOwnerBinding("CalendarLedgerItemStyle"));
                _ledgerItems.Children.Add(item);
            }
        }

        public Calendar Owner { get; set; }

        private BindingBase GetOwnerBinding(string propertyName)
        {
            return new Binding(propertyName) { Source = Owner };
        }
    }
}
