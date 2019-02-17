using System;
using System.CodeDom;
using System.Collections.Generic;
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

        public static DrawingImage GetDrawingImage(this List<AreaPoints> areaPointsList)
        {
            var drawingGroup = new DrawingGroup();
            var colorStep = (int)Math.Pow(2, 24) / areaPointsList.Count;

            for (var i = 0; i < areaPointsList.Count; i++)
            {
                drawingGroup.DrawClass(colorStep * i, areaPointsList[i]);
            }

            return new DrawingImage(drawingGroup);
        }
    }
}