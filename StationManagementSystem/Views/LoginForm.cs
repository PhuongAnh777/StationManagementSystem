using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        private readonly AccountService _accountService;
        private readonly EmployeeService _employeeService;
        private readonly RoleService _roleService;
        public LoginForm()
        {
            InitializeComponent();

            _accountService = new AccountService();
            _employeeService = new EmployeeService();
            _roleService = new RoleService();

            this.StartPosition = FormStartPosition.CenterScreen; // Đặt form ở giữa màn hình
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            string username = tbxTen.Text.Trim();
            string password = tbxMK.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập và tài khoản không được bỏ trống.");
                return;
            }
            //if (!cbox.Checked)
            //{
            //    MessageBox.Show("Hãy chọn vào ô chấp nhận điều khoản.");
            //    return;
            //}
            // Kiểm tra thông tin đăng nhập
            var userAccount = await _accountService.CheckLogin(username, password);

            if (userAccount != null)
            {
                //MessageBox.Show("Login successful!");
                //var account = await _accountService.GetUserAccountByUserNameAsync(username);
                //Guid? accountId = Guid.Empty;
                //if (account != null)
                //    accountId = account.AccountID;

                Guid? employeeId = Guid.Empty;
                var employee = await _employeeService.GetEmployeeByIdAsync(userAccount.EmployeeID);
                if (employee != null)
                    employeeId = employee.EmployeeID;

                string roleName = string.Empty;
                var role = await _roleService.GetRoleByIdAsync(userAccount.RoleID);
                if (role != null)
                    roleName = role.RoleName;

                this.Hide(); // Ẩn form hiện tại
                if (roleName == "Admin")
                {
                    var mainForm = new MainForm(userAccount, employee, roleName);
                    mainForm.ShowDialog(); // Hiển thị MainForm
                }
                else if (roleName == "Ticket Employee")
                {
                    var ticketForm = new TicketEmployeeForm(userAccount, employee, roleName);
                    ticketForm.ShowDialog();
                }
                else if (roleName == "Invoice Employee")
                {
                    var invoiceForm = new InvoiceEmployeeForm(userAccount, employee, roleName);
                    invoiceForm.ShowDialog();
                }

                this.Close(); // Đóng form đăng nhập sau khi form mới đóng
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
