using Smartshop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartshop.Core.Interfaces
{
    public interface INavigator
    {
        public event Action CurrentViewModelChanged;
        public ViewModelBase? CurrentViewModel { get; set; }
    }
}
