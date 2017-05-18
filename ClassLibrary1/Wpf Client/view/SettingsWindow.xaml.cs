using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_Client.model;
using Wpf_Client.viewModel;

namespace Wpf_Client
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel vm;
        public SettingsWindow()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new ApplicationSettingsModel());
            this.DataContext = vm;
        }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
