// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using PRM.Algorithms;
using PRM.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using PRM.Models;

namespace PRM.LR2
{
    public partial class MainWindow : Window
    {
        private List<Point> _points;
        private List<AreaPoints> _areaPoints;

        public MainWindow()
        {
            InitializeComponent();
            KMeansButton.IsEnabled = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CountOfPoints.Text, out var countOfPoints))
            {
                Button.Content = "Загрузка";
                Button.IsEnabled = false;
                PointsImage.Source = await GetDrawingImage(countOfPoints, (int)PointsImage.Width, (int)PointsImage.Height - 40);
                Button.Content = "Распределить";
                Button.IsEnabled = KMeansButton.IsEnabled = true;
            }
        }

        private async void KMeansButton_Click(object sender, RoutedEventArgs e)
        {
            KMeansButton.Content = "Загрузка";
            Button.IsEnabled = KMeansButton.IsEnabled = false;

            PointsImage.Source = await GetDrawingImage();

            KMeansButton.Content = "K-Means";
            Button.IsEnabled = KMeansButton.IsEnabled = true;
        }

        private async Task<DrawingImage> GetDrawingImage(int countOfPoints, int maxX, int maxY)
        {
            var maximinAlgorithm = new MaximinAlgorithm(_points = countOfPoints.GenerateRandomPoints(maxX, maxY).ToList());
            _areaPoints = await maximinAlgorithm.GetResultAsync();

            return _areaPoints.GetDrawingImage();
        }

        private async Task<DrawingImage> GetDrawingImage()
        {
            var kmeansAlgorithm = new KMeansAlgorithm(_points, _areaPoints);
            var result = await kmeansAlgorithm.GetResultAsync();

            return result.GetDrawingImage();
        }
    }
}
