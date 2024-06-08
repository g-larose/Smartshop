using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Smartshop.Core.Commands;
using Smartshop.Core.Data;
using Smartshop.Core.Factories;
using Smartshop.Core.Interfaces;
using Smartshop.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smartshop.Core.ViewModels
{
    /// <summary>
    /// Created by the template
    /// make changes as needed
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory? _dbFactory;
        public ICommand? LoginCommand { get; set; }
        public ICommand? CancelCommand { get; set; }

        private string? _userName;
        public string? UserName
        {
            get => _userName;
            set => OnPropertyChanged(ref _userName, value);
        }
        private string? _password;
        public string? Password
        {
            get => _password;
            set => OnPropertyChanged(ref _password, value);
        }

        public LoginViewModel(INavigator? navigator, AppDbContextFactory? dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            var appView = new AppWindow(_navigator!, _dbFactory!);
            appView.Show();
            App.Current.Windows[0].Close();

        }
    }
}
