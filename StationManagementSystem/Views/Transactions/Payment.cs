using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure;
using StationManagementSystem.DTO.Invoice;
using StationManagementSystem.DTO.Ticket;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Transactions
{
    public partial class Payment : Form
    {
        private readonly InvoiceService _invoiceService;
        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        private InvoiceCreateDto _invoiceCreateDto;

        private Employee _employee;
        private TicketIssuance _ticketIssuance;
        public Payment()
        {
            InitializeComponent();
            _invoiceService = new InvoiceService();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _invoiceCreateDto = new InvoiceCreateDto();

        }
        public Payment(Employee employee, TicketIssuance ticketIssuance)
        {
            InitializeComponent();
            _invoiceService = new InvoiceService();
            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _invoiceCreateDto = new InvoiceCreateDto();

            _employee = employee;
            _ticketIssuance = ticketIssuance;

            LoadPayment();
        }
        public async Task LoadPayment()
        {
            var vehicles = await _vehicleService.GetVehicleByIdAsync(_ticketIssuance.VehicleID);
            lblBienSoV.Text = vehicles.LicensePlate.ToString();

            var owners = await _ownerService.GetOwnerByIdAsync(vehicles.OwnerID);
            lblDVVTV.Text = owners.Company.ToString();

            var itinerary = await _itineraryService.GetItineraryByIdAsync(_ticketIssuance.ItineraryID);

            var routes = await _routeService.GetRouteByIdAsync(itinerary.RouteID);
            lblTuyenV.Text = routes.DeparturePoint.ToString() + " - " + routes.ArrivalPoint.ToString();

            lblBenCuoiV.Text = itinerary.Terminus.ToString();

            lblChuyenV.Text = _ticketIssuance.MonthlyFrequency.ToString();
            lblHinhThucV.Text = _ticketIssuance.OperatingSchedule.ToString();

            lblGheNgoiV.Text = vehicles.SeatTicket.ToString();
            lblGheNamV.Text = vehicles.SleeperTicket.ToString();
            lblNgayV.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblGioXuatV.Text = DateTime.Now.ToString("HH:mm:ss");
            lblNhanVienV.Text = _employee.FullName.ToString();

            lblDichVuV.Text = _ticketIssuance.ServiceFee.ToString();
            lblHoaHongV.Text = _ticketIssuance.TicketSalesCommission.ToString();

            lblSoVeNamV.Text = _ticketIssuance.Tickets.Count(x => x.TicketType == "Sleeper").ToString();
            lblSoVeNgoiV.Text = _ticketIssuance.Tickets.Count(x => x.TicketType == "Seat").ToString();
            lblTienNamV.Text = _ticketIssuance.Tickets
                        .Where(x => x.TicketType == "Sleeper")
                        .Select(x => x.Price)
                        .FirstOrDefault().ToString();
            lblTienNgoiV.Text = _ticketIssuance.Tickets
                        .Where(x => x.TicketType == "Seat")
                        .Select(x => x.Price)
                        .FirstOrDefault().ToString();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            LoadPayment();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            _invoiceCreateDto.SleeperTicket = int.Parse(lblSoVeNamV.Text);
            _invoiceCreateDto.SeatTicket = int.Parse(lblSoVeNgoiV.Text);
            if (string.IsNullOrEmpty(tbxDoDem.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền phí đỗ đêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!string.IsNullOrEmpty(tbxDoDem.Text))
            {
                if (float.TryParse(tbxDoDem.Text, out float doDem))
                {
                    _invoiceCreateDto.OvernightParkingFee = doDem;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền phí đỗ đêm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrEmpty(tbxDoCho.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền phí đỗ chờ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!string.IsNullOrEmpty(tbxDoCho.Text))
            {
                if (float.TryParse(tbxDoCho.Text, out float phiVe))
                {
                    _invoiceCreateDto.WaitingFee = phiVe;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền phí đỗ chờ hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrEmpty(tbxVeSinh.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền phí vệ sinh xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!string.IsNullOrEmpty(tbxVeSinh.Text))
            {
                if (float.TryParse(tbxVeSinh.Text, out float phiVe))
                {
                    _invoiceCreateDto.WashingFee = phiVe;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền phí vệ sinh xe hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrEmpty(tbxNhienLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền phí nhiên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!string.IsNullOrEmpty(tbxNhienLieu.Text))
            {
                if (float.TryParse(tbxNhienLieu.Text, out float phiVe))
                {
                    _invoiceCreateDto.FuelCost = phiVe;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số tiền phí nhiên liệu hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            _invoiceCreateDto.EmployeeID = _employee.EmployeeID;
            float chiPhi = _ticketIssuance.ServiceFee
               + _invoiceCreateDto.OvernightParkingFee
               + _invoiceCreateDto.WaitingFee
               + _invoiceCreateDto.WashingFee
               + _invoiceCreateDto.FuelCost;
            lblTongChiPhiV.Text = chiPhi.ToString();
            int soVeNam = int.Parse(lblSoVeNamV.Text); // Chuyển đổi từ Text thành float
            float tienNam = float.Parse(lblTienNamV.Text); // Chuyển đổi từ Text thành float
            int soVeNgoi = int.Parse(lblSoVeNgoiV.Text); // Chuyển đổi từ Text thành float
            float tienNgoi = float.Parse(lblTienNgoiV.Text); // Chuyển đổi từ Text thành float
            float tongTien = chiPhi - (soVeNam * tienNam + soVeNgoi * tienNgoi);

            lblTongTienV.Text = tongTien.ToString();
            _invoiceCreateDto.Amount = tongTien;

            var respone = await _invoiceService.CreateInvoiceAsync(_invoiceCreateDto);
            if (respone != null)
            { 
            
                MessageBox.Show($"Thêm thành công! {respone.InvoiceID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
