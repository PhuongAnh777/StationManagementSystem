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
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Employees
{
    public partial class EmployeeEdit : Form
    {
        private readonly EmployeeService _employeeService;
        //private readonly AccountService _accountService;
        private Models.Employee _employee;
        private EmployeeUpdateDto _employeeDto;
        public EmployeeEdit()
        {
            InitializeComponent();

            _employeeService = new EmployeeService();
            //_accountService = new AccountService();

            _employeeDto = new EmployeeUpdateDto();

            rbtnNu.Checked = true;
        }
        public EmployeeEdit(Employee employe)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen; // Đặt form ở giữa màn hình

            _employeeService = new EmployeeService();
            //_accountService = new AccountService();

            _employeeDto = new EmployeeUpdateDto();

            _employee = employe;

            dateTime.Checked = false;

            rbtnNu.Checked = true;

            LoadEmployee();
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
        private async void LoadEmployee()
        {
            tbxTenNhanVien.Text = _employee.FullName;
            if (_employee.Gender == true)
                rbtnNu.Checked = true;
            else if (_employee.Gender == false)
                rbtnNam.Checked = true;
            tbxSoDienThoai.Text = _employee.Phone;
            tbxEmail.Text = _employee.Email;

            //var account = await _accountService.GetUserAccountByIdAsync(_employee.AccountID);
            //tbxTaiKhoan.Text = account.Username;

            if (_employee.BirthDate.HasValue)
            {
                dateTime.Value = _employee.BirthDate.Value;
            }
            else
            {
                dateTime.Value = DateTime.Now; // Hoặc một giá trị mặc định khác
            }
            tbxDiaChi.Text = _employee.Address;
        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận xóa
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn xóa nhân viên này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {

                // Gọi hàm xóa từ service
                var isDeleted = await _employeeService.DeleteEmployeeAsync(_employee.EmployeeID);

                if (isDeleted)
                {
                    this.Close();
                    MessageBox.Show("Xóa thành công nhân viên!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng thử lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTenNhanVien.Text))
            {
                MessageBox.Show("Tên nhân viên không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbtnNam.Checked)
            {
                _employeeDto.Gender = false;
            }
            else if (rbtnNu.Checked)
            {
                _employeeDto.Gender = true;
            }
            _employeeDto.FullName = tbxTenNhanVien.Text;
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
                MessageBox.Show("Ẹmail không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _employeeDto.Email = tbxEmail.Text;
            if (dateTime.Checked)
            {
                if (dateTime.Value > DateTime.Now || dateTime.Value.Year < 1925)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _employeeDto.BirthDate = dateTime.Value;
            }
            else
            {
                _employeeDto.BirthDate = null;
            }
            // Regex kiểm tra số điện thoại Việt Nam
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
                MessageBox.Show("Số điện thoại không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _employeeDto.Phone = tbxSoDienThoai.Text;

            if (string.IsNullOrEmpty(tbxDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _employeeDto.Address = tbxDiaChi.Text;

            var respone = await _employeeService.UpdateEmployeeAsync(_employee.EmployeeID, _employeeDto);

            if (respone != null)
            {
                MessageBox.Show($"Cập nhật thành công! {respone.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnBoQua_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ban có chắc chắn muốn ngừng hoạt động nhân viên này?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                var respone = await _employeeService.UpdateEmployeeStatusAsync(_employee.EmployeeID);

                if (respone != null)
                {
                    MessageBox.Show($"Cập nhật thành công! {respone.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
