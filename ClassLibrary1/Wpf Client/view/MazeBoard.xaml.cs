using MazeLib;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf_Client.view
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        private Grid grid;
        private Rectangle[,] rectArray;
        private Char[,] mazeAsChars;

        public MazeBoard()
        {
            grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            for (int i = 0; i < ColsUC; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < RowsUC; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            InitializeComponent();
            

        }

       /* public static readonly DependencyProperty Maze_ObjectProperty =
            DependencyProperty.Register("Maze_Object", typeof(Maze), typeof(MazeBoard), new
                PropertyMetadata(0));

        public Maze Maze_Object
        {
            get { return (Maze)GetValue(Maze_ObjectProperty); }
            set { SetValue(Maze_ObjectProperty, value); }
        }*/


        //hanani
        public static readonly DependencyProperty RowsUCProperty =
            DependencyProperty.Register("RowsUC", typeof(int), typeof(MazeBoard), new
                PropertyMetadata(0));

        public int RowsUC
        {
            get { return (int)GetValue(RowsUCProperty); }
            set { SetValue(RowsUCProperty, value); }
        }



        public static readonly DependencyProperty MazeStringUCProperty =
            DependencyProperty.Register("MazeStringUC", typeof(string), typeof(MazeBoard));

        public string MazeStringUC
        {
            get { return (string)GetValue(MazeStringUCProperty); }
            set { SetValue(MazeStringUCProperty, value); }
        }



        public static readonly DependencyProperty ColsUCProperty =
            DependencyProperty.Register("ColsUC", typeof(int), typeof(MazeBoard), new PropertyMetadata(0));

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
     


        public void DrawMaze()
        {
            string maze = MazeStringUC;
            int currentPos = 0;
            int rows = RowsUC;
            int cols = ColsUC;
            mazeAsChars = new Char[RowsUC, cols];
            double recSize = Math.Min(300 / rows, 300 / cols);
            rectArray = new Rectangle[rows,cols];
            for (int i = 0; i < RowsUC; i++)
            {
                for (int j = 0; j < ColsUC; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Height = recSize;
                    rectangle.Width = recSize;
                    if (maze[currentPos].Equals('0'))
                    {
                        Brush brush = Brushes.Black;
                        rectangle.Fill = brush;
                    }
                    else if(maze[currentPos].Equals('1'))
                    {
                        Brush brush = Brushes.White;
                        rectangle.Fill = brush;
                    }
                    //entrance
                    else if (maze[currentPos].Equals('*'))
                    {
                        Brush brush = Brushes.Orange;
                        rectangle.Fill = brush;
                    }
                    //exit
                    else
                    {
                        Brush brush = Brushes.Purple;
                        rectangle.Fill = brush;
                    }
                    currentPos++;
                    rectArray[i, j] = rectangle;
                    mazeAsChars[i, j] = maze[currentPos];
                    myCanvas.Children.Add(rectangle);
                    Canvas.SetLeft(rectangle, j * recSize);
                    Canvas.SetTop(rectangle, i * recSize);
                }
            }
        }

    }
}
