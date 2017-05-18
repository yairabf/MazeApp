﻿using System;
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
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        private SinglePlayerVm vm;
        public SinglePlayerWindow()
        {
            InitializeComponent();
            vm = new SinglePlayerVm(new SinglePlayerModel());
            this.DataContext = vm;
        }

        private void NameOfGameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}