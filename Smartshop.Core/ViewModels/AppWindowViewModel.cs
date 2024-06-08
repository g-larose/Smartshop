using Microsoft.EntityFrameworkCore;
using Smartshop.Core.Commands;
using Smartshop.Core.Data;
using Smartshop.Core.Factories;
using Smartshop.Core.Interfaces;
using Smartshop.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smartshop.Core.ViewModels
{
    public class AppWindowViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory _dbFactory;
       
        public ViewModelBase? SelectedViewModel => _navigator!.CurrentViewModel;

        public ICommand ExitApplicationCommand { get; }
        public ICommand NavigateToCustomersViewCommand { get; }

        public AppWindowViewModel(INavigator navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator.CurrentViewModelChanged += OnViewModelChanged;
             ExitApplicationCommand = new RelayCommand(ExitApp);
            NavigateToCustomersViewCommand = new NavigateCommand<CustomersViewModel>(_navigator, () => new CustomersViewModel());

        }

        private void ExitApp()
        {
            App.Current.Shutdown();
        }

        private void OnViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
