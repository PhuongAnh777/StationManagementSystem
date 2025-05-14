using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            if (!string.IsNullOrEmpty(tbxSoDienThoai.Text))
            {
                string pattern = @"^(0(3|5|7|8|9)[0-9]{8}|01[2|6|8|9][0-9]{8})$";
                bool isValid = Regex.IsMatch(tbxSoDienThoai.Text, pattern);
                if (!isValid)
                {
                    MessageBox.Show("Số điện thoại chưa đúng định dạng", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
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
            if (await _ownerService.IsTransportUnitExists(tbxDVVT.Text))
            {
                MessageBox.Show("Tên đơn vị vận tải đã tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ownerDto.Company = tbxDVVT.Text;

            if (string.IsNullOrEmpty(tbxDiaChi.Text))
            {
                _ownerDto.Address = null;
            }
            _ownerDto.Address = tbxDiaChi.Text;

            if (!string.IsNullOrEmpty(tbxEmail.Text))
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                bool isValid = Regex.IsMatch(tbxEmail.Text, pattern);
                if (!isValid)
                {
                    MessageBox.Show("Email chưa đúng định dạng", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
