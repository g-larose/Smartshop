using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartshop.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid Customer_Identifier { get; set; }
        public string? Company_Name { get; set; }
        public string? Contact_Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Street_Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }

    }
}
