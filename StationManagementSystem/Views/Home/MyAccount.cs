using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Home
{
    public partial class MyAccount : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly AccountService _accountService;
        private readonly RoleService _roleService;
        private Employee _employee;
        public MyAccount()
        {
            InitializeComponent();

            _employeeService = new EmployeeService();
            _accountService = new AccountService();
            _roleService = new RoleService();
        }

        public MyAccount(Employee employee)
        {
            InitializeComponent();

            _employeeService = new EmployeeService();
            _accountService = new AccountService();
            _roleService = new RoleService();

            _employee = employee;

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
                lblGioiTinhV.Text = "Nữ";
            else lblGioiTinhV.Text = "Nam";
            lblSoDienThoaiV.Text = _employee.Phone;
            lblEmailV.Text = _employee.Email;

            if (_employee.BirthDate.HasValue)
            {
                lblNgaySinhV.Text = _employee.BirthDate.Value.ToString();
            }
            else
            {
                lblNgaySinhV.Text = "Không có dữ liệu"; // Hoặc một giá trị mặc định khác
            }
            lblDiaChiV.Text = _employee.Address;
        }
        private async void LoadAccount()
        {
            var account = await _accountService.GetAccountByEmployeeIdAsync(_employee.EmployeeID);
            lblTenDangNhapV.Text = account.Username;
            lblMatKhauV.Text = account.Password;

            var roles = await _roleService.GetRoleByIdAsync(account.RoleID);
            lblVaiTroV.Text = roles.RoleName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
