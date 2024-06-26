﻿using Smartshop.Core.Interfaces;
using Smartshop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartshop.Core.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
