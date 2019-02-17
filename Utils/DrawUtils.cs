using PRM.Models.KMeans;
using System.Windows.Media;

namespace PRM.Utils
{
    public static class DrawUtils
    {
        public static void DrawClass(this DrawingGroup drawingGroup, int colorNumber, KMeans kClass)
        {
            var ellipses = new GeometryGroup();

            foreach (var point in kClass.GetPoints())
            {
                var pointSize = kClass.CompareCenter(point) ? 4 : 1;

                ellipses.Children.Add(new EllipseGeometry(point, pointSize, pointSize));
            }

            var classColor = colorNumber.GetColor();
            var brush = new SolidColorBrush(classColor);
            var geometryDrawing = new GeometryDrawing(brush, new Pen(brush, 1), ellipses)
            {
                Geometry = ellipses
            };

            drawingGroup.Children.Add(geometryDrawing);
        }
    }
}