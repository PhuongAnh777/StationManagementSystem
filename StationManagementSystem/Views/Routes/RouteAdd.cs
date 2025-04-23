using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Routes
{
    public partial class RouteAdd : Form
    {
        private readonly RouteService _routeService;
        private RouteCreateDto _routeDto;
        public RouteAdd()
        {
            InitializeComponent();

            _routeService = new RouteService();
            _routeDto = new RouteCreateDto();
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
    }
}
