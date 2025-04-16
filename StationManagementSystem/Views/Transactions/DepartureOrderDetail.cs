using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StationManagementSystem.DTO.DepartureOrder;
using StationManagementSystem.Services;

namespace StationManagementSystem.Views.Transactions
{
    public partial class DepartureOrderDetail : Form
    {
        private readonly DepartureOrderService _departureOrderService;
        private DepartureOrderCreateDto _departureOrderCreateDto;
        
        public DepartureOrderDetail()
        {
            InitializeComponent();
        }
        public void LoadDepartureOrder()
        {

        }
    }
}
