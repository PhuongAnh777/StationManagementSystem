using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StationManagementSystem.Views.Partners
{
    public partial class VehicleDetail : Form
    {
        public VehicleDetail()
        {
            InitializeComponent();
        }
        public VehicleDetail(Guid vehicleId)
        {
            InitializeComponent();
        }
        private void CreateFormChild(Form form)
        {
            // Kiểm tra nếu đã có form nào khác trong pnChild
            foreach (Control ctrl in pnChild.Controls)
            {
                if (ctrl is Form existingForm)
                {
                    existingForm.Close();
                    pnChild.Controls.Remove(existingForm);
                    break;
                }
            }

            form.TopLevel = false;
            pnChild.Controls.Add(form);
            form.Show();
        }

        private void lblThongTinChinh_Click(object sender, EventArgs e)
        {
            CreateFormChild(new VehicleDetailMain());
        }

        private void lblThongTinKhac_Click(object sender, EventArgs e)
        {
            CreateFormChild(new VehicleDetailExtra());
        }
    }
}
