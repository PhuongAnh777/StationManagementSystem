using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Partners
{
    public partial class VehicleList : Form
    {
        private readonly VehicleService _vehicleService;
        private readonly OwnerService _ownerService;
        //private VehicleCreateDto _vehicleDto;
        private List<Vehicle> _originalData; // Dữ liệu gốc
        private int _pageSize = 10;                    // Số hàng trên mỗi trang
        private int _currentPage = 1;                 // Trang hiện tại
        private int _totalPages;                      // Tổng số trang
        private bool _isAscending = true;
        private string _sortedColumn = "";        // Cột hiện đang sắp xếp

        private string _selectedTransportUnit = "";
        private string _licensePlateFilter = "";
        private string _roleName;
        public VehicleList()
        {
            InitializeComponent();
            _vehicleService = new VehicleService();
            _ownerService = new OwnerService();
            _originalData = new List<Vehicle>();
            //gridView.AutoGenerateColumns = false;
            //gridView.Columns["ID"].Visible = false;
        }
        public VehicleList(string roleName)
        {
            InitializeComponent();
            _vehicleService = new VehicleService();
            _ownerService = new OwnerService();
            _originalData = new List<Vehicle>();

            _roleName = roleName;
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

        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gridView.Rows.Count)
                return;
            var selectedRow = gridView.Rows[e.RowIndex];
            var vehicleId = (Guid)selectedRow.Cells["VehicleID"].Value;
            var response = await _vehicleService.GetVehicleByIdAsync(vehicleId);

            if (response != null)
            {
                OpenChildForm(new VehicleDetailOriginal(response, _roleName));
                await LoadVehicle();
            }
            else
            {
                MessageBox.Show("Failed to retrieve customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadVehicle()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehiclesAsync();

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


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền thêm mới phương tiện.");
                return;
            }
            OpenChildForm(new VehicleAdd());
            await LoadVehicle();
        }

        private async void VehicleList_Load(object sender, EventArgs e)
        {
            await LoadVehicle();

            var companies = await _ownerService.GetAllOwnersAsync();
            cbxDVVT.DataSource = companies;
            cbxDVVT.DisplayMember = "DeparturePoint"; // hoặc tên thuộc tính bạn muốn hiển thị
            cbxDVVT.ValueMember = "OwnerID";
            cbxDVVT.SelectedIndex = -1;
        }

        private void cbxDVVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedTransportUnit = cbxDVVT.SelectedValue?.ToString() ?? "";
            _licensePlateFilter = "";

            // Reset các control khác
            tbxBienSo.Text = "";

            // Lọc và hiển thị dữ liệu
            FilterAndDisplayData();
        }

        private void tbxBienSo_TextChanged(object sender, EventArgs e)
        {
            _licensePlateFilter = tbxBienSo.Text;
            _selectedTransportUnit = "";

            // Reset các control khác
            cbxDVVT.SelectedIndex = -1;

            // Lọc và hiển thị dữ liệu
            FilterAndDisplayData();
        }

        private void cbxTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_selectedRoute = cbxTuyen.SelectedValue?.ToString() ?? "";
            //_selectedTransportUnit = "";
            //_licensePlateFilter = "";

            //// Reset các control khác
            //cbxDVVT.SelectedIndex = -1;
            //cbxTuyen.Text = "";

            //// Lọc và hiển thị dữ liệu
            //FilterAndDisplayData();
        }
        // Phương thức lọc và hiển thị dữ liệu
        private void FilterAndDisplayData()
        {
            List<Vehicle> filteredData = _originalData;

            if (!string.IsNullOrEmpty(_selectedTransportUnit))
            {
                // Giả sử vehicle có thuộc tính OwnerName hoặc TransportUnit
                filteredData = filteredData.Where(v => v.OwnerID.ToString() == _selectedTransportUnit).ToList();
            }
            else if (!string.IsNullOrEmpty(_licensePlateFilter))
            {
                filteredData = filteredData.Where(v => v.LicensePlate.Contains(_licensePlateFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Cập nhật dữ liệu hiển thị
            _currentPage = 1;
            _totalPages = (int)Math.Ceiling((double)filteredData.Count / _pageSize);

            // Hiển thị dữ liệu đã lọc
            gridView.DataSource = filteredData.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            // Cập nhật thông tin phân trang
            lblPage.Text = $"{_currentPage}/{_totalPages}";
            labelPageInfo.Text = $"Hiển thị {Math.Min(_pageSize * (_currentPage - 1) + 1, filteredData.Count)} - {Math.Min(_currentPage * _pageSize, filteredData.Count)} / Tổng số {filteredData.Count} phương tiện";
        }

    }
}
