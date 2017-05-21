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
    /// Interaction logic for Single_PlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {

        private SP_GameVm singlePlayerVm;
 
        public SinglePlayerWindow(SinglePlayerModel model)
        {
            InitializeComponent();
            singlePlayerVm = new SP_GameVm(model);
            this.DataContext = singlePlayerVm;

        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
            my_mazeBoard.DrawMaze();
        }
    }
}
