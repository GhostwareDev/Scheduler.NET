using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ghostware.Scheduler.Example
{
    public class BorderGrid : Grid
    {
        protected override void OnRender(DrawingContext dc)
        {
            double leftOffset = 0;
            double topOffset = 0;
            Pen pen = new Pen(Brushes.Gray, 0.5);
            pen.Freeze();

            foreach (RowDefinition row in RowDefinitions)
            {
                dc.DrawLine(pen, new Point(0, topOffset), new Point(this.ActualWidth, topOffset));
                topOffset += row.ActualHeight;
            }

            foreach (ColumnDefinition column in ColumnDefinitions)
            {
                dc.DrawLine(pen, new Point(leftOffset, 0), new Point(leftOffset, ActualHeight));
                leftOffset += column.ActualWidth;
            }

            base.OnRender(dc);
        }
    }
}
