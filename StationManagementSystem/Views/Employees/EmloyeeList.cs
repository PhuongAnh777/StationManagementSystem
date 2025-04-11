using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StationManagementSystem.Views.Employees
{
    public partial class EmloyeeList : Form
    {
        //private readonly EmployeeService _employeeService;
        //private readonly OrderService _orderService;
        //private readonly AccountService _accountService;
        //private List<EmployeeDto> _originalData;
        private int _pageSize = 10;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp
        public EmloyeeList()
        {
            InitializeComponent();
            //_employeeService = new EmployeeService();
            //_orderService = new OrderService();
            //_accountService = new AccountService();
        }
        public void OpenChildForm(Form childForm)
        {
            // Đặt vị trí xuất hiện của form con là chính giữa màn hình
            childForm.StartPosition = FormStartPosition.Manual; // Đặt chế độ thủ công
            var screen = Screen.FromControl(this).WorkingArea; // Lấy kích thước màn hình làm tham chiếu
            childForm.Location = new Point(
                screen.X + (screen.Width - childForm.Width) / 2,
                screen.Y + (screen.Height - childForm.Height) / 2
            );

            // Làm mờ form chính
            this.Opacity = 0.1;

            // Hiển thị form con dưới dạng modal
            childForm.ShowDialog();

            // Khôi phục độ trong suốt của form chính
            this.Opacity = 1.0;
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var selectedRow = gridView.Rows[e.RowIndex];
            //var employeeId = (Guid)selectedRow.Cells["ID"].Value;
            //var response = await _employeeService.GetEmployeeByIdAsync(employeeId);

            //if (response != null)
            //{
            //    OpenChildForm(new EmployeeEdit(response));
            //    await LoadEmployee(); // Cập nhật lại dữ liệu trong DataGridView

            //}
            //else
            //{
            //    MessageBox.Show("Failed to retrieve category details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        private async Task LoadEmployee()
        {
            //try
            //{
            //    var response = await _employeeService.GetAllEmployeesAsync();

            //    if (response != null)
            //    {
            //        _originalData = new List<EmployeeDto>();
            //        foreach (var employee in response)
            //        {
            //            // Lấy tổng số đơn hàng của từng người dùng bằng hàm GetOrderById
            //            decimal totalOrders = 0;
            //            totalOrders = await _orderService.GetAmountOrdersByEmployeeIDAsync(employee.EmployeeID);
            //            string active;
            //            if (!employee.IsDiscontinued)
            //                active = "Đang hoạt động";
            //            else
            //                active = "Dừng hoạt động";

            //            var user = await _accountService.GetUserAccountByIdAsync(employee.AccountID);
            //            string userName = null;
            //            if (user != null)
            //                userName = user.Username;

            //            string gender = null;
            //            if (employee.Gender != null)
            //            {
            //                if (employee.Gender == true)
            //                {
            //                    gender = "Nữ";
            //                }
            //                else
            //                {
            //                    gender = "Nam";
            //                }
            //            }
            //            _originalData.Add(new EmployeeDto
            //            {
            //                ID = employee.EmployeeID,
            //                Name = employee.Name,
            //                Gender = gender,
            //                PhoneNumber = employee.PhoneNumber,
            //                Email = employee.Email,
            //                DateOfBirth = employee.DateOfBirth,
            //                Active = active,
            //                Amount = totalOrders,
            //                UserName = userName,
            //            });

            //        }

            //        _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize);
            //        DisplayPage(_currentPage);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không thể tải dữ liệu danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        //private void DisplayPage(int pageNumber)
        //{
        //    if (_originalData == null || !_originalData.Any()) return;

        //    var pagedData = _originalData.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();

        //    gridView.DataSource = pagedData;

        //    lblPage.Text = $"{_currentPage}/{_pageSize}";
        //    labelPageInfo.Text = $"Hiển thị {_pageSize * (_currentPage - 1) + 1} - {_currentPage * _pageSize} / Tổng số 32 hàng hóa";
        //}

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            //if (_currentPage > 1)
            //{
            //    _currentPage--;
            //    DisplayPage(_currentPage);
            //}
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            //if (_currentPage < _totalPages)
            //{
            //    _currentPage++;
            //    DisplayPage(_currentPage);
            //}
        }
        //private void SortData(string columnName, bool ascending)
        //{
        //    if (_originalData == null || !_originalData.Any()) return;

        //    _originalData = ascending
        //        ? _originalData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
        //        : _originalData.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();

        //    _currentPage = 1;
        //    DisplayPage(_currentPage);
        //}
        private void UpdateColumnHeaders()
        {
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                if (column.DataPropertyName == _sortedColumn)
                {
                    column.HeaderText = _isAscending
                        ? $"{column.HeaderText.TrimEnd('↑', '↓')} ↑"
                        : $"{column.HeaderText.TrimEnd('↑', '↓')} ↓";
                }
                else
                {
                    column.HeaderText = column.HeaderText.TrimEnd('↑', '↓');
                }
            }
        }

        private void gridView_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (gridView.Columns[e.ColumnIndex].Name == "Image" || (gridView.Columns[e.ColumnIndex].Name == "Remove"))
            //{
            //    return;
            //}
            //string columnName = gridView.Columns[e.ColumnIndex].DataPropertyName;

            //if (_sortedColumn == columnName)
            //{
            //    _isAscending = !_isAscending;
            //}
            //else
            //{
            //    _sortedColumn = columnName;
            //    _isAscending = true;
            //}

            //SortData(columnName, _isAscending);

            //UpdateColumnHeaders();

        }

        private async void EmloyeeList_Load(object sender, EventArgs e)
        {
            await LoadEmployee();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new EmployeeAdd());
            //await LoadEmployee();

        }
    }
}
