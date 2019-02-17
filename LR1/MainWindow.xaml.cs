using System;
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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CountOfPoints.Text, out var countOfPoints) &&
                int.TryParse(CountOfClasses.Text, out var countOfClasses))
            {
                PointsImage.Source = await GetDrawingImage(countOfPoints, countOfClasses, (int) PointsImage.Width, (int) PointsImage.Height - 40);
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
