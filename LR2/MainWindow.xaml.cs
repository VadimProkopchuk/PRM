using PRM.Algorithms;
using PRM.Utils;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PRM.LR2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CountOfPoints.Text, out var countOfPoints))
            {
                PointsImage.Source = await GetDrawingImage(countOfPoints, (int)PointsImage.Width, (int)PointsImage.Height - 40);
            }
        }

        private async Task<DrawingImage> GetDrawingImage(int countOfPoints, int maxX, int maxY)
        {
            var maximinAlgorithm = new MaximinAlgorithm(countOfPoints.GenerateRandomPoints(maxX, maxY));
            var result = await maximinAlgorithm.GetResultAsync();
            var drawingGroup = new DrawingGroup();
            var colorStep = (int)Math.Pow(2, 24) / result.Count;

            for (var i = 0; i < result.Count; i++)
            {
                drawingGroup.DrawClass(colorStep * i, result[i]);
            }

            return new DrawingImage(drawingGroup);
        }
    }
}
