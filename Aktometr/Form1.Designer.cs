namespace Aktometr
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startBtn = new System.Windows.Forms.Button();
            this.Filepath = new System.Windows.Forms.TextBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.signalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.secondsActive = new System.Windows.Forms.CheckBox();
            this.writeSecondsIntervalCtrl = new System.Windows.Forms.NumericUpDown();
            this.minutesActive = new System.Windows.Forms.CheckBox();
            this.writeMinutesIntervalCtrl = new System.Windows.Forms.NumericUpDown();
            this.hoursActive = new System.Windows.Forms.CheckBox();
            this.writeHoursIntervalCtrl = new System.Windows.Forms.NumericUpDown();
            this.TotalCountCtrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowExcelCtrl = new System.Windows.Forms.CheckBox();
            this.secondsChart = new System.Windows.Forms.CheckBox();
            this.minutesChart = new System.Windows.Forms.CheckBox();
            this.hoursChart = new System.Windows.Forms.CheckBox();
            this.formatXLS = new System.Windows.Forms.RadioButton();
            this.formatCSV = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.eventCounterCtrl = new Automation.BDaq.EventCounterCtrl(this.components);
            this.sync = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.runtimeLimit = new System.Windows.Forms.CheckBox();
            this.timeLimit = new System.Windows.Forms.NumericUpDown();
            this.time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSecondsIntervalCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeMinutesIntervalCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeHoursIntervalCtrl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(12, 347);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(155, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Filepath
            // 
            this.Filepath.Location = new System.Drawing.Point(173, 14);
            this.Filepath.Name = "Filepath";
            this.Filepath.Size = new System.Drawing.Size(576, 20);
            this.Filepath.TabIndex = 1;
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(173, 347);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(155, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // signalChart
            // 
            this.signalChart.BackColor = System.Drawing.SystemColors.Control;
            this.signalChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.signalChart.BorderlineWidth = 0;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Bisque;
            chartArea1.AxisX.MinorTickMark.LineWidth = 0;
            chartArea1.AxisX.TitleForeColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 12D;
            chartArea1.AxisY.MaximumAutoSize = 20F;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.LightGray;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackSecondaryColor = System.Drawing.SystemColors.Control;
            chartArea1.BorderColor = System.Drawing.SystemColors.Control;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.signalChart.ChartAreas.Add(chartArea1);
            this.signalChart.Location = new System.Drawing.Point(12, 115);
            this.signalChart.Name = "signalChart";
            this.signalChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Name = "Signal";
            this.signalChart.Series.Add(series1);
            this.signalChart.Size = new System.Drawing.Size(737, 222);
            this.signalChart.TabIndex = 6;
            // 
            // secondsActive
            // 
            this.secondsActive.AutoSize = true;
            this.secondsActive.Location = new System.Drawing.Point(5, 22);
            this.secondsActive.Name = "secondsActive";
            this.secondsActive.Size = new System.Drawing.Size(68, 17);
            this.secondsActive.TabIndex = 7;
            this.secondsActive.Text = "Sekundy";
            this.secondsActive.UseVisualStyleBackColor = true;
            this.secondsActive.CheckedChanged += new System.EventHandler(this.secondsActive_CheckedChanged);
            // 
            // writeSecondsIntervalCtrl
            // 
            this.writeSecondsIntervalCtrl.Enabled = false;
            this.writeSecondsIntervalCtrl.Location = new System.Drawing.Point(75, 22);
            this.writeSecondsIntervalCtrl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.writeSecondsIntervalCtrl.Name = "writeSecondsIntervalCtrl";
            this.writeSecondsIntervalCtrl.Size = new System.Drawing.Size(54, 20);
            this.writeSecondsIntervalCtrl.TabIndex = 8;
            this.writeSecondsIntervalCtrl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minutesActive
            // 
            this.minutesActive.AutoSize = true;
            this.minutesActive.Location = new System.Drawing.Point(135, 22);
            this.minutesActive.Name = "minutesActive";
            this.minutesActive.Size = new System.Drawing.Size(57, 17);
            this.minutesActive.TabIndex = 9;
            this.minutesActive.Text = "Minuty";
            this.minutesActive.UseVisualStyleBackColor = true;
            this.minutesActive.CheckedChanged += new System.EventHandler(this.minutesActive_CheckedChanged);
            // 
            // writeMinutesIntervalCtrl
            // 
            this.writeMinutesIntervalCtrl.Enabled = false;
            this.writeMinutesIntervalCtrl.Location = new System.Drawing.Point(194, 22);
            this.writeMinutesIntervalCtrl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.writeMinutesIntervalCtrl.Name = "writeMinutesIntervalCtrl";
            this.writeMinutesIntervalCtrl.Size = new System.Drawing.Size(51, 20);
            this.writeMinutesIntervalCtrl.TabIndex = 10;
            this.writeMinutesIntervalCtrl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // hoursActive
            // 
            this.hoursActive.AutoSize = true;
            this.hoursActive.Location = new System.Drawing.Point(260, 23);
            this.hoursActive.Name = "hoursActive";
            this.hoursActive.Size = new System.Drawing.Size(64, 17);
            this.hoursActive.TabIndex = 11;
            this.hoursActive.Text = "Godziny";
            this.hoursActive.UseVisualStyleBackColor = true;
            this.hoursActive.CheckedChanged += new System.EventHandler(this.hoursActive_CheckedChanged);
            // 
            // writeHoursIntervalCtrl
            // 
            this.writeHoursIntervalCtrl.Enabled = false;
            this.writeHoursIntervalCtrl.Location = new System.Drawing.Point(327, 20);
            this.writeHoursIntervalCtrl.Name = "writeHoursIntervalCtrl";
            this.writeHoursIntervalCtrl.Size = new System.Drawing.Size(46, 20);
            this.writeHoursIntervalCtrl.TabIndex = 12;
            this.writeHoursIntervalCtrl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TotalCountCtrl
            // 
            this.TotalCountCtrl.Enabled = false;
            this.TotalCountCtrl.Location = new System.Drawing.Point(649, 347);
            this.TotalCountCtrl.Name = "TotalCountCtrl";
            this.TotalCountCtrl.Size = new System.Drawing.Size(100, 20);
            this.TotalCountCtrl.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Licznik:";
            // 
            // ShowExcelCtrl
            // 
            this.ShowExcelCtrl.AutoSize = true;
            this.ShowExcelCtrl.Enabled = false;
            this.ShowExcelCtrl.Location = new System.Drawing.Point(613, 41);
            this.ShowExcelCtrl.Name = "ShowExcelCtrl";
            this.ShowExcelCtrl.Size = new System.Drawing.Size(90, 17);
            this.ShowExcelCtrl.TabIndex = 15;
            this.ShowExcelCtrl.Text = "Pokaż arkusz";
            this.ShowExcelCtrl.UseVisualStyleBackColor = true;
            this.ShowExcelCtrl.CheckedChanged += new System.EventHandler(this.ShowExcelCtrl_CheckedChanged);
            // 
            // secondsChart
            // 
            this.secondsChart.AutoSize = true;
            this.secondsChart.Enabled = false;
            this.secondsChart.Location = new System.Drawing.Point(5, 45);
            this.secondsChart.Margin = new System.Windows.Forms.Padding(2);
            this.secondsChart.Name = "secondsChart";
            this.secondsChart.Size = new System.Drawing.Size(62, 17);
            this.secondsChart.TabIndex = 16;
            this.secondsChart.Text = "Wykres";
            this.secondsChart.UseVisualStyleBackColor = true;
            // 
            // minutesChart
            // 
            this.minutesChart.AutoSize = true;
            this.minutesChart.Enabled = false;
            this.minutesChart.Location = new System.Drawing.Point(135, 45);
            this.minutesChart.Margin = new System.Windows.Forms.Padding(2);
            this.minutesChart.Name = "minutesChart";
            this.minutesChart.Size = new System.Drawing.Size(62, 17);
            this.minutesChart.TabIndex = 17;
            this.minutesChart.Text = "Wykres";
            this.minutesChart.UseVisualStyleBackColor = true;
            // 
            // hoursChart
            // 
            this.hoursChart.AutoSize = true;
            this.hoursChart.Enabled = false;
            this.hoursChart.Location = new System.Drawing.Point(260, 45);
            this.hoursChart.Margin = new System.Windows.Forms.Padding(2);
            this.hoursChart.Name = "hoursChart";
            this.hoursChart.Size = new System.Drawing.Size(62, 17);
            this.hoursChart.TabIndex = 18;
            this.hoursChart.Text = "Wykres";
            this.hoursChart.UseVisualStyleBackColor = true;
            // 
            // formatXLS
            // 
            this.formatXLS.AutoSize = true;
            this.formatXLS.Location = new System.Drawing.Point(4, 17);
            this.formatXLS.Margin = new System.Windows.Forms.Padding(2);
            this.formatXLS.Name = "formatXLS";
            this.formatXLS.Size = new System.Drawing.Size(45, 17);
            this.formatXLS.TabIndex = 19;
            this.formatXLS.Text = "XLS";
            this.formatXLS.UseVisualStyleBackColor = true;
            this.formatXLS.CheckedChanged += new System.EventHandler(this.formatXLS_CheckedChanged);
            // 
            // formatCSV
            // 
            this.formatCSV.AutoSize = true;
            this.formatCSV.Checked = true;
            this.formatCSV.Location = new System.Drawing.Point(4, 39);
            this.formatCSV.Margin = new System.Windows.Forms.Padding(2);
            this.formatCSV.Name = "formatCSV";
            this.formatCSV.Size = new System.Drawing.Size(46, 17);
            this.formatCSV.TabIndex = 20;
            this.formatCSV.TabStop = true;
            this.formatCSV.Text = "CSV";
            this.formatCSV.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secondsActive);
            this.groupBox1.Controls.Add(this.secondsChart);
            this.groupBox1.Controls.Add(this.writeSecondsIntervalCtrl);
            this.groupBox1.Controls.Add(this.hoursChart);
            this.groupBox1.Controls.Add(this.minutesActive);
            this.groupBox1.Controls.Add(this.minutesChart);
            this.groupBox1.Controls.Add(this.writeHoursIntervalCtrl);
            this.groupBox1.Controls.Add(this.writeMinutesIntervalCtrl);
            this.groupBox1.Controls.Add(this.hoursActive);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(390, 68);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interval zapisu";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.formatXLS);
            this.groupBox2.Controls.Add(this.formatCSV);
            this.groupBox2.Location = new System.Drawing.Point(406, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(79, 66);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format pliku";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(339, 352);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLabel.TabIndex = 23;
            // 
            // eventCounterCtrl
            // 
            this.eventCounterCtrl._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("eventCounterCtrl._StateStream")));
            // 
            // sync
            // 
            this.sync.AutoSize = true;
            this.sync.Location = new System.Drawing.Point(613, 61);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(137, 17);
            this.sync.TabIndex = 24;
            this.sync.Text = "Synchronizuj z zegarem";
            this.sync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sync.UseVisualStyleBackColor = true;
            this.sync.CheckedChanged += new System.EventHandler(this.sync_CheckedChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(17, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 23);
            this.saveBtn.TabIndex = 25;
            this.saveBtn.Text = "Zapisz jako...";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // runtimeLimit
            // 
            this.runtimeLimit.AutoSize = true;
            this.runtimeLimit.Location = new System.Drawing.Point(490, 41);
            this.runtimeLimit.Name = "runtimeLimit";
            this.runtimeLimit.Size = new System.Drawing.Size(82, 17);
            this.runtimeLimit.TabIndex = 26;
            this.runtimeLimit.Text = "Czas zapisu";
            this.runtimeLimit.UseVisualStyleBackColor = true;
            this.runtimeLimit.CheckedChanged += new System.EventHandler(this.runtimeLimit_CheckedChanged);
            // 
            // timeLimit
            // 
            this.timeLimit.Enabled = false;
            this.timeLimit.Location = new System.Drawing.Point(490, 57);
            this.timeLimit.Name = "timeLimit";
            this.timeLimit.Size = new System.Drawing.Size(43, 20);
            this.timeLimit.TabIndex = 27;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(540, 64);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 13);
            this.time.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 377);
            this.Controls.Add(this.time);
            this.Controls.Add(this.timeLimit);
            this.Controls.Add(this.runtimeLimit);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.sync);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ShowExcelCtrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalCountCtrl);
            this.Controls.Add(this.signalChart);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.Filepath);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Aktometr";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSecondsIntervalCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeMinutesIntervalCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeHoursIntervalCtrl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox Filepath;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart signalChart;
        private System.Windows.Forms.CheckBox secondsActive;
        private System.Windows.Forms.NumericUpDown writeSecondsIntervalCtrl;
        private System.Windows.Forms.CheckBox minutesActive;
        private System.Windows.Forms.NumericUpDown writeMinutesIntervalCtrl;
        private System.Windows.Forms.CheckBox hoursActive;
        private System.Windows.Forms.NumericUpDown writeHoursIntervalCtrl;
        private System.Windows.Forms.TextBox TotalCountCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ShowExcelCtrl;
        private System.Windows.Forms.CheckBox secondsChart;
        private System.Windows.Forms.CheckBox minutesChart;
        private System.Windows.Forms.CheckBox hoursChart;
        private System.Windows.Forms.RadioButton formatXLS;
        private System.Windows.Forms.RadioButton formatCSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label timeLabel;
        private Automation.BDaq.EventCounterCtrl eventCounterCtrl;
        private System.Windows.Forms.CheckBox sync;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox runtimeLimit;
        private System.Windows.Forms.NumericUpDown timeLimit;
        private System.Windows.Forms.Label time;
    }
}

