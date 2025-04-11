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
using static System.Net.Mime.MediaTypeNames;

namespace StationManagementSystem.Views.Partners
{
    public partial class VehicleAdd : Form
    {
        private readonly VehicleService _vehicleService;
        private VehicleCreateDto _vehicleDto;
        private readonly OwnerService _ownerService;
        private List<string> nhomXe;
        private bool _isPressed;
        public VehicleAdd()
        {
            InitializeComponent();
            _vehicleService = new VehicleService();
            _vehicleDto = new VehicleCreateDto();
            _ownerService = new OwnerService();

            nhomXe = new List<string>
            {
                "Xe khách cố định",
                "Xe buýt",
                "Xe hợp đồng",
                "Xe taxi",
                "Xe tải"
            };

            _isPressed = false;
        }
        public async void LoadVehicle()
        {
            cbxNhomXe.DataSource = nhomXe;
            cbxNhomXe.SelectedIndex = 0;
            var companies = await _ownerService.GetAllOwnersAsync();
            cbxTaiXe.DataSource = companies;
            cbxTaiXe.DisplayMember = "Company"; // hoặc tên thuộc tính bạn muốn hiển thị
            cbxTaiXe.ValueMember = "OwnerID";
            cbxTaiXe.SelectedIndex = -1; // Đặt giá trị mặc định là không có lựa chọn nào
        }

        private void VehicleAdd_Load(object sender, EventArgs e)
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

            if (((int)numGheNgoi.Value <= 0) && ((int)numGheNam.Value <= 0))
            {
                MessageBox.Show("Vui lòng nhập tải trọng xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _vehicleDto.SeatTicket = (int)numGheNgoi.Value;
            _vehicleDto.SleeperTicket = (int)numGheNam.Value;

            if ((cbxTaiXe.SelectedValue == null) && (_isPressed == false))
            {
                MessageBox.Show("Vui lòng chọn thông tin chủ xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxTaiXe.SelectedValue != null)
            {
                _vehicleDto.OwnerID = Guid.Parse(cbxTaiXe.SelectedValue.ToString());
            }
           
            _vehicleDto.VehicleType = cbxNhomXe.SelectedValue.ToString();

            var respone = await _vehicleService.CreateVehicleAsync(_vehicleDto);

            if (respone != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.VehicleID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThemChuXe_Click(object sender, EventArgs e)
        {
            _isPressed = true;
            using (var ownerForm = new OwnerAdd())
            {
                if (ownerForm.ShowDialog() == DialogResult.OK)
                {
                    Guid selectedOwnerId = ownerForm.SelectedOwnerId;

                    // Gán vào form hoặc control hiển thị
                    lblOwnerId.Text = selectedOwnerId.ToString();
                    _vehicleDto.OwnerID = selectedOwnerId;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
