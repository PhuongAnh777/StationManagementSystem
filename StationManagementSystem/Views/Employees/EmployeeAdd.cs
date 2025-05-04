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
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Employees
{
    public partial class EmployeeAdd : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private EmployeeCreateDto _employeeDto;
        private AccountCreateDto _accountDto;
        public EmployeeAdd()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _accountService = new AccountService();
            _roleService = new RoleService();
            _employeeDto = new EmployeeCreateDto();
            _accountDto = new AccountCreateDto();
            //LoadAccount();

            dateTime.Checked = false;

            rbtnNu.Checked = true;

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
        public async void LoadRole()
        {
            var roles = await _roleService.GetAllRolesAsync();
            cbxRole.DataSource = roles;
            cbxRole.DisplayMember = "RoleName"; // hoặc tên thuộc tính bạn muốn hiển thị
            cbxRole.ValueMember = "RoleID";
            cbxRole.SelectedIndex = -1; // Đặt giá trị mặc định là không có lựa chọn nào
        }
        //public async void LoadAccount()
        //{
        //    var response = await _accountService.GetAllUserAccountsAsync();
        //    if (response != null)
        //    {
        //        var employeeDtos = response.Select(account => new EmployeeCreateDto
        //        {
        //            AccountID = account.AccountID,
        //            UserName = account.Username,
        //            // Thêm các thuộc tính khác nếu cần
        //        }).ToList();

        //        lboxTaiKhoan.DataSource = employeeDtos;
        //        lboxTaiKhoan.DisplayMember = "UserName";
        //        lboxTaiKhoan.ValueMember = "AccountID";
        //        lboxTaiKhoan.SelectedIndex = -1;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Failed to load parent account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        //private async Task<bool> IsUsernameExists(string username)
        //{
        //    // Giả sử bạn có một danh sách các tài khoản đã tồn tại
        //    //var existingUsernames = await _accountService.GetAllUserNamesAsync(); // Chờ kết quả trả về
        //    //return existingUsernames.Contains(username);
        //}
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
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTenNhanVien.Text))
            {
                MessageBox.Show("Tên nhân viên không được trống", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _employeeDto.FullName = tbxTenNhanVien.Text;

            if (rbtnNam.Checked)
            {
                _employeeDto.Gender = false;
            }
            else if (rbtnNu.Checked)
            {
                _employeeDto.Gender = true;
            }
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

            _employeeDto.Phone =tbxSoDienThoai.Text;

            if (string.IsNullOrEmpty(tbxDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _employeeDto.Address = tbxDiaChi.Text;

            // Kiểm tra tài khoản

            if (string.IsNullOrEmpty(tbxUserName.Text))
            {
                MessageBox.Show("Vui lòng tên đăng nhập", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var responeUserName = await _accountService.IsUsernameExistsAsync(tbxUserName.Text);
            if (responeUserName == true)
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

            var respone = await _employeeService.CreateEmployeeAsync(_employeeDto);
            _accountDto.EmployeeID = respone.EmployeeID;
            var responeAccount = await _accountService.CreateAccountAsync(_accountDto);

            if (respone != null && responeAccount != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
