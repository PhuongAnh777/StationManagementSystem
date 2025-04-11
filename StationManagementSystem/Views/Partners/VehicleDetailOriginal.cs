using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Partners
{
    public partial class VehicleDetailOriginal : Form
    {
        private readonly VehicleService _vehicleService;
        private VehicleUpdateDto _vehicleDto;
        private readonly OwnerService _ownerService;
        private List<string> nhomXe;
        private Vehicle _vehicle;
        public VehicleDetailOriginal()
        {
            InitializeComponent();

            _vehicleService = new VehicleService();
            _vehicleDto = new VehicleUpdateDto();

            nhomXe = new List<string>
            {
                "Xe khách cố định",
                "Xe buýt",
                "Xe hợp đồng",
                "Xe taxi",
                "Xe tải"
            };
        }
        public VehicleDetailOriginal(Vehicle vehicle)
        {
            InitializeComponent();

            _vehicleService = new VehicleService();
            _vehicleDto = new VehicleUpdateDto();
            _vehicle = vehicle;

            nhomXe = new List<string>
            {
                "Xe khách cố định",
                "Xe buýt",
                "Xe hợp đồng",
                "Xe taxi",
                "Xe tải"
            };
        }

        private async void LoadVehicle()
        {
            tbxBienSo.Text = _vehicle.LicensePlate;

            cbxNhomXe.SelectedValue = _vehicle.VehicleType;

            numGheNgoi.Value = _vehicle.SeatTicket;
            numGheNam.Value = _vehicle.SleeperTicket;

            numNam.Value = _vehicle.ManufacturingYear.HasValue ? _vehicle.ManufacturingYear.Value : 0;

            tbxDangKyXe.Text = _vehicle.Registration ?? string.Empty;
            tbxBaoHiem.Text = _vehicle.Insurance ?? string.Empty;

            if (_vehicle.InspectionStartDate.HasValue && _vehicle.InspectionExpiryDate.HasValue)
            {
                DateTimeFromKD.Value = _vehicle.InspectionStartDate.Value;
                DateTimeToKD.Value = _vehicle.InspectionExpiryDate.Value;
            }

            if (_vehicle.ImpoundmentDate.HasValue && _vehicle.ReleaseDate.HasValue)
            {
                DateTimeFromBB.Value = _vehicle.ImpoundmentDate.Value;
                DateTimeToBB.Value = _vehicle.ReleaseDate.Value;
            }

            //if (_vehicle != null)
            //{
            //    var respone = await _ownerService.GetOwnerByIdAsync(_vehicle.OwnerID);

            //    if (respone != null)
            //    {
            //        lblDVVTV.Text = respone.Company ?? "Không có tên công ty";
            //    }
            //    else
            //    {
            //        lblDVVTV.Text = "Không tìm thấy chủ xe";
            //    }
            //}
            //else
            //{
            //    lblDVVTV.Text = "Không có dữ liệu xe";
            //}
        }

        private void VehicleDetailOriginal_Load(object sender, EventArgs e)
        {
            LoadVehicle();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (numNam.Value == 0)
            {
                _vehicleDto.ManufacturingYear = null;
            }
            else if (numNam.Value <= 1990 || numNam.Value > DateTime.Now.Year)
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _vehicleDto.ManufacturingYear = (int)numNam.Value;

            if (string.IsNullOrEmpty(tbxDangKyXe.Text))
            {
                _vehicleDto.Registration = null;
            }
            _vehicleDto.Registration = tbxDangKyXe.Text;

            if (string.IsNullOrEmpty(tbxBaoHiem.Text))
            {
                _vehicleDto.Insurance = null;
            }
            _vehicleDto.Insurance = tbxBaoHiem.Text;

            if (DateTimeFromKD.Value >= DateTimeToKD.Value)
            {
                _vehicleDto.InspectionStartDate = null;
                _vehicleDto.InspectionExpiryDate = null;
            }
            _vehicleDto.InspectionStartDate = DateTimeFromKD.Value;
            _vehicleDto.InspectionExpiryDate = DateTimeToKD.Value;

            if (string.IsNullOrEmpty(tbxBienSo.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _vehicleDto.LicensePlate = tbxBienSo.Text;

            if (DateTimeFromBB.Value >= DateTimeToBB.Value)
            {
                _vehicleDto.ImpoundmentDate = null;
                _vehicleDto.ReleaseDate = null;
            }
            _vehicleDto.ImpoundmentDate = DateTimeFromBB.Value;
            _vehicleDto.ReleaseDate = DateTimeToBB.Value;

            _vehicleDto.SeatTicket = (int)numGheNgoi.Value;
            _vehicleDto.SleeperTicket = (int)numGheNam.Value;

            _vehicleDto.VehicleType = cbxNhomXe.SelectedValue.ToString();

            var respone = await _vehicleService.UpdateVehicleAsync(_vehicle.VehicleID, _vehicleDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.VehicleID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnNgung_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn ngưng hoạt động xe này?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var respone = await _vehicleService.UpdateVehicleStatusAsync(_vehicle.VehicleID);

                if (respone != null)
                {
                    MessageBox.Show($"Cập nhật thành công! {respone.VehicleID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void btnCancle_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa xe này?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {

                var respone = await _vehicleService.DeleteVehicleAsync(_vehicle.VehicleID);

                if (respone != null)
                {
                    MessageBox.Show($"Xóa thành công! {respone.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
