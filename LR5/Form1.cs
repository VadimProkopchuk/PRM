// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PRM.Algorithms;
using PRM.Models;

namespace LR5
{
    public partial class Form1 : Form
    {
        private readonly ToolTip _tooltip = new ToolTip();
        private readonly List<Point>[] _points = new List<Point>[2];

        private PotentialsFunction _separetFunction = null;
        private double _step;
        private bool _showen = false;

        public Form1()
        {
            _points[0] = new List<Point>();
            _points[1] = new List<Point>();
            InitializeComponent();
        }

        private void teachingButton_Click(object sender, EventArgs e)
        {
            _step = pictureBox.Height / 20;

            var potentials = new PotentialsAlgorithm();
            var teaching = new Point[2][];

            teaching[0] = new Point[2];
            teaching[1] = new Point[2];

            teaching[0][0] = new Point((int)x11NumericUpDown.Value, (int)y11NumericUpDown.Value);
            teaching[0][1] = new Point((int)x12NumericUpDown.Value, (int)y12NumericUpDown.Value);
            teaching[1][0] = new Point((int)x21NumericUpDown.Value, (int)y21NumericUpDown.Value);
            teaching[1][1] = new Point((int)x22NumericUpDown.Value, (int)y22NumericUpDown.Value);

            _points[0].Add(teaching[0][0]);
            _points[0].Add(teaching[0][1]);
            _points[1].Add(teaching[1][0]);
            _points[1].Add(teaching[1][1]);

            var potentialsResult = potentials.GetResult(teaching);
            _separetFunction = potentialsResult.Function;
            functionTextBox.Text = String.Empty;

            if (!potentialsResult.HasWarning)
            {
                functionTextBox.Text = "Разделяющая функция: " + _separetFunction.ToString();
            }
            else
            {
                MessageBox.Show("Невозможно построить разделяющую функцию", "POTENTIALS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                if (!potentialsResult.HasWarning)
                {
                    DrawGraph(graphics);
                }

                graphics.DrawLine(Pens.Black, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
                graphics.DrawLine(Pens.Black, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height);

                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        DrawPoint(graphics, teaching[i][j], i);
                    }
                }
            }

            pictureBox.Image = bitmap;
            testGroupBox.Enabled = !potentialsResult.HasWarning;
        }

        private void DrawGraph(Graphics graphics)
        {
            var graphPen = new Pen(Color.Red, 2);
            var prevPoint = new Point(pictureBox.Width / 2 + (int)(-pictureBox.Width / 2 * _step),
                pictureBox.Height / 2 - (int)(_separetFunction.GetY(-pictureBox.Width / 2 / _step) * _step));
            for (double x = -pictureBox.Width / 2; x < pictureBox.Width / 2; x += 0.1)
            {
                var y = _separetFunction.GetY(x / _step);
                var nextPoint = new Point((int)(pictureBox.Width / 2 + x),
                    (int)(pictureBox.Height / 2 - y * _step));
                if (Math.Abs(nextPoint.Y - prevPoint.Y) < pictureBox.Height)
                {
                    graphics.DrawLine((Pen)graphPen, prevPoint, nextPoint);
                }

                prevPoint = nextPoint;
            }
        }

        private void DrawPoint(Graphics graphics, Point point, int classNumber)
        {
            graphics.FillEllipse(new SolidBrush(classNumber == 0 ? Color.ForestGreen : Color.Blue),
                (int)(pictureBox.Width / 2 + point.X * _step - 4),
                (int)(pictureBox.Height / 2 - point.Y * _step - 4), 9, 9);
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawToolTip(e, _points[0], 1)) return;
            if (DrawToolTip(e, _points[1], 2)) return;
            _tooltip.Hide(pictureBox);
            _showen = false;

        }

        private bool DrawToolTip(MouseEventArgs e, IEnumerable<Point> list, int classNumber)
        {
            foreach (var point in list)
            {
                var position = e.Location;
                if (Math.Abs(point.X * _step + pictureBox.Width / 2 - position.X) < 10 &&
                    Math.Abs(pictureBox.Height / 2 - point.Y * _step - position.Y) < 10)
                {
                    if (!_showen)
                    {
                        _tooltip.Show($"Класс:{classNumber}\r\n({point.X};{point.Y})", pictureBox, e.Location + new Size(10, 10));
                        _showen = true;

                    }
                    return true;

                }
            }
            return false;
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            var testPoint = new Point((int)testXNumericUpDown.Value, (int)testYNumericUpDown.Value);
            var classNumber = _separetFunction.GetValue(testPoint) >= 0 ? 0 : 1;
            var bitmap = new Bitmap(pictureBox.Image);

            _points[classNumber].Add(testPoint);
            testTextBox.Text = $@"Класс {classNumber + 1}";
            pictureBox.Image.Dispose();

            using (var graphics = Graphics.FromImage(bitmap))
            {
                DrawPoint(graphics, testPoint, classNumber);
            }

            pictureBox.Image = bitmap;
        }
    }
}
