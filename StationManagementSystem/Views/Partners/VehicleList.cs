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
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Partners
{
    public partial class VehicleList : Form
    {
        //private readonly VehicleService _vehicleService;
        //private VehicleCreateDto _vehicleDto;
        //private List<VehicleDto> _originalData; // Dữ liệu gốc
        //private int _pageSize = 10;                    // Số hàng trên mỗi trang
        //private int _currentPage = 1;                 // Trang hiện tại
        //private int _totalPages;                      // Tổng số trang
        //private bool _isAscending = true;
        //private string _sortedColumn = "";        // Cột hiện đang sắp xếp
        public VehicleList()
        {
            InitializeComponent();
            //_supplierService = new SupplierService();
            //_purchaseService = new PurchaseService();

            //gridView.AutoGenerateColumns = false;
            //gridView.Columns["ID"].Visible = false;
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

        private async void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var selectedRow = gridView.Rows[e.RowIndex];
            //var supplierId = (Guid)selectedRow.Cells["ID"].Value;
            //var response = await _supplierService.GetSupplierByIdAsync(supplierId);

            //if (response != null)
            //{
            //    OpenChildForm(new VehicleEdit(response));
            //    await LoadSupplier(); // Cập nhật lại dữ liệu trong DataGridView

            //}
            //else
            //{
            //    MessageBox.Show("Failed to retrieve customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private async Task LoadVehicle()
        {
            //try
            //{
            //    var response = await _supplierService.GetAllSuppliersAsync();

            //    if (response != null)
            //    {
            //        _originalData = new List<SupplierDto>();

            //        foreach (var supplier in response)
            //        {
            //            // Lấy tổng số đơn hàng của từng người dùng bằng hàm GetOrderById
            //            decimal totalOrders = 0;
            //            totalOrders = await _purchaseService.GetAmountPurchasesBySupplierIDAsync(supplier.SupplierID);
            //            string active;
            //            if (!supplier.IsDiscontinued)
            //                active = "Đang hoạt động";
            //            else
            //                active = "Dừng hoạt động";
            //            _originalData.Add(new SupplierDto
            //            {
            //                ID = supplier.SupplierID,
            //                Name = supplier.Name,
            //                PhoneNumber = supplier.PhoneNumber,
            //                Email = supplier.Email,
            //                Address = supplier.Address,
            //                Active = active,
            //                Amount = totalOrders,
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
        private void DisplayPage(int pageNumber)
        {
            //if (_originalData == null || !_originalData.Any()) return;

            //var pagedData = _originalData.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();

            //gridView.DataSource = pagedData;

            //lblPage.Text = $"{_currentPage}/{_pageSize}";
            //labelPageInfo.Text = $"Hiển thị {_pageSize * (_currentPage - 1) + 1} - {_currentPage * _pageSize} / Tổng số 32 hàng hóa";
        }

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
        private void SortData(string columnName, bool ascending)
        {
            //if (_originalData == null || !_originalData.Any()) return;

            //_originalData = ascending
            //    ? _originalData.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
            //    : _originalData.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();

            //_currentPage = 1;
            //DisplayPage(_currentPage);
        }
        private void UpdateColumnHeaders()
        {
            //foreach (DataGridViewColumn column in gridView.Columns)
            //{
            //    if (column.DataPropertyName == _sortedColumn)
            //    {
            //        column.HeaderText = _isAscending
            //            ? $"{column.HeaderText.TrimEnd('↑', '↓')} ↑"
            //            : $"{column.HeaderText.TrimEnd('↑', '↓')} ↓";
            //    }
            //    else
            //    {
            //        column.HeaderText = column.HeaderText.TrimEnd('↑', '↓');
            //    }
            //}
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

        private async void Supplier_Load(object sender, EventArgs e)
        {
            //await LoadSupplier();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VehicleAdd());
            await LoadVehicle(); 
        }
    }
}
