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
using StationManagementSystem.DTO.Route;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Routes
{
    public partial class RouteEdit : Form
    {
        private readonly RouteService _routeService;
        private RouteUpdateDto _routeDto;
        private Route _route;
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
        //public RouteEdit()
        //{
        //    InitializeComponent();

        //    LoadRoute();

        //    _routeService = new RouteService();
        //    _routeDto = new RouteUpdateDto();
        //}
        public RouteEdit(Route route)
        {
            InitializeComponent();

            _route = route; // Assign _route first
            LoadRoute();

            _routeService = new RouteService();
            _routeDto = new RouteUpdateDto();
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
        private async void LoadRoute()
        {
            cbxDiemDi.DataSource = new List<string>(provinces);
            cbxDiemDen.DataSource = new List<string>(provinces);

            cbxDiemDen.SelectedItem = _route.ArrivalPoint;
            cbxDiemDi.SelectedItem = _route.DeparturePoint;
            lblKhoangCachV.Text = _route.Distance.ToString();
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
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa tuyến này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {

                // Gọi hàm xóa từ service
                var isDeleted = await _routeService.DeleteRouteAsync(_route.RouteID);

                if (isDeleted)
                {
                    this.Close();
                    MessageBox.Show("Xóa thành công tuyến!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            _routeDto.Distance = float.Parse(lblKhoangCachV.Text);

            var respone = await _routeService.UpdateRouteAsync(_route.RouteID, _routeDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.RouteID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnBoQua_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn ngừng hoạt động tuyến này?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var respone = await _routeService.UpdateRouteStatusAsync(_route.RouteID);

                if (respone != null)
                {
                    MessageBox.Show($"Cập nhật thành công! {respone.RouteID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RouteEdit_Load(object sender, EventArgs e)
        {
            cbxDiemDi.SelectedIndexChanged += async (s, e) => await CalculateAndShowDistanceAsync();
            cbxDiemDen.SelectedIndexChanged += async (s, e) => await CalculateAndShowDistanceAsync();
        }
    }
}
