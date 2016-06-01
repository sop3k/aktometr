using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Excel = Microsoft.Office.Interop.Excel;

namespace Aktometr
{
    public partial class Form1 : Form
    {
        Point[] chartData = new Point[100];
        bool isCanceled;
        bool ShowExcel = false;
        int readFreq = 0;

        System.Threading.Timer secondsTimer;
        System.Threading.Timer minutesTimer;
        System.Threading.Timer hoursTimer;

        BackgroundWorker deviceWorker = new BackgroundWorker();

        public Form1()
        {
            deviceWorker.WorkerSupportsCancellation = true;
            deviceWorker.DoWork += new DoWorkEventHandler(deviceWorker_DoWork);

            InitializeComponent();
        }

        private void FillData()
        {
            for (int i = 0; i < 33; i++)
            {
                signalChart.Series[0].Points.AddXY(i, 0);
                signalChart.Series[0].Points.AddXY(i, 0);
                signalChart.Series[0].Points.AddXY(i, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!eventCounterCtrl.Initialized)
            {
                MessageBox.Show("Urządzenie nie gotowe.", "Aktometr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillData();

            startBtn.Enabled = false;
            stopBtn.Enabled = true;

            deviceWorker.RunWorkerAsync(Filepath.Text);
        }

        private Excel.Chart CreateChart(ExcelWriter writer, Excel.Worksheet worksheet)
        {
            int used = worksheet.UsedRange.Rows.Count;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.Chart chartPage = xlCharts.Add(200.0, 30.0, 400.0, 300.0).Chart;
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            return chartPage;
        }

        private void deviceWorker_DoWork(Object sender, DoWorkEventArgs args)
        {
            ExcelWriter excel = null;
            Excel.Workbook workbook = null;
            System.IO.StreamWriter file = null;

            eventCounterCtrl.Enabled = true;

            try
            {
                Excel.Worksheet seconds = null;
                Excel.Worksheet minutes = null;
                Excel.Worksheet hours = null;

                Excel.Chart chartSeconds = null;
                Excel.Chart chartMinutes = null;
                Excel.Chart chartHours = null;

                if (formatXLS.Checked)
                {
                    excel = new ExcelWriter(ShowExcel);
                    workbook = excel.CreateExcelWorkbook();

                    if (secondsActive.Checked)
                    {
                        seconds = excel.CreateWorksheet(workbook, "seconds");
                        chartSeconds = CreateChart(excel, seconds);

                        excel.getCell(seconds, 1, 1).Value2 = "Czas";
                        excel.getCell(seconds, 1, 2).Value2 = "Licznik";
                        excel.getCell(seconds, 1, 3).Value2 = "Zmiana";
                        excel.getCell(seconds, 1, 4).Value2 = "Start:";

                        excel.getCell(seconds, 2, 1).Value2 = "0.00:00:00.00";
                        excel.getCell(seconds, 2, 2).Value2 = "0";
                        excel.getCell(seconds, 2, 3).Value2 = "0";

                        excel.getCell(seconds, 1, 5).Value2 = String.Format(@"{0:g}", DateTime.Now);
                        excel.getCell(seconds, 1, 5).Columns.AutoFit(); 
                    }

                    if (minutesActive.Checked)
                    {
                        minutes = excel.CreateWorksheet(workbook, "minutes");
                        chartMinutes = CreateChart(excel, minutes);

                        excel.getCell(minutes, 1, 4).Value2 = "Start:";
                        excel.getCell(minutes, 1, 1).Value2 = "Czas:";
                        excel.getCell(minutes, 1, 2).Value2 = "Licznik";
                        excel.getCell(minutes, 1, 3).Value2 = "Zmiana";

                        excel.getCell(minutes, 2, 1).Value2 = "0.00:00:00.00";
                        excel.getCell(minutes, 2, 2).Value2 = "0";
                        excel.getCell(minutes, 2, 3).Value2 = "0";

                        excel.getCell(minutes, 2, 5).Value2 = String.Format(@"{0:g}", DateTime.Now);
                        excel.getCell(minutes, 2, 5).Columns.AutoFit();
                    }

                    if (hoursActive.Checked)
                    {
                        hours = excel.CreateWorksheet(workbook, "hours");
                        chartHours = CreateChart(excel, hours);

                        excel.getCell(hours, 1, 4).Value2 = "Start:";

                        excel.getCell(hours, 1, 1).Value2 = "Czas";
                        excel.getCell(hours, 1, 2).Value2 = "Licznik";
                        excel.getCell(hours, 1, 3).Value2 = "Zmiana";

                        excel.getCell(hours, 2, 1).Value2 = "0.00:00:00.00";
                        excel.getCell(hours, 2, 2).Value2 = "0";
                        excel.getCell(hours, 2, 3).Value2 = "0";

                        excel.getCell(hours, 1, 5).Value2 = String.Format(@"{0:g}", DateTime.Now);
                        excel.getCell(hours, 1, 5).Columns.AutoFit();
                    
                    }
                }
                else if (formatCSV.Checked)
                {
                    file = new System.IO.StreamWriter((String)args.Argument);
                    file.AutoFlush = true;

                    file.WriteLine("Start: {0:g}", DateTime.Now);
                    file.WriteLine("Time;Sekundy;ZmianaSekundy;Minuty;ZmianaMinuty;Godziny;ZmianaGodziny");
                }

                byte oldData = 0xFF;
                byte data = 0x00;
                long counter = 0;

                System.TimeSpan writeSecondsInterval = TimeSpan.FromMilliseconds((double)writeSecondsIntervalCtrl.Value * 1000);
                System.TimeSpan writeMinutesInterval = TimeSpan.FromMinutes((double)writeMinutesIntervalCtrl.Value);
                System.TimeSpan writeHoursInterval = TimeSpan.FromHours((double)writeHoursIntervalCtrl.Value);

                Stopwatch fromBegin = Stopwatch.StartNew();
                Stopwatch lastSleep = Stopwatch.StartNew();

                Stopwatch writeSecondsTimer = Stopwatch.StartNew();
                Stopwatch writeMinutesTimer = Stopwatch.StartNew();
                Stopwatch writeHoursTimer = Stopwatch.StartNew();

                //starting row
                int currentSecond = 2;
                int currentMinute = 2;
                int currentHour = 2;

                long oldCounterSeconds = 0;
                long oldCounterMinutes = 0;
                long oldCounterHours = 0;

                long timeTick = 0;

                bool bufferReady = false;

                do
                {
                    if(formatXLS.Checked)
                        excel.ShowOrHide(ShowExcel);

                    if (getRunTimeLimit() <= (decimal)fromBegin.Elapsed.TotalSeconds)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            Stop();
                        });
                    }

                    String[] buffer = { "", "", "", "", "", "", "" };

                    if (secondsActive.Checked &&
                        TimeSpan.Compare(writeSecondsTimer.Elapsed, writeSecondsInterval) >= 0)
                    {
                        ++currentSecond;

                        if (formatXLS.Checked)
                        {
                            excel.getCell(seconds, currentSecond, 1).Value2 = String.Format(@"{0:d\.hh\:mm\:ss\.ff}", fromBegin.Elapsed);
                            excel.getCell(seconds, currentSecond, 2).Value2 = String.Format("{0}", counter);
                            excel.getCell(seconds, currentSecond, 3).Value2 = String.Format("{0}", counter - oldCounterSeconds);
                        }
                        else
                        {
                            buffer[1] = String.Format("{0}", counter);
                            buffer[2] = String.Format("{0}", counter - oldCounterSeconds);

                            bufferReady = true;
                        }

                        writeSecondsTimer.Restart();
                        oldCounterSeconds = counter;

                        if (formatXLS.Checked && secondsChart.Checked)
                        {
                            Excel.Range[] range = new Excel.Range[2]{
                                seconds.Range[seconds.Cells[1, 1], seconds.Cells[seconds.UsedRange.Rows.Count, 1]],
                                seconds.Range[seconds.Cells[1, 3], seconds.Cells[seconds.UsedRange.Rows.Count, 3]]
                            };

                            chartSeconds.SetSourceData(excel.Union(range[0], range[1]));            
                        }

                        if(formatXLS.Checked)
                            seconds.ChartObjects(Type.Missing).Visible = secondsChart.Checked;
                    }

                    if (minutesActive.Checked &&
                        writeMinutesTimer.ElapsedMilliseconds >= writeMinutesInterval.TotalMilliseconds)
                    {
                        if ((sync.Checked && DateTime.Now.Second == 0) || !sync.Checked)
                        {
                            ++currentMinute;

                            if (formatXLS.Checked)
                            {
                                String format = @"{0:d\.hh\:mm\:ss}";
                                TimeSpan time = fromBegin.Elapsed;
                                if (sync.Checked)
                                {
                                    time = new TimeSpan(
                                        System.DateTime.Now.Hour,
                                        System.DateTime.Now.Minute,
                                        0);

                                    format = @"{0:hh\:mm\:ss}";
                                }
                                excel.getCell(minutes, currentMinute, 1).Value2 = String.Format(format, time);
                                excel.getCell(minutes, currentMinute, 2).Value2 = String.Format("{0}", counter);
                                excel.getCell(minutes, currentMinute, 3).Value2 = String.Format("{0}", counter - oldCounterMinutes);
                            }
                            else
                            {
                                buffer[3] = String.Format("{0}", counter);
                                buffer[4] = String.Format("{0}", counter - oldCounterMinutes);

                                bufferReady = true;
                            }

                            writeMinutesTimer.Restart();
                            oldCounterMinutes = counter;

                            if (minutesChart.Checked && formatXLS.Checked)
                            {
                                Excel.Range[] range = new Excel.Range[2]{
                                    minutes.Range[minutes.Cells[1, 1], minutes.Cells[minutes.UsedRange.Rows.Count, 1]],
                                    minutes.Range[minutes.Cells[1, 3], minutes.Cells[minutes.UsedRange.Rows.Count, 3]]
                                };

                                chartMinutes.SetSourceData(excel.Union(range[0], range[1]));
                            }

                            if(formatXLS.Checked) 
                                minutes.ChartObjects(Type.Missing).Visible = minutesChart.Checked;
                        }
                    }

                    if (hoursActive.Checked &&
                        writeHoursTimer.ElapsedMilliseconds >= writeHoursInterval.TotalMilliseconds)
                    {
                        if ((sync.Checked && DateTime.Now.Minute == 0) || !sync.Checked)
                        {
                            ++currentHour;

                            if (formatXLS.Checked)
                            {
                                String format = @"{0:d\.hh\:mm\:ss}";
                                TimeSpan time = fromBegin.Elapsed;
                                if (sync.Checked)
                                {
                                    time = new TimeSpan(
                                        System.DateTime.Now.Hour,
                                        System.DateTime.Now.Minute,
                                        0);
                                    format = @"{0:hh\:mm\:ss}";
                                }
                                excel.getCell(hours, currentHour, 1).Value2 = String.Format(format, time);
                                excel.getCell(hours, currentHour, 2).Value2 = String.Format("{0}", counter);
                                excel.getCell(hours, currentHour, 3).Value2 = String.Format("{0}", counter - oldCounterHours);
                            }
                            else
                            {
                                buffer[5] = String.Format("{0}", counter);
                                buffer[6] = String.Format("{0}", counter - oldCounterHours);

                                bufferReady = true;
                            }

                            writeHoursTimer.Restart();
                            oldCounterHours = counter;

                            if (hoursChart.Checked && formatXLS.Checked)
                            {
                                Excel.Range[] range = new Excel.Range[2]{
                                    hours.Range[hours.Cells[1, 1], hours.Cells[hours.UsedRange.Rows.Count, 1]],
                                    hours.Range[hours.Cells[1, 3], hours.Cells[hours.UsedRange.Rows.Count, 3]]
                                };

                                if(formatXLS.Checked) 
                                    chartHours.SetSourceData(excel.Union(range[0], range[1]));
                            }
                            hours.ChartObjects(Type.Missing).Visible = hoursChart.Checked;
                        }
                    }

                    if (formatCSV.Checked && bufferReady == true)
                    {
                        String line = String.Join(";", buffer);
                        if (line.Length > 8) //don't write empty lines.
                        {
                            String format = @"{0:d\.hh\:mm\:ss\.ff}";
                            TimeSpan time = fromBegin.Elapsed;
                            if (sync.Checked)
                            {
                                time = new TimeSpan(
                                    System.DateTime.Now.Hour,
                                    System.DateTime.Now.Minute, 0);
                                format = @"{0:hh\:mm\:ss\.ff}";
                            }
                            buffer[0] = String.Format(format, time);
                            file.WriteLine(String.Join(";", buffer));
                            file.Flush();

                            bufferReady = false;
                        }
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        TotalCountCtrl.Text = counter.ToString();
                    });

                    if (counter != eventCounterCtrl.Value)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            signalChart.Series["Signal"].Points.RemoveAt(0);
                            signalChart.Series["Signal"].Points.RemoveAt(1);
                            signalChart.Series["Signal"].Points.RemoveAt(2);

                            signalChart.Refresh();

                            signalChart.Series["Signal"].Points.AddXY(timeTick, 0);
                            signalChart.Series["Signal"].Points.AddXY(timeTick, new Random().Next(0, 12));
                            signalChart.Series["Signal"].Points.AddXY(timeTick, 0);

                        });

                        timeTick++;
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        timeLabel.Text = String.Format(@"{0:d\.hh\:mm\:ss\.f}", fromBegin.Elapsed);
                    });

                    counter = eventCounterCtrl.Value;

                    //Thread.Sleep(TimeSpan.FromMilliseconds(System.Math.Abs(TimeSpan.FromSeconds(1).TotalMilliseconds - lastSleep.ElapsedMilliseconds)));
                    //lastSleep.Restart();

                    if(formatXLS.Checked && fromBegin.Elapsed.TotalSeconds % 10 == 0)
                        workbook.SaveCopyAs(args.Argument);

                } while (deviceWorker.CancellationPending == false);
            }
            finally
            {
                if (formatXLS.Checked)
                {
                    workbook.SaveCopyAs(args.Argument);
                    excel.Close();
                }
                else
                {
                    file.Close();
                }
            }
        }

        private void Stop()
        {
            deviceWorker.CancelAsync();
            eventCounterCtrl.Enabled = false;
            stopBtn.Enabled = false;

            toggleStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void ShowExcelCtrl_CheckedChanged(object sender, EventArgs e)
        {
            ShowExcel = ShowExcelCtrl.Checked;
        }

        private void toggleStart()
        {
            startBtn.Enabled = (Filepath.Text.Length > 0) && (secondsActive.Checked || minutesActive.Checked || hoursActive.Checked);
        }

        private void toggleRunTime()
        {
            time.Text = hoursActive.Checked ? "godz." : (minutesActive.Checked ? "min." : "sek.");
        }

        private void toggleSync()
        {
            sync.Enabled = minutesActive.Checked || hoursActive.Checked;
        }

        private void secondsActive_CheckedChanged(object sender, EventArgs e)
        {
            writeSecondsIntervalCtrl.Enabled = secondsActive.Checked;
            secondsChart.Enabled = secondsActive.Checked && formatXLS.Checked;

            toggleSync();
            toggleRunTime();
            toggleStart();
        }

        private void minutesActive_CheckedChanged(object sender, EventArgs e)
        {
            writeMinutesIntervalCtrl.Enabled = minutesActive.Checked;
            minutesChart.Enabled = minutesActive.Checked && formatXLS.Checked;

            toggleSync();
            toggleRunTime();
            toggleStart();
        }

        private void hoursActive_CheckedChanged(object sender, EventArgs e)
        {
            writeHoursIntervalCtrl.Enabled = hoursActive.Checked;
            hoursChart.Enabled = hoursActive.Checked && formatXLS.Checked;

            toggleSync();
            toggleRunTime();
            toggleStart();
        }

        private void formatXLS_CheckedChanged(object sender, EventArgs e)
        {
            ShowExcelCtrl.Enabled = formatXLS.Checked;

            hoursChart.Enabled = formatXLS.Checked;
            minutesChart.Enabled = formatXLS.Checked;
            secondsChart.Enabled = formatXLS.Checked;
        }

        private decimal getRunTimeLimit()
        {
            if (runtimeLimit.Checked)
            {
                if (hoursActive.Checked)
                    return timeLimit.Value * 60 * 60;
                else if (minutesActive.Checked)
                    return timeLimit.Value * 60;
                else
                    return timeLimit.Value;
            }

            return System.Int32.MaxValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();

            dlg.AddExtension = true;
            dlg.DefaultExt = formatXLS.Checked ? "xls" : "csv";
            dlg.Filter = formatXLS.Checked ? "Pliki excel(.xls)|xls" : "Pliki csv(.csv)|csv";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Filepath.Text = dlg.FileName;
            }

            startBtn.Enabled = Filepath.Text.Length > 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void runtimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            timeLimit.Enabled = runtimeLimit.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string deviceDescription = "USB-4716,BID#0";
            eventCounterCtrl.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceDescription);
        }

        private void sync_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
