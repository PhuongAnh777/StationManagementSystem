using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            tbxDiemDen.Text = _route.ArrivalPoint;
            tbxDiemDi.Text = _route.DeparturePoint;
            tbxKhoangCach.Text = _route.Distance.ToString();
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
            if (string.IsNullOrEmpty(tbxDiemDi.Text))
            {
                MessageBox.Show("Điểm đi không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _routeDto.DeparturePoint = tbxDiemDi.Text;

            if (string.IsNullOrEmpty(tbxDiemDen.Text))
            {
                MessageBox.Show("Điểm đến không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _routeDto.ArrivalPoint = tbxDiemDen.Text;

            if (string.IsNullOrEmpty(tbxKhoangCach.Text))
            {
                MessageBox.Show("Khoảng cách không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(tbxKhoangCach.Text, out _) || float.TryParse(tbxKhoangCach.Text, out _))
            {
                _routeDto.Distance = float.Parse(tbxKhoangCach.Text);
            }
            else
            {
                MessageBox.Show("Khoảng cách không hợp lệ", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
    }
}
