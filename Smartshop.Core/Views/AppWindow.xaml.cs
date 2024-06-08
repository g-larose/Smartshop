using Microsoft.EntityFrameworkCore;
using Smartshop.Core.Data;
using Smartshop.Core.Factories;
using Smartshop.Core.Interfaces;
using Smartshop.Core.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Smartshop.Core.Views
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        private readonly INavigator _navigator;
        private readonly AppDbContextFactory _dbFactory;
        public AppWindow(INavigator navigator, AppDbContextFactory dbFactory)
        {
            InitializeComponent();
            _navigator = navigator;
            _dbFactory = dbFactory;
            DataContext = new AppWindowViewModel(_navigator, _dbFactory);
        }

        private void border_header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
