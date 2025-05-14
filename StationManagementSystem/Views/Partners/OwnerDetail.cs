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
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Partners
{
    public partial class OwnerDetail : Form
    {
        private readonly OwnerService _ownerService;
        private OwnerUpdateDto _ownerDto;
        private Owner _owner;
        private string _roleName;
        public OwnerDetail()
        {
            InitializeComponent();

            _ownerService = new OwnerService();
            _ownerDto = new OwnerUpdateDto();
        }
        public OwnerDetail(Owner owner, string roleName)
        {
            InitializeComponent();

            _ownerService = new OwnerService();
            _ownerDto = new OwnerUpdateDto();
            _owner = owner;
            _roleName = roleName;
        }
        private async void LoadOwner()
        {
            tbxTen.Text = _owner.Name;
            tbxCCCD.Text = _owner.IDCard;
            tbxSoDienThoai.Text = _owner.Phone;
            tbxDiaChi.Text = _owner.Address;
            tbxEmail.Text = _owner.Email;
            tbxDVVT.Text = _owner.Company;
            tbxBangLai.Text = _owner.DrivingLicense;
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
        private void OwnerDetail_Load(object sender, EventArgs e)
        {
            LoadOwner();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền sửa thông tin chủ xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            if (_owner.Company.ToLower() != tbxDVVT.Text.ToLower())
            {
                if (await _ownerService.IsTransportUnitExists(tbxDVVT.Text))
                {
                    MessageBox.Show("Tên đơn vị vận tải đã tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

            var respone = await _ownerService.UpdateOwnerAsync(_owner.OwnerID, _ownerDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.OwnerID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnNgung_Click(object sender, EventArgs e)
        {
            //var respone = await _ownerService.UpdateOwnerStatusAsync(_owner.OwnerID);

            //if (respone != null)
            //{
            //    MessageBox.Show($"Cập nhật thành công! {respone.OwnerID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private async void btnCancle_Click(object sender, EventArgs e)
        {
            //var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa chủ xe này?",
            //                                   "Xác nhận xóa",
            //                                   MessageBoxButtons.YesNo,
            //                                   MessageBoxIcon.Warning);

            //if (confirmResult == DialogResult.Yes)
            //{

            //    var respone = await _ownerService.DeleteOwnerAsync(_owner.OwnerID);

            //    if (respone != null)
            //    {
            //        MessageBox.Show($"Xóa thành công! {respone.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
