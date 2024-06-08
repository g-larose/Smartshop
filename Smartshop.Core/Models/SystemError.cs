using Smartshop.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;

namespace Smartshop.Core.Models
{
    public class SystemError
    {
        public Guid? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public ErrorType ErrorType { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
