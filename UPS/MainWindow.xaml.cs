using System.Windows;
using UPS.Core.Interface;

namespace UPS
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;

        public MainWindow(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            GetEmployees();
        }

        private void GetEmployees()
        {
            var employees = _userService.GetAll(1).Result;
            var x = employees.Data;
            //EmployeeDG.ItemsSource = x;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var re = _userService.GetAll(1).Result;
        }
    }
}