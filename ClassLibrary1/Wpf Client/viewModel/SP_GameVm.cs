using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;
using Wpf_Client.model;

namespace Wpf_Client.viewModel
{
    class SP_GameVm:ViewModel
    {
        private SinglePlayerModel model;

        public SP_GameVm(SinglePlayerModel m)
        {
            this.model = m;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };
        }
       
        public string MazeAsStringProp
        {
            get { return model.MazeAsStringProp; }
            set
            {
                model.MazeAsStringProp = value;
                NotifyPropertyChanged("MazeAsStringProp");
            }
        }

        public string SolutionProp
        {
            get
            {
                string solution = this.model.SolutionProp;
                if (solution != null)
                {
                    JObject solutionObject = JObject.Parse(solution);
                    string solutionAsString =  solutionObject["solution"].ToString();
                    return solutionAsString;
                }
                return null;
            }
            set
            {
                model.SolutionProp = value;
                NotifyPropertyChanged("SolutionProp");
            }
            
        }

        public int ColsProp
        {
            get { return model.ColsProp; }
            set
            {
                this.model.ColsProp = value;
                NotifyPropertyChanged("ColsProp");
            }
        }

        public int RowsProp
        {
            get { return model.RowsProp; }
            set
            {
                this.model.RowsProp = value;
                NotifyPropertyChanged("RowsProp");
            }
        }

        public Position InitialPosProp
        {
            get { return this.model.InitialPosProp; }
            set { NotifyPropertyChanged("InitialPosProp");}
        }

        public Position GoalPosProp
        {
            get { return this.model.GoalPosProp; }
            set
            {
                NotifyPropertyChanged("GoalPosProp");
            }
        }

        public Maze MazeObjProp
        {
            get {
                    return this.model.MazeObjProp;
                }
            set
            {
                this.model.MazeObjProp = value;
                NotifyPropertyChanged("MazeObjProp");
            }
        }

        public void StartGame()
        {
            string generate = "generate " + Properties.Settings.Default.NameOfMaze + " " + Properties.Settings.Default.NumOfRows +
                              " " + Properties.Settings.Default.NumOfCol;
            this.model.StartGame(generate);
        }

        public void SolveGame()
        {
            this.model.SolveGame();
        }


    }
}

