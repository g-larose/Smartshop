using Smartshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartshop.Core.Interfaces
{
    public interface IDataProvider
    {
        Result<string, SystemError> GetConnectionString();
    }
}
