namespace LR4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.getClassButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.teachingButton = new System.Windows.Forms.Button();
            this.elementsCountNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.vectorsCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.classesCountNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.teachingResultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementsCountNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorsCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesCountNnumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 57);
            this.dataGridView1.TabIndex = 9;
            // 
            // getClassButton
            // 
            this.getClassButton.Enabled = false;
            this.getClassButton.Location = new System.Drawing.Point(7, 30);
            this.getClassButton.Margin = new System.Windows.Forms.Padding(4);
            this.getClassButton.Name = "getClassButton";
            this.getClassButton.Size = new System.Drawing.Size(155, 28);
            this.getClassButton.TabIndex = 10;
            this.getClassButton.Text = "Классифицировать";
            this.getClassButton.UseVisualStyleBackColor = true;
            this.getClassButton.Click += new System.EventHandler(this.getClassButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.teachingButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.elementsCountNumericUpDown3);
            this.groupBox1.Controls.Add(this.vectorsCountNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.classesCountNnumericUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 299);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // teachingButton
            // 
            this.teachingButton.Location = new System.Drawing.Point(442, 126);
            this.teachingButton.Margin = new System.Windows.Forms.Padding(4);
            this.teachingButton.Name = "teachingButton";
            this.teachingButton.Size = new System.Drawing.Size(160, 28);
            this.teachingButton.TabIndex = 13;
            this.teachingButton.Text = "Обучение";
            this.teachingButton.UseVisualStyleBackColor = true;
            this.teachingButton.Click += new System.EventHandler(this.teachingButton_Click_1);
            // 
            // elementsCountNumericUpDown3
            // 
            this.elementsCountNumericUpDown3.Location = new System.Drawing.Point(442, 96);
            this.elementsCountNumericUpDown3.Margin = new System.Windows.Forms.Padding(4);
            this.elementsCountNumericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elementsCountNumericUpDown3.Name = "elementsCountNumericUpDown3";
            this.elementsCountNumericUpDown3.Size = new System.Drawing.Size(160, 22);
            this.elementsCountNumericUpDown3.TabIndex = 12;
            this.elementsCountNumericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // vectorsCountNumericUpDown
            // 
            this.vectorsCountNumericUpDown.Location = new System.Drawing.Point(442, 63);
            this.vectorsCountNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.vectorsCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vectorsCountNumericUpDown.Name = "vectorsCountNumericUpDown";
            this.vectorsCountNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.vectorsCountNumericUpDown.TabIndex = 11;
            this.vectorsCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Число объектов в обучающей выборке для каждого класса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Число признаков объекта";
            // 
            // classesCountNnumericUpDown
            // 
            this.classesCountNnumericUpDown.Location = new System.Drawing.Point(442, 31);
            this.classesCountNnumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.classesCountNnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.classesCountNnumericUpDown.Name = "classesCountNnumericUpDown";
            this.classesCountNnumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.classesCountNnumericUpDown.TabIndex = 8;
            this.classesCountNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Число классов";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.teachingResultTextBox);
            this.groupBox2.Location = new System.Drawing.Point(632, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 358);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выходные данные";
            // 
            // teachingResultTextBox
            // 
            this.teachingResultTextBox.Enabled = false;
            this.teachingResultTextBox.Location = new System.Drawing.Point(7, 22);
            this.teachingResultTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.teachingResultTextBox.Multiline = true;
            this.teachingResultTextBox.Name = "teachingResultTextBox";
            this.teachingResultTextBox.ReadOnly = true;
            this.teachingResultTextBox.Size = new System.Drawing.Size(351, 329);
            this.teachingResultTextBox.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.getClassButton);
            this.groupBox3.Location = new System.Drawing.Point(10, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(592, 130);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Классификация";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.classTextBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 53);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результат классификации";
            // 
            // classTextBox
            // 
            this.classTextBox.BackColor = System.Drawing.Color.White;
            this.classTextBox.Enabled = false;
            this.classTextBox.Location = new System.Drawing.Point(8, 24);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.ReadOnly = true;
            this.classTextBox.Size = new System.Drawing.Size(596, 22);
            this.classTextBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 376);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "МиАПР 4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementsCountNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorsCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesCountNnumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button getClassButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button teachingButton;
        private System.Windows.Forms.NumericUpDown elementsCountNumericUpDown3;
        private System.Windows.Forms.NumericUpDown vectorsCountNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown classesCountNnumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox teachingResultTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox classTextBox;
    }
}

