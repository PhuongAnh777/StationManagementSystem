using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.ApiClients;
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Routes
{
    public partial class RouteAdd : Form
    {
        private readonly RouteService _routeService;
        private RouteCreateDto _routeDto;
        List<string> provinces = new List<string>
        {
            "Hà Nội", "Hồ Chí Minh", "Đà Nẵng", "Cần Thơ", "Hải Phòng",
            "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu",
            "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước",
            "Bình Thuận", "Cà Mau", "Cao Bằng", "Cần Thơ", "Gia Lai",
            "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hòa Bình",
            "Hậu Giang", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum",
            "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An",
            "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ",
            "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh",
            "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên",
            "Thanh Hóa", "Thừa Thiên - Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang",
            "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
        };
        public RouteAdd()
        {
            InitializeComponent();

            _routeService = new RouteService();
            _routeDto = new RouteCreateDto();

            cbxDiemDi.DataSource = new List<string>(provinces);
            cbxDiemDen.DataSource = new List<string>(provinces);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ viền mỏng xung quanh form
            using (Pen borderPen = new Pen(Color.Black, 1)) // Viền màu đen, dày 1px
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
        }
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxDiemDi.Text))
            {
                MessageBox.Show("Điểm đi không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _routeDto.DeparturePoint = cbxDiemDi.Text;

            if (string.IsNullOrEmpty(cbxDiemDen.Text))
            {
                MessageBox.Show("Điểm đến không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _routeDto.ArrivalPoint = cbxDiemDen.Text;

            if (string.IsNullOrEmpty(lblKhoangCachV.Text))
            {
                MessageBox.Show("Khoảng cách không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(lblKhoangCachV.Text))
            {
                MessageBox.Show("Vui lòng đợi lấy khoảng cách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _routeDto.Distance = float.Parse(lblKhoangCachV.Text);



            var respone = await _routeService.CreateRouteAsync(_routeDto);

            if (respone != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.RouteID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnTimKC_Click(object sender, EventArgs e)
        {

        }
        private async Task CalculateAndShowDistanceAsync()
        {
            try
            {
                var geocoder = new GeocodingService();
                var distanceService = new DistanceService();

                var from = await geocoder.GetCoordinatesAsync(cbxDiemDi.Text.Trim());
                var to = await geocoder.GetCoordinatesAsync(cbxDiemDen.Text.Trim());

                if (from is null)
                {
                    MessageBox.Show("Không tìm thấy địa điểm xuất phát.");
                    return;
                }

                if (to is null)
                {
                    MessageBox.Show("Không tìm thấy địa điểm đích.");
                    return;
                }

                var result = await distanceService.CalculateDistanceAsync(
                    from.Value.lat, from.Value.lon,
                    to.Value.lat, to.Value.lon
                );

                lblKhoangCachV.Text = result.distanceKm.ToString("F1");

                //MessageBox.Show($"Khoảng cách: {result.distanceKm:F1} km\nThời gian ước tính: {result.durationHours:F1} giờ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void cbxDiemDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDiemDi.SelectedIndex != cbxDiemDen.SelectedIndex)
            {
                string selectedProvince = cbxDiemDi.SelectedItem.ToString();
                // Xử lý cho ComboBox Provinces
            }
        }

        private void cbxDiemDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDiemDen.SelectedIndex != cbxDiemDi.SelectedIndex)
            {
                string selectedCity = cbxDiemDen.SelectedItem.ToString();
                // Xử lý cho ComboBox Cities
            }
        }

        private void RouteAdd_Load(object sender, EventArgs e)
        {
            cbxDiemDi.SelectedIndexChanged += async (s, e) => await CalculateAndShowDistanceAsync();
            cbxDiemDen.SelectedIndexChanged += async (s, e) => await CalculateAndShowDistanceAsync();
        }
    }
}
