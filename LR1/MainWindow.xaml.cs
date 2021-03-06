﻿// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using PRM.Algorithms;
using PRM.Utils;

namespace PRM.LR1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button.Content = "Распределить";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CountOfPoints.Text, out var countOfPoints) &&
                int.TryParse(CountOfClasses.Text, out var countOfClasses))
            {
                Button.Content = "Загрузка";
                Button.IsEnabled = false;
                PointsImage.Source = await GetDrawingImage(countOfPoints, countOfClasses, (int) PointsImage.Width, (int) PointsImage.Height - 40);
                Button.Content = "Распределить";
                Button.IsEnabled = true;
            }
        }

        private async Task<DrawingImage> GetDrawingImage(int countOfPoints, int countOfClasses, int maxX, int maxY)
        {
            var kMeansAlgorithm = new KMeansAlgorithm(countOfPoints.GenerateRandomPoints(maxX, maxY), countOfClasses);
            var result = await kMeansAlgorithm.GetResultAsync();

            return result.GetDrawingImage();
        }
    }
}
