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
            this.MazeAsStringProp = this.maze.ToString();
            this.RowsProp = Properties.Settings.Default.NumOfRows;
            this.ColsProp = Properties.Settings.Default.NumOfCol;
        }

        private void HandeSolve(string s)
        {
            this.SolutionProp = s;
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

        public String SolutionProp
        {
            get { return this.solution; }
            set
            {
                this.solution = value;
                NotifyPropertyChanged("Solution");
            }
        }
    }
}
