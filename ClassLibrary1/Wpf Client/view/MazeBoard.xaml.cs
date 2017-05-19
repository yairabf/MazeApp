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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MazeLib;

namespace Wpf_Client.view
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        public MazeBoard()
        {
            InitializeComponent();

        }

        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty RowsUCProperty =
            DependencyProperty.Register("RowsUC", typeof(int), typeof(MazeBoard), new
                PropertyMetadata(0));

        public int RowsUC
        {
            get { return (int)GetValue(RowsUCProperty); }
            set { SetValue(RowsUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for stringMazeUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeUCProperty =
            DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard));

        public string MazeUC
        {
            get { return (string)GetValue(MazeUCProperty); }
            set { SetValue(MazeUCProperty, value); }
        }



        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColsUCProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));

        public int ColsUC
        {
            get { return (int)GetValue(ColsUCProperty); }
            set { SetValue(ColsUCProperty, value); }
        }


        // Using a DependencyProperty as the backing store for InitialPosUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialPosUCProperty =
            DependencyProperty.Register("InitialPosUC", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));

        public int InitialPosUC
        {
            get { return (int)GetValue(InitialPosUCProperty); }
            set { SetValue(InitialPosUCProperty, value); }
        }


        // Using a DependencyProperty as the backing store for GoalPosUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalPosUCProperty =
            DependencyProperty.Register("GoalPosUC", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));

        public int GoalPosUC
        {
            get { return (int)GetValue(GoalPosUCProperty); }
            set { SetValue(GoalPosUCProperty, value); }
        }

        public static readonly DependencyProperty NameUCProperty =
            DependencyProperty.Register("NameUC", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));

        public string NameUC
        {
            get { return (string)GetValue(NameUCProperty); }
            set { SetValue(NameUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalPosUC.  This enables animation, styling, binding, etc...
     


//        public void DrawMaze()
//        {
//            string maze = Maze;
//            for(int i = 0; i < ColsUC;   )
//        }

    }
}
