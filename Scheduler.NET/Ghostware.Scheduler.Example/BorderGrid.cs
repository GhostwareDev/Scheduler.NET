using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ghostware.Scheduler.Example
{
    public class BorderGrid : Grid
    {
        public BorderGrid()
        {
            Background = Brushes.Transparent;
        }

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

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            var point = Mouse.GetPosition(this);

            var row = 0;
            var col = 0;
            var accumulatedHeight = 0.0;
            var accumulatedWidth = 0.0;

            foreach (var rowDefinition in RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            //color cell Red:
            var childGrid = new Grid {Background = Brushes.Red};
            SetColumn(childGrid, col);
            SetRow(childGrid, row);
            Children.Add(childGrid);
        }
    }
}
