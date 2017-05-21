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

namespace Wpf_Client.view
{
    /// <summary>
    /// Interaction logic for SinglePlayerMenu.xaml
    /// </summary>
    public partial class SinglePlayerMenu : Window
    {
        private SP_MenuVm singlePlayerVm;

        public SinglePlayerMenu()
        {
            singlePlayerVm = new SP_MenuVm(new SinglePlayerModel());
            this.DataContext = singlePlayerVm;
            InitializeComponent();
        }

        private void Ok_Clicked(object sender, RoutedEventArgs e)
        {
            SinglePlayerWindow win = new SinglePlayerWindow(singlePlayerVm.Model);
            this.singlePlayerVm.StartGame();
            this.Close();
            win.Show();
            
        }
    }
}
