using System.ComponentModel;
using System.Net.Mime;
using ClientConsole;
using MazeLib;

//yaiur
namespace WpfMaze.model 
{
    class SinglePlayerModel : GameModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Maze maze;

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
            string generate = this.mazeName + " " + this.rows + " " + this.cols;
            client.SendCommands(generate);

        }
        public void SolveGame()
        {
            int algorithm = Wpf_Client.Properties.Settings.Default.SearchAlgorithm;
            string solve = "solve " + maze.Name + " " + algorithm;
            client.SendCommands(solve);
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void HandleStart(string mazeString)
        {
            client.Notify -= HandleStart;
            client.Notify += HandeSolve;
            this.maze = Maze.FromJSON(mazeString);
        }

        private void HandeSolve(string s)
        {
            this.solution = s;
        }

        public Maze mazeProp
        {
            get { return maze; }
            set
            {
                this.maze = value;
                OnPropertyChanged("maze");
            }
        }

        public int NumOfRows
        {
            get { return maze.Rows; }
            set { this.rows = value; }
        }

        public int NumOfCol
        {
            get { return maze.Cols; }
            set { this.cols = value; }
        }

        public string NameOfMaze
        {
            get { return maze.Name; }
            set { this.mazeName = value; }
        }
    }
}
