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

namespace StationManagementSystem.Views.Transactions
{
    public partial class VehicleDepartureList : Form
    {
        private readonly VehicleService _vehicleService;
        private readonly OwnerService _ownerService;
        private readonly TicketIssuanceService _ticketIssuanceService;

        //private VehicleCreateDto _vehicleDto;
        private List<Vehicle> _originalData; // Dữ liệu gốc
        private int _pageSize = 10;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp

        private Employee _employee;
        public VehicleDepartureList(Employee employee)
        {
            InitializeComponent();
            _vehicleService = new VehicleService();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _originalData = new List<Vehicle>();
            _employee = employee;
        }
        public void OpenChildForm(Form childForm)
        {
            //Đặt vị trí xuất hiện của form con là chính giữa màn hình
            childForm.StartPosition = FormStartPosition.Manual; // Đặt chế độ thủ công
            var screen = Screen.FromControl(this).WorkingArea; // Lấy kích thước màn hình làm tham chiếu
            childForm.Location = new Point(
                screen.X + (screen.Width - childForm.Width) / 2,
                screen.Y + (screen.Height - childForm.Height) / 2
            );

            //Làm mờ form chính
            this.Opacity = 0.1;

            // Hiển thị form con dưới dạng modal
            childForm.ShowDialog();

            // Khôi phục độ trong suốt của form chính
            this.Opacity = 1.0;
        }
        private void RenameVehicleGridColumns()
        {
            gridView.Columns["VehicleID"].HeaderText = "Mã xe";
            gridView.Columns["LicensePlate"].HeaderText = "Biển số xe";
            gridView.Columns["VehicleType"].HeaderText = "Loại xe";
            gridView.Columns["SeatTicket"].HeaderText = "Ghế ngồi";
            gridView.Columns["SleeperTicket"].HeaderText = "Giường nằm";
            gridView.Columns["ManufacturingYear"].HeaderText = "Năm sản xuất";
            gridView.Columns["Registration"].HeaderText = "Đăng ký";
            gridView.Columns["Insurance"].HeaderText = "Bảo hiểm";
            gridView.Columns["InspectionStartDate"].HeaderText = "Ngày kiểm định";
            gridView.Columns["InspectionExpiryDate"].HeaderText = "Hạn kiểm định";
            gridView.Columns["ImpoundmentDate"].HeaderText = "Ngày tạm giữ";
            gridView.Columns["ReleaseDate"].HeaderText = "Ngày trả xe";
            gridView.Columns["OwnerID"].HeaderText = "Chủ xe";
        }
        private async Task LoadVehicle()
        {
            try
            {
                var vehicles = await _ticketIssuanceService.GetDepartureVehiclesAsync();

                if (vehicles != null && vehicles.Any())
                {
                    _originalData = vehicles.ToList();

                    _totalPages = (int)Math.Ceiling((double)_originalData.Count / _pageSize);
                    DisplayPage(_currentPage);
                    RenameVehicleGridColumns();
                }
                else
                {
                    gridView.DataSource = new List<Vehicle>(); // Gán một danh sách rỗng cho DataSource
                    lblPage.Text = "0/0";
                    labelPageInfo.Text = "Hiển thị 0 - 0 / Tổng số 0 hàng hóa";
                    MessageBox.Show("Không có dữ liệu xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

        private async void VehicleDepartureList_Load(object sender, EventArgs e)
        {
            await LoadVehicle();
        }

        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridView.Rows.Count)
                return;
            var selectedRow = gridView.Rows[e.RowIndex];
            var vehicleId = (Guid)selectedRow.Cells["VehicleID"].Value;
            var response = await _ticketIssuanceService.GetTicketIssuanceByVehicleIdAsync(vehicleId);

            if (response != null)
            {
                OpenChildForm(new Payment(_employee, response));
            }
            else
            {
                MessageBox.Show("Failed to retrieve customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
