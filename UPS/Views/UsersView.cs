using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using UPS.Core.Dto;
using UPS.Core.Entity;
using UPS.Core.Form;
using UPS.Core.Interface;

namespace UPS.Views
{
    /// <summary>
    ///     Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        private readonly IUserService _userService;

        public Start(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            var users = await _userService.GetAll(1);
            Label.Content = $"Total Users Loaded : {users.Data.Count}";
            EmployeeDG.ItemsSource = users.Data;
            EmployeeDG.Items.Refresh();
            Export.Visibility = Visibility.Visible;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(EmployeeDG.SelectedItem is User user))
                return;
            var serviceResponse = Task.Run(() => _userService.Update(new UpdateUserForm
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Status = user.Status,
                Gender = user.Gender
            })).Result;
            if (serviceResponse.Error)
                MessageBox.Show($"Error {serviceResponse.ServiceMessage}");
            MessageBox.Show("The record has been updated");
        
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (!(EmployeeDG.SelectedItem is User user))
            return;
        var serviceResponse =Task.Run(()=> _userService.Remove(user)).Result;
        if (serviceResponse.Error)
        {
            MessageBox.Show("Bad Request");
        }
        Label.Content = user.Id;
        LoadData();
    }

    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(SearchBox.Text))
        {
            MessageBox.Show("Please type a name");
            return;
        }

        var users = await _userService.Find(SearchBox.Text);
        Label.Content = $"Total Users Loaded  : {users.Data.Count}";
        EmployeeDG.ItemsSource = users.Data;
        EmployeeDG.Items.Refresh();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        EmployeeDG.SelectAllCells();
        EmployeeDG.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
        ApplicationCommands.Copy.Execute(null, EmployeeDG);
        EmployeeDG.UnselectAllCells();
        var content = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
        var dialog = new SaveFileDialog
        {
            Filter = "CSV file (*.csv)|*.csv",
            FileName = "result"
        };

        if (dialog.ShowDialog() == true) File.WriteAllText(dialog.FileName, content);
    }
}
}