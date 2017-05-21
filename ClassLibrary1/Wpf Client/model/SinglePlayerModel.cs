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
        
        public void StartGame()
        {
            string generate = "generate " + this.mazeName + " " + this.rows + " " + this.cols;
            client.SendCommands(generate);

        }

        public void SolveGame()
        {
            int algorithm = Wpf_Client.Properties.Settings.Default.SearchAlgorithm;
            string solve = "solve " + maze.Name + " " + algorithm;
            client.SendCommands(solve);
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        /*protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }*/

        

        private void HandleStart(string s)
        {
            client.Notify -= HandleStart;
            client.Notify += HandeSolve;
            this.maze = Maze.FromJSON(s);
            this.MazeAsStringProp = s;
        }

        private void HandeSolve(string s)
        {
            this.SolutionProp = s;
        }

       /* public Maze mazeProp
        {
            get { return this.maze; }
            set
            {
                this.maze = value;
                NotifyPropertyChanged("Maze");
            }
        }*/

        public string MazeAsStringProp
        {
            get { return this.mazeAsString; }
            set
            {
                this.mazeAsString = value;
                NotifyPropertyChanged("MazeAsString");
            }
        }

        /*public string MazeAsString
        {
            get { return this.mazeAsString; }
            set
            {
                this.mazeAsString = value;
                OnPropertyChanged("MazeAsString");
            }
        }*/


        public String SolutionProp
        {
            get { return this.solution; }
            set
            {
                this.solution = value;
                NotifyPropertyChanged("Solution");
            }
        }

        //properties of SP_MenuVm
        public int NumOfRows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }

        public int NumOfCol
        {
            get { return this.cols; }
            set { this.cols = value; }
        }

        public string NameOfMaze
        {
            get { return this.mazeName; }
            set { this.mazeName = value; }
        }
    }
}
