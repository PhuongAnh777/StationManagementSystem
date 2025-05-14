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
using StationManagementSystem.DTO.Account;
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Employees
{
    public partial class EmployeeEdit : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;

        private Employee _employee;
        private EmployeeUpdateDto _employeeDto;
        private AccountUpdateDto _accountDto;
        public EmployeeEdit()
        {
            InitializeComponent();

            _employeeService = new EmployeeService();
            _accountService = new AccountService();
            _roleService = new RoleService();

            _employeeDto = new EmployeeUpdateDto();
            _accountDto = new AccountUpdateDto();

            rbtnNu.Checked = true;
        }
        public EmployeeEdit(Employee employe)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen; // Đặt form ở giữa màn hình

            _employeeService = new EmployeeService();
            _accountService = new AccountService();
            _roleService = new RoleService();

            _employeeDto = new EmployeeUpdateDto();
            _accountDto = new AccountUpdateDto();

            _employee = employe;

            dateTime.Checked = false;

            rbtnNu.Checked = true;

            LoadEmployee();
            LoadAccount();
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
        private async void LoadAccount()
        {
            var account = await _accountService.GetAccountByEmployeeIdAsync(_employee.EmployeeID);
            tbxUserName.Text = account.Username;
            tbxPass.Text = account.Password;
            cbxRole.SelectedValue = account.RoleID;

            var roles = await _roleService.GetAllRolesAsync();
            cbxRole.DataSource = roles;
            cbxRole.DisplayMember = "RoleName"; // hoặc tên thuộc tính bạn muốn hiển thị
            cbxRole.ValueMember = "RoleID";
            cbxRole.SelectedValue = account.RoleID;
        }
        private bool IsValidPassword(string password)
        {
            // Kiểm tra độ dài ít nhất 8 ký tự
            if (password.Length < 8)
                return false;

            // Kiểm tra chứa chữ hoa
            if (!password.Any(char.IsUpper))
                return false;

            // Kiểm tra chứa chữ thường
            if (!password.Any(char.IsLower))
                return false;

            // Kiểm tra chứa số
            if (!password.Any(char.IsDigit))
                return false;

            // Kiểm tra chứa ký tự đặc biệt
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;

            return true;
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
                var isDeletedAccount = await _accountService.DeleteAccountAsync(_employee.Account.Username);

                if (isDeleted && isDeletedAccount)
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

            // Kiểm tra tài khoản
            var resopneUser = await _accountService.GetAccountByEmployeeIdAsync(_employee.EmployeeID);
            if (string.IsNullOrEmpty(tbxUserName.Text))
            {
                MessageBox.Show("Vui lòng tên đăng nhập", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responeUserName = await _accountService.IsUsernameExistsAsync(tbxUserName.Text);
            if (responeUserName == true && tbxUserName.Text != resopneUser.Username)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _accountDto.Username = tbxUserName.Text;

            if (string.IsNullOrEmpty(tbxPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidPassword(tbxPass.Text))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _accountDto.Password = tbxPass.Text;

            if (cbxRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _accountDto.RoleID = Guid.Parse(cbxRole.SelectedValue.ToString());

            var respone = await _employeeService.UpdateEmployeeAsync(_employee.EmployeeID, _employeeDto);


            var responeAccount = await _accountService.UpdateAccountAsync(resopneUser.Username, _accountDto);

            if (respone != null && responeAccount != null)
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
                var responeAccount = await _accountService.UpdateAccountStatusAsync(_employee.Account.Username);

                if (respone != null && responeAccount != null)
                {
                    MessageBox.Show($"Cập nhật thành công! {respone.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
