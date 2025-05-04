using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Role;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Employees
{
    public partial class RoleEdit : Form
    {
        private readonly RoleService _roleService;

        private Role _role;
        private RoleUpdateDto _roleDto;
        public RoleEdit()
        {
            InitializeComponent();
            _roleService = new RoleService();
            _roleDto = new RoleUpdateDto();
        }
        public RoleEdit(Role role)
        {
            InitializeComponent();
            _roleService = new RoleService();

            _role = role;
            _roleDto = new RoleUpdateDto();
            LoadRole();
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
        private async void LoadRole()
        {
            tbxTen.Text = _role.RoleName;
            tbxMoTa.Text = _role.Description;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận xóa
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa vai trò này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {

                // Gọi hàm xóa từ service
                var isDeleted = await _roleService.DeleteRoleAsync(_role.RoleID);

                if (isDeleted)
                {
                    this.Close();
                    MessageBox.Show("Xóa thành công vai trò!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTen.Text))
            {
                MessageBox.Show("Tên vai trò không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responeRole = await _roleService.IsRoleNameExistsAsync(tbxTen.Text);
            if (responeRole == true && tbxTen.Text != _role.RoleName)
            {
                MessageBox.Show("Tên vai trò đã tồn tại", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _roleDto.RoleName = tbxTen.Text;

            if (string.IsNullOrEmpty(tbxMoTa.Text))
            {
                MessageBox.Show("Mô tả không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _roleDto.Description = tbxMoTa.Text;

            var respone = await _roleService.UpdateRoleAsync(_role.RoleID, _roleDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.RoleName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
