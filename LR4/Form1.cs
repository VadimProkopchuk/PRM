// ======================================
// Copyright © 2019 Vadim Prokopchuk. All rights reserved.
// Contacts: mailvadimprokopchuk@gmail.com
// License:  http://opensource.org/licenses/MIT
// ======================================

using PRM.Algorithms;
using PRM.Models;
using System;
using System.Windows.Forms;
using PRM.Algorithms.Providers;
using PRM.Utils;

namespace LR4
{
    public partial class Form1 : Form
    {
        private readonly PersiptronTextResultProvider _persiptronTextResultProvider;

        private PersiptronFunction[] _functions;
        private PersiptronAlgorithm _persiptron;

        public Form1()
        {
            InitializeComponent();
            
            _persiptronTextResultProvider = new PersiptronTextResultProvider();
        }

        private Vector GetElementsFormGridView()
        {
            var countOfElements = (int) elementsCountNumericUpDown3.Value;
            var matrix = new Vector(countOfElements + 1);

            for (var i = 0; i < countOfElements; i++)
            {
                matrix.Elements[i] = int.Parse((dataGridView1[i, 0].Value ?? 0).ToString());
            }

            matrix.Elements[countOfElements] = 1;

            return matrix;
        }

        private void getClassButton_Click(object sender, EventArgs e)
        {
            var classNumber = _persiptron.GetMaxVectorClass(_functions, GetElementsFormGridView()) + 1;
            classTextBox.Text = $"Заданный вектор принадлежит {classNumber} классу.";
        }

        private void teachingButton_Click_1(object sender, EventArgs e)
        {
            var classCount = (int)classesCountNnumericUpDown.Value;
            var vectorsSize = (int)elementsCountNumericUpDown3.Value;
            var vectorsCount = (int)vectorsCountNumericUpDown.Value;

            dataGridView1.ColumnCount = vectorsSize;
            dataGridView1.RowCount = 1;

            _persiptron = new PersiptronAlgorithm(classCount, vectorsSize + 1);
            var vectors = classCount.GetRandomVectors(vectorsCount, vectorsSize);
            var persiptronResult = _persiptron.GetResult(vectors);

            _functions = persiptronResult.SepareteFunctions;

            if (persiptronResult.HasWarning)
            {
                MessageBox.Show("Итерационный процесс не сошёлся. Возможны неверные результаты",
                    "PERSIPTRON", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            teachingResultTextBox.Text = _persiptronTextResultProvider.GetTextResult(classCount, vectorsCount, vectorsSize, vectors, _functions);
            getClassButton.Enabled = true;
        }
    }
}
