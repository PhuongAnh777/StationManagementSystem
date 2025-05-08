using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using StationManagementSystem.DTO.DepartureOrder;
using StationManagementSystem.DTO.Invoice;
using StationManagementSystem.Models;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Transactions
{
    public partial class DepartureOrderDetail : Form
    {
        private readonly DepartureOrderService _departureOrderService;
        private DepartureOrderCreateDto _departureOrderCreateDto;

        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        private TicketIssuance _ticketIssuance;
        private Guid _invoiceID;
        public DepartureOrderDetail()
        {
            InitializeComponent();
            _departureOrderService = new DepartureOrderService();
            _departureOrderCreateDto = new DepartureOrderCreateDto();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();
        }
        public DepartureOrderDetail(TicketIssuance ticketIssuance, Guid invoiceID)
        {
            InitializeComponent();
            _departureOrderService = new DepartureOrderService();
            _departureOrderCreateDto = new DepartureOrderCreateDto();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _ticketIssuance = ticketIssuance;
            _invoiceID = invoiceID;

            LoadDepartureOrder();
        }
        public async Task LoadDepartureOrder()
        {
            var vehicles = await _vehicleService.GetVehicleByIdAsync(_ticketIssuance.VehicleID);
            lblBienSoV.Text = vehicles.LicensePlate.ToString();

            var owners = await _ownerService.GetOwnerByIdAsync(vehicles.OwnerID);
            lblDVVTV.Text = owners.Company.ToString();

            var itinerary = await _itineraryService.GetItineraryByIdAsync(_ticketIssuance.ItineraryID);
            lblHanhTrinhV.Text = itinerary.ItineraryName.ToString();

            var routes = await _routeService.GetRouteByIdAsync(itinerary.RouteID);
            lblTuyenV.Text = routes.DeparturePoint.ToString() + " - " + routes.ArrivalPoint.ToString();
            lblCuLyV.Text = routes.Distance.ToString() + " km";

            lblBenCuoiV.Text = itinerary.Terminus.ToString();
            lblGioXuatV.Text = DateTime.Now.ToString("HH:mm:ss");

            lblSoVeV.Text = _ticketIssuance.Tickets
                .Where(t => t.IssuanceID == _ticketIssuance.IssuanceID)
                .SelectMany(t => t.TicketDetails)
                .Count()
                .ToString();
            lblGiaVeV.Text = _ticketIssuance.Tickets
                .Where(t => t.IssuanceID == _ticketIssuance.IssuanceID)
                .Select(t => t.Price)
                .FirstOrDefault()
                .ToString();

        }

        private void DepartureOrderDetail_Load(object sender, EventArgs e)
        {
            LoadDepartureOrder();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxLenh.Text))
            {
                MessageBox.Show("Vui lòng nhập lệnh xuất bến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _departureOrderCreateDto.DepartureOrders = tbxLenh.Text;

            _departureOrderCreateDto.InvoiceID = _invoiceID;
            _departureOrderCreateDto.IssuanceID = _ticketIssuance.IssuanceID;

            var respone = await _departureOrderService.CreateDepartureOrderAsync(_departureOrderCreateDto);
            if (respone != null)
            {
                var responeTicket = await _ticketIssuanceService.UpdateTicketIssuancesNotesDepartuedAsync(_ticketIssuance.IssuanceID);
                MessageBox.Show($"Xuất bến thành công! {respone.InvoiceID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
