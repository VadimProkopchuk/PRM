using System.Windows.Media;
using PRM.Models;

namespace PRM.Utils
{
    public static class DrawUtils
    {
        public static void DrawClass(this DrawingGroup drawingGroup, int colorNumber, AreaPoints areaPoints)
        {
            var ellipses = new GeometryGroup();

            foreach (var point in areaPoints.GetPoints())
            {
                var pointSize = areaPoints.CompareCore(point) ? 4 : 1;

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