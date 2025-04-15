using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSampleApp1.Properties.Models
{
    public class ActiveRentals
    {
        // Properties corresponding to the columns in the active_rentals view
        public int RentalAgreementId { get; set; }
        public string TenantFullName { get; set; }
        public string TenantEmail { get; set; }
        public string TenantMobile { get; set; }
        public string SerialNumberId { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public decimal TotalAmountDue { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
