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
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using StationManagementSystem.Services;
using StationManagementSystem.Views.Partners;

namespace StationManagementSystem.Views.Transactions
{
    public partial class Check : Form
    {
        private readonly TicketIssuanceService _ticketIssuanceService;
        private readonly OwnerService _ownerService;
        private readonly VehicleService _vehicleService;
        private readonly RouteService _routeService;
        private readonly ItineraryService _itineraryService;

        private readonly TicketIssuance _ticketIssuance;
        public Check()
        {
            InitializeComponent();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();
        }
        public Check(TicketIssuance ticketIssuance)
        {
            InitializeComponent();

            _ticketIssuanceService = new TicketIssuanceService();
            _ownerService = new OwnerService();
            _vehicleService = new VehicleService();
            _routeService = new RouteService();
            _itineraryService = new ItineraryService();

            _ticketIssuance = ticketIssuance;
        }
        public async void LoadCheck()
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(_ticketIssuance.VehicleID);

            if (vehicle != null)
            {
                lblBienSoV.Text = vehicle.LicensePlate.ToString();
                tbxDangKyXe.Text = vehicle.Registration.ToString();
                tbxBaoHiem.Text = vehicle.Insurance.ToString();
                DateTimeFromKD.Text = vehicle.InspectionStartDate.ToString();
                DateTimeToKD.Text = vehicle.InspectionExpiryDate.ToString();
                DateTimeFromBB.Text = vehicle.ImpoundmentDate.ToString();
                DateTimeToBB.Text = vehicle.ReleaseDate.ToString();
            }

            var owner = await _ownerService.GetOwnerByIdAsync(vehicle.OwnerID);

            if (owner != null)
            {
                lblDVVTV.Text = owner.Name.ToString();
                tbxBangLai.Text = owner.DrivingLicense.ToString();
            }

            var itinerary = await _itineraryService.GetItineraryByIdAsync(_ticketIssuance.ItineraryID);

            if (itinerary != null)
            {
                var route = await _routeService.GetRouteByIdAsync(itinerary.RouteID);
                if (route != null)
                {
                    lblTuyen.Text = $"{route.DeparturePoint} - {route.ArrivalPoint}";
                }
            }

            if (_ticketIssuance != null)
            {
                tbxHinhThuc.Text = _ticketIssuance.OperatingSchedule.ToString();
                lblXuatBen.Text = _ticketIssuance.EstimatedDepartureTime.ToString();
            }

        }
    }
}
