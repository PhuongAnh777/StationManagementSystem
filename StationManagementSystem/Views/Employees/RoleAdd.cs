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
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Employees
{
    public partial class RoleAdd : Form
    {
        private readonly RoleService _roleService;
        private RoleCreateDto _roleDto;
        public RoleAdd()
        {
            InitializeComponent();

            _roleService = new RoleService();
            _roleDto = new RoleCreateDto();
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
                MessageBox.Show("Tên vai trò không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responeRole = await _roleService.IsRoleNameExistsAsync(tbxTen.Text);
            if (responeRole == true)
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

            var respone = await _roleService.CreateRoleAsync(_roleDto);

            if (respone != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.RoleName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
