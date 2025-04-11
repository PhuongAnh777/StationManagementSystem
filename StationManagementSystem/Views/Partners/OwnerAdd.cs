using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Owner;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Partners
{
    public partial class OwnerAdd : Form
    {
        private readonly OwnerService _ownerService;
        private OwnerCreateDto _ownerDto;
        public Guid SelectedOwnerId { get; private set; }
        public OwnerAdd()
        {
            InitializeComponent();

            _ownerService = new OwnerService();
            _ownerDto = new OwnerCreateDto();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chủ xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ownerDto.Name = tbxTen.Text;

            if (string.IsNullOrEmpty(tbxCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CMND/CCCD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ownerDto.IDCard = tbxCCCD.Text;

            if (string.IsNullOrEmpty(tbxSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ownerDto.Phone = tbxSoDienThoai.Text;

            if (string.IsNullOrEmpty(tbxDVVT.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị vận tải", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ownerDto.Company = tbxDVVT.Text;

            if (string.IsNullOrEmpty(tbxDiaChi.Text))
            {
                _ownerDto.Address = null;
            }
            _ownerDto.Address = tbxDiaChi.Text;

            if (string.IsNullOrEmpty(tbxEmail.Text))
            {
                _ownerDto.Email = null;
            }
            _ownerDto.Email = tbxEmail.Text;

            if (string.IsNullOrEmpty(tbxBangLai.Text))
            {
                _ownerDto.DrivingLicense = null;
            }
            _ownerDto.DrivingLicense = tbxBangLai.Text;

            var respone = await _ownerService.CreateOwnerAsync(_ownerDto);

            if (respone != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.OwnerID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectedOwnerId = respone.OwnerID;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
