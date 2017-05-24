using MazeLib;
using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

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
            InitializeComponent();
        }


        public int RowsUC
        {
            get { return (int)GetValue(RowsUCProperty); }
            set { SetValue(RowsUCProperty, value); }
        }
        public static readonly DependencyProperty RowsUCProperty =
            DependencyProperty.Register("RowsUC", typeof(int), typeof(MazeBoard));



        public Maze MazeObjUC
        {
            get { return(Maze) GetValue(MazeObjUCProperty); }
            set { SetValue(MazeObjUCProperty, value); }
        }
        public static readonly DependencyProperty MazeObjUCProperty =
            DependencyProperty.Register("MazeObjUC", typeof(Maze), typeof(MazeBoard));



        public string MazeStringUC
        {
            get { return (string)GetValue(MazeStringUCProperty); }
            set { SetValue(MazeStringUCProperty, value); }
        }
        public static readonly DependencyProperty MazeStringUCProperty =
            DependencyProperty.Register("MazeStringUC", typeof(string), typeof(MazeBoard));




        public int ColsUC
        {
            get { return (int)GetValue(ColsUCProperty); }
            set { SetValue(ColsUCProperty, value); }
        }
        public static readonly DependencyProperty ColsUCProperty =
            DependencyProperty.Register("ColsUC", typeof(int), typeof(MazeBoard), new PropertyMetadata(PropertiesChanged));


        private static void PropertiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeBoard)d).DrawMaze();
        }


        
        public Position InitialPosUC
        {
            get { return (Position)GetValue(InitialPosUCProperty); }
            set { SetValue(InitialPosUCProperty, value); }
        }
        public static readonly DependencyProperty InitialPosUCProperty =
            DependencyProperty.Register("InitialPosUC", typeof(Position), typeof(MazeBoard));


       
        public Position GoalPosUC
        {
            get { return (Position)GetValue(GoalPosUCProperty); }
            set { SetValue(GoalPosUCProperty, value); }
        }
        public static readonly DependencyProperty GoalPosUCProperty =
            DependencyProperty.Register("GoalPosUC", typeof(Position), typeof(MazeBoard));


        public string NameUC
        {
            get { return (string)GetValue(NameUCProperty); }
            set { SetValue(NameUCProperty, value); }
        }
        public static readonly DependencyProperty NameUCProperty =
            DependencyProperty.Register("NameUC", typeof(string), typeof(MazeBoard));


        public string SolutionUC
        {
            get { return (string)GetValue(SolutionUCProperty); }
            set { SetValue(SolutionUCProperty, value); }
        }
        public static readonly DependencyProperty SolutionUCProperty =
            DependencyProperty.Register("SolutionUC", typeof(string), typeof(MazeBoard), new PropertyMetadata(SolutionReceived));


        private static void SolutionReceived(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MazeBoard) d).DrawSolution();
        }

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
                        Brush brush = Brushes.White;
                        rectangle.Fill = brush;
                    }
                    else if(maze[currentPos].Equals('1'))
                    {
                        Brush brush = Brushes.Black;
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
                    myCanvas.Children.Add(rectArray[i,j]);
                    Canvas.SetLeft(rectangle, j * recSize);
                    Canvas.SetTop(rectangle, i * recSize);
                }
                currentPos += 2;
            }
        }

        private void DrawSolution()
        {
            Rectangle player = new Rectangle();
            Brush brush = Brushes.Red;
            int rows = RowsUC;
            int cols = ColsUC;
            double recSize = Math.Min(300 / rows, 300 / cols);
            int currentRow = InitialPosUC.Row;
            int currentCol = InitialPosUC.Col;
            int prevRow;
            int prevCol;
            player.Fill = brush;
            Canvas.SetLeft(player, currentCol * recSize);
            Canvas.SetTop(player, currentRow * recSize);
            int currentMoveInd = 0;
            char currentMove;
            while (currentMoveInd < SolutionUC.Length)
            {
                currentMove = SolutionUC[currentMoveInd];
                prevCol = currentCol;
                prevRow = currentRow;
                switch (currentMove)
                {
                    case '0':
                        currentCol -= 1;
                        break;

                    case '1':
                        currentCol += 1;
                        break;

                    case '2':
                        currentRow -= 1;
                        break;

                    default:
                        currentRow += 1;
                        break;
                }
                player.Fill = brush;
                rectArray[prevRow, prevCol] = rectArray[currentRow, currentCol];
                rectArray[currentRow, currentCol] = player;
                Canvas.SetLeft(player, currentCol * recSize);
                Canvas.SetTop(player, currentRow * recSize);
                currentMoveInd++;
                //refreshes the canvas
                myCanvas.Dispatcher.Invoke(delegate { }, DispatcherPriority.Render);
                System.Threading.Thread.Sleep(200);
                //myCanvas.Children.Remove(player);
            }
        }

        public void RestartGame()
        {
            Brush brush = Brushes.Red;
            rectArray[GoalPosUC.Row, GoalPosUC.Col].Fill = brush;
        }

    }
}
