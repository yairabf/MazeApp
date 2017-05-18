using System.ComponentModel;
using ClientConsole;
using MazeLib;

namespace WpfMaze.model 
{
    class SinglePlayerModel : GameModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Maze maze;
        private string solution;

        private Client client;

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
            int algorithm = System;
            client.SendCommands(solve);
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void HandleStart(string s)
        {
            client.Notify -= HandleStart;
            client.Notify += HandeSolve;
            this.maze = Maze.FromJSON(s);
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

        public int rowProp
        {
            get { return maze.Rows; }
        }

        public int colProp
        {
            get { return maze.Cols; }
        }

        public string nameProp
        {
            get { return maze.Name; }
        }
    }
}
