using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ClientConsole;
using MazeLib;

namespace Wpf_Client.model 
{
    public class SinglePlayerModel : GameModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Maze maze;

        private string mazeAsString;

        private string solution;

        private Client client;

        private string mazeName;

        private int rows;

        private int cols;
        

        public SinglePlayerModel()
        {
            client = new Client();
            client.Notify += HandleStart;
        }
        
        public void StartGame(string generate)
        {

            client.SendCommands(generate);
            
        }

        public void SolveGame()
        {
            int algorithm = Wpf_Client.Properties.Settings.Default.SearchAlgorithm;
            //this.mazeName = Properties.Settings.Default.NameOfMaze;
            string solve = "solve " + maze.Name + " " + algorithm;
            client.SendCommands(solve);
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        

        private void HandleStart(string s)
        {
            client.Notify -= HandleStart;
            client.Notify += HandeSolve;
            this.maze = Maze.FromJSON(s);
            this.MazeAsStringProp = this.maze.ToString();
            this.InitialPosProp = this.maze.InitialPos;
            this.GoalPosProp = this.maze.GoalPos;
            this.RowsProp = maze.Rows;
            this.ColsProp = maze.Cols;
        }

        private void HandeSolve(string s)
        {
            this.SolutionProp = s;
        }



        public int RowsProp
        {
            get { return this.rows; }
            set
            {
                this.rows = value;
                NotifyPropertyChanged("RowsProp");
            }
        }

        public int ColsProp
        {
            get { return this.cols; }
            set
            {
                this.cols = value;
                NotifyPropertyChanged("ColsProp");
            }
        }

        public Position InitialPosProp
        {
            get
            {
                return this.maze.InitialPos;
            }
            set
            {
                NotifyPropertyChanged("InitialPosProp");
            }
        }

        public Position GoalPosProp
        {
            get { return this.maze.GoalPos; }
            set
            {
                NotifyPropertyChanged("GoalPosProp");
            }
        }


        public string MazeAsStringProp
        {
            get { return this.mazeAsString; }
            set
            {
                this.mazeAsString = value;
                NotifyPropertyChanged("MazeAsStringProp");
            }
        }

        public Maze MazeObjProp
        {
            get { return this.maze; }
            set
            {
                this.maze = value;
                NotifyPropertyChanged("MazeObjProp");
            }
        }


        public String SolutionProp
        {
            get { return this.solution; }
            set
            {
                this.solution = value;
                NotifyPropertyChanged("SolutionProp");
            }
        }
    }
}
