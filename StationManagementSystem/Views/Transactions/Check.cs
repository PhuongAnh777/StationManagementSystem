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
        }
        public async void LoadCheck()
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(_ticketIssuance.VehicleID);

            if (vehicle != null)
            {
                lblBienSoV.Text = vehicle.LicensePlate.ToString();
                tbxDangKyXe.Text = vehicle.Registration.ToString();
                tbxBaoHiem.Text = vehicle.Insurance.ToString();
                DateTimeFromKD.Text = vehicle.InspectionStartDate.ToString();
                DateTimeToKD.Text = vehicle.InspectionExpiryDate.ToString();
                DateTimeFromBB.Text = vehicle.ImpoundmentDate.ToString();
                DateTimeToBB.Text = vehicle.ReleaseDate.ToString();
            }

            var owner = await _ownerService.GetOwnerByIdAsync(vehicle.OwnerID);

            if (owner != null)
            {
                lblDVVTV.Text = owner.Name.ToString();
                tbxBangLai.Text = owner.DrivingLicense.ToString();
            }

            var itinerary = await _itineraryService.GetItineraryByIdAsync(_ticketIssuance.ItineraryID);

            if (itinerary != null)
            {
                var route = await _routeService.GetRouteByIdAsync(itinerary.RouteID);
                if (route != null)
                {
                    lblTuyen.Text = $"{route.DeparturePoint} - {route.ArrivalPoint}";
                }
            }

            if (_ticketIssuance != null)
            {
                tbxHinhThuc.Text = _ticketIssuance.OperatingSchedule.ToString();
                lblXuatBen.Text = _ticketIssuance.EstimatedDepartureTime.ToString();
            }

        }

        private void btnDu_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tbxDangKyXe.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra đăng ký xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(tbxBaoHiem.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bảo hiểm xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(tbxBangLai.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bằng lái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeToKD.Value > DateTimeFromKD.Value)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra kiểm định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeToBB.Value > DateTimeFromBB.Value)
            {
                MessageBox.Show("Vui lòng bỏ chọn đã kiểm tra biển bản tạm giữ giấy tờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkDK.Checked && checkBH.Checked && checkBL.Checked && checkKD.Checked && !checkBB.Checked)
            {
                MessageBox.Show($"Lên nốt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ticketIssuance.Status = "checked";
                return;
            }
        }

        private async void btnKhongDu_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tbxDangKyXe.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra đăng ký xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(tbxBaoHiem.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bảo hiểm xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(string.IsNullOrEmpty(tbxBangLai.Text)))
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra bằng lái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeToKD.Value > DateTimeFromKD.Value)
            {
                MessageBox.Show("Vui lòng chọn đã kiểm tra kiểm định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeToBB.Value > DateTimeFromBB.Value)
            {
                MessageBox.Show("Vui lòng bỏ chọn đã kiểm tra biển bản tạm giữ giấy tờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
}
