using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.TicketIssuance;
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

        public async void LoadTicketIssuance()
        {
            var companies = await _ownerService.GetAllOwnersAsync();
            cbXDVVT.DisplayMember = "Company";
            cbXDVVT.ValueMember = "OwnerID";
            cbXDVVT.SelectedIndex = -1;
            cbXDVVT.DataSource = companies;

            //var vehicles = await _vehicleService.GetAllVehiclesAsync();
            //cbxBienSo.DataSource = vehicles;
            //cbxBienSo.DisplayMember = "LicensePlate";
            //cbxBienSo.ValueMember = "VehicleID";
            //cbxBienSo.SelectedIndex = -1;
            cbxBienSo.DropDownStyle = ComboBoxStyle.DropDown;


            var routes = await _routeService.GetAllRoutesAsync();
            cbxTuyen.DataSource = routes.Select(r => new
            {
                r.RouteID,
                DisplayRoute = $"{r.DeparturePoint} - {r.ArrivalPoint}"
            }).ToList();
            cbxTuyen.DisplayMember = "DisplayRoute";
            cbxTuyen.ValueMember = "RouteID";
            cbxTuyen.SelectedIndex = -1;
            cbxTuyen.DataSource = routes;

            // Lưu danh sách itinerary toàn bộ để lọc sau
            //var allItineraries = await _itineraryService.GetAllItinerariesAsync();
            cbxLoTrinh.Enabled = false; // Vô hiệu hoá ban đầu
            cbxBienSo.Enabled = false;
        }
        private async void TicketIssuanceAdd_Load(object sender, EventArgs e)
        {
            LoadTicketIssuance();
        }

        private async void cbxLoTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void cbxBienSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cbxTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTuyen.SelectedIndex != -1 && cbxTuyen.SelectedValue != null)
            {
                var selectedRouteID = (Guid)cbxTuyen.SelectedValue;
                var allItineraries = await _itineraryService.GetAllItinerariesAsync();
                // Lọc các lộ trình thuộc tuyến đã chọn
                var filteredItineraries = allItineraries
                    .Where(i => i.RouteID == selectedRouteID) // RouteID phải tồn tại trong Itinerary
                    .ToList();

                cbxLoTrinh.DisplayMember = "ItineraryName";
                cbxLoTrinh.ValueMember = "ItineraryID";
                cbxLoTrinh.SelectedIndex = -1;
                cbxLoTrinh.DataSource = filteredItineraries;
                cbxLoTrinh.Enabled = true; // Cho phép chọn
            }
        }

        private async void cbXDVVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXDVVT.SelectedIndex != -1 && cbXDVVT.SelectedValue != null)
            {
                var selectedOwnerID = (Guid)cbXDVVT.SelectedValue;
                var allVehicles = await _vehicleService.GetActiveVehiclesAsync();
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
    }
}
