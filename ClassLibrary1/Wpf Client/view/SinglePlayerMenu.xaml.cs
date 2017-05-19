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
using WpfMaze.model;
using Wpf_Client.viewModel;

namespace Wpf_Client.view
{
    /// <summary>
    /// Interaction logic for SinglePlayerMenu.xaml
    /// </summary>
    public partial class SinglePlayerMenu : Window
    {
        private SinglePlayerVm singlePlayerVm;

        public SinglePlayerMenu()
        {
            singlePlayerVm = new SinglePlayerVm(new SinglePlayerModel());
            this.DataContext = singlePlayerVm;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.singlePlayerVm.StartGame();
        }

    }
}
