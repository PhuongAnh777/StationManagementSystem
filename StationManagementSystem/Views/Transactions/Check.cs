using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.TicketIssuance;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using StationManagementSystem.Services;
using StationManagementSystem.Views.Partners;

namespace StationManagementSystem.Views.Transactions
{
    public partial class Check : Form
    {
        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        private readonly TicketIssuance _ticketIssuance;
        public Check()
        {
            InitializeComponent();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();
        }
        public Check(TicketIssuance ticketIssuance)
        {
            InitializeComponent();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _ticketIssuance = ticketIssuance;
            LoadCheck();
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
        public async void LoadCheck()
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(_ticketIssuance.VehicleID);

            if (vehicle != null)
            {
                lblBienSoV.Text = vehicle.LicensePlate.ToString();
                lblDangKyV.Text = vehicle.Registration.ToString();
                lblBaoHiemV.Text = vehicle.Insurance.ToString();
                DateTimeFromKD.Text = vehicle.InspectionStartDate.ToString();
                DateTimeToKD.Text = vehicle.InspectionExpiryDate.ToString();
                DateTimeFromBB.Text = vehicle.ImpoundmentDate.ToString();
                DateTimeToBB.Text = vehicle.ReleaseDate.ToString();
            }

            var owner = await _ownerService.GetOwnerByIdAsync(vehicle.OwnerID);

            if (owner != null)
            {
                lblDVVTV.Text = owner.Name.ToString();
                lblBangLaiV.Text = owner.DrivingLicense.ToString();
            }

            var itinerary = await _itineraryService.GetItineraryByIdAsync(_ticketIssuance.ItineraryID);

            if (itinerary != null)
            {
                var route = await _routeService.GetRouteByIdAsync(itinerary.RouteID);
                if (route != null)
                {
                    lblTuyenV.Text = $"{route.DeparturePoint} - {route.ArrivalPoint}";
                }
            }

            if (_ticketIssuance != null)
            {
                lblHinhThucV.Text = _ticketIssuance.OperatingSchedule.ToString();
                lblXuatBen.Text = _ticketIssuance.EstimatedDepartureTime.TimeOfDay.ToString();
            }

        }

        private async void btnDu_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(lblDangKyV.Text)) && !checkDK.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra đăng ký xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(lblBaoHiemV.Text)) && !checkBH.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bảo hiểm xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(lblBangLaiV.Text)) && !checkBL.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bằng lái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((DateTimeToKD.Value > DateTimeFromKD.Value) && !checkKD.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra kiểm định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((DateTimeToBB.Value <= DateTimeFromBB.Value) && checkBB.Checked)
            {
                MessageBox.Show("Vui lòng bỏ chọn đã kiểm tra biển bản tạm giữ giấy tờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkDK.Checked && checkBH.Checked && checkBL.Checked && checkKD.Checked && !checkBB.Checked)
            {
                var respone = await _ticketIssuanceService.UpdateTicketIssuancesStatusAsync(_ticketIssuance.IssuanceID);

                if (respone != null)
                {
                    MessageBox.Show($"Lên nốt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if(!checkDK.Checked)
                {
                    MessageBox.Show("Xe thiếu đăng ký xe không thể lên nốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else if (!checkBH.Checked)
                {
                    MessageBox.Show("Xe thiếu bảo hiểm xe không thể lên nốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else if (!checkBL.Checked)
                {
                    MessageBox.Show("Thiếu bằng lái xe không thể lên nốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else if (!checkKD.Checked)
                {
                    MessageBox.Show("Xe thiếu kiểm định xe không thể lên nốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else if (checkBB.Checked)
                {
                    MessageBox.Show("Xe đang có biên bản tạm giữ giấy tờ không thể lên nốt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private async void btnKhongDu_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(lblDangKyV.Text)) && !checkDK.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra đăng ký xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(lblBaoHiemV.Text)) && !checkBH.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bảo hiểm xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(lblBangLaiV.Text)) && !checkBL.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bằng lái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((DateTimeToKD.Value > DateTimeFromKD.Value) && !checkKD.Checked)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra kiểm định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((DateTimeToBB.Value <= DateTimeFromBB.Value) && checkBB.Checked)
            {
                MessageBox.Show("Vui lòng bỏ chọn đã kiểm tra biển bản tạm giữ giấy tờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!checkDK.Checked || !checkBH.Checked || checkBL.Checked || checkKD.Checked || checkBB.Checked)
            {
                var confirmResult = MessageBox.Show("Ban có chắc chắn muốn hủy bỏ điều kiện lên nốt của xe này?",
                                                   "Xác nhận hủy",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var respone = await _ticketIssuanceService.DeleteTicketIssuancesAsync(_ticketIssuance.IssuanceID);

                    if (respone != null)
                    {
                        MessageBox.Show($"Hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
