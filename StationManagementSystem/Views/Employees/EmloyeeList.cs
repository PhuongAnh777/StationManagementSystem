﻿using System;
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
using StationManagementSystem.Views.Partners;

namespace StationManagementSystem.Views.Employees
{
    public partial class EmloyeeList : Form
    {
        private readonly EmployeeService _employeeService;

        private List<Employee> _originalData;
        private int _pageSize = 10;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp
        public EmloyeeList()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _originalData = new List<Employee>();
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

        private void RenameEmployeeGridColumns()
        {
            gridView.Columns["EmployeeID"].HeaderText = "Mã nhân viên";
            gridView.Columns["FullName"].HeaderText = "Họ và tên";
            gridView.Columns["Phone"].HeaderText = "Số điện thoại";
            gridView.Columns["Address"].HeaderText = "Địa chỉ";
            gridView.Columns["Email"].HeaderText = "Email";
            gridView.Columns["BirthDate"].HeaderText = "Ngày sinh";
            gridView.Columns["Gender"].HeaderText = "Giới tính"; // Bạn có thể xử lý định dạng lại thành "Nam"/"Nữ" nếu cần
        }
        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridView.Rows.Count)
                return;
            var selectedRow = gridView.Rows[e.RowIndex];
            var employeeId = (Guid)selectedRow.Cells["EmployeeID"].Value;
            var response = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (response != null)
            {
                OpenChildForm(new EmployeeEdit(response));
                await LoadEmployee(); // Cập nhật lại dữ liệu trong DataGridView

            }
            else
            {
                MessageBox.Show("Failed to retrieve category details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task LoadEmployee()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();

                if (employees != null && employees.Any())
                {
                    _originalData = employees.ToList();

                    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize);
                    DisplayPage(_currentPage);
                    RenameEmployeeGridColumns();
                }
                else
                {
                    gridView.DataSource = new List<Employee>(); // Gán một danh sách rỗng cho DataSource
                    lblPage.Text = "0/0";
                    labelPageInfo.Text = "Hiển thị 0 - 0 / Tổng số 0 hàng hóa";
                    MessageBox.Show("Không có dữ liệu nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DisplayPage(int pageNumber)
        {
            if (_originalData == null || !_originalData.Any()) return;

            var pagedData = _originalData.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();

            gridView.DataSource = pagedData;

            lblPage.Text = $"{_currentPage}/{_pageSize}";
            labelPageInfo.Text = $"Hiển thị {_pageSize * (_currentPage - 1) + 1} - {_currentPage * _pageSize} / Tổng số 32 hàng hóa";
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage(_currentPage);
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayPage(_currentPage);
            }
        }
        private void SortData(string columnName, bool ascending)
        {
            if (_originalData == null || !_originalData.Any()) return;

            _originalData = ascending
                ? _originalData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
                : _originalData.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();

            _currentPage = 1;
            DisplayPage(_currentPage);
        }
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
            string columnName = gridView.Columns[e.ColumnIndex].DataPropertyName;

            if (_sortedColumn == columnName)
            {
                _isAscending = !_isAscending;
            }
            else
            {
                _sortedColumn = columnName;
                _isAscending = true;
            }

            SortData(columnName, _isAscending);

            UpdateColumnHeaders();

        }

        private async void EmloyeeList_Load(object sender, EventArgs e)
        {
            await LoadEmployee();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeAdd());
            await LoadEmployee();

        }
    }
}
