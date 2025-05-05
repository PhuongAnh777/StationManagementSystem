using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.DTO.TicketIssuance;
using StationManagementSystem.Models;
using StationManagementSystem.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StationManagementSystem.Views.Transactions
{
    public partial class TicketIssuanceAdd : Form
    {
        private readonly TicketIssuanceService _ticketIssuanceService;
        private TicketIssuanceCreateDto _ticketIssuanceDto;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        private readonly Employee _employee;
        public TicketIssuanceAdd()
        {
            InitializeComponent();

            _ticketIssuanceDto = new TicketIssuanceCreateDto();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            //cbxLoTrinh.Enabled = false;
            LoadTicketIssuance();
        }
        public TicketIssuanceAdd(Employee employee)
        {
            InitializeComponent();

            _ticketIssuanceDto = new TicketIssuanceCreateDto();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _employee = employee;
            //cbxLoTrinh.Enabled = false;
            LoadTicketIssuance();
        }
        public async Task LoadTicketIssuance()
        {
            var companies = await _ownerService.GetAllOwnersAsync();
            cbXDVVT.DisplayMember = "Company";
            cbXDVVT.ValueMember = "OwnerID";
            cbXDVVT.SelectedIndex = -1;
            cbXDVVT.DataSource = companies;

            cbxBienSo.DropDownStyle = ComboBoxStyle.DropDown;


            var routes = await _routeService.GetAllRoutesAsync();

            cbxTuyen.DataSource = routes.Select(r => new RouteDisplayItem
            {
                RouteID = r.RouteID,
                DisplayRoute = $"{r.DeparturePoint} - {r.ArrivalPoint}"
            }).ToList();
            cbxTuyen.DisplayMember = "DisplayRoute";
            cbxTuyen.ValueMember = "RouteID";
            cbxTuyen.SelectedIndex = -1;

            cbxLoTrinh.Enabled = false; // Vô hiệu hoá ban đầu
            cbxBienSo.Enabled = false;

            cbxHinhThucChay.DataSource = new List<string>
            {
                "Chạy theo ngày",
                "Cả tháng",
                "Giới hạn ngày dương",
                "Giới hạn ngày âm"
            };
            cbxHinhThucChay.SelectedIndex = -1;

            cbxHinhThuc.DataSource = new List<string>
            {
                "1. Dịch vụ bến theo ngày, hoa hồng bán vé theo ngày",
                "2. Dịch vụ bến theo tháng, hoa hồng bán vé theo tháng"
            };
            cbxHinhThuc.SelectedIndex = -1; // Đặt giá trị mặc định là không có lựa chọn nào

        }
        private async void TicketIssuanceAdd_Load(object sender, EventArgs e)
        {
            LoadTicketIssuance();
        }

        private async void cbxLoTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLoTrinh.SelectedIndex != -1 && cbxLoTrinh.SelectedValue != null)
            {
                var selected = (Guid)cbxLoTrinh.SelectedValue;
                var info = await _itineraryService.GetItineraryByIdAsync(selected);

                if (info != null)
                {
                    lblBenCuoiV.Text = info.Terminus;
                }
            }
        }

        private async void cbxBienSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cbxTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTuyen.SelectedIndex != -1 && cbxTuyen.SelectedValue != null)
            {
                var selectedRoute = cbxTuyen.SelectedItem as RouteDisplayItem;
                if (selectedRoute != null)
                {
                    var selectedRouteID = selectedRoute.RouteID;



                    var allItineraries = await _itineraryService.GetAllItinerariesAsync();
                    // Lọc các lộ trình thuộc tuyến đã chọn
                    var filteredItineraries = allItineraries
                        .Where(i => i.RouteID == selectedRouteID) // RouteID phải tồn tại trong Itinerary
                        .ToList();

                    cbxLoTrinh.DisplayMember = "ItineraryName";
                    cbxLoTrinh.ValueMember = "ItineraryID";
                    cbxLoTrinh.DataSource = filteredItineraries;
                    cbxLoTrinh.SelectedIndex = -1;
                    cbxLoTrinh.Enabled = true; // Cho phép chọn

                }
                else
                {
                    cbxLoTrinh.DataSource = null; // Nếu không có tuyến nào được chọn, đặt DataSource thành null
                    cbxLoTrinh.Enabled = false; // Vô hiệu hóa ComboBox
                }
            }
        }

        private async void cbXDVVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXDVVT.SelectedIndex != -1 && cbXDVVT.SelectedValue != null)
            {
                var selectedOwnerID = (Guid)cbXDVVT.SelectedValue;
                var allVehicles = await _vehicleService.GetContinueVehiclesAsync();
                // Lọc các xe thuộc chủ sở hữu đã chọn
                var filteredVehicles = allVehicles
                    .Where(v => v.OwnerID == selectedOwnerID)
                    .ToList();

                cbxBienSo.DisplayMember = "LicensePlate";
                cbxBienSo.ValueMember = "VehicleID";
                cbxBienSo.SelectedIndex = -1;
                cbxBienSo.DataSource = filteredVehicles;
                cbxBienSo.Enabled = true; // Cho phép chọn
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (DateTimeFrom.Value.Year <= 1990 || DateTimeFrom.Value > DateTime.Now)
            {
                MessageBox.Show("Vui lòng nhập ngày bắt đầu hoạt động hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeTo.Value.Year <= 1990 || DateTimeTo.Value > DateTime.Now)
            {
                MessageBox.Show("Vui lòng nhập ngày kết thúc hoạt động hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTimeTo.Value < DateTimeFrom.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.StartDate = DateTimeFrom.Value;
            _ticketIssuanceDto.EndDate = DateTimeTo.Value;

            if (cbxHinhThucChay.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hình thức chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.OperatingSchedule = cbxHinhThucChay.SelectedValue.ToString();

            _ticketIssuanceDto.MonthlyFrequency = (int)numTanSuat.Value;

            if (DateTimeXuatBen.Value.TimeOfDay < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("Vui lòng nhập giờ xuất bến hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.EstimatedDepartureTime = DateTimeXuatBen.Value;

            if (cbxHinhThuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.PaymentMethod = cbxHinhThuc.SelectedValue.ToString();

            _ticketIssuanceDto.ServiceFee = (float)numPhi.Value;

            _ticketIssuanceDto.TicketSalesCommission = (float)numHoaHong.Value;

            _ticketIssuanceDto.SeatTicket = (int)numVeNgoi.Value;
            _ticketIssuanceDto.SleeperTicket = (int)numVeNam.Value;

            if (tbxNote.Text == string.Empty)
            {
                _ticketIssuanceDto.Notes = "Done";
            }
            else
            {
                _ticketIssuanceDto.Notes = tbxNote.Text;
            }

            if (cbxLoTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lộ trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.ItineraryID = (Guid)cbxLoTrinh.SelectedValue;

            if (cbxBienSo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ticketIssuanceDto.VehicleID = (Guid)cbxBienSo.SelectedValue;

            _ticketIssuanceDto.EmployeeID = _employee.EmployeeID;

            var respone = await _ticketIssuanceService.CreateTicketIssuancesAsync(_ticketIssuanceDto);

            if (respone != null)
            {
                MessageBox.Show($"Thêm thành công! {respone.IssuanceID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
