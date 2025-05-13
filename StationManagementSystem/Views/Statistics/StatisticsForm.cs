using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Statistics
{
    public partial class StatisticsForm : Form
    {
        private readonly InvoiceService _invoiceService;
        public StatisticsForm()
        {
            InitializeComponent();
            //VeBieuDoTanSuatXuatBen();

            _invoiceService = new InvoiceService();
        }
        //private async Task<List<int>> GetBusDepartureFrequencyForHours()
        //{
        //    var lstFrequency = new List<int>();

        //    // Giả sử gọi dịch vụ lấy dữ liệu tần suất xuất bến
        //    var departureData = await _busService.GetDepartureDataAsync();

        //    // Khởi tạo một mảng 24 giờ (0h - 23h)
        //    var hours = new int[24];

        //    // Tính toán số lượt xuất bến theo từng giờ
        //    foreach (var data in departureData)
        //    {
        //        var hour = data.DepartureTime.Hour;
        //        hours[hour]++; // Tăng tần suất cho từng giờ
        //    }

        //    // Chuyển đổi mảng thành List<int>
        //    lstFrequency = hours.ToList();
        //    return lstFrequency;
        //}
        //private async void VeBieuDoTanSuatXuatBen()
        //{
        //    var lstFrequency = await GetBusDepartureFrequencyForHours();
        //    string[] hours = Enumerable.Range(0, 24).Select(h => $"{h:00}:00").ToArray();

        //    var chart = new Chart
        //    {
        //        Dock = DockStyle.Fill
        //    };

        //    var chartArea = new ChartArea();
        //    chart.ChartAreas.Add(chartArea);

        //    var series = new Series
        //    {
        //        Name = "TanSuat",
        //        ChartType = SeriesChartType.Column
        //    };

        //    for (int i = 0; i < lstFrequency.Count; i++)
        //    {
        //        series.Points.AddXY(hours[i], lstFrequency[i]);
        //    }

        //    chart.Series.Add(series);
        //    chart.Titles.Add("Biểu đồ tần suất giờ xuất bến");

        //    this.Controls.Add(chart);
        //}
        }
}
