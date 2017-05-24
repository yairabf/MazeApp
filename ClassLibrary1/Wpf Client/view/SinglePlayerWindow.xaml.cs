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

        public SinglePlayerWindow()
        {
           
            singlePlayerVm = new SP_GameVm(new SinglePlayerModel());
            this.DataContext = singlePlayerVm;
            singlePlayerVm.StartGame();
            InitializeComponent();
        }

        private void mazeBoard_Loaded(object sender, RoutedEventArgs e)
        {
            //my_mazeBoard.DrawMaze();
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            this.singlePlayerVm.SolveGame();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerWindow win = new SinglePlayerWindow();
            this.Close();
            win.Show(); 
        }

        private void RestartGameButton_Click(object sender, RoutedEventArgs e)
        {
            my_mazeBoard.RestartGame();
        }
    }
}