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

namespace StationManagementSystem.Views.Transactions
{
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }
        public Check(TicketIssuance ticketIssuance)
        {
            InitializeComponent();
        }
    }
}
